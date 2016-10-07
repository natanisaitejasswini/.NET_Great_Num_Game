using Nancy;
using System;
using System.Collections.Generic;

namespace GameNancy
{
    public class GameModule : NancyModule
    {
        public GameModule()
        {

            Get("/", args => {
                Console.WriteLine(Session["number"]);

                if(Session["number"] == null){
                    int rnd = new Random().Next(0,100);
                    Session["number"] = rnd;
                    Console.WriteLine("Random Number is" +  Session["number"]);
                }

                ViewBag.display = "";
                ViewBag.Show = true;

                Console.WriteLine("Random Number" + Session["number"]);
                return View["Game"];
            });



            Post("/formsubmitted", args =>
            {
                int Guess = Request.Form.guess;
                Session["guess"] = Guess;
                Console.WriteLine(Session["guess"]);
                if(Guess == (int) Session["number"])
                {
                    ViewBag.display = Session["guess"] + " was the number";
                    ViewBag.show = false;
                    Session["number"] = null;
                    return View["Game"];
                }
                else if(Guess > (int) Session["number"])
                {
                    ViewBag.display = "Too High!";
                    ViewBag.show = true;
                    return View["Game"];
                }
                else
                {
                    ViewBag.display = "Too Low!";
                    ViewBag.show = true;
                    return View["Game"];
                }
            });
        }
    }
}

