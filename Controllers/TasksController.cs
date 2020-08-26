using Microsoft.AspNetCore.Mvc;
using BusinessManagment.Entities;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace BusinessManagment.Controllers
{
    public class TasksController : AccesController
    {
        private string user = string.Empty;
        public ADM_TasksCollection Get()
        {
            user = HttpContext.Session.GetString("AccountLoginUser");
            ADM_TasksCollection tasks = new ADM_TasksCollection().Select(0, user);
            return tasks;
        }
        //obtiene el detalle de una tarea
        public ADM_Tasks Detail(int id)
        {
            ADM_Tasks task = new ADM_Tasks();
            user = HttpContext.Session.GetString("AccountLoginUser");
            if (id != 0)
            {
                task = new ADM_Tasks().Select(id, user);
            }
            return task;
        }
        //Guarda la información de la tarea 
        public ADM_Tasks Save([FromBody] ADM_Tasks taskReceived)
        {

            user = HttpContext.Session.GetString("AccountLoginUser");
            ADM_Tasks task = new ADM_Tasks();
            SEG_Accounts account = new SEG_Accounts().Select(0, user,string.Empty);
            //Crear
            if (taskReceived.TaskID == 0)
            {
                task.TaskName = taskReceived.TaskName;
                task.TaskDate = taskReceived.TaskDate;
                task.TaskStatusID = taskReceived.TaskStatusID;
                task.AccountID = account.AccountID;
                task.CreatedBy = user;
                task.CreatedDate = DateTime.Now;
                task.Insert(task);
                return task;
            }
            //Editar
            else
            {
                task = new ADM_Tasks().Select(taskReceived.TaskID, string.Empty);
                task.TaskName = taskReceived.TaskName;
                task.TaskDate = taskReceived.TaskDate;
                task.TaskStatusID = taskReceived.TaskStatusID;
                task.ModifiedBy = user;
                task.ModifiedDate = DateTime.Now;
                task.Update(task);
                return task;
            }
        }

        //Elimina una tarea
        public ADM_Tasks Delete(int id)
        {
            ADM_Tasks task = new ADM_Tasks().Select(id, string.Empty);
            task.Delete(task);
            return task;
        }

        public IEnumerable<ADM_TaskStatus> GetTaskStatus()
        {
            ADM_TaskStatusCollection tasks = new ADM_TaskStatusCollection().Select();
            return tasks;
        }
    }
}