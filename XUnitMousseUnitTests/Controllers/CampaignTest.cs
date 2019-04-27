using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using BrochetteEnMousse.Controllers;
using BrochetteEnMousse.Services;
using BrochetteEnMousse.Data;

namespace XUnitMousseUnitTests.Controllers
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
            Assert.IsType<ViewResutl>(result);
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
