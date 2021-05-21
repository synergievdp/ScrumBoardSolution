using ScrumBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumBoard.Services {
    public class InMemoryToDoRepository : IToDoRepository {
        List<ToDo> ToDos;
        private static InMemoryToDoRepository instance;
        public static InMemoryToDoRepository Instance { get { return instance ?? new InMemoryToDoRepository(); } }

        private InMemoryToDoRepository() {
            ToDos = new();
            ToDos.Add(new ToDo() { Title = "ToDo", Id = 1 });
            ToDos.Add(new ToDo() { Title = "ToDo", Id = 2, DueDate = DateTime.Now });
            ToDos.Add(new ToDo() { Title = "ToDo", Id = 3, StartDate = DateTime.Now, DueDate = DateTime.Now});
            ToDos.Add(new ToDo() { Title = "ToDo", Id = 4, State = State.ToDo });
            ToDos.Add(new ToDo() { Title = "ToDo", Id = 5, State = State.Doing });
            ToDos.Add(new ToDo() { Title = "ToDo", Id = 6, State = State.Done });
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
            toDo.Id = ToDos.Max(t => t.Id) + 1;
        }

        public void Update(ToDo toDo) {
            var old = GetById(toDo.Id);
            foreach (var prop in typeof(ToDo).GetProperties()) {
                prop.SetValue(old, prop.GetValue(toDo));
            }
        }
    }
}
