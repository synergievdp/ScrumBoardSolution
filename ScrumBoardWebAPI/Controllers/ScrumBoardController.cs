using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScrumBoardWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrumBoardWebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ScrumBoardController : ControllerBase {
        private readonly IToDoService service;

        public ScrumBoardController(IToDoService service) {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Get() {
            var model = service.GetAll();
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            var model = service.GetById(id);
            if(model == null) {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPost]
        public IActionResult Post(ToDoModel model) {
            if (ModelState.IsValid) {
                service.Insert(model);
                return Ok();
            } else
                return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ToDoModel model) {
            if (service.GetById(id) == null)
                return NotFound();
            else if(ModelState.IsValid) {
                service.Update(model);
                return Ok();
            } else
                return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            if (service.GetById(id) == null)
                return NotFound();
            else
                return Ok();
        }
    }
}
