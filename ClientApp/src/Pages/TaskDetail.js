import React,{ Component } from 'react'
import PropTypes from 'prop-types'
import {TitleForm} from '../Components/TitleForm'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import {SnackBar} from '../Components/SnackBar';

export class TaskDetail extends Component{

    constructor(props){
        super(props);
        this.goBack = this.goBack.bind(this);
        this.inputChange = this.inputChange.bind(this);
        this.taskSave = this.taskSave.bind(this);
        this.state = {
            taskID:0,
            taskName:'',
            taskDate:'',
            taskStatusName:'',
            taskStatusID:0,
            options: []
        }  
    }

    static propTypes = {
        match: PropTypes.shape({
            params: PropTypes.object,
            isExact: PropTypes.bool,
            path: PropTypes.string,
            url: PropTypes.string
        })
    }

    //Referencia para el componente que muestra los mensajes
    snackbarRef = React.createRef();

    //Obtiene la información del ingreso para mostrarla en los campos
    getTask ({id}){
        fetch(`Tasks/Detail/?id=${id}`)
        .then(response => {
            if (response.status === 401) { //response.redirected
                window.location.href = "/";//response.url
            }
            return response.json();
        })
        .then(task => {
            this.setState({
                taskID:task.taskID,
                taskName:task.taskName,
                taskDate:task.taskDate,
                taskStatusName:task.taskStatusName,
                taskStatusID:task.taskStatusID,
            })
        }).catch(error => {
            this.snackbarRef.current.openSnackBar('','error al obtener tarea');
        });
    }

    //Ciclo de vida de montaje del componente
    componentDidMount(){
        const {id} = this.props.match.params
        if(id !== "0")
        {
            this.getTask({id})
        }      
        fetch('Tasks/GetTaskStatus')
        .then(response => {
            if (response.status === 401) { //response.redirected
                window.location.href = "/";//response.url
            }
            return response.json();
        })
        .then(data => {
          let taskStatus = data.map(op => {
            return {value: op.taskStatusID, display: op.taskStatusName}
          });
          this.setState({
            options: [{value: '', display: 'Seleccione el estado'}].concat(taskStatus)
          });
        }).catch(error => {
            this.snackbarRef.current.openSnackBar('','Error al obtener estados');
        });
    }

    //Actualiza el state dependiendo del input en que se hizo cambio
    inputChange(event){
        this.setState({ [event.target.name]: event.target.value });
    }

    //Guarda la información
    taskSave(event){
        event.preventDefault()
        let task = {}

        task = {
            "taskID":this.state.taskID,
            "taskName":this.state.taskName,
            "taskDate":this.state.taskDate,
            "taskStatusName":this.state.taskStatusName,
            "taskStatusID":parseInt(this.state.taskStatusID)
        }
        fetch(`Tasks/Save`,
        {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(task)
        })
        .then(response => {
            if (response.status === 401) { //response.redirected
                window.location.href = "/";//response.url
            }
            return response.json();
        })
        .then(user => {
            this.snackbarRef.current.openSnackBar('success','Información guardada con exito');
         }).catch(error => {
            this.snackbarRef.current.openSnackBar('','Error al intentar guardar la información');
        });
    }

    //Regresar a la página anterior
    goBack(){
        this.props.history.goBack();
    }
    
    render(){
        let title = this.state.taskID === 0 ? "Nueva Tarea" : "Detalle de Tarea"
        let icon = this.state.taskID === 0 ? "plus" : "clipboard-list"
        return(
            <form onSubmit={this.taskSave} className="container-section">    
                <div className="form-container">  
                
                    <div className="form">
                        <TitleForm title={title} iconName={icon}></TitleForm>
                        <p className="form-description">
                            {
                                this.state.taskID !== 0
                                ? 'Edite la informacíón, despues presione el botón guardar'
                                : 'Llene los campos del formulario y presione guardar'
                            }
                            
                        </p>
                        <div className="form-group">
                            <label className="form-item form-label">
                               Nombre
                            </label>
                            <div className="form-item">
                                <input type="text" required className="form-item form-value"  defaultValue={this.state.taskName} name="taskName" onChange={this.inputChange} />                           
                            </div>                                                          
                        </div>
                        <div className="form-group">                             
                            <label className="form-item form-label">
                                Fecha 
                            </label>
                            <input type="date" required className="form-item form-value" value={this.state.taskDate.slice(0, 10)} name="taskDate" onChange={this.inputChange} />
                        </div>
                        <div className="form-group">                             
                            <label className="form-item form-label">
                                Estado
                            </label>
                            <div className="form-item">
                                <select required className="form-value" value={this.state.taskStatusID} name="taskStatusID" onChange={this.inputChange}>
                                    { 
                                        this.state.options.map(
                                            
                                            (op) => 
                                            <option  key={op.value} value={op.value} >{op.display}</option>
                                        )
                                    }
                                </select>
                            </div>                   
                        </div>
                        <div className="form-group-buttons">
                            <button type="button" className="form-secondary-button" title="Regresar" onClick={this.goBack}>
                                <FontAwesomeIcon icon="times-circle"  size="lg" style={{ paddingRight: '5' }} />Cancelar
                            </button>
                            <button type="submit" className="form-primary-button" title="clic para guardar ingreso">
                                <FontAwesomeIcon icon="save" size="lg" style={{ paddingRight: '5' }} /> Guardar
                            </button>
                        </div>
                    </div>
                </div>    
                {
                    <SnackBar ref = {this.snackbarRef}/>
                }     
            </form>
        )
    }
} 