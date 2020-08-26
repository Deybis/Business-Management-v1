using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BusinessManagment.Entities;

namespace BusinessManagment.Controllers
{
    public class UsersController : Controller
    {
        //Obtiene todos los usuarios
        public IEnumerable<SEG_Users> Get()
        {
            SEG_UsersCollection users = new SEG_UsersCollection().Select();
            return users;
        }

        //Muestra el detalle de un usuario
        public SEG_Users Detail(int id)
        {
            SEG_Users user = new SEG_Users();
            if (id != 0)
            {
                user = new SEG_Users().Select(id);
            }
            return user;
        }

        //Actualiza la información del usuario 
        public SEG_Users Save([FromBody] SEG_Users userReceived)
        {

            SEG_Users user = new SEG_Users();
            //Crear
            if (userReceived.UserID == 0)
            {
                user.UserName = userReceived.UserName;
                user.UserLogin = userReceived.UserLogin;
                user.GenderID = userReceived.GenderID;
                user.UserImage = new byte[10];
                user.Note = userReceived.Note;
                user.CreatedBy = "admin";
                user.CreatedDate = DateTime.Now;
                user.Insert(user);
            }
            //Editar
            else
            {
                user = new SEG_Users().Select(userReceived.UserID);
                user.UserName = userReceived.UserName;
                user.UserLogin = userReceived.UserLogin;
                user.Note = userReceived.Note;
                user.GenderID = userReceived.GenderID;
                user.ModifiedBy = "admin";
                user.ModifiedDate = DateTime.Now;
                user.Update(user);
            }


            return user;
        }

        //Elimina Usuario
        public SEG_Users Delete(int id)
        {
            SEG_Users user = new SEG_Users().Select(id);
            user.Delete(user);
            return user;
        }

        //Obtiene información de genero para llenar input select
        public IEnumerable<ADM_Gender> GetGender()
        {
            ADM_GenderCollection genders = new ADM_GenderCollection().Select();
            return genders;
        }
    }
}
