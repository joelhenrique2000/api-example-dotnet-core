using api_todo_list.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace api_todo_list.Repository {
    public class TodoRepository : ITodoRepository {
        private readonly string _connectionString;

        public TodoRepository(IConfiguration configuration) {
            _connectionString = configuration.GetConnectionString("TodoListDataServer");
            //_connectionString = configuration.GetConnectionString("Server=localhost\\SQLEXPRESS; Database = ESTUDO1; Trusted_Connection = true");
            // _connectionString = "Server=localhost\\SQLEXPRESS; Database = ESTUDO1; Trusted_Connection = true";
        }

        public IEnumerable<Todo> ListAll() {

            using var connection = new SqlConnection(_connectionString);

            var pessoaData = connection.Query<Todo>("SELECT * FROM PESSOA");

            return pessoaData;
        }

        public int Insert(string nome) {
            using var connection = new SqlConnection(_connectionString);

            var query = "INSERT INTO PESSOA (id, nome, concluido) VALUES (@id, @nome, @concluido)";

            var result = connection.Execute(query, new { id = 123, concluido = 0, nome = "asdas" });

            return result;
        }

        public int Update(long id, string nome, bool concluido) {
            using var connection = new SqlConnection(_connectionString);

            var query = "UPDATE PESSOA SET nome = @nome, concluido = @concluido WHERE id = @id";

            var result = connection.Execute(query, new { id = id, concluido = concluido, nome = nome });

            return result;
        }

        public int Delete(long id) {
            using var connection = new SqlConnection(_connectionString);

            var query = "DELETE FROM TODO WHERE id = @id";

            var result = connection.Execute(query, new { id = id });

            return result;
        }
    }
}
