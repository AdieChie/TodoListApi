using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoListApi.models;

namespace TodoListApi.data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
using(var serviceScope= applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if (!context.Tasks.Any())
                {
                    context.Tasks.AddRange(new TaskItem()
                    {
                        Id = "qwert123",
                        Title = "1st task",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now,
                        Category = "task category",
                        Priority = 1,
                        Status = 1

                    }) ;

                    context.SaveChanges();

                }
            }
        }
    }
}
