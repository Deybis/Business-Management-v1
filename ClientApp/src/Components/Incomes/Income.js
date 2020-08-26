import React, {Component} from "react"
import PropTypes from 'prop-types'
import { Link } from 'react-router-dom'
import incomeImage from '../../Images/svg/income.svg'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'


export class Income extends Component{

    static propTypes = {
        incomeID : PropTypes.number,                
        incomeName: PropTypes.string,
        incomeDescription:PropTypes.string,
        incomeAmount: PropTypes.number,
        incomeTypesID:PropTypes.number,
        incomeTypesName:PropTypes.string
    }
    
    render(){
        const {incomeID,incomeName,incomeDescription,incomeAmount,incomeTypesName} = this.props      
        let incomeAmoundFormat = new Intl.NumberFormat("es-Hn").format(incomeAmount) 
        return(
            <div>
                <div className="card-user">
                    <div className="card-user-image-container">
                        <img  className="card-user-image" src={incomeImage} alt={incomeName}/>                                  
                    </div>
                    <div className="card-user-information">
                        <div className="card-user-item card-user-name">{incomeName}</div>
                        <div className="card-user-item card-user-description">{incomeDescription}</div>
                        <div className="card-user-item">
                            <span className="card-user-badge">L. {incomeAmoundFormat}</span>
                            <span className="card-user-badge">{incomeTypesName}</span>
                        </div>
                    </div>
                    <div className="card-user-button-container">
                        <Link className="card-user-button" title="clic para editar ingreso" to={`/IncomeDetail/${incomeID}`}>
                            <FontAwesomeIcon icon="pencil-alt" size="sm" style={{ color: 'steelblue' }} />
                        </Link>
                        <button title="clic para eliminar ingreso" className="card-user-button" onClick={() =>{this.props.showModal(this.props.incomeID)}}>
                            <FontAwesomeIcon icon="trash" size="sm" style={{ color: 'tomato' }} />
                        </button>
                        
                    </div>
                </div>
              
            </div>
        )
    }

}