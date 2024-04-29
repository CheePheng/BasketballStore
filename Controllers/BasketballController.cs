using BasketballStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace BasketballStore.Controllers
{

    public class BasketballController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AuthorizeUser(string code)
        {
            {
                if (!string.IsNullOrWhiteSpace(code))
                {
                    var client = new RestClient("https://login.microsoftonline.com/");
                    var request = new RestRequest("common/oauth2/v2.0/token", Method.Post);
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    request.AddParameter("grant_type", "authorization_code");
                    request.AddParameter("code", code);
                    request.AddParameter("redirect_uri", "https://localhost:7200/Basketball");

                    request.AddParameter("client_id", "3ed46488-5c04-4492-a1b3-c0b7b03d996d");
                    request.AddParameter("client_secret", "szY8Q~ZvPszCVeyn54mFal7zhmVqWu_FXQCwWcSr");
                    RestResponse response = client.Execute(request);
                    var content = response.Content;

                    var res = (JObject)JsonConvert.DeserializeObject(content);
                    var client2 = new RestClient("https://graph.microsoft.com/");
                    client2.AddDefaultHeader("Authorization", "Bearer" + res["access_token"]);
                    request = new RestRequest("v1.0/me",Method.Get);
                    var response2 = client2.Execute(request);

                    var content2 = response2.Content;

                    var useremail = (JObject)JsonConvert.DeserializeObject(content2);

                }
                return View();
            }
        }

        public async Task Login()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme,
                new AuthenticationProperties
                {
                    RedirectUri = Url.Action("GoogleResponse")
                }
                );
        }

        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            var claims=result.Principal.Identities.FirstOrDefault().Claims.Select(claim=> new {
            
            claim.Issuer,
            claim.OriginalIssuer,
            claim.Type,
            claim.Value
            
            });

            //return Json(claims);
            return RedirectToAction("Index", "Basketball", new { area = "" });

        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public IActionResult Details()
        {
            var teams = new List<Team>
    {
        new Team
        {
            TeamId = 1,
            Name = "Los Angeles Lakers",
            Description = "One of the most successful teams in the NBA.",
        },
        new Team
        {
            TeamId = 2,
            Name = "LA Clippers",
            Description = "One of the oldest and most successful franchises in the NBA.",
        },
    };

            return View(teams);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Team team)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(team);
        }

        public IActionResult Edit(int id)
        {
            var team = new Team
            {
                TeamId = id,
                Name = "Team Name", // Replace with actual team name from the database
                Description = "Team Description" // Replace with actual team description from the database
            };

            return View(team);
        }

        // POST: /Basketball/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Team team)
        {
            if (id != team.TeamId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                return RedirectToAction("Details");
            }

            return View(team);
        }



    }

}

