﻿using PPPK_OsobaCRUD.Dao;
using PPPK_OsobaCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PPPK_OsobaCRUD.Controllers
{
    public class PersonController : Controller
    {
        private static readonly ICosmosDbService service = CosmosDbServiceProvider.CosmosDbService;

        // GET: Person
        public async Task<ActionResult> Index()
        {
            return View(await service.GetPeopleAsync("SELECT * FROM Person"));
        }

        // GET: Person/Details/5
        public async Task<ActionResult> Details(string id)
            => await ShowPerson(id);

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public async Task<ActionResult> Create(Osoba person)
        {
            if (ModelState.IsValid)
            {
                person.Id = Guid.NewGuid().ToString();
                await service.AddPersonAsync(person);
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: Person/Edit/5
        public async Task<ActionResult> Edit(string id)
            => await ShowPerson(id);

        // POST: Person/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Osoba person)
        {
            if (ModelState.IsValid)
            {
                await service.UpdatePersonAsync(person);
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: Person/Delete/5
        public async Task<ActionResult> Delete(string id)
            => await ShowPerson(id);

        // POST: Person/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(Osoba person)
        {
            await service.DeletePersonAsync(person);
            return RedirectToAction("Index");
        }

        private async Task<ActionResult> ShowPerson(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var person = await service.GetPersonAsync(id);
            if (person == null)
            {
                return HttpNotFound();
            }

            return View(person);
        }
    }
}
