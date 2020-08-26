import React, {Component} from 'react'
import PropTypes from 'prop-types'
import { Task } from './Task'
import {TitleSection} from '../TitleSection'
import { Link } from 'react-router-dom'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import ModalGlobal from "../ModalGlobal"
import {SnackBar} from '../SnackBar';

export class TasksList extends Component{
    
    constructor(props){
        super(props)
        this.state = {
            showModal: false,
            taskID:0,
        }
        this.showModal = this.showModal.bind(this)
        this.closeModal =  this.closeModal.bind(this)
        this.confirm =  this.confirm.bind(this)
    }

    //Referencia para el componente que muestra los mensajes
    snackbarRef = React.createRef();

    static propTypes = {
        incomes: PropTypes.array
    }

    showModal(id){
        this.setState({
            showModal:true,
            taskID : id
        })      
    }

    closeModal() {
        this.setState({
            showModal: false,
        });
    }

    confirm(id){
        fetch(`Tasks/Delete/?id=${id}`)
        .then(response => {
            if (response.status === 401) { //response.redirected
                window.location.href = "/";//response.url
            }
            return response.json();
        })
        .then(user => {
            this.setState({
                showModal: false,
            });
            this.snackbarRef.current.openSnackBar('success','Tarea Eliminada');
            this.props.refresh()
        }).catch(error => {
            this.snackbarRef.current.openSnackBar('','Hubo un error inesperado,no se pudo eliminar');
        });
    }
    
    render(){

        const { tasks } = this.props

        return(
            <div className="user-main-container">
            <div className="header-section">
                <TitleSection title="Tareas"/>
                <div className="header-item">                  
                    <div className="header-information">
                        <span>Número de registros</span><span className="header-badge header-badge-default">{tasks.length}</span>
                    </div>
                    <Link className="primary-button" title="clic para agregar tarea" to={`/TaskDetail/${this.state.taskID}`}>
                        <FontAwesomeIcon icon="plus" size="lg" style={{ paddingRight: '5' }} /> Agregar Tarea
                    </Link>
                </div>
            </div>

            <div className='user-list'>
            {
                tasks.map(task =>{
                    return (
                        <div key={task.taskID} className="card-users-item">
                            <Task     
                                taskID={task.taskID}      
                                accountID={task.accountID}                    
                                taskName={task.taskName}  
                                taskDate={task.taskDate}
                                taskStatusID={task.taskStatusID}
                                taskStatusName={task.taskStatusName}
                                showButtons = {true}
                                showModal={this.showModal}
                            />
                        </div>  
                    )
                })                  
            }
            </div>
          <ModalGlobal id={this.state.taskID} title="¿Desea eliminar esta tarea?" showModal={this.state.showModal} closeModal={this.closeModal} confirm={this.confirm} ></ModalGlobal>    
          {
            <SnackBar ref = {this.snackbarRef}/>
          }  
        </div>
        )
    }
}