using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_todo_list.Model;
using api_todo_list.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api_todo_list.Controller {
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase {

        private readonly ILogger<TodoController> _logger;
        private readonly ITodoRepository _todoRepository;

        public TodoController(ILogger<TodoController> logger, ITodoRepository todoRepository) {
            _logger = logger;
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public IActionResult GetAllData() {
            try {
                var data = _todoRepository.ListAll();
                return Ok(data);
            } catch (Exception ex) {
                _logger.LogError(ex, "Erro ao requisitar o todo");
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        public IActionResult SetData([FromBody] Todo todo) {
            try {
                //Console.WriteLine(todo);
                //Console.WriteLine(todo.Nome);
                var data = _todoRepository.Insert(todo.Nome);
                return Ok(todo.Nome);
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Erro ao criar um todo");
                return new StatusCodeResult(500);
            }
        }
    }
}
