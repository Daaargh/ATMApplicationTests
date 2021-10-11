using Microsoft.VisualStudio.TestTools.UnitTesting;
using ATMApplication.Classes;
using System;
using System.IO;

namespace ATMApplicationTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Correct_PIN_Return_Correct_Balance()
        {
            // Arrange
            BankAccount account = new("12345678", "1234", 500, 100);

            // Act
            string response = account.GetBalance("1234");

            // Assert
            Assert.AreEqual("500", response);

            //var stringWriter = new StringWriter();
            //Console.SetOut(stringWriter);

            //Act
            //account.GetBalance();

            //Assert
            //Assert.AreEqual("500\r\n", stringWriter.ToString());
        }

        [TestMethod]
        public void Inorrect_PIN_Return_Correct_Balance()
        {
            // Arrange
            BankAccount account = new("12345678", "1234", 500, 100);

            // Act
            string response = account.GetBalance("1212");

            // Assert
            Assert.AreEqual("ACCOUNT_ERR", response);
        }

        [TestMethod]
        public void Correct_PIN_Return_Funds_Error()
        {
            // Arrange
            BankAccount account = new("12345678", "1234", 500, 100);

            // Act
            string response = account.WithDrawFunds(700, "1234");

            // Assert
            Assert.AreEqual("FUNDS_ERR", response);
        }

        [TestMethod]
        public void Incorrect_PIN_Return_Funds_Error()
        {
            // Arrange
            BankAccount account = new("12345678", "1234", 500, 100);

            // Act
            string response = account.WithDrawFunds(700, "1552");

            // Assert
            Assert.AreEqual("ACCOUNT_ERR", response);
        }

        [TestMethod]
        public void Correct_PIN_Withdraw_Balance_And_Overdraft()
        {
            // Arrange
            BankAccount account = new("12345678", "1234", 500, 100);

            // Act
            string response = account.WithDrawFunds(600, "1234");

            // Assert
            Assert.AreEqual("-100", response);
        }

        [TestMethod]
        public void Incorrect_PIN_Withdraw_Balance_And_Overdraft()
        {
            // Arrange
            BankAccount account = new("12345678", "1234", 500, 100);

            // Act
            string response = account.WithDrawFunds(600, "6524");

            // Assert
            Assert.AreEqual("ACCOUNT_ERR", response);
        }

        [TestMethod]
        public void Correct_PIN_Withdraw_Valid_Amount_From_Balance()
        {
            // Arrange
            BankAccount account = new("12345678", "1234", 500, 100);

            // Act
            string response = account.WithDrawFunds(200, "1234");

            // Assert
            Assert.AreEqual("300", response);
        }

        [TestMethod]
        public void Incorrect_PIN_Withdraw_Valid_Amount_From_Balance()
        {
            // Arrange
            BankAccount account = new("12345678", "1234", 500, 100);

            // Act
            string response = account.WithDrawFunds(200, "8326");

            // Assert
            Assert.AreEqual("ACCOUNT_ERR", response);
        }

        [TestMethod]
        public void Test_Correct_PIN_Check()
        {

            // Arrange
            BankAccount account = new("12345678", "1234", 500, 100);

            // Act
            bool checkPIN = account.CheckPIN("1234");

            // Assert
            Assert.IsTrue(checkPIN);
        }

        [TestMethod]
        public void Test_Incorrect_PIN_Check()
        {

            // Arrange
            BankAccount account = new("12345678", "1234", 500, 100);

            // Act
            bool checkPIN = account.CheckPIN("3672");

            // Assert
            Assert.IsFalse(checkPIN);
        }
    }
}
