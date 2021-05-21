using ScrumBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumBoard.Services {
    public class InMemoryToDoRepository : IToDoRepository {
        List<ToDo> ToDos;

        public InMemoryToDoRepository() {
            ToDos = new();
            ToDos.Add(new ToDo() { Title = "Test 1", Id = 0, State = State.Backlog }); ;
            ToDos.Add(new ToDo() { Title = "Test 2", Id = 1, State = State.Doing, StartDate = new DateTime(2021, 5, 28), DueDate = new DateTime(2021, 6, 28) });
            ToDos.Add(new ToDo() { Title = "Test 3", Id = 2, State = State.Done, StartDate = DateTime.Now, DueDate = DateTime.Now});
            ToDos.Add(new ToDo() { Title = "Test 4", Id = 3, State = State.ToDo });
            ToDos.Add(new ToDo() { Title = "Test 5", Id = 4, State = State.Doing });
            ToDos.Add(new ToDo() { Title = "Test 6", Id = 5, State = State.Done });
        }
        public void Delete(int id) {
            ToDo toDo = GetById(id);
            if(toDo != null)
                ToDos.Remove(toDo);
        }

        public IEnumerable<ToDo> GetAll() {
            return ToDos.OrderBy(t => t.State);
        }

        public ToDo GetById(int id) {
            return ToDos.FirstOrDefault(t => t.Id == id);
        }

        public void Insert(ToDo toDo) {
            ToDos.Add(toDo);
            toDo.Id = ToDos.Max(t => t.Id);
        }

        public void Update(ToDo toDo) {
            var old = GetById(toDo.Id);
            //foreach(var prop in typeof(ToDo).GetProperties()) {
            //    prop.SetValue(old, prop.GetValue(toDo));
            //}
            old.State = toDo.State;
        }
    }
}
