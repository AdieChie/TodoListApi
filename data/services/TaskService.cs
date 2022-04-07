using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListApi.models;

namespace TodoListApi.data.services
{
    public class TaskService
    {
        private AppDbContext _context;
        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public void AddTask(TaskItem task)
        {
            var _task = new TaskItem()
            {
               // Id = task.Id,
                Title = task.Title,
                StartDate = task.StartDate,
                EndDate = task.EndDate,
                Priority = task.Priority,
                Status = task.Status,
                Category = task.Category

            };
            _context.Tasks.Add(_task);
            _context.SaveChanges();
        }
        
        public List<TaskItem> GetAllTasks()
        {
            return _context.Tasks.ToList();
            
        }

        public TaskItem GetTaskById(Guid id)
        {
            return _context.Tasks.FirstOrDefault(n=> n.Id == id);

        }

        public TaskItem UpdateTaskById(Guid id , TaskItem task)
        {
            var _task = _context.Tasks.FirstOrDefault(n => n.Id == id);
            if(_task != null)
            {
                _task.Title = task.Title;
                _task.StartDate = task.StartDate;
                _task.EndDate = task.EndDate;
                _task.Priority = task.Priority;
                _task.Status = task.Status;
                _task.Category = task.Category;
                _context.SaveChanges();
            }
            return _task;
        }

        public void DeleteTaskById(Guid id)
        {
            var _task = _context.Tasks.FirstOrDefault(n => n.Id == id);
            if (_task != null)
            {
                _context.Tasks.Remove(_task);
                _context.SaveChanges();
            }
        }
    }
    
}
