import React, {Component} from 'react'
import { NotResult } from '../Components/NotResults';
import { Loading } from '../Components/Loading'
import { Link } from 'react-router-dom'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { ExpensesList } from '../Components/Expenses/ExpensesList'

export class ExpensesHome extends Component {
    
    constructor(props){
        document.title = "Gastos - Gestión de Negocio"
        super(props)
        this.state = {
            expenses : [],
            loading : true
        }
        this.componentDidMount = this.componentDidMount.bind(this)
    }

    componentDidMount() {
        fetch('Expenses/GetData')  
        .then(response => {
            if (response.status === 401) { //response.redirected
                window.location.href = "/";//response.url
            }
            return response.json();
        })
        .then(data => {  
            this.setState({ expenses: data,loading: false  });  
        }).catch(error => {
            console.log(error.message)
        });
    }
    
    render(){
        let id = 0
        return(
            this.state.loading      
            ? <Loading></Loading>
            : this.state.expenses.length === 0
            ? <div className="section-container">
                    <NotResult description="GASTOS"></NotResult>
                    <div className="button-container-absolute">
                        <Link className="primary-button" title="clic para agregar ingreso" to={`/ExpenseDetail/${id}`}>
                            <FontAwesomeIcon icon="plus" size="lg" style={{ paddingRight: '5' }} /> Agregar Gasto
                        </Link>
                    </div>
                </div>
            
            : <div className="section-container">
                    <ExpensesList refresh={this.componentDidMount} expenses={this.state.expenses}></ExpensesList>
                </div>  
                
        )
        
    }
}