using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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

        //public IActionResult Privacy()
        //{
        //    return View();
        //}
        public IActionResult Index()
        {
            return View("WebRTC");
        }

        public IActionResult WebRTC()
        {
            return View();
        }

        //public IActionResult Index()
        //{
        //    return View("WebRTCMain");
        //}

        //public IActionResult WebRTCMain()
        //{
        //    return View();
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult JoinMeeting(string meetingId)
        //{
        //    ViewBag.MeetingId = meetingId;
        //    return View();
        //}
    }
}
