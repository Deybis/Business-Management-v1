import React,{Component} from 'react'
import { NotResult } from '../Components/NotResults';
import { Loading } from '../Components/Loading'
import { Link } from 'react-router-dom'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { TasksList } from '../Components/Tasks/TasksList'

export class TaskHome extends Component{

    constructor(props){
        document.title = "Tareas - Gestión de Negocio"
        super(props)
        this.state = {
            tasks : [],
            loading: true
        }
        this.componentDidMount = this.componentDidMount.bind(this)
    }

    componentDidMount(){
        fetch('Tasks/Get')
        .then(response => {
            if (response.status === 401) { //response.redirected
                window.location.href = "/";//response.url
            }
            return response.json();
        })
        .then(data => {
            this.setState({
                tasks:data,
                loading: false
            })
        }).catch(error => {
            console.log(error.message)
        });
    }

    render(){
        let id = 0
        return(
            this.state.loading      
            ? <Loading></Loading>
            : this.state.tasks.length === 0
            ? <div className="section-container">
                    <NotResult description="TAREAS"></NotResult>
                    <div className="button-container-absolute">
                        <Link className="primary-button" title="clic para agregar tarea" to={`/TaskDetail/${id}`}>
                            <FontAwesomeIcon icon="plus" size="lg" style={{ paddingRight: '5' }} /> Agregar Tarea
                        </Link>
                    </div>
                </div>            
            : <div className="section-container">
                    <TasksList refresh={this.componentDidMount} tasks={this.state.tasks}></TasksList>
               </div>  
        )
    }
}