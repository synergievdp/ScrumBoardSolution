﻿using ScrumBoard.Models;
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

        public void Insert(ToDoViewModel viewModel) {
            if (viewModel != null) {
                ToDo toDo = new();
                adapter.Adapt(viewModel, toDo);
                repo.Insert(toDo);
                viewModel.Id = toDo.Id;
            }
        }

        public void Update(ToDoViewModel viewModel) {
            if (viewModel != null && GetById(viewModel.Id) != null) {
                ToDo toDo = repo.GetById(viewModel.Id);
                adapter.Adapt(viewModel, toDo);
                repo.Update(toDo);
            }
        }
    }
}
