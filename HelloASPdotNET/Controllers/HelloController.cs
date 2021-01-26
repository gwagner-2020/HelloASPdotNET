using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloASPdotNET.Controllers
{
    [Route("/helloworld/")]
    public class HelloController : Controller
    {
        // GET route now /helloworld (no longer default route /Hello/Index)
        // GET /helloworld/
        [HttpGet] //this attribute explicitly tells to be GET request - GET is default
        //[Route("/helloworld/")] //this attribute overrides default route /Hello/Index -- case insensitive
        public IActionResult Index()
        {
            //string html = "<h1>" + "Hello World!" + "</h1>";
            string html = "<form method='post' action='/helloworld/welcome'>" + 
                "<input type='text' name='firstName' />" +
                //"<input type='date' name='date'" +
                "<select name='language'>" + 
                "<option value='english'>English</option>" +
                "<option value='french'>French</option>" + 
                "<option value='esperanto'>Esperanto</option>" + 
                "<option value='german'>German</option></select>" + 
                "<input type='submit' value='Greet Me!' />" + 
                "</form>";

            return Content(html, "text/html");
        }

        // GET: /Hello/Welcome
        // "World" is a default value if nothing is passed in to query
        // possible to use two parameters
        //public IActionResult Welcome(string name = "World", string farewell = "Bye")
        //[HttpGet]
        [HttpGet("welcome/{firstName?}/")]
        [HttpPost("welcome/")]
        //[Route("/helloworld/Welcome/{firstName?}")]
        //[Route("/helloworld/")]

        public IActionResult Welcome(string firstName = "World", string language = "english")
        {
            //CreateMessage(firstName, language);

            //string html = "<h1>" + "Welcome to my app, " + firstName + "</h1>";
            //html += "<h2>" + farewell + "</h2>";

            string returnGreeting = CreateMessage(firstName, language);

            string html = "<h1 style='color: blue;'>" + returnGreeting + ", " + firstName + "</h1>";
            
            return Content(html, "text/html");
        }

        public static string CreateMessage(string firstName, string language)
        {
            string greeting = "";

            if (language == "english")
            {
                greeting = "Hello";
                //return "Hello, " + firstName;
            }
            
            else if (language == "french")
            {
                greeting = "Bonjour";
                //return "Bonjour, " + firstName;
            }
            else if (language == "esperanto")
            {
                greeting = "Saluton";
                // return "Saluton, " + firstName;
            }
            else if (language == "German")
            {
                greeting = "Guten Tag";
                // return "Guten Tag, " + firstName;
            }
            else 
            {
                greeting = "Hello";
                //return "Hello, " + firstName;
            }

            return greeting;
            
            
        }
    }
}
