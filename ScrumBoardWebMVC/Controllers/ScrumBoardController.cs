﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScrumBoard.Services;
using ScrumBoard.Models;
using Microsoft.AspNetCore.Http;
using ScrumBoardWebMVC.Models;

namespace ScrumBoardWebMVC.Controllers {
    public class ScrumBoardController : Controller {
        IToDoRepository repo = new InMemoryToDoRepository();
        public IActionResult Index() {
            var model = repo.GetAll();
            return View(model);
        }

        public IActionResult Details(int id) {
            var model = repo.GetById(id);
            if(model == null) {
                return new NotFoundResult();
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ToDo toDo) {
            if(ModelState.IsValid) {
                repo.Insert(toDo);
                return RedirectToAction("Details", new { Id = toDo.Id });
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id) {
            var model = repo.GetById(id);
            if (model == null)
                return new NotFoundResult();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ToDo toDo) {
            if(ModelState.IsValid) {
                repo.Update(toDo);
                return RedirectToAction("Details", new { Id = toDo.Id });
            }
            return View(toDo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id) {
            var model = repo.GetById(id);
            if (model == null)
                return new NotFoundResult();
            repo.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult State(int id, State state) {
            var model = repo.GetById(id);
            if (model == null)
                return NotFound();
            model.State = state;
            repo.Update(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult PostState(StatePost data)
        {
            var model = repo.GetById(data.GetId());
            model.State = data.GetState();
            repo.Update(model);
            return RedirectToAction("Index");
        }
    }
}
