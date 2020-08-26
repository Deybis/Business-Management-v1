import React, {Component} from 'react'
import PropTypes from 'prop-types'
import { Income } from './Income'
import {TitleSection} from '../TitleSection'
import { Link } from 'react-router-dom'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import ModalGlobal from "../ModalGlobal"
import {SnackBar} from '../SnackBar';

export class IncomesList extends Component{
    
    constructor(props){
        super(props)
        this.state = {
            showModal: false,
            incomeID:0,
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
            incomeID : id
        })      
    }

    closeModal() {
        this.setState({
            showModal: false,
        });
    }

    confirm(id){
        fetch(`Incomes/Delete/?id=${id}`)
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
            this.snackbarRef.current.openSnackBar('success','Ingreso Eliminado');
            this.props.refresh()
        }).catch(error => {
            this.snackbarRef.current.openSnackBar('','Hubo un error inesperado,no se pudo eliminar');
        });
    }
    
    render(){

        const { incomes } = this.props
        let incomeTotal = 0; 
        incomes.map(income =>
        {           
           return incomeTotal += income.incomeAmount             
        })         
        incomeTotal = new Intl.NumberFormat("es-HN").format(incomeTotal)  
        return(
            <div className="user-main-container">
            <div className="header-section">
                <TitleSection title="Ingresos"/>
                <div className="header-item">     
                    <div className="header-information">
                        <span>Total Ingresos</span><span className="header-badge header-badge-succes">L.{incomeTotal}</span>
                    </div>               
                    <div className="header-information">
                        <span>Número de registros</span><span className="header-badge header-badge-default">{incomes.length}</span>
                    </div>
                    <Link className="primary-button" title="clic para agregar ingreso" to={`/IncomeDetail/${this.state.incomeID}`}>
                        <FontAwesomeIcon icon="plus" size="lg" style={{ paddingRight: '5' }} /> Agregar Ingreso
                    </Link>
                </div>
            </div>

            <div className='user-list'>
            {
                incomes.map(income =>{
                    return (
                        <div key={income.incomeID} className="card-users-item">
                            <Income     
                                incomeID={income.incomeID}                      
                                incomeName={income.incomeName}  
                                incomeDescription={income.incomeDescription}
                                incomeAmount={income.incomeAmount}
                                incomeTypesID={income.incomeTypesID}
                                incomeTypesName={income.incomeTypesName}
                                showModal={this.showModal}
                            />
                        </div>  
                    )
                })                  
            }
            </div>
          <ModalGlobal id={this.state.incomeID} title="¿Desea eliminar este ingreso?" showModal={this.state.showModal} closeModal={this.closeModal} confirm={this.confirm} ></ModalGlobal>    
          {
            <SnackBar ref = {this.snackbarRef}/>
          }  
        </div>
        )
    }
}