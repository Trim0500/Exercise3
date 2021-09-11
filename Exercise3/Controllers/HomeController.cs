using Exercise3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Exercise3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        /*Define a route for the URL to direct the application to go into this controller, find this method and use it
         * The first segment, the action indicates the method of the controller to be used. The action parameter makes it so we don't need to specify a controller
         * Next we define a segment corresponding to an argument from the method declaration, in this case the start of the loop to initialize
         * After that we define the next segment as an argument, that being the number to go down to at the end of the for loop
         * Finally, we define an end message to display when the program finishes the for loop.
         * 
         * Putting in a question mark indicates that the segment is optional, as the arguments likely have default values
        */
        [Route("[action]/{start}/{end?}/{message?}")]
        public IActionResult Countdown(int start, int end = 0, string message = "")
        {
            string contentString = "Counting Down:\n"; //Create a message and assign it a value

            for(int i = start; i >= end; i--) //Begin the for loop to iterate down to the end value
            {
                contentString += i + "\n"; //Append the string with a new line and the next value of the loop
            }
            contentString += message + "\n"; //Add the message provided by the url to the string when the loop is finished

            return Content(contentString); //Output a string rather than a view directly on the page
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
