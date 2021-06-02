using Microsoft.AspNetCore.Mvc;
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
        private readonly IToDoService service;

        public ScrumBoardController(IToDoService service) {
            this.service = service;
        }
        public IActionResult Index() {
            var model = service.GetAll();
            return View(model);
        }

        public IActionResult Details(int id) {
            var model = service.GetById(id);
            if(model == null) {
                return NotFound();
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create() {
            return View(new ToDoViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ToDoViewModel viewModel) {
            if(ModelState.IsValid) {
                service.Insert(viewModel);
                return RedirectToAction("Details", new { Id = viewModel.Id });
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id) {
            var model = service.GetById(id);
            if (model == null)
                return NotFound();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ToDoViewModel viewModel) {
            if (service.GetById(viewModel.Id) == null)
                return NotFound();
            else if(ModelState.IsValid) {
                service.Update(viewModel);
                return RedirectToAction("Details", new { Id = viewModel.Id });
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Delete(int id) {
            var model = service.GetById(id);
            if (model == null)
                return NotFound();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection form = null) {
            if (service.GetById(id) == null)
                return NotFound();
            service.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult State(int id, State state) {
            var model = service.GetById(id);
            if (model == null)
                return NotFound();
            model.State = state;
            service.Update(model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult PostState([FromBody] StatePost data)
        {
            var model = service.GetById(data.GetId());
            if (model == null)
                return NotFound();
            model.State = data.GetState();
            service.Update(model);
            return Json(new { success = true, page = "/Scrumboard" });
        }
    }
}
