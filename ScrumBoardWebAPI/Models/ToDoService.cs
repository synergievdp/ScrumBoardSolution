using ScrumBoard.Models;
using ScrumBoard.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrumBoardWebAPI.Models {
    public class ToDoService : IToDoService {
        private readonly IToDoRepository repo;
        private readonly IToDoAdapter adapter;

        public ToDoService(IToDoRepository repo, IToDoAdapter adapter) {
            this.repo = repo;
            this.adapter = adapter;
        }
        public void Delete(int id) {
            repo.Delete(id);
        }

        public IEnumerable<ToDoModel> GetAll() {
            return repo.GetAll().Select(toDo => GetById(toDo.Id));
        }

        public ToDoModel GetById(int id) {
            var toDo = repo.GetById(id);
            if (toDo == null)
                return null;
            ToDoModel model = new();
            adapter.Adapt(toDo, model);
            return model;
        }

        public void Insert(ToDoModel model) {
            if (model != null) {
                ToDo toDo = new();
                adapter.Adapt(model, toDo);
                repo.Insert(toDo);
                model.Id = toDo.Id;
            }
        }

        public void Update(ToDoModel model) {
            if (model != null && GetById(model.Id) != null) {
                ToDo toDo = repo.GetById(model.Id);
                adapter.Adapt(model, toDo);
                repo.Update(toDo);
            }
        }
    }
}
