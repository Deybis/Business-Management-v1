import React,{ Component } from 'react'
import PropTypes from 'prop-types'
import {TitleForm} from '../Components/TitleForm'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import {SnackBar} from '../Components/SnackBar';

export class IncomeDetail extends Component{

    constructor(props){
        super(props);
        this.goBack = this.goBack.bind(this);
        this.inputChange = this.inputChange.bind(this);
        this.incomeSave = this.incomeSave.bind(this);
        this.state = {
            incomeID:0,
            incomeName:'',
            incomeDescription:'',
            incomeAmount:0,
            incomeTypesID:0,
            incomeTypesName:'',
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
    getIncome ({id}){
        fetch(`Incomes/Detail/?id=${id}`)
        .then(response => {
            if (response.status === 401) { //response.redirected
                window.location.href = "/";//response.url
            }
            return response.json();
        })
        .then(income => {
            this.setState({
                incomeID:income.incomeID,
                incomeName:income.incomeName,
                incomeDescription:income.incomeDescription,
                incomeAmount:income.incomeAmount,
                incomeTypesID:income.incomeTypesID,
                incomeTypesName:income.incomeTypesName
            })
        }).catch(error => {
            this.snackbarRef.current.openSnackBar('','Hubo un error inesperado');
        });
    }

    //Ciclo de vida de montaje del componente
    componentDidMount(){
        const {id} = this.props.match.params
        if(id !== "0")
        {
            this.getIncome({id})
        }      
        fetch('Incomes/GetIncomeTypes')
        .then(response => {
            if (response.status === 401) { //response.redirected
                window.location.href = "/";//response.url
            }
            return response.json();
        })
        .then(data => {
          let incomeTypes = data.map(op => {
            return {value: op.incomeTypesID, display: op.incomeTypesName}
          });
          this.setState({
            options: [{value: '', display: 'Seleccione el típo de ingreso'}].concat(incomeTypes)
          });
        }).catch(error => {
            this.snackbarRef.current.openSnackBar('','Hubo un error inesperado');
        });
    }

    //Actualiza el state dependiendo del input en que se hizo cambio
    inputChange(event){
        this.setState({ [event.target.name]: event.target.value });
    }

    //Guarda la información
    incomeSave(event){
        event.preventDefault()
        let income = {}

        income = {
            "incomeID":this.state.incomeID,
            "IncomeName":this.state.incomeName,
            "IncomeDescription":this.state.incomeDescription,
            "IncomeTypesID":parseInt(this.state.incomeTypesID),
            "IncomeAmount":parseFloat(this.state.incomeAmount)
        }
        fetch(`Incomes/Save`,
        {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(income)
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
        let title = this.state.incomeID === 0 ? "Nuevo Ingreso" : "Detalle de ingreso"
        let icon = this.state.incomeID === 0 ? "plus" : "clipboard-list"
        return(
            <form onSubmit={this.incomeSave} className="container-section">    
                <div className="form-container">  
                
                    <div className="form">
                        <TitleForm title={title} iconName={icon}></TitleForm>
                        <p className="form-description">
                            {
                                this.state.incomeID !== 0
                                ? 'Edite la informacíón, despues presione el botón guardar'
                                : 'Llene los campos del formulario y presione guardar'
                            }
                            
                        </p>
                        <div className="form-group">
                            <label className="form-item form-label">
                               Nombre
                            </label>
                            <div className="form-item">
                                <input type="text" required className="form-item form-value"  defaultValue={this.state.incomeName} name="incomeName" onChange={this.inputChange} />                           
                            </div>                                                          
                        </div>
                        <div className="form-group">                             
                            <label className="form-item form-label">
                                Descripción
                            </label>
                            <input type="text" required className="form-item form-value" defaultValue={this.state.incomeDescription} name="incomeDescription" onChange={this.inputChange} />
                        </div>
                        <div className="form-group">                             
                            <label className="form-item form-label">
                                Tipo de Ingreso
                            </label>
                            <div className="form-item">
                                <select required value={this.state.incomeTypesID} className="form-value" name="incomeTypesID" onChange={this.inputChange}>
                                    { 
                                        this.state.options.map(
                                            
                                            (op) => 
                                            <option  key={op.value} value={op.value}>{op.display}</option>
                                        )
                                    }
                                </select>
                            </div>                   
                        </div>
                        <div className="form-group">
                            <label className="form-item form-label">
                                Cantidad
                            </label>
                                <input type="number" required className="form-item form-value" value={this.state.incomeAmount} name="incomeAmount" onChange={this.inputChange} />                      
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