import React,{Component} from 'react'
import {TitleForm} from '../../Components/TitleForm'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import {SnackBar} from '../../Components/SnackBar';

export class AddUser extends Component{

    constructor(props){
        super(props)
        this.state = {userID:'0',userName:'', userLogin:'', GenderID:'', note:'', options: []}
        this.inputChange = this.inputChange.bind(this)
        this.createUser = this.createUser.bind(this)
        this.goBack = this.goBack.bind(this)
    }

    componentDidMount() {
        fetch('Users/GetGender')
        .then((response) => {
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


    //Referencia para el componente que muestra los mensajes
    snackbarRef = React.createRef();

    //Actualiza el state cuando el usuario ingresa información
    inputChange(event){
        this.setState({
            [event.target.name]: event.target.value
        })
    }

    //Enivia la información al controlador para guardar el usuario
    createUser(event){
        // event.preventDefault()
        console.log(event)
        let user = {}

        user = {
            "UserID":this.state.userID,
            "UserName":this.state.userName,
            "UserLogin":this.state.userLogin,
            // "GenderID":this.state.genderID,
            "Note":this.state.note
        }
        console.log(user)
        fetch(`Users/Create`,
        {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(user)
        })
        .then(res => res.json())
        .then(user => {
            this.setState({saveData:true})
            this.snackbarRef.current.openSnackBar('success','Usuario creado con exito');
         }).catch(error => {
            this.snackbarRef.current.openSnackBar('','Hubo un error inesperado');
        });
    }

    //Regresar a la página anterior
    goBack(){
        this.props.history.goBack();
    }

    render(){

        return(
            
            <div className="container-section">    
            <div className="form-container">  
            
                <form method="POST" onSubmit={this.createUser} className="form">
                    <TitleForm title="Agregar usuario" iconName="plus"></TitleForm>
                    <p className="form-description">
                       Ingrese la informacíón requerida en el siguiente formulario y presione Guardar para agregar un usuario.
                    </p>
                    <div className="form-group">
                        <label className="form-item form-label">
                           Nombre
                        </label>
                        <input type="text" required className="form-item form-value"  defaultValue={this.state.userName} name="userName" onChange={this.inputChange}  />                                                                     
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
                                { this.state.options.map((op) => <option key={op.value} value={op.value}>{op.display}</option>)}
                            </select>
                        </div>                   
                    </div>
                    <div className="form-group">
                        <label className="form-item form-label">
                            Comentario
                        </label>
                        <input type="text" className="form-item form-value" defaultValue={this.state.note} name="note" onChange={this.inputChange} />                                                    
                    </div>
                    <div className="form-group-buttons">
                        <button className="form-secondary-button" title="Regresar" onClick={this.goBack}>
                            <FontAwesomeIcon icon="times-circle"  size="lg" style={{ paddingRight: '5' }} />Cancelar
                        </button>
                        <button className="form-primary-button" title="clic para guardar usuario">
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