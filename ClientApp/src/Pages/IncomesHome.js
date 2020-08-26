import React, {Component} from 'react'
import { NotResult } from '../Components/NotResults';
import { Loading } from '../Components/Loading'
import { Link } from 'react-router-dom'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { IncomesList } from '../Components/Incomes/IncomesList'

export class IncomesHome extends Component {
    
    constructor(props){
        document.title = "Ingresos - Gestión de Negocio"
        super(props)
        this.state = {
            incomes : [],
            loading : true
        }
        this.componentDidMount = this.componentDidMount.bind(this)
    }

    componentDidMount() {
        fetch('Incomes/GetData')  
        .then(response => {
            if (response.status === 401) { //response.redirected
                window.location.href = "/";//response.url
            }
            return response.json();
        })
        .then(data => {  
            this.setState({ incomes: data,loading: false  });  
        }).catch(error => {
            console.log(error.message)
        });
    }
    
    render(){
        let id = 0
        return(
            this.state.loading      
            ? <Loading></Loading>
            : this.state.incomes.length === 0
            ? <div className="section-container">
                    <NotResult description="INGRESOS"></NotResult>
                    <div className="button-container-absolute">
                        <Link className="primary-button" title="clic para agregar ingreso" to={`/IncomeDetail/${id}`}>
                            <FontAwesomeIcon icon="plus" size="lg" style={{ paddingRight: '5' }} /> Agregar Ingreso
                        </Link>
                    </div>
                </div>
            
            : <div className="section-container">
                    <IncomesList refresh={this.componentDidMount} incomes={this.state.incomes}></IncomesList>
                </div>  
        )
    }
}