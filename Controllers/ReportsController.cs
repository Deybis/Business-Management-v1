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

namespace BusinessManagment.Controllers
{

    public class ReportsController : AccesController
    { 
        public up_ADM_AccountStatisticsCollection GetData([FromBody] Criteria criteria)
        {
            string user = HttpContext.Session.GetString("AccountLoginUser");
            SEG_Accounts account = new SEG_Accounts().Select(0,user,string.Empty);

            DateTime now = DateTime.Now;
            criteria.Day = criteria.Day == 0 ? now.Day : criteria.Day;
            criteria.Month = criteria.Month == 0 ? now.Month : criteria.Month;
            criteria.Year = criteria.Year == 0 ? now.Year : criteria.Year;                
            
            up_ADM_AccountStatisticsCollection report = new up_ADM_AccountStatisticsCollection().Select(criteria.Day,criteria.Month,criteria.Year,user,account.AccountID);
            
            return report;
        }
    }
}