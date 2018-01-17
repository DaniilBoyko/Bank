using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Bank.Models;
using Bank.Models.Mapping;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Entities.Exceptions;
using BLL.Interfaces.Services;
using DependencyResolver;
using Ninject;

namespace Bank.Controllers
{
    /// <summary>
    /// Controller for users and their accounts.
    /// </summary>
    public class AccountController : Controller
    {
        static AccountController()
        {
            KernelResolver = new StandardKernel();
            KernelResolver.ConfigurateReolverWeb();
            UserService = KernelResolver.Get<IUserService>();
            AccountService = KernelResolver.Get<IAccountService>();
        }

        /// <summary>
        /// Gets or sets kernel resolver.
        /// </summary>
        private static IKernel KernelResolver { get; }

        /// <summary>
        /// Gets or sets user service.
        /// </summary>
        private static IUserService UserService { get; }

        /// <summary>
        /// Gets or sets account service.
        /// </summary>
        private static IAccountService AccountService { get; }

        /// <summary>
        /// Get view for register new user.
        /// </summary>
        /// <returns>Page view for register new user.</returns>
        [AllowAnonymous]
        public ActionResult Register()
        {
            return this.View();
        }

        /// <summary>
        /// Register new user.
        /// </summary>
        /// <param name="userModel">model of user</param>
        /// <returns>Page view with information about register new user.</returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserViewModel userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserService.CreateUser(userModel.Name, userModel.Surname, userModel.Email, userModel.Password);
                    ModelState.Clear();
                    ViewBag.Message = "Account successfully registered.";
                    return this.View();
                }
            }
            catch (UserAlreadyExistsException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.View(userModel);
        }

        /// <summary>
        /// Get view for log in.
        /// </summary>
        /// <returns>Page view for log in.</returns>
        [AllowAnonymous]
        public ActionResult Login()
        {
            return this.View();
        }

        /// <summary>
        /// Log in user.
        /// </summary>
        /// <param name="userModle">model or user</param>
        /// <returns>Page view after login.</returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel userModle)
        {
            if (ModelState.IsValid)
            {
                User user = UserService.GetUser(userModle.Email, userModle.Password);
                if (user != null)
                {
                    this.Session["Email"] = user.Email;
                    this.Session["Name"] = user.Name;
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    return this.RedirectToAction("Accounts");
                }

                ModelState.AddModelError(string.Empty, "User with such email and passwod is not found.");
            }

            return this.View(userModle);
        }

        /// <summary>
        /// Show user accounts.
        /// </summary>
        /// <returns>Page view with user accounts.</returns>
        [Authorize]
        public ActionResult Accounts()
        {
            var accounts = AccountService.SelectAll(Session["Email"].ToString())?.Select(acc => acc.ToAccountViewModel());
            return this.View(accounts);
        }

        /// <summary>
        /// Show user account with specified id.
        /// </summary>
        /// <param name="id">id of the user account</param>
        /// <returns>Page view with user account.</returns>
        [Authorize]
        public ActionResult Account(int id)
        {
            this.Session["CurrentAccId"] = id;
            return this.View();
        }

        /// <summary>
        /// Get view to create new account.
        /// </summary>
        /// <returns>Page view to create new account.</returns>
        [Authorize]
        public ActionResult Create()
        {
            SelectList types = new SelectList(AccountService.GetAllTypes(), "Type", "Type");
            ViewBag.Types = types;
            return this.View();
        }

        /// <summary>
        /// Create new account.
        /// </summary>
        /// <param name="accountViewModel">model of the account</param>
        /// <returns>Page view with info about creation.</returns>
        [HttpPost]
        [Authorize]
        public ActionResult Create(AccountViewModel accountViewModel)
        {
            if (ModelState.IsValid)
            {
                AccountService.CreateNewAccount(accountViewModel.Type, Session["Email"].ToString(), accountViewModel.Amount);
                ViewBag.Message = "Account successfully created!";
                return this.View();
            }

            SelectList types = new SelectList(AccountService.GetAllTypes(), "Type", "Type");
            ViewBag.Types = types;
            return this.View(accountViewModel);
        }

        /// <summary>
        /// Show details of the account.
        /// </summary>
        /// <returns>Page view with account info.</returns>
        [Authorize]
        public ActionResult Details()
        {
            ViewBag.ShowMore = "false";
            int id = int.Parse(Session["CurrentAccId"].ToString());
            return this.View(AccountService.GetAccount(id).ToAccountViewModel());
        }

        /// <summary>
        /// Show view to withdraw from account.
        /// </summary>
        /// <returns>Page view to withdraw from account.</returns>
        [Authorize]
        public ActionResult Withdraw()
        {
            return this.View();
        }

        /// <summary>
        /// Withdraw money from account.
        /// </summary>
        /// <param name="money">model of money</param>
        /// <returns>Page view with info about withdraw.</returns>
        [HttpPost]
        [Authorize]
        public ActionResult Withdraw(MoneyViewModel money)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int id = int.Parse(Session["CurrentAccId"].ToString());
                    AccountService.WithdrawFromAccount(id, money.Amount);
                    ViewBag.Message = "Operation complete successfully!";
                    return this.View();
                }
            }
            catch (NotEnoughMoneyException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return this.View(money);
        }

        /// <summary>
        /// Shows page for deposit to account.
        /// </summary>
        /// <returns>Page view for deposit to account.</returns>
        [Authorize]
        public ActionResult Deposit()
        {
            return this.View();
        }

        /// <summary>
        /// Deposit to account.
        /// </summary>
        /// <param name="money">model of money</param>
        /// <returns>Page view with info about deposit</returns>
        [HttpPost]
        [Authorize]
        public ActionResult Deposit(MoneyViewModel money)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int id = int.Parse(Session["CurrentAccId"].ToString());
                    AccountService.DepositToAccount(id, money.Amount);
                    ViewBag.Message = "Operation complete successfully!";
                    return this.View();
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Wrong operation.");
            }

            return this.View(money);
        }

        /// <summary>
        /// Show page for print account.
        /// </summary>
        /// <returns>Page view for print account.</returns>
        [Authorize]
        public ActionResult Print()
        {
            return this.View();
        }

        /// <summary>
        /// Show page for transfer money between accounts.
        /// </summary>
        /// <returns>Page view for transfer money between accounts.</returns>
        [Authorize]
        public ActionResult Transfer()
        {
            return this.View();
        }

        /// <summary>
        /// Transfer money between accounts.
        /// </summary>
        /// <param name="transfer">model for transfer money</param>
        /// <returns>Page view with information about transfer.</returns>
        [HttpPost]
        [Authorize]
        public ActionResult Transfer(TransferViewModel transfer)
        {
            if (ModelState.IsValid)
            {
                int id = int.Parse(Session["CurrentAccId"].ToString());
                try
                {
                    AccountService.Transfer(id, transfer.ToId, transfer.Amount);
                    ViewBag.Message = "Operation complete successfully!";
                }
                catch (AccountNotFoundException ex)
                {
                    ViewBag.Message = ex.Message;
                }
                catch (NotEnoughMoneyException ex)
                {
                    ViewBag.Message = ex.Message;
                }
            }

            return this.View(transfer);
        }

        /// <summary>
        /// Delete account.
        /// </summary>
        /// <returns>Page view with info about delete.</returns>
        [Authorize]
        public ActionResult Delete()
        {
            int id = int.Parse(Session["CurrentAccId"].ToString());
            try
            {
                AccountService.DeleteAccount(id);
                this.Session["CurrentAccId"] = null;
                ViewBag.Message = "Operation complete successfully!";
            }
            catch (AccountHasMoneyException ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Err = "Error";
            }

            return this.View();
        }

        /// <summary>
        /// Log off user.
        /// </summary>
        /// <returns>Page view with info about log off.</returns>
        [HttpPost]
        [Authorize]
        public ActionResult LogOff()
        {
            this.Session["Name"] = null;
            this.Session["Email"] = null;
            FormsAuthentication.SignOut();
            ViewBag.Message = "Log off successful!";
            return this.RedirectToAction("Login");
        }
    }
}