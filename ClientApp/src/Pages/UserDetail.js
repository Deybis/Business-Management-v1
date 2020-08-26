import React,{ Component } from 'react'
import PropTypes from 'prop-types'
import {TitleForm} from '../Components/TitleForm'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import {SnackBar} from '../Components/SnackBar';

export class UserDetail extends Component{

    constructor(props){
        super(props);
        this.goBack = this.goBack.bind(this);
        this.inputChange = this.inputChange.bind(this);
        this.userSave = this.userSave.bind(this)
        this.state = {
            userID:0,
            userName:'',
            userLogin:'',
            genderName:'',
            genderID:0, 
            note:'',
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

    //Obtiene la información del usuario para mostrarla en los campos
    getUser ({id}){
        fetch(`Users/Detail/?id=${id}`)
        .then(response => {
            if (response.status === 401) { //response.redirected
                window.location.href = "/";//response.url
            }
            return response.json();
        })
        .then(user => {
           this.setState({
            userID:user.userID,
            userName:user.userName,
            userLogin:user.userLogin,
            genderName:user.genderName,
            genderID:user.genderID,
            note:user.note === null ? "" : user.note
            })
        }).catch(error => {
            this.snackbarRef.current.openSnackBar('','Hubo un error inesperado');
        });
    }

    //Ciclo de vida de montaje del componente
    componentDidMount(){
        const {id} = this.props.match.params
        if(id !== 0){
            this.getUser({id})
        }      
        fetch('Users/GetGender')
        .then(response => {
            if (response.status === 401) { //response.redirected
                window.location.href = "/";//response.url
            }
            return response.json();
        })
        .then(data => {
          let genders = data.map(op => {
            return {value: op.genderID, display: op.genderName}
          });
          this.setState({
            options: [{value: '', display: 'Seleccione el genero'}].concat(genders)
          });
        }).catch(error => {
            this.snackbarRef.current.openSnackBar('','Hubo un error inesperado');
        });  
    }

    //Actualiza el state dependiendo del input en que se hizo cambio
    inputChange(event){
        this.setState({ [event.target.name]: event.target.value });
    }

    //Actualiza la información
    userSave(event){
        event.preventDefault()
        let user = {}

        user = {
            "UserID":parseInt(this.state.userID),
            "UserName":this.state.userName,
            "UserLogin":this.state.userLogin,
            "GenderID":parseInt(this.state.genderID),
            "Note":this.state.note
        }

        fetch(`Users/Save`,
        {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(user)
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
            this.snackbarRef.current.openSnackBar('','Hubo un error inesperado');
        });
    }

    //Regresar a la página anterior
    goBack(){
        this.props.history.goBack();     
    }
    
    render(){
        let title = this.state.userID === 0 ? "Nuevo Usuario" : "Detalle de usuario"
        let icon = this.state.userID === 0 ? "plus" : "clipboard-list"
        return(
            <div className="container-section">    
                <div className="form-container">  
                
                    <form onSubmit={this.userSave} className="form">
                        <TitleForm title={title} iconName={icon}></TitleForm>
                        <p className="form-description">
                            {
                                this.state.userID !== 0
                                ? 'Edite la información,despues presione el botón guardar'
                                : 'Llene los campos del formulario y presione guardar'
                            }
                        </p>
                        <div className="form-group">
                            <label className="form-item form-label">
                               Nombre
                            </label>
                            <div className="form-item">
                                <input type="text" required className="form-item form-value"  defaultValue={this.state.userName} name="userName" onChange={this.inputChange} />                            
                            </div>                                                          
                        </div>
                        <div className="form-group">                             
                            <label className="form-item form-label">
                                Usuario
                            </label>
                            <input type="text" required className="form-item form-value" defaultValue={this.state.userLogin} name="userLogin" onChange={this.inputChange} />
                        </div>
                        <div className="form-group">                             
                            <label className="form-item form-label">
                                Sexo
                            </label>
                            <div className="form-item">
                                <select required className="form-value" name="genderID" onChange={this.inputChange}>
                                    { 
                                        this.state.options.map(
                                            
                                            (op) => 
                                            <option  key={op.value} value={op.value} selected={this.state.genderID === op.value ? "selected" : ""}>{op.display}</option>
                                        )
                                    }
                                </select>
                            </div>                   
                        </div>
                        <div className="form-group">
                            <label className="form-item form-label">
                                Comentario
                            </label>
                            <input type="text" className="form-item form-value" value={this.state.note} name="note" onChange={this.inputChange}/>                                                      
                        </div>
                        <div className="form-group-buttons">
                            <button type="button" className="form-secondary-button" title="Regresar" onClick={this.goBack}>
                                <FontAwesomeIcon icon="times-circle"  size="lg" style={{ paddingRight: '5' }} />Cancelar
                            </button>
                            <button type="submit" className="form-primary-button" title="clic para guardar usuario">
                                <FontAwesomeIcon icon="save" size="lg" style={{ paddingRight: '5' }} /> Guardar
                            </button>
                        </div>
                    </form>
                </div>    
                {
                    <SnackBar ref = {this.snackbarRef}/>
                }     
            </div>
        )
    }
} 