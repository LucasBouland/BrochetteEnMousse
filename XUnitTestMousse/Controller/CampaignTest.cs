using BrochetteEnMousse.Controllers;
using BrochetteEnMousse.Data;
using BrochetteEnMousse.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestMousse.Controller
{
    public class CampaignTest
    {
        readonly CampaignsController _controller;
        readonly ICampaignService _service;

        public CampaignTest()
        {
            _service = new CampaignsData();
            _controller = new CampaignsController(_service);
        }

        [Fact]
        public void IndexTest()
        {

            var result = _controller.Index();

            Assert.NotNull(result);
            //Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void CreateTest()
        {

        }

        [Fact]
        public void SelectTest()
        {/*
            // Arrange
            var testGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");

            // Act
            var okResult = _controller.Get(testGuid);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);*/
        }

        [Fact]
        public void EditTest()
        {

        }

        [Fact]
        public void DeleteTest()
        {

        }
    }
}
