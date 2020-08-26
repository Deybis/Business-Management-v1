import React, { Component} from 'react'
import { UsersList } from '../Components/Users/UsersList'
import { NotResult } from '../Components/NotResults';
import { Loading } from '../Components/Loading'
import { Link } from 'react-router-dom'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'

export class UsersHome extends Component{

    constructor(props) {
        super(props);
        this.state = { results: [],loading: true };
        this.componentDidMount = this.componentDidMount.bind(this)
    }

    componentDidMount() {
        fetch('Users/Get')  
        .then(response => {
            if (response.status === 401) { //response.redirected
                window.location.href = "/";//response.url
            }
            return response.json();
        })
        .then(data => {  
            this.setState({ results: data,loading: false  });  
        }).catch(error => {
            console.log(error.message)
        });
    }

    renderResults(){    
        return this.state.loading      
        ? <Loading></Loading>
        : this.state.results.length === 0
          ? <div className="section-container">
                <NotResult description="USUARIOS"></NotResult>
                <div className="button-container-absolute">
                    <Link className="primary-button" title="clic para agregar usuario" to={`/AddUser`}>
                        <FontAwesomeIcon icon="plus" size="lg" style={{ paddingRight: '5' }} /> Agregar usuario
                    </Link>
                </div>
            </div>
         
          : <div className="section-container">
                <UsersList refresh={this.componentDidMount} users={this.state.results}></UsersList>
            </div>   
    }

    render(){
        return(
            <div>                
                {
                 this.renderResults()
                }
            </div>
        )
    }
}