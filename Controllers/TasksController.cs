using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListApi.data.services;
using TodoListApi.models;

namespace TodoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        public TaskService _taskService;
        public TasksController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("get-all-tasks")]
        public IActionResult GetAllTasks()
        {
            var allTasks = _taskService.GetAllTasks();
            return Ok(allTasks);
        }

        [HttpGet("get-task-by-id/{id}")]
        public IActionResult GetTaskById(string id)
        {
            var task = _taskService.GetTaskById(id);
            return Ok(task);
        }

        [HttpPost]
        public IActionResult AddTask([FromBody]TaskItem task)
        {
            _taskService.AddTask(task);
            return Ok();
        }

        [HttpPut("UpdateTask/{id}")]
        public IActionResult UpdateTaskBYId(string id , [FromBody] TaskItem task)
        {
            var updatedTask = _taskService.UpdateTaskById(id, task);
            return Ok(updatedTask);
        }
        [HttpDelete("DeleteTask/{id}")]
        public IActionResult DeleteTaskById(string id)
        {
            _taskService.DeleteTaskById(id);
            return Ok();
        }
    }
}
