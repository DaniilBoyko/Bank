using BLL.Interfaces.Entities.Account;

namespace Bank.Models.Mapping
{
    /// <summary>
    /// Class contents methods for mapping models from view models to business layer models.
    /// </summary>
    public static class ModelMapping
    {
        /// <summary>
        /// Convert business layer account model to account view model.
        /// </summary>
        /// <param name="account">business layer account</param>
        /// <returns>Account view model.</returns>
        public static AccountViewModel ToAccountViewModel(this Account account)
        {
            return new AccountViewModel()
            {
                Id = account.Id,
                Amount = account.Amount,
                Points = account.Points,
                Type = account.GetAccountType()
            };
        }
    }
}