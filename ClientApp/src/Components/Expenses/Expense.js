import React, {Component} from "react"
import PropTypes from 'prop-types'
import { Link } from 'react-router-dom'
import expenseImage from '../../Images/svg/budget.svg'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'


export class Expense extends Component{

    static propTypes = {
        expenseID : PropTypes.number,                
        expenseName: PropTypes.string,
        expenseDescription:PropTypes.string,
        expenseAmount: PropTypes.number,
        expenseTypesID:PropTypes.number,
        expenseTypesName:PropTypes.string
    }
    
    render(){
        const {expenseID,expenseName,expenseDescription,expenseAmount,expenseTypesName} = this.props      
        let expenseAmoundFormat = new Intl.NumberFormat("es-Hn").format(expenseAmount)   
        return(
            <div>
                <div className="card-user">
                    <div className="card-user-image-container">
                        <img  className="card-user-image" src={expenseImage} alt={expenseName}/>                                  
                    </div>
                    <div className="card-user-information">
                        <div className="card-user-item card-user-name">{expenseName}</div>
                        <div className="card-user-item card-user-description">{expenseDescription}</div>
                        <div className="card-user-item">
                            <span className="card-user-badge">L. {expenseAmoundFormat}</span>
                            <span className="card-user-badge">{expenseTypesName}</span>
                        </div>
                    </div>
                    <div className="card-user-button-container">
                        <Link className="card-user-button" title="clic para editar gasto" to={`/expenseDetail/${expenseID}`}>
                            <FontAwesomeIcon icon="pencil-alt" size="sm" style={{ color: 'steelblue' }} />
                        </Link>
                        <button title="clic para eliminar gasto" className="card-user-button" onClick={() =>{this.props.showModal(this.props.expenseID)}}>
                            <FontAwesomeIcon icon="trash" size="sm" style={{ color: 'tomato' }} />
                        </button>
                        
                    </div>
                </div>
              
            </div>
        )
    }

}