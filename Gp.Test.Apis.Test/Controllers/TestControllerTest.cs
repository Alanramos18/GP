using Gp.Test.Api.DTO;
using Gp.Test.Interface.Services;
using Gp.Test.Interface.Validations;
using GP.Test.Apis.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Gp.Test.Apis.Test.Controllers
{
    [TestFixture]
    public class TestControllerTest
    {
        private Mock<ITestService> _testServices;
        private Mock<ITestValidation> _testValidation;
        private CancellationToken _cancellationToken;

        private PersonasDTORequest _fakeRequest;
        private PersonasDTOResponse _fakeResponse;

        private TestController _controller;

        [OneTimeSetUp]
        public void Setup()
        {
            _testServices = new Mock<ITestService>();
            _testValidation = new Mock<ITestValidation>();
            _cancellationToken = new CancellationToken();

            _controller = new TestController(_testServices.Object, _testValidation.Object);

            FakeDtos();
        }

        [Test]
        public async Task CreatePersonaAsync_WithValidDto_ReturnsOk()
        {
            // Arrange
            _testValidation.Setup(x => x.ValidatePersona(_fakeRequest));
            _testServices.Setup(x => x.CreatePersonaAsync(_fakeRequest, _cancellationToken)).Returns(Task.FromResult(_fakeResponse));

            // Act
            var result = await _controller.CreatePersonaAsync(_fakeRequest);

            // Assert
            Assert.That(result, Is.TypeOf<CreatedAtRouteResult>());
        }

        private void FakeDtos()
        {
            _fakeRequest = new PersonasDTORequest
            {
                NombreCompleto = "Test",
                Domicilio = "Test Address",
                Edad = "18",
                Telefono = "12345678",
                Profesion = "Tester",
                Dni = "12345678"
            };

            _fakeResponse = new PersonasDTOResponse
            {
                Id = Guid.NewGuid(),
                NombreCompleto = "Test",
                Domicilio = "Test Address",
                Edad = "18",
                Telefono = "12345678",
                Profesion = "Tester",
                Dni = "12345678"
            };
        }
    }
}