import React, { Component } from 'react'
import PropTypes from 'prop-types'
import { Loading } from '../Components/Loading'
import ActivateAccountsContent from '../Components/ActivateAccountContent';


export class ActivateAccounts extends Component {

    constructor(props) {
        super(props)
        this.state = {
            accountActivate: false,
            loading: true
        }
        this.ActivateAccounts = this.ActivateAccounts.bind(this)
    }

    static propTypes = {
        match: PropTypes.shape({
            params: PropTypes.object,
            isExact: PropTypes.bool,
            path: PropTypes.string,
            url: PropTypes.string
        })
    }

    componentDidMount() {
        let id = this.props.match.params.id
        let token = this.props.match.params.token
        this.ActivateAccounts(id, token)
    }

    ActivateAccounts(id, token) {
        fetch(`Accounts/ActivateAccounts/?id=${id}&token=${token}`)
        .then(response => response.json())
        .then(data => {
            if (data.accountActive)
            {
                this.setState({ accountActivate: true,loading:false })
            }
            else
            {
                this.setState({ accountActivate: false,loading:false })
            }               
        }).catch(error => {
            this.setState({ accountActivate: false,loading:false })
            console.log(error.message)
        });
    }

    renderResults() {
        return this.state.loading
            ? <Loading></Loading>
            : this.state.accountActivate
                ? <ActivateAccountsContent title="¡Bienvenido!" accountActivate ={this.state.accountActivate} buttonText="Iniciar Sesion"></ActivateAccountsContent>
                : <ActivateAccountsContent title="¡Algo Salió Mal!" accountActivate ={this.state.accountActivate} buttonText="Regresar"></ActivateAccountsContent>
    }

    render() {
        return (
            <div>                
                {
                 this.renderResults()
                }
            </div>             
        )
    }
}