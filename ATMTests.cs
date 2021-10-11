using ATMApplication.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApplicationTests
{
    class ATMTests
    {
        [TestClass]
        public class BankAccountTests
        {
            [TestMethod]
            public void Withdraw_Funds_Correct_PIN_Enough_Money()
            {
                // Arrange
                BankAccount account = new("12345678", "1234", 500, 100);
                ATM atm = new(8000, account);

                // Act
                string response = atm.WithdrawMoney(100, "1234");

                // Assert
                Assert.AreEqual("400", response);
            }

            [TestMethod]
            public void Withdraw_Funds_Incorrect_PIN_Enough_Money()
            {
                // Arrange
                BankAccount account = new("12345678", "1234", 500, 100);
                ATM atm = new(8000, account);

                // Act
                string response = atm.WithdrawMoney(100, "6721");

                // Assert
                Assert.AreEqual("ACCOUNT_ERR", response);
            }

            [TestMethod]
            public void Withdraw_Funds_Correct_PIN_Insufficient_Money()
            {
                // Arrange
                BankAccount account = new("12345678", "1234", 500, 100);
                ATM atm = new(8000, account);

                // Act
                string response = atm.WithdrawMoney(10000, "1234");

                // Assert
                Assert.AreEqual("FUNDS_ERR", response);
            }

            [TestMethod]
            public void Withdraw_Funds_Incorrect_PIN_Insufficient_Money()
            {
                // Arrange
                BankAccount account = new("12345678", "1234", 500, 100);
                ATM atm = new(8000, account);

                // Act
                string response = atm.WithdrawMoney(10000, "5721");

                // Assert
                Assert.AreEqual("FUNDS_ERR", response);
            }

            [TestMethod]
            public void Withdraw_Funds_Correct_PIN_No_Money()
            {
                // Arrange
                BankAccount account = new("12345678", "1234", 500, 100);
                ATM atm = new(0, account);

                // Act
                string response = atm.WithdrawMoney(10000, "1234");

                // Assert
                Assert.AreEqual("ATM_ERR", response);
            }

            [TestMethod]
            public void Withdraw_Funds_Incorrect_PIN_No_Money()
            {
                // Arrange
                BankAccount account = new("12345678", "1234", 500, 100);
                ATM atm = new(0, account);

                // Act
                string response = atm.WithdrawMoney(10000, "5721");

                // Assert
                Assert.AreEqual("ATM_ERR", response);
            }

            [TestMethod]
            public void Check_Balance_Correct_PIN()
            {
                // Arrange
                BankAccount account = new("12345678", "1234", 500, 100);
                ATM atm = new(8000, account);

                // Act
                string response = atm.CheckAccountBalance("1234");

                // Assert
                Assert.AreEqual("500", response);
            }

            [TestMethod]
            public void Check_Balance_Incorrect_PIN()
            {
                // Arrange
                BankAccount account = new("12345678", "1234", 500, 100);
                ATM atm = new(8000, account);

                // Act
                string response = atm.CheckAccountBalance("3435");

                // Assert
                Assert.AreEqual("ACCOUNT_ERR", response);
            }
        }
    }
}
