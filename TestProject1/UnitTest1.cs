using NUnit.Framework;
using Moq;
using WebApi.Controllers.v1;
using Microsoft.AspNetCore.Mvc;
using WebApi.Domain.Repositories;
using WebApi.Domain.Model.PersonAggregate;
using WebApi.Application.ViewModel;
using System.Threading.Tasks;
using System;

namespace WebApi.Tests.Controllers
{
    [TestFixture]
    public class PersonControllerTests
    {
        private PersonController _controller;
        private Mock<IPersonRepository> _personRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _personRepositoryMock = new Mock<IPersonRepository>();
            _controller = new PersonController(_personRepositoryMock.Object);
        }

        /// <summary>
        /// Verifica se a adição de uma pessoa válida retorna um resultado Ok.
        /// </summary>
        [Test]
        public async Task Add_ValidPerson_ReturnsOkResult()
        {
            // Arrange
            var personViewModel = new PersonViewModel { Name = "John", Age = 30 };

            // Act
            var result = await _controller.Add(personViewModel);

            // Assert
            Assert.IsInstanceOf<OkResult>(result);
        }

        /// <summary>
        /// Verifica se a obtenção de uma pessoa existente retorna um resultado Ok com o modelo de visualização da pessoa.
        /// </summary>
        [Test]
        public async Task Get_ExistingId_ReturnsOkResultWithPersonViewModel()
        {
            // Arrange
            var existingPerson = new Person { Id = 1, Name = "John", Age = 30 };
            _personRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(existingPerson);

            // Act
            var result = await _controller.Get(1);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsInstanceOf<PersonViewModel>(okResult.Value);
        }

        /// <summary>
        /// Verifica se a atualização de uma pessoa existente retorna um resultado Ok.
        /// </summary>
        [Test]
        public async Task Update_ExistingId_ReturnsOkResult()
        {
            // Arrange
            var existingPerson = new Person { Id = 1, Name = "John", Age = 30 };
            var personViewModel = new PersonViewModel { Name = "Updated John", Age = 35 };
            _personRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(existingPerson);

            // Act
            var result = await _controller.Update(1, personViewModel);

            // Assert
            Assert.IsInstanceOf<OkResult>(result);
        }

        /// <summary>
        /// Verifica se a exclusão de uma pessoa existente retorna um resultado Ok.
        /// </summary>
        [Test]
        public async Task Delete_ExistingId_ReturnsOkResult()
        {
            // Arrange
            var existingPerson = new Person { Id = 1, Name = "John", Age = 30 };
            _personRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(existingPerson);

            // Act
            var result = await _controller.Delete(1);

            // Assert
            Assert.IsInstanceOf<OkResult>(result);
        }
    }
}
