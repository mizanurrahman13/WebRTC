using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;
using System.Text.RegularExpressions;
using WebRTC.Infrastructure;
using WebRTC.Web.Models;

namespace WebRTC.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //public IActionResult Index()
        //{
        //    return View("WebRTC");
        //}

        //public IActionResult WebRTC()
        //{
        //    return View();
        //}

        public IActionResult Index()
        {
            return View("Create");
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult JoinMeeting(string meetingId = "")
        {
            ViewBag.MeetingId = meetingId;

            return View("Create");
        }
    }
}
