using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Dev.Middleware.Application.Dtos.ClinicDto;
using Api.Dev.Middleware.Application.Interfaces;
using Api.Dev.Middleware.Application.Services;
using Api.Dev.Middleware.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Api.Dev.Middleware.Tests.Controllers
{
    public class ClinicControllerTest
    {
       
        private readonly Mock<IClinicService> _mockClinicService;
        private readonly ClinicController _controller;

        private readonly Mock<ILogger<ClinicController>> _mockLogger;  // Mock Logger
        
        public ClinicControllerTest()
        {
            _mockClinicService = new Mock<IClinicService>();
            _mockLogger = new Mock<ILogger<ClinicController>>();  // Initialize Mock Logger

            _controller =new ClinicController(_mockClinicService.Object,_mockLogger.Object);
        }


        [Fact]
        public async Task ClinicController_GetAllClinicsAsync_ValidResult()
        {
            // Arrange
            var expectedClinics = new List<ClinicDto>
        {
            new ClinicDto { ClinicID = 5, ClinicName = "Valley Diagnostic",ContactNumber="123456789",
                Address="Nowgam By-pass srinagar",Email="abc@gmail.com"},

            new ClinicDto { ClinicID = 8, ClinicName = "BiopAssay", ContactNumber="1234567899",
                Address="string",Email="user @example.com", Website="xyz" }

        };

            _mockClinicService.Setup(s => s.GetAllClinicsAsync())
                .ReturnsAsync(expectedClinics);

            // Act
            var result = await _controller.GetAllClinicsAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var clinics = Assert.IsAssignableFrom<IEnumerable<ClinicDto>>(okResult.Value);
            // Assert.Equal(expectedClinics.Count(), clinics.Count());

            //Assert.Equal(8, clinics.ElementAt(1).ClinicID);
            // Assert.Equal("Valley Diagnostic", clinics.First().ClinicName);

            Assert.Collection(clinics,
             clinic1 =>
                {
                    Assert.Equal(5, clinic1.ClinicID);
                    Assert.Equal("Valley Diagnostic", clinic1.ClinicName);
                },
                clinic2 =>
                {
                    Assert.Equal(8, clinic2.ClinicID);
                    Assert.Equal("BiopAssay", clinic2.ClinicName);
                }
            );

        }


        [Fact]
        public async Task ClinicController_GetAllClinicsAsync_NotFound()
        {
            
            
            // Arrange
            _mockClinicService.Setup(s => s.GetAllClinicsAsync())
                .ReturnsAsync((IEnumerable<ClinicDto>)null);  
            

            // Act
            var result = await _controller.GetAllClinicsAsync();

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal("No Record Exists", notFoundResult.Value);



        }
    }
}
