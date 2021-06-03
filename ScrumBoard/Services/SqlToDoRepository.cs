using Microsoft.EntityFrameworkCore;
using ScrumBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumBoard.Services {
    public class SqlToDoRepository : IToDoRepository {
        private readonly ScrumBoardDbContext dbContext;

        public SqlToDoRepository(ScrumBoardDbContext dbContext) {
            this.dbContext = dbContext;
        }
        public void Delete(int id) {
            dbContext.ToDos.Remove(GetById(id));
            dbContext.SaveChanges();
        }

        public IEnumerable<ToDo> GetAll() {
            return dbContext.ToDos.Include(t => t.Contact).Include(t => t.Files).OrderBy(toDo => toDo.State);
        }

        public ToDo GetById(int id) {
            return dbContext.ToDos.Include(t => t.Contact).Include(t => t.Files).FirstOrDefault(toDo => toDo.Id == id);
        }

        public void Insert(ToDo toDo) {
            dbContext.ToDos.Add(toDo);
            dbContext.SaveChanges();
        }

        public void Update(ToDo toDo) {
            var entry = dbContext.Entry(toDo);
            entry.State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
