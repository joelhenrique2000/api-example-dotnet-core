using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_todo_list.Model {
    public class Todo {
        public long Id { get; set; }
        public string Nome { get; set; }
        public bool Concluido { get; set; }
    }
}
