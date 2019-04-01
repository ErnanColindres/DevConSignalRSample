using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DevConSignalRSample.Models;
using DevConSignalRBusinessAccessLayer.Services.Interfaces;

namespace DevConSignalRSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICandidateService _candidateService;

        public HomeController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        public IActionResult Index()
        {

            var candidateInfo = _candidateService.GetCandidateVotes();
            return View(candidateInfo);
        }
    }
}
