using api_todo_list.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_todo_list.Repository {
    public interface ITodoRepository {
        public IEnumerable<Todo> ListAll();
        public int Insert(string nome);
        public int Update(long id, string nome, bool concluido);
        public int Delete(long id);
    }
}
