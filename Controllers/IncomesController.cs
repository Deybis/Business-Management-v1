using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BusinessManagment.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace BusinessManagment.Controllers
{

    public class IncomesController : AccesController
    {
        private string user = string.Empty;

        public CXC_IncomesCollection GetData()
        {
            user = HttpContext.Session.GetString("AccountLoginUser");
            CXC_IncomesCollection incomes = new CXC_IncomesCollection().Select(0, user);
            return incomes;
        }
        //Muestra el detalle de un ingreso
        public CXC_Incomes Detail(int id)
        {
            CXC_Incomes income = new CXC_Incomes();
            user = HttpContext.Session.GetString("AccountLoginUser");
            if (id != 0)
            {
                income = new CXC_Incomes().Select(id, user);
            }
            return income;
        }

        //Actualiza la información del ingreso 
        public CXC_Incomes Save([FromBody] CXC_Incomes incomeReceived)
        {

            user = HttpContext.Session.GetString("AccountLoginUser");
            CXC_Incomes income = new CXC_Incomes();
            SEG_Accounts account = new SEG_Accounts().Select(0, user,string.Empty);
            //Crear
            if (incomeReceived.IncomeID == 0)
            {
                income.IncomeName = incomeReceived.IncomeName;
                income.IncomeDescription = incomeReceived.IncomeDescription;
                income.IncomeTypesID = incomeReceived.IncomeTypesID;
                income.AccountID = account.AccountID;
                income.IncomeAmount = incomeReceived.IncomeAmount;
                income.CreatedBy = "admin";
                income.CreatedDate = DateTime.Now;
                income.Insert(income);
                return income;
            }
            //Editar
            else
            {
                income = new CXC_Incomes().Select(incomeReceived.IncomeID, string.Empty);
                income.IncomeName = incomeReceived.IncomeName;
                income.IncomeDescription = incomeReceived.IncomeDescription;
                income.IncomeAmount = incomeReceived.IncomeAmount;
                income.IncomeTypesID = incomeReceived.IncomeTypesID;
                income.ModifiedBy = "admin";
                income.ModifiedDate = DateTime.Now;
                income.Update(income);
                return income;
            }
        }

        //Elimina un Ingreso
        public CXC_Incomes Delete(int id)
        {
            CXC_Incomes income = new CXC_Incomes().Select(id, string.Empty);
            income.Delete(income);
            return income;
        }

        public IEnumerable<CXC_IncomeTypes> GetIncomeTypes()
        {
            CXC_IncomeTypesCollection itc = new CXC_IncomeTypesCollection().Select();
            return itc;
        }
    }
}