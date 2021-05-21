using ScrumBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumBoard.Services {
    public interface IToDoRepository {
        IEnumerable<ToDo> GetAll();
        ToDo GetById(int id);
        void Insert(ToDo toDo);
        void Update(ToDo toDo);
        void Delete(int id);
    }
}
