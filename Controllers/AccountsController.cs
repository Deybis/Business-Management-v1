using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BusinessManagment.Entities;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Security.Cryptography;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using System.Text;

namespace BusinessManagment.Controllers
{

    public class AccountsController : Controller
    {
        public SEG_Accounts Authenticate([FromBody] SEG_Accounts user)
        {

            SEG_Accounts account = new SEG_Accounts().Select(0, user.AccountLoginUser, string.Empty);

            if (account.AccountID != 0)
            {
                account.AccountLoginPassword = Helper.Decrypt(account.AccountLoginPassword);

                if (user.AccountLoginUser != account.AccountLoginUser)
                {
                    account.LoginError = "Usuario Incorrecto";
                }
                else if (user.AccountLoginPassword != account.AccountLoginPassword)
                {
                    account.LoginError = "Contraseña Incorrecta";
                    account.isAuthenticated = false;
                }
                else if (account.AccountActive == false)
                {
                    account.LoginError = "Su cuenta aún no ha sido activada, revise su correo y active su cuenta";
                    account.isAuthenticated = false;
                }
                else
                {
                    account.isAuthenticated = true;

                    HttpContext.Session.SetString("AccountLoginUser", account.AccountLoginUser);
                    HttpContext.Session.SetInt32("AccountID",Convert.ToInt32(account.AccountID));

                    // var BMClaims = new List<Claim>(){
                    //     new Claim(ClaimTypes.Name, account.AccountLoginUser),
                    //     new Claim(ClaimTypes.Email, account.CompanyEmail),
                    // };
                    // var BMIdentity = new ClaimsIdentity(BMClaims, "BM Identity");
                    // var userPrincipal = new ClaimsPrincipal(new[] { BMIdentity });
                    // HttpContext.SignInAsync(userPrincipal);
                }
            }
            else
            {
                SEG_Accounts a = new SEG_Accounts();
                a.LoginError = "No existe una cuenta relacionada con la información que proporciono";
                a.isAuthenticated = false;
                return a;
            }
            return account;
        }

        public SEG_Accounts CreateAccount([FromBody] SEG_Accounts user)
        {

            SEG_Accounts account = new SEG_Accounts().Select(0, string.Empty, user.CompanyEmail);
            if (account.AccountID == 0)
            {
                account.StatusID = Convert.ToInt32(myEnums.Status.Create);
                account.AccountLoginUser = user.AccountLoginUser;
                account.AccountLoginPassword = Helper.Encrypt(user.AccountLoginPassword);
                account.CompanyName = user.CompanyName;
                account.CompanyEmail = user.CompanyEmail;
                account.CompanyPhoneNumber = user.CompanyPhoneNumber;
                account.AccountActive = false;

                //generar Hash
                int length = 24;
                Random random = new Random();
                string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

                StringBuilder tokenStringBuilder = new StringBuilder(length);
                for (int i = 0; i < length; i++)
                {
                    tokenStringBuilder.Append(characters[random.Next(characters.Length)]);
                }
                var token = tokenStringBuilder.ToString();

                // var tokenBytes = Encoding.ASCII.GetBytes(tokenStringBuilder.ToString());
                // using (var crypto = new RNGCryptoServiceProvider()) crypto.GetBytes(tokenBytes);
                // var token = Encoding.ASCII.GetString(tokenBytes);//Convert.ToBase64String(tokenBytes);
                // token = token.Replace("/", "gn").Replace(":", "gn").Replace("=", "gn").Replace("+", "gn").Replace("-", "gn");

                account.AccountIdentifyToken = token;
                account.CreatedBy = user.AccountLoginUser;
                account.CreatedDate = DateTime.Now;
                account.AccountID = account.Insert(account);

                //Enviar correo de activación
                string urlServer =  HttpContext.Request.Host.Value;
                string body = SendMail.PrepareHtml(account.AccountLoginUser, account.AccountID, account.AccountIdentifyToken, Convert.ToInt32(myEnums.MailType.ActivateAccountMail),urlServer);
                SendMail.CLR_SendEmail("Activar Cuenta", body, account.CompanyEmail);

            }
            else
            {
                account.LoginError = "Ya existe una cuenta asociada al correo ingresado";
            }

            return account;
        }

