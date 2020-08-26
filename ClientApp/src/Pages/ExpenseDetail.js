import React,{ Component } from 'react'
import PropTypes from 'prop-types'
import {TitleForm} from '../Components/TitleForm'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import {SnackBar} from '../Components/SnackBar';

export class ExpenseDetail extends Component{

    constructor(props){
        super(props);
        this.goBack = this.goBack.bind(this);
        this.inputChange = this.inputChange.bind(this);
        this.expenseSave = this.expenseSave.bind(this);
        this.state = {
            expenseID:0,
            expenseName:'',
            expenseDescription:'',
            expenseAmount:0,
            expenseTypesID:0,
            expenseTypesName:'',
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

    //Obtiene la información del gasto para mostrarla en los campos
    getexpense ({id}){
        fetch(`Expenses/Detail/?id=${id}`)
        .then(response => {
            if (response.status === 401) { //response.redirected
                window.location.href = "/";//response.url
            }
            return response.json();
        })
        .then(expense => {
            this.setState({
                expenseID:expense.expenseID,
                expenseName:expense.expenseName,
                expenseDescription:expense.expenseDescription,
                expenseAmount:expense.expenseAmount,
                expenseTypesID:expense.expenseTypesID,
                expenseTypesName:expense.expenseTypesName
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
            this.getexpense({id})
        }      
        fetch('Expenses/GetExpenseTypes')
        .then(response => {
            if (response.status === 401) { //response.redirected
                window.location.href = "/";//response.url
            }
            return response.json();
        })
        .then(data => {
          let expenseTypes = data.map(op => {
            return {value: op.expenseTypesID, display: op.expenseTypesName}
          });
          this.setState({
            options: [{value: '', display: 'Seleccione el típo de gasto'}].concat(expenseTypes)
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
    expenseSave(event){
        event.preventDefault()
        let expense = {}

        expense = {
            "expenseID":this.state.expenseID,
            "expenseName":this.state.expenseName,
            "expenseDescription":this.state.expenseDescription,
            "expenseTypesID":parseInt(this.state.expenseTypesID),
            "expenseAmount":parseFloat(this.state.expenseAmount)
        }
        fetch(`Expenses/Save`,
        {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(expense)
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
        let title = this.state.expenseID === 0 ? "Nuevo Gasto" : "Detalle de Gasto"
        let icon = this.state.expenseID === 0 ? "plus" : "clipboard-list"
        return(
            <form onSubmit={this.expenseSave} className="container-section">    
                <div className="form-container">  
                
                    <div className="form">
                        <TitleForm title={title} iconName={icon}></TitleForm>
                        <p className="form-description">
                            {
                                this.state.expenseID !== 0
                                ? 'Edite la informacíón, despues presione el botón guardar'
                                : 'Llene los campos del formulario y presione guardar'
                            }
                            
                        </p>
                        <div className="form-group">
                            <label className="form-item form-label">
                               Nombre
                            </label>
                            <div className="form-item">
                                <input type="text" required className="form-item form-value"  defaultValue={this.state.expenseName} name="expenseName" onChange={this.inputChange} />                           
                            </div>                                                          
                        </div>
                        <div className="form-group">                             
                            <label className="form-item form-label">
                                Descripción
                            </label>
                            <input type="text" required className="form-item form-value" defaultValue={this.state.expenseDescription} name="expenseDescription" onChange={this.inputChange} />
                        </div>
                        <div className="form-group">                             
                            <label className="form-item form-label">
                                Tipo de Gasto
                            </label>
                            <div className="form-item">
                                <select required value={this.state.expenseTypesID} className="form-value" name="expenseTypesID" onChange={this.inputChange}>
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
                                <input type="number" required className="form-item form-value" value={this.state.expenseAmount} name="expenseAmount" onChange={this.inputChange} />                      
                        </div>
                        <div className="form-group-buttons">
                            <button type="button" className="form-secondary-button" title="Regresar" onClick={this.goBack}>
                                <FontAwesomeIcon icon="times-circle"  size="lg" style={{ paddingRight: '5' }} />Cancelar
                            </button>
                            <button type="submit" className="form-primary-button" title="clic para guardar gasto">
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