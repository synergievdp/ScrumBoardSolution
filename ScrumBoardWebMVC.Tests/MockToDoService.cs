using ScrumBoardWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumBoardWebMVC.Tests {
    class MockToDoService : IToDoService {
        public int DeleteArgument { get; set; }
        public void Delete(int id) {
            DeleteArgument = id;
        }
        public IEnumerable<ToDoViewModel> GetAllReturnValue { get; set; }
        public IEnumerable<ToDoViewModel> GetAll() {
            return GetAllReturnValue;
        }
        public ToDoViewModel GetByIdReturnValue { get; set; }
        public ToDoViewModel GetById(int id) {
            return GetByIdReturnValue;
        }
        public ToDoViewModel InsertArgument { get; set; }
        public void Insert(ToDoViewModel toDo) {
            InsertArgument = toDo;
        }
        public ToDoViewModel UpdateArgument { get; set; }
        public void Update(ToDoViewModel toDo) {
            UpdateArgument = toDo;
        }
    }
}