        public SEG_Accounts ActivateAccounts(long id, string token)
        {
            SEG_Accounts account = new SEG_Accounts().Select(id, string.Empty, string.Empty);

            if (account.AccountID != 0)
            {
                if (account.AccountIdentifyToken == token)
                {
                    account.AccountActive = true;
                    account.StatusID = Convert.ToInt32(myEnums.Status.Active);
                    account.Update(account);
                }
                else
                {
                    account.AccountActive = false;
                }
            }
            else
            {
                account.AccountActive = false;
            }
            return account;
        }

        public SEG_Accounts GetAccount()
        {
            var user = User.Identity.Name;
            SEG_Accounts account = new SEG_Accounts().Select(0, user, string.Empty);
            account.AccountLoginPasswordDecrypt = Helper.Decrypt(account.AccountLoginPassword);
            return account;
        }

        public SEG_Accounts UpdateAccount([FromBody] SEG_Accounts user)
        {
            SEG_Accounts account = new SEG_Accounts().Select(user.AccountID, string.Empty, string.Empty);
            var passwordDecrypt = Helper.Decrypt(account.AccountLoginPassword);        
            account.AccountLoginPassword =  passwordDecrypt == user.AccountLoginPasswordDecrypt ? account.AccountLoginPassword : Helper.Encrypt(user.AccountLoginPasswordDecrypt);
            account.CompanyName = user.CompanyName;
            account.CompanyEmail = user.CompanyEmail;
            account.CompanyPhoneNumber = user.CompanyPhoneNumber;
            account.ModifiedBy = user.AccountLoginUser;
            account.ModifiedDate = DateTime.Now;
            account.Update(account);

            return account;
        }

        public SEG_Accounts UpdateAccountImage([FromForm] FileModel image)
        {
            var user = User.Identity.Name;
            SEG_Accounts account = new SEG_Accounts().Select(0, user, string.Empty);

            byte[] imageData = null;
            using (var binaryReader = new BinaryReader(image.File.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)image.File.Length);
            }
            account.CompanyImage = imageData;
            account.Update(account);
            return account;
        }

        public SEG_Accounts DeleteAccount([FromBody] SEG_Accounts accountReceived)
        {
            SEG_Accounts account = new SEG_Accounts().Select(accountReceived.AccountID, string.Empty, string.Empty);
            account.StatusID = Convert.ToInt32(myEnums.Status.Delete);
            account.Update(account);
            return account;
        }

        public SEG_Accounts ChangePasswordMail([FromBody] SEG_Accounts accountInfo)
        {
            SEG_Accounts account = new SEG_Accounts().Select(0, string.Empty, accountInfo.CompanyEmail);
            if (account.AccountID > 0)
            {
                //Enviar correo para cambio de contraseña
                string urlServer = HttpContext.Request.Host.Value;
                string body = SendMail.PrepareHtml(account.AccountLoginUser, account.AccountID, account.AccountIdentifyToken, Convert.ToInt32(myEnums.MailType.ChangePasswordMail),urlServer);
                SendMail.CLR_SendEmail("Cambio de Contraseña", body, account.CompanyEmail);
            }
            else
            {
                account.LoginError = "No encontramos una cuenta asociada al correo proporcionado";
            }
            return account;
        }

        public SEG_Accounts PasswordUpdate([FromBody] SEG_Accounts accountInfo)
        {
            SEG_Accounts account = new SEG_Accounts().Select(accountInfo.AccountID, string.Empty, string.Empty);
            if (account.AccountID > 0)
            {
                account.AccountLoginPassword = Helper.Encrypt(accountInfo.AccountLoginPassword);
                account.Update(account);
            }
            else
            {
                account.LoginError = "No se pudo actualizar la contraseña";
            }
            return account;
        }

        public SEG_Accounts Logout()
        {
            HttpContext.SignOutAsync();
            SEG_Accounts account = new SEG_Accounts();
            account.isAuthenticated = false;
            return account;
        }
    }
}