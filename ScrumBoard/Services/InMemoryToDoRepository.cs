using ScrumBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumBoard.Services {
    public class InMemoryToDoRepository : IToDoRepository {
        List<ToDo> ToDos = new();

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
