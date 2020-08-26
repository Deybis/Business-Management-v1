import React,{Component} from 'react'
import { Redirect } from 'react-router-dom'
import {Loading} from '../Components/Loading'

export class LogOut extends Component{
    constructor(props){
        super(props)
        this.state = {
            logOut: false,
            loading:true
        }
    }
    componentDidMount(){
        fetch('Accounts/Logout')
        .then(response => response.json())
        .then(data => {
            if(!data.isAuthenticated){             
                this.setState({
                    logOut: true,
                    loading:false
                })
            }
        })
        .catch(error => {
            console.log(error.message)
        });
    }
    render(){
        return(
            this.state.logOut
            ? <Redirect to="/" />
            : <Loading/>
        )
    }
}