using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScrumBoardWebMVC.Controllers;
using ScrumBoardWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumBoardWebMVC.Tests {
    [TestClass]
    public class ScrumBoardControllerTest {
        private ScrumBoardController sut;
        private MockToDoService service;

        [TestInitialize]
        public void OnTestInitialize() {
            service = new MockToDoService();
            sut = new ScrumBoardController(service);
        }

        [TestMethod]
        public void GetIndex() {
            service.GetAllReturnValue = new List<ToDoViewModel>();

            ViewResult tmp = sut.Index() as ViewResult;
            var model = tmp.Model as IEnumerable<ToDoViewModel>;

            Assert.IsNotNull(model);
        }

        [TestMethod]
        public void GetDetailsFound() {
            service.GetByIdReturnValue = new ToDoViewModel();

            ViewResult tmp = sut.Details(1) as ViewResult;
            var model = tmp.Model as ToDoViewModel;

            Assert.IsNotNull(model);
        }

        [TestMethod]
        public void GetDetailsNotFound() {
            var actual = sut.Details(-1);

            Assert.IsInstanceOfType(actual, typeof(NotFoundResult));
        }

        [TestMethod]
        public void PostCreate() {
            var toDo = new ToDoViewModel();
            var result = sut.Create(toDo);

            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void GetEdit() {
            service.GetByIdReturnValue = new ToDoViewModel();

            ViewResult tmp = sut.Edit(1) as ViewResult;
            var model = tmp.Model as ToDoViewModel;

            Assert.IsNotNull(model);
        }

        [TestMethod]
        public void GetEditNotFoundId() {
            var actual = sut.Edit(-1);

            Assert.IsInstanceOfType(actual, typeof(NotFoundResult));
        }

        [TestMethod]
        public void PostEdit() {
            ToDoViewModel toDo = new();
            service.GetByIdReturnValue = toDo;

            var result = sut.Edit(toDo);

            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void PostEditNotFoundModel() {
            var toDo = new ToDoViewModel();

            var actual = sut.Edit(toDo);

            Assert.IsInstanceOfType(actual, typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetDelete() {
            service.GetByIdReturnValue = new ToDoViewModel();

            ViewResult tmp = sut.Delete(1) as ViewResult;
            var model = tmp.Model as ToDoViewModel;

            Assert.IsNotNull(model);
        }

        [TestMethod]
        public void GetDeleteNotFound() {
            var actual = sut.Delete(-1);

            Assert.IsInstanceOfType(actual, typeof(NotFoundResult));
        }

        [TestMethod]
        public void PostDelete() {
            service.GetByIdReturnValue = new ToDoViewModel();
            var actual = sut.Delete(1, null);

            Assert.IsInstanceOfType(actual, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void PostDeleteNotFound() {
            var actual = sut.Delete(-1, null);

            Assert.IsInstanceOfType(actual, typeof(NotFoundResult));
        }

        [TestMethod]
        public void State() {
            service.GetByIdReturnValue = new ToDoViewModel();
            
            var result = sut.State(1, ScrumBoard.Models.State.ToDo);

            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void StateNotFound() {
            var result = sut.State(-1, ScrumBoard.Models.State.ToDo);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
