import React, { Component } from 'react'
import { HomeAccesButton } from './HomeAccesButton'
import Expenses from '../Images/svg/budget.svg'
import Income from '../Images/svg/income.svg'
import Report from '../Images/svg/report.svg'
import TaskImage from '../Images/svg/task.svg'
import UserAvatar from '../Images/svg/user-avatar-m.svg'
import { Link } from 'react-router-dom'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { Loading } from '../Components/Loading'
import { Task } from './Tasks/Task'


export class Dashboard extends Component {

  constructor(props) {
    super(props)
    document.title = 'Inicio - Gestión de Negocio'
    this.state = {
      dashBoardData: [],
      accountID: 0,
      companyEmail: "",
      companyImage: null,
      companyName: "",
      companyPhoneNumber: "",
      expensesTotal: 0,
      incomesTotal: 0,
      taskID: 0,
      loading: true
    }
  }

  componentDidMount() {
    fetch('DashBoard/Get')
    .then(response => {      
      if (response.status === 401) { //response.redirected
          window.location.href = "/";//response.url
      }
      return response.json();
    })
    .then(data => {
      this.setState({
        dashBoardData: data,
        accountID: data[0].accountID,
        companyEmail: data[0].companyEmail,
        companyImage: data[0].companyImage,
        companyName: data[0].companyName,
        companyPhoneNumber: data[0].companyPhoneNumber,
        expensesTotal: data[0].expensesTotal,
        incomesTotal: data[0].incomesTotal,
        taskID: data[0].taskID,
        loading: false
      })
    }).catch(error => {
      console.log(error.message)
    });
  }

  render() {
    let companyImage = 'data:image/png;base64,' + this.state.companyImage + ''
    return (

      this.state.loading
        ? <Loading></Loading>
        : <div className="home-main-container">
          <div className="profile-container">
            <div className="profile">
              <div className="profile-header">
                <div className="profile-image-container">
                  {
                    this.state.companyImage === null
                      ? <img className="profile-image" src={UserAvatar} alt="wd" />
                      : <img className="profile-image" src={companyImage} alt={this.state.companyName} />
                  }
                </div>
                <div className="profile-text-container">
                  <div className="profile-company-name">
                    {this.state.companyName}
                  </div>
                  <div className="profile-company-item">
                    <FontAwesomeIcon icon="envelope" style={{ marginRight: '2' }} /> {this.state.companyEmail}
                  </div>
                  <div className="profile-company-item">
                    <FontAwesomeIcon icon="phone-alt" style={{ marginRight: '2' }} /> {this.state.companyPhoneNumber}
                  </div>
                  <Link to={`/Account/${this.state.companyName}`} className="profile-button">
                    <FontAwesomeIcon icon="pencil-alt" style={{ marginRight: '2' }} /> Editar Cuenta
                  </Link>
                </div>
              </div>
              <div className="profile-footer">
                <div className="profile-footer-item">
                  <div className="profile-footer-item-value">
                    {this.state.incomesTotal}
                  </div>
                  <div className="profile-footer-item-label income-color">
                    Ingresos
                  </div>
                </div>
                <div className="profile-footer-item">
                  <div className="profile-footer-item-value ">
                    {this.state.expensesTotal}
                  </div>
                  <div className="profile-footer-item-label expense-color">
                    Gastos
                  </div>
                </div>
                <div className="profile-footer-item">
                  <div className="profile-footer-item-value">
                    {this.state.taskID > 0 ? this.state.dashBoardData.length : 0}
                  </div>
                  <label className="profile-footer-item-label default-color">
                    Tareas
                  </label>
                </div>
              </div>
            </div>

            <div className="panel-container">
              <div className="panel-item">
                <HomeAccesButton title="Ingresos" alt="ingresos" source={Income} description="Registro de todos los ingresos" url="/IncomesHome"></HomeAccesButton>
              </div>
              <div className="panel-item">
                <HomeAccesButton title="Gastos" alt="gastos" source={Expenses} description="Registro de todos los gastos" url="/ExpensesHome"></HomeAccesButton>
              </div>
              <div className="panel-item">
                <HomeAccesButton title="Tareas" alt="tareas" source={TaskImage} description="Tareas por realizar" url="/TaskHome"></HomeAccesButton>
              </div>
              <div className="panel-item">
                <HomeAccesButton title="Reportes" alt="reportes" source={Report} description="Estadísticas del negocio" url="/Reports"></HomeAccesButton>
              </div>
            </div>
          </div>

          <div className="home-panel">
            <h3 className="panel-title">
              <FontAwesomeIcon className="icon-primary" icon="check-circle" style={{ marginRight: '5' }} />
                Tareas
              </h3>
            <div className="panel-list">
              {
                this.state.taskID !== 0
                  ? this.state.dashBoardData.map(data => {
                    return (
                      <div key={data.taskID} className="dashboard-task">
                        <Task
                          taskName={data.taskName}
                          taskDate={data.taskDate}
                          taskStatusName={data.taskStatusName}
                          showButtons={false}
                        />
                      </div>
                    )
                  })
                  : <div className="panel-result">
                    <div className="panel-result-image-container">
                      <img className="panel-result-image" src={TaskImage} alt="tareas" />
                    </div>
                    <div className="panel-result-text">
                      Aún no tienes tareas...
                    </div>
                  </div>
              }
            </div>
          </div>
        </div>

    );
  }
}
