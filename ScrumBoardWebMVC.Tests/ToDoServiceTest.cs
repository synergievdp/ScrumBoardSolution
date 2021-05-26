using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScrumBoard.Models;
using ScrumBoard.Services;
using ScrumBoardWebMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace ScrumBoardWebMVC.Tests {
    [TestClass]
    public class ToDoServiceTest {
        private ToDoService sut;
        private IToDoRepository repo;
        private IToDoAdapter adapter;

        [TestInitialize]
        public void OnTestInitialize() {
            repo = new InMemoryToDoRepository();
            adapter = new ToDoAdapter();
            sut = new ToDoService(repo, adapter);
        }

        [TestMethod]
        public void PopulatedGetAll() {
            ToDo toDo = new();
            repo.Insert(toDo);

            ToDoViewModel viewModel = new();

            var actual = sut.GetAll().ToList();

            Assert.AreEqual(1, actual.Count);
        }

        [TestMethod]
        public void EmptyGetAll() {
            var actual = sut.GetAll().ToList();

            Assert.IsTrue(actual.Count == 0);
        }

        [TestMethod]
        public void GetByIdFound() {
            ToDo toDo = new();
            repo.Insert(toDo);

            var actual = sut.GetById(1);

            Assert.AreEqual(1, actual.Id);
        }

        [TestMethod]
        public void GetByIdNotFound() {
            var actual = sut.GetById(1);

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void Insert() {
            ToDoViewModel viewModel = new();

            sut.Insert(viewModel);

            Assert.AreEqual(1, viewModel.Id);

            var actual = repo.GetById(viewModel.Id);
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void InsertNull() {
            sut.Insert(null);

            var actual = repo.GetById(1);
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void UpdateNotFound() {
            ToDoViewModel viewModel = new();
            sut.Update(viewModel);

            Assert.AreEqual(0, viewModel.Id);
            Assert.AreEqual(0, repo.GetAll().ToList().Count);
        }

        [TestMethod]
        public void UpdateNull() {
            sut.Update(null);

            Assert.AreEqual(0, repo.GetAll().ToList().Count);
        }

        [TestMethod]
        public void UpdateFound() {
            ToDo toDo = new();
            repo.Insert(toDo);

            ToDoViewModel viewModel = new();
            viewModel.Id = 1;
            viewModel.Title = "Updated";
            sut.Update(viewModel);

            var actual = sut.GetById(1);
            Assert.AreEqual("Updated", actual.Title);
        }

        [TestMethod]
        public void DeleteNotFound() {
            sut.Delete(-1);

            var actual = repo.GetAll().ToList().Count;
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void DeleteFound() {
            ToDo toDo = new ToDo();
            repo.Insert(toDo);

            sut.Delete(1);

            var actual = repo.GetAll().ToList().Count;
            Assert.AreEqual(0, actual);
        }
    }
}
