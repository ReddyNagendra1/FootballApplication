﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using FootballApplication.Models;

namespace FootballApplication.Controllers
{
    public class TeamController : Controller
    {
        private static readonly HttpClient client;
        private JavaScriptSerializer jss = new JavaScriptSerializer();

        static TeamController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44338/api/");
        }
        // GET: Team/List
        public ActionResult List()
        {
            string url = "TeamData/ListTeams";
            HttpResponseMessage response = client.GetAsync(url).Result;
            IEnumerable<TeamDto> teams = response.Content.ReadAsAsync<IEnumerable<TeamDto>>().Result;
            return View(teams);
        }

        // GET: Team/Details/5
        public ActionResult Details(int id)
        {
            string url = "TeamData/FindTeam/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            TeamDto selectedTeam = response.Content.ReadAsAsync<TeamDto>().Result;
            return View(selectedTeam);
        }

        // GET: Team/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Team/Create
        [HttpPost]
        public ActionResult Create(TeamDto teamDto)
        {
            string url = "TeamData/AddTeam";
            string jsonPayload = jss.Serialize(teamDto);
            HttpContent content = new StringContent(jsonPayload);
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            return RedirectToAction("List");
        }

        // GET: Team/Edit/5
        public ActionResult Edit(int id)
        {
            string url = "TeamData/FindTeam/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            TeamDto teamDto = response.Content.ReadAsAsync<TeamDto>().Result;
            return View(teamDto);
        }

        // POST: Team/Update/5
        [HttpPost]
        public ActionResult Update(int id, TeamDto teamDto)
        {
            string url = "TeamData/UpdateTeam/" + id;
            string jsonPayload = jss.Serialize(teamDto);
            HttpContent content = new StringContent(jsonPayload);
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            //return RedirectToAction("List");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                // Handle the error response appropriately
                ModelState.AddModelError("", "Unable to save changes. Try again later.");
                return View(teamDto);
            }
        }

        // GET: Team/DeleteConfirm/5
        public ActionResult DeleteConfirm(int id)
        {
            string url = "TeamData/FindTeam/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            TeamDto teamDto = response.Content.ReadAsAsync<TeamDto>().Result;
            return View(teamDto);
        }

        // POST: Team/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            string url = "TeamData/DeleteTeam/" + id;
            HttpContent content = new StringContent("");
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            return RedirectToAction("List");
        }
    }
}
