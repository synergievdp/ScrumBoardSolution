using ScrumBoard.Models;
using ScrumBoard.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrumBoardWebMVC.Models {
    public class ToDoService : IToDoService {
        IToDoRepository repo;
        IToDoAdapter adapter;

        public ToDoService(IToDoRepository repo, IToDoAdapter adapter) {
            this.repo = repo;
            this.adapter = adapter;
        }

        public void Delete(int id) {
            repo.Delete(id);
        }

        public IEnumerable<ToDoViewModel> GetAll() {
            return repo.GetAll().Select(toDo => GetById(toDo.Id));
        }

        public ToDoViewModel GetById(int id) {
            var toDo = repo.GetById(id);
            if (toDo == null)
                return null;
            ToDoViewModel viewModel = new();
            adapter.Adapt(toDo, viewModel);
            return viewModel;
        }

        public void Insert(ToDoViewModel toDo) {
            if (toDo != null) {
                ToDo model = new();
                adapter.Adapt(toDo, model);
                repo.Insert(model);
                toDo.Id = model.Id;
            }
        }

        public void Update(ToDoViewModel toDo) {
            if (toDo != null && GetById(toDo.Id) != null) {
                ToDo model = new();
                adapter.Adapt(toDo, model);
                repo.Update(model);
            }
        }
    }
}
