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

            // Assert
            //Assert.IsType<OkObjectResult>(result.Result);
            Assert.NotNull(result);
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
    }
}
