using BrochetteEnMousse.Controllers;
using BrochetteEnMousse.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using MousseModels.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestMousse.Controller
{
    public class CampaignTest
    {

        [Fact]
        public async Task IndexTestAsync()
        {
            // Arrange
            var mockRepo = new Mock<ICrudTest<Campaign>>();
            mockRepo.Setup(repo => repo.Index())
                .ReturnsAsync(GetTestCampaigs());
            var controller = new CampaignsController(mockRepo.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void CreateTest()
        {

        }

        [Fact]
        public void SelectTest()
        {

        }

        [Fact]
        public void EditTest()
        {

        }

        [Fact]
        public void DeleteTest()
        {

        }

        private List<Campaign> GetTestCampaigs()
        {
            var campaigns = new List<Campaign>
            {
                new Campaign()
                {
                    ID = "1",
                    Name = "Test One",
                    Description = "Test description"
                },
                new Campaign()
                {
                    ID = "1",
                    Name = "Test One",
                    Description = "Test description"
                }
            };
            return campaigns;
        }
    }
}
