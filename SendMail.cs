using System;
using System.Net;
using Microsoft.SqlServer.Server;
using System.Net.Mail;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;

namespace BusinessManagment
{
    public partial class SendMail
    {
        public static string PrepareHtml(string AccountLoginUser,long AccountID,string AccountIdentifyToken,int MailType,string urlServer){
             
             string url = string.Empty;
             string buttonName = string.Empty;
             string description = string.Empty;

             if(MailType == Convert.ToInt32(myEnums.MailType.ActivateAccountMail)){
                url = @"http://"+urlServer+@"/ActivateAccounts/"+ AccountID +@"/"+ AccountIdentifyToken;
                buttonName = "Activar Cuenta";
                description = "Activa tu cuenta <strong> Gestión de Negocio </strong> haciendo clic en el siguiente enlace";
             }

             if(MailType == Convert.ToInt32(myEnums.MailType.ChangePasswordMail)){
                url = @"http://"+urlServer+@"/ChangePassword/"+ AccountID;
                buttonName = "Cambiar Contraseña";
                description = "Puedes cambiar la contraseña de tu cuenta <strong> Gestión de Negocio </strong> haciendo clic en el siguiente enlace";
             }

            string html = @"
                    <style>
                        .container-template-activation{
                            width: 80%;
                            background-color: #eefff6;
                            box-shadow: 0 0 10px rgba(0,0,0,0.1);
                            margin: auto;
                            border-radius: 5px;
                            overflow: hidden;
                            border:1px solid #e8e8e8;
                        }
                        .template-activation-header{           
                            background-color: #11101D;                            
                        }
                        .template-activation-logo{
                            float: left;
                            padding: 10px 15px;
                        }
                        .logo-icon{
                            display: inline-block;
                            background-color: #00FF7F;
                            color:#11101D;
                            width: 40px;
                            height: 40px;
                            line-height: 40px;
                            text-align: center;
                            font-size: 18px;
                            border-radius: 50%;
                            font-weight: bold;
                        }
                        .logo-description{
                            display: inline-block;
                            margin-left: 5px;
                            text-transform: uppercase;
                            font-weight: bold;
                            color:#fff;
                        }
                        .template-activation-social{
                            padding: 15px;
                            float: right;
                        }
                        .clear{
                            clear: both;
                        }
                        .template-social-btn{
                            margin: 0 5px;
                            text-decoration: none;
                        }
                        .template-social-btn-img{
                            width: 30px;
                            height: 30px;
                        }
                        .template-activation-content{
                            padding: 50px;
                        }
                        .paragraph{
                            color:#444;
                            font-size: 14px;
                            padding: 0;
                            margin:5px 0;
                        }
                        .user-name{
                            color:#00FF7F;
                            font-weight: bold;
                            font-size: 15px;
                            margin-left: 7px;
                        }
                        .template-button-container{
                            width: 100%;
                            padding: 30px 0;
                            text-align: center;
                        }
                        .template-primary-button{
                            background-color: #00FF7F;
                            color:#11101D;
                            padding:15px 30px;
                            border-radius: 5px;
                            text-decoration: none;
                            outline: none;
                            font-weight:bold;
                        }
                        .template-footer{
                            text-align: center;
                            padding: 20px 0;
                            width: 100%;
                            color:#555;
                            border-top:1px dashed #e8e8e8;
                            font-size: 14px;
                        }
                    </style>
                    <div class='container-template-activation'>
                        <div class='template-activation-header'>
                            <div class='template-activation-logo'>
                                <div class='logo-icon'>GN</div>
                                <div class='logo-description'>Gestión de Negocio</div>
                            </div>
                            <div class='template-activation-social'>
                                <a class='template-social-btn' href='https://www.facebook.com'>
                                    <img class='template-social-btn-img' src='https://i.ibb.co/ScgFXwK/facebook.png' alt='facebook'>
                                </a>
                                <a class='template-social-btn' href='https://www.instagram.com'>
                                    <img class='template-social-btn-img' src='https://i.ibb.co/YtQBG8R/instagram.png' alt='instagram'>
                                </a>
                                <a class='template-social-btn' href='https://www.youtube.com'>
                                    <img class='template-social-btn-img' src='https://i.ibb.co/Jj1Mz9f/youtube.png' alt='youtube'>
                                </a>
                            </div>
                            <div class='clear'></div>
                        </div>    
                        <div class='template-activation-content'>
                            <span class='paragraph'><strong>Hola:</strong></span> <span class='user-name'>"+ AccountLoginUser +@"</span>
                            <p class='paragraph'>"+@description+@"</p>
                            <div class='template-button-container'> 
                            <a class='template-primary-button' href='"+url+@"'>"+buttonName+@"</a>
                            </div>
                            <p class='paragraph'><strong>¡Gracias por ser parte de GN!</strong></p>
                            <p class='paragraph'>El equipo de Seven Design®</p>
                        </div>
                        <div class='template-footer'>
                        © 2020 Seven Design® - Todos los derechos reservados
                        </div>  
                    </div>";
            return html;
        }
        public static void CLR_SendEmail(string subject, string body, string to)
        {
            SmtpClient smtpClient = new SmtpClient();
            NetworkCredential basicCredential = new NetworkCredential("cc3f006b94664de32d25d38338dd1c4c", "8527a9f47e001c4052b008e307719735");
            MailMessage message = new MailMessage();
            MailAddress fromAddress = new MailAddress("sevendesignhn@gmail.com","Gestión Negocio - SevenDesign®");

            smtpClient.Host = "in-v3.mailjet.com";
            // smtpClient.Port = 25;
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = basicCredential;
            smtpClient.EnableSsl = false;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

            message.From = fromAddress;
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = body;
            message.To.Add(to);
            smtpClient.Send(message);
        }
    }
}