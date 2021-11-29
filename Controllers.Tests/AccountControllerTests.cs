using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Wallet.BLL.DTO;
using Wallet.BLL.Interfaces;
using Wallet.DAL.Entities;
using Wallet.WEB.Controllers;
using Xunit;

namespace Controllers.Tests
{
    public class AccountControllerTests
    {
        [Fact]
        public void GetAcouuntsOkObjectResultWithListOfAccounts()
        {
            // Arrange
            var mock = new Mock<ITransactionService>();
            mock.Setup(repo => repo.GetAccounts()).Returns(GetTestAccounts());
            var controller = new AccountController(mock.Object);

            // Act
            var result = controller.GetAcouunts();

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<AccountDTO>>(okObjectResult.Value);
            Assert.Equal(GetTestAccounts().Count, model.Count());
        }
        private List<AccountDTO> GetTestAccounts()
        {
            var accounts = new List<AccountDTO>
            {
                new AccountDTO { Id = 1, Money = 1000 },
                new AccountDTO { Id = 2, Money = 2000 },
                new AccountDTO { Id = 3, Money = 3000 },
                new AccountDTO { Id = 4, Money = 4000 }
            };
            return accounts;
        }
    }
}
