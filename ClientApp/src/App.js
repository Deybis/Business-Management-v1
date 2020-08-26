import React, { Component } from 'react';
import {Route, Switch } from 'react-router';
// import {BrowserRouter as Router} from 'react-router-dom';
import { Layout } from './Components/Layout';
import { Dashboard } from './Components/Dashboard';
import { IncomesHome } from './Pages/IncomesHome';
import { IncomeDetail } from './Pages/IncomeDetail';
import { ExpensesHome } from './Pages/ExpensesHome';
import { ExpenseDetail } from './Pages/ExpenseDetail';
// import { Redirect } from 'react-router-dom'
import './custom.css'
import { Accounts } from './Pages/Accounts';
import { ActivateAccounts } from './Pages/ActivateAccount';
import { AccountDetail } from './Pages/AccountDetail';
import { LogOut } from './Components/LogOut';
import { TaskHome } from './Pages/TaskHome';
import { TaskDetail } from './Pages/TaskDetail';
import { Reports } from './Pages/Reports';
import { ChangePassword } from './Components/ChangePassword';
import { NotFound } from './Components/NotFound'


export default class App extends Component {

  static displayName = App.name;
 

  render () {
    return (
      <div>
          <Switch>
              <Route exact path='/' component={Accounts} />         
              <Route exact path='/ActivateAccounts/:id/:token' component={ActivateAccounts}></Route>
              <Route exact path='/ChangePassword/:id' component={ChangePassword}></Route>
              <Layout>
                <Switch> 
                  <Route exact path='/Dashboard' component={Dashboard}></Route>  
                  <Route path='/IncomesHome' component={IncomesHome}></Route>
                  <Route path='/IncomeDetail/:id' component={IncomeDetail}></Route>
                  <Route path='/ExpensesHome' component={ExpensesHome}></Route>
                  <Route path='/ExpenseDetail/:id' component={ExpenseDetail}></Route>
                  <Route path='/TaskHome' component={TaskHome}></Route>
                  <Route path='/TaskDetail/:id' component={TaskDetail}></Route>
                  <Route path='/Account/:AccountName' component={AccountDetail}></Route>
                  <Route path='/LogOut' component={LogOut}></Route>
                  <Route path='/Reports' component={Reports}></Route>  
                  <Route component={NotFound} />
                </Switch>            
              </Layout>
          </Switch>  
      </div>
    );
  }
}
