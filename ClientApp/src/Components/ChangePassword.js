import React, { Component } from 'react'
import PropTypes from 'prop-types'
import { Redirect } from 'react-router-dom'
import Logo from '../Images/logo-dark.png';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { TitleForm } from '../Components/TitleForm'
import { SnackBar } from '../Components/SnackBar';

export class ChangePassword extends Component {
    constructor(props) {
        super(props)
        this.state = {
            accountID: 0,
            accountLoginPassword: "",
            redirect: false
        }
        this.passwordUpdate = this.passwordUpdate.bind(this)
        this.inputChange = this.inputChange.bind(this)
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

    inputChange(event) {
        this.setState({ [event.target.name]: event.target.value });
    }
    passwordUpdate(event) {
        event.preventDefault();

        let account = {
            "AccountID": parseInt(this.props.match.params.id),
            "AccountLoginPassword": this.state.accountLoginPassword
        }

        fetch(`Accounts/PasswordUpdate`,
            {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(account)
            })
            .then(response => response.json())
            .then(data => {
                if (data.loginError === null) {
                    this.snackbarRef.current.openSnackBar('success', 'Contraseña Actualizada');
                    setTimeout(() => {
                        this.setState({ redirect: true })                        
                    }, 5000);
                } else {
                    this.snackbarRef.current.openSnackBar('', data.loginError);
                }
            }).catch(error => {
                alert(error.message)
                console.log(error.message)
            });
    }
    render() {
        return (
            this.state.redirect
                ? <Redirect to="/" />
                : <div className="activate-account-container">
                    <div className="activate-account">
                        <div className="logo-area">
                            <div className="brand-logo">
                                <div className="logo">
                                    GN
                                </div>
                                <span>Gestión de Negocio</span>
                            </div>
                            <div className="logo-information">
                                <small className="logo-small">Desarrollado por</small>
                                <div className="logo-title">
                                    <img src={Logo} alt="logo-gestion-negocio" />
                                    <span>
                                        Seven Design®
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div className="activate-account-content justify-content-center align-items-center">
                            <form onSubmit={this.passwordUpdate}>
                                <TitleForm title="Cambio de Contraseña" iconName="unlock-alt"></TitleForm>
                                <p className="form-description">
                                    Ingresa tu nueva contraseña, luego da clic en enviar.
                                </p>
                                <div className="form-group margin-top">
                                    <label className="form-item form-label">Nueva Contraseña</label>
                                    <div className="form-item">
                                        <input type="password" required className="form-item form-value" name="accountLoginPassword" onChange={this.inputChange} />
                                    </div>
                                </div>
                                <div className="form-group-buttons">
                                    <button type="submit" className="form-primary-button" title="clic para enviar nueva contraseña" >
                                        <FontAwesomeIcon icon="paper-plane" size="lg" style={{ paddingRight: '5' }} /> Enviar
                                    </button>
                                </div>
                            </form>
                        </div>
                    </div>
                    <SnackBar ref={this.snackbarRef} />
                </div>
                
        )
    }
}