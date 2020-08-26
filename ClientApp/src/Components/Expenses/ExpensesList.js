import React, {Component} from 'react'
import PropTypes from 'prop-types'
import { Expense } from './Expense'
import {TitleSection} from '../TitleSection'
import { Link } from 'react-router-dom'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import ModalGlobal from "../ModalGlobal"
import {SnackBar} from '../SnackBar';

export class ExpensesList extends Component{
    
    constructor(props){
        super(props)
        this.state = {
            showModal: false,
            expenseID:0,
        }
        this.showModal = this.showModal.bind(this)
        this.closeModal =  this.closeModal.bind(this)
        this.confirm =  this.confirm.bind(this)
    }

    //Referencia para el componente que muestra los mensajes
    snackbarRef = React.createRef();

    static propTypes = {
        expenses: PropTypes.array
    }

    showModal(id){
        this.setState({
            showModal:true,
            expenseID : id
        })      
    }

    closeModal() {
        this.setState({
            showModal: false,
        });
    }

    confirm(id){
        fetch(`Expenses/Delete/?id=${id}`)
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
            this.snackbarRef.current.openSnackBar('success','Gasto Eliminado');
            this.props.refresh()
        }).catch(error => {
            this.snackbarRef.current.openSnackBar('','Hubo un error inesperado,no se pudo eliminar');
        });
    }
    
    render(){

        const { expenses } = this.props
        let expenseTotal = 0; 
        expenses.map(expense =>
        {        
           return  expenseTotal +=  expense.expenseAmount 
        }) 

        expenseTotal = new Intl.NumberFormat("es-Hn").format(expenseTotal)   
      
        return(
            <div className="user-main-container">
            <div className="header-section">
                <TitleSection title="Gastos"/>
                <div className="header-item">     
                    <div className="header-information">
                        <span>Total Gastos</span><span className="header-badge header-badge-danger">L.{expenseTotal}</span>
                    </div>               
                    <div className="header-information">
                        <span>Número de registros</span><span className="header-badge header-badge-default">{expenses.length}</span>
                    </div>
                    <Link className="primary-button" title="clic para agregar gasto" to={`/ExpenseDetail/${this.state.expenseID}`}>
                        <FontAwesomeIcon icon="plus" size="lg" style={{ paddingRight: '5' }} /> Agregar Gasto
                    </Link>
                </div>
            </div>

            <div className='user-list'>
            {
                expenses.map(expense =>{
                    return (
                        <div key={expense.expenseID} className="card-users-item">
                            <Expense     
                                expenseID={expense.expenseID}                      
                                expenseName={expense.expenseName}  
                                expenseDescription={expense.expenseDescription}
                                expenseAmount={expense.expenseAmount}
                                expenseTypesID={expense.expenseTypesID}
                                expenseTypesName={expense.expenseTypesName}
                                showModal={this.showModal}
                            />
                        </div>  
                    )
                })                  
            }
            </div>
          <ModalGlobal id={this.state.expenseID} title="¿Desea eliminar este gasto?" showModal={this.state.showModal} closeModal={this.closeModal} confirm={this.confirm} ></ModalGlobal>    
          {
            <SnackBar ref = {this.snackbarRef}/>
          }  
        </div>
        )
    }
}