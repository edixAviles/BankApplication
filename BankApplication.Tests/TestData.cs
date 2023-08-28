using BankApplication.Src.Domain.Accounts;
using BankApplication.Src.Domain.Customers;
using BankApplication.Src.Shared.Domain;

namespace BankApplication.Tests
{
    public static class TestData
    {
        #region Customers
        public static readonly Guid IdCustomer1 = Guid.Parse("684cca36-435d-11ee-be56-0242ac120002");
        public static readonly Guid IdCustomer2 = Guid.Parse("33d5bc9a-45c4-11ee-be56-0242ac120002");
        public static readonly Guid IdCustomer3 = Guid.Parse("39dcc0e8-45c4-11ee-be56-0242ac120002");
        public static readonly Guid IdCustomer4 = Guid.Parse("3f1b2e6e-45c4-11ee-be56-0242ac120002");
        public static readonly Guid IdCustomer5 = Guid.Parse("46cc0c8c-45c4-11ee-be56-0242ac120002");
        public static readonly Customer Customer1 = new() { Id = IdCustomer1, Identification = "0701234567", Name = "Edison Avilés", Gender = "Masculino", Age = 30, Address = "Quito", Phone = "0991123456", Password = "123456", State = true };
        public static readonly Customer Customer2 = new() { Id = IdCustomer2, Identification = "0701234567", Name = "Edison Avilés", Gender = "Masculino", Age = 30, Address = "Quito", Phone = "0991123456", Password = "123456", State = true };
        public static readonly Customer Customer3 = new() { Id = IdCustomer3, Identification = "0701234567", Name = "Edison Avilés", Gender = "Masculino", Age = 30, Address = "Quito", Phone = "0991123456", Password = "123456", State = true };
        public static readonly Customer Customer4 = new() { Id = IdCustomer4, Identification = "0701234567", Name = "Edison Avilés", Gender = "Masculino", Age = 30, Address = "Quito", Phone = "0991123456", Password = "123456", State = true };
        public static readonly Customer Customer5 = new() { Id = IdCustomer5, Identification = "0701234567", Name = "Edison Avilés", Gender = "Masculino", Age = 30, Address = "Quito", Phone = "0991123456", Password = "123456", State = true };
        #endregion

        #region Accounts
        public static readonly Guid IdAccount1 = Guid.Parse("022ebd16-4373-11ee-be56-0242ac120002");
        public static readonly Guid IdAccount2 = Guid.Parse("0ca2fa28-4373-11ee-be56-0242ac120002");
        public static readonly Guid IdAccount3 = Guid.Parse("071de998-45c4-11ee-be56-0242ac120002");
        public static readonly Guid IdAccount4 = Guid.Parse("6d4aeeea-45c5-11ee-be56-0242ac120002");
        public static readonly Guid IdAccount5 = Guid.Parse("7372d4f4-45c5-11ee-be56-0242ac120002");
        public static readonly Account Account1 = new() { Id = IdAccount1, Number = "123456", Type = AccountConsts.SavingsAccount, InitialBalance = 100, CustomerId = IdCustomer1, State = true };
        public static readonly Account Account2 = new() { Id = IdAccount2, Number = "123456", Type = AccountConsts.SavingsAccount, InitialBalance = 100, CustomerId = IdCustomer2, State = true };
        public static readonly Account Account3 = new() { Id = IdAccount3, Number = "123456", Type = AccountConsts.SavingsAccount, InitialBalance = 100, CustomerId = IdCustomer3, State = true };
        public static readonly Account Account4 = new() { Id = IdAccount4, Number = "123456", Type = AccountConsts.SavingsAccount, InitialBalance = 100, CustomerId = IdCustomer4, State = true };
        public static readonly Account Account5 = new() { Id = IdAccount5, Number = "123456", Type = AccountConsts.SavingsAccount, InitialBalance = 100, CustomerId = IdCustomer5, State = true };
        #endregion
    }
}
