using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BusinessManagment.Entities;
using Microsoft.AspNetCore.Http;

namespace BusinessManagment.Controllers
{
    public class ExpensesController : AccesController
    {
        private string user = string.Empty;
        public CXP_ExpensesCollection GetData()
        {
            user = HttpContext.Session.GetString("AccountLoginUser");
            CXP_ExpensesCollection expenses = new CXP_ExpensesCollection().Select(0, user);
            return expenses;
        }
        //Muestra el detalle de un gasto
        public CXP_Expenses Detail(int id)
        {
            CXP_Expenses expense = new CXP_Expenses();
            if (id != 0)
            {
                expense = new CXP_Expenses().Select(id, string.Empty);
            }
            return expense;
        }

        //Actualiza la información del gasto 
        public CXP_Expenses Save([FromBody] CXP_Expenses expenseReceived)
        {

            user = HttpContext.Session.GetString("AccountLoginUser");
            CXP_Expenses expense = new CXP_Expenses();
            SEG_Accounts account = new SEG_Accounts().Select(0, user,string.Empty);
            //Crear
            if (expenseReceived.ExpenseID == 0)
            {
                expense.ExpenseName = expenseReceived.ExpenseName;
                expense.ExpenseDescription = expenseReceived.ExpenseDescription;
                expense.ExpenseTypesID = expenseReceived.ExpenseTypesID;
                expense.ExpenseAmount = expenseReceived.ExpenseAmount;
                expense.AccountID = account.AccountID;
                expense.CreatedBy = "admin";
                expense.CreatedDate = DateTime.Now;
                expense.Insert(expense);
                return expense;
            }
            //Editar
            else
            {
                expense = new CXP_Expenses().Select(expenseReceived.ExpenseID,string.Empty);
                expense.ExpenseName = expenseReceived.ExpenseName;
                expense.ExpenseDescription = expenseReceived.ExpenseDescription;
                expense.ExpenseAmount = expenseReceived.ExpenseAmount;
                expense.ExpenseTypesID = expenseReceived.ExpenseTypesID;
                expense.ModifiedBy = "admin";
                expense.ModifiedDate = DateTime.Now;
                expense.Update(expense);
                return expense;
            }
        }

        //Elimina un Ingreso
        public CXP_Expenses Delete(int id)
        {
            CXP_Expenses expense = new CXP_Expenses().Select(id,string.Empty);
            expense.Delete(expense);
            return expense;
        }

        public IEnumerable<CXP_ExpenseTypes> GetExpenseTypes()
        {
            CXP_ExpenseTypesCollection etc = new CXP_ExpenseTypesCollection().Select();
            return etc;
        }
    }
}