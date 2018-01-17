using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Entities;
using BLL.Interfaces.Entities.Exceptions;
using BLL.Interfaces.Services;
using BLL.Mappers;
using BLL.Models;
using DAL.Interfaces.DTO;
using DAL.Interfaces.Repository;

namespace BLL.Services
{
    /// <summary>
    /// Model of user service.
    /// </summary>
    public class UserService : IUserService
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="unitOfWork">unit of work</param>
        /// <param name="userRepository">contains methods for manipulate with users</param>
        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            UserRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets user repository.
        /// </summary>
        private IUserRepository UserRepository { get; }

        /// <summary>
        /// Gets unit of work.
        /// </summary>
        private IUnitOfWork UnitOfWork { get; }

        #endregion

        /// <inheritdoc cref="IUserService.GetUser"/>
        public User GetUser(string email, string password)
        {
            return UserRepository.GetByPredicate(user => user.Email.Equals(email) && user.Password.Equals(password))?.ToUser();
        }

        /// <inheritdoc cref="IUserService.CreateUser"/>
        public void CreateUser(string name, string surname, string email, string password)
        {
            // Возможно здесь нужны проверки!!!!!!!!!
            User user = new User
            {
                Name = name,
                Surname = surname,
                Email = email,
                Password = password
            };

            if (UserRepository.GetByPredicate(usr => usr.Email.Equals(email)) != null)
            {
                throw new UserAlreadyExistsException($"User already exists with email {email}");
            }

            UserRepository.Create(user.ToDalUser());
            UnitOfWork.Commit();
        }

        /// <inheritdoc cref="IUserService.DeleteUser"/>
        public void DeleteUser(User user)
        {
            UserRepository.Delete(user.ToDalUser());
            UnitOfWork.Commit();
        }
    }
}
