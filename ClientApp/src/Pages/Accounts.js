import React, { Component } from 'react'
import { Redirect } from 'react-router-dom'
import { SnackBar } from '../Components/SnackBar';
import Logo from '../Images/logo-dark.png';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import Footer from '../Components/Footer';
import {Loading} from '../Components/Loading'

export class Accounts extends Component {

    constructor(props) {
        document.title = 'Gestión de Negocio'
        super(props)
        this.state = {
            accountLoginUser: "",
            accountLoginPassword: "",
            companyName: "",
            companyEmail: "",
            companyPhoneNumber: "",
            redirect: false,
            showLogin: true,
            showRegister: false,
            showChangePassword: false,
            loading: false
        }
        this.inputChange = this.inputChange.bind(this)
        this.authenticate = this.authenticate.bind(this)
        this.showLogin = this.showLogin.bind(this)
        this.showRegister = this.showRegister.bind(this)
        this.createAccount = this.createAccount.bind(this)
        this.showChangePassword = this.showChangePassword.bind(this)
        this.changePasswordMail = this.changePasswordMail.bind(this)
    }

    //Referencia para el componente que muestra los mensajes
    snackbarRef = React.createRef();

    authenticate(event) {
        this.setState({
            loading: true
        })
        event.preventDefault();

        let user = {
            "AccountLoginUser": this.state.accountLoginUser,
            "AccountLoginPassword": this.state.accountLoginPassword,
        }

        fetch(`Accounts/Authenticate`,
            {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(user)
            })
            .then(response => response.json())
            .then(data => {
                if (data.isAuthenticated) {
                    this.setState({ 
                        redirect: true,
                        loading: false
                     })
                } else {
                    this.snackbarRef.current.openSnackBar('caution', '' + data.loginError + '');
                    this.setState({ 
                        loading: false
                     })
                }
            }).catch(error => {
                alert(error.message)
                console.log(error.message)
            });
    }

    createAccount(event) {
        event.preventDefault();

        this.setState({
            loading: true
        })

        let account = {
            "AccountLoginUser": this.state.accountLoginUser,
            "AccountLoginPassword": this.state.accountLoginPassword,
            "CompanyName": this.state.companyName,
            "CompanyEmail": this.state.companyEmail,
            "CompanyPhoneNumber": this.state.companyPhoneNumber
        }

        fetch(`Accounts/CreateAccount`,
            {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(account)
            })
            .then(response => response.json())
            .then(data => {
                if (data.loginError === null) {
                    this.setState({ showLogin: true, showRegister: false, loading: false })
                    this.snackbarRef.current.openSnackBar('success', 'Cuenta Creada,revise su correo para activar su cuenta');
                } else {
                    this.snackbarRef.current.openSnackBar('caution', data.loginError);
                    this.setState({ loading: false })
                }
            }).catch(error => {
                alert(error.message)
                console.log(error.message)
            });
    }

    inputChange(event) {
        this.setState({ [event.target.name]: event.target.value });
    }

    showLogin() {
        this.setState({
            showLogin: true,
            showRegister: false,
            showChangePassword: false
        })
    }

    showRegister() {
        this.setState({
            showLogin: false,
            showRegister: true,
            showChangePassword: false
        })
    }

    showChangePassword() {
        this.setState({
            showLogin: false,
            showRegister: false,
            showChangePassword: true
        })
    }

    changePasswordMail(event) {
        event.preventDefault();

        this.setState({
            loading: true
        })

        let account = {
            "CompanyEmail": this.state.companyEmail,
        }

        fetch(`Accounts/ChangePasswordMail`,
            {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(account)
            })
            .then(response => response.json())
            .then(data => {
                if (data.loginError === null) {
                    this.setState({ showLogin: true, showRegister: false, loading: false })
                    this.snackbarRef.current.openSnackBar('success', 'Enviamos un correo donde podrás acceder al cambio de contraseña');
                } else {
                    this.snackbarRef.current.openSnackBar('caution', data.loginError);
                    this.setState({loading: false})
                }
            }).catch(error => {
                alert(error.message)
                console.log(error.message)
            });
    }

    render() {
        let buttonLoginSelected = this.state.showLogin ? 'login-tab-button tab-button-selected' : 'login-tab-button'
        let buttonRegisterSelected = this.state.showRegister ? 'login-tab-button tab-button-selected' : 'login-tab-button'
        let showlogin = this.state.showLogin ? "show-form" : "hidden-form"
        let showRegister = this.state.showRegister ? "show-form" : "hidden-form"
        let showChangePassword = this.state.showChangePassword ? "show-form" : "hidden-form"
        return (
            <div className="login-section">
                <div className="information-item">
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
                    <div className="social-footer">
                        <a href="https://www.facebook.com" className="social-footer-button">
                            <FontAwesomeIcon icon={["fab", "facebook"]} size="lg" style={{ color: '#11101D' }} />
                        </a>
                        <a href="https://www.instagram.com" className="social-footer-button">
                            <FontAwesomeIcon icon={["fab", "instagram"]} size="lg" style={{ color: '#11101D' }} />
                        </a>
                        <a href="https://www.youtube.com" className="social-footer-button">
                            <FontAwesomeIcon icon={["fab", "youtube"]} size="lg" style={{ color: '#11101D' }} />
                        </a>
                    </div>
                </div>
                <div className="login-item">
                    <div className="login">
                        <div className="login-tabs">
                            <button className={buttonLoginSelected} onClick={this.showLogin}>
                                <FontAwesomeIcon icon="user" size="lg" className="icon-primary" style={{ paddingRight: '5' }} />Ingresar
                            </button>
                            <button className={buttonRegisterSelected} onClick={this.showRegister}>
                                <FontAwesomeIcon icon="plus" size="lg" className="icon-primary" style={{ paddingRight: '5' }} />Crear Cuenta
                            </button>
                        </div>
                        {
                            this.state.showLogin
                                ? <form className={showlogin} onSubmit={this.authenticate}>
                                    <div className="form-group">
                                        <label className="form-item form-label">Usuario</label>
                                        <div className="form-item">
                                            <input type="text" className="form-item form-value" required defaultValue={this.state.accountLoginUser} name="accountLoginUser" onChange={this.inputChange} />
                                        </div>
                                    </div>

                                    <div className="form-group">
                                        <label className="form-item form-label">Contraseña</label>
                                        <div className="form-item">
                                            <input type="password" className="form-item form-value" defaultValue={this.state.accountLoginPassword} required name="accountLoginPassword" onChange={this.inputChange} />
                                        </div>
                                    </div>
                                    <div className="form-group-buttons">
                                        <button type="button" className="login-recover-password" onClick={this.showChangePassword} title="clic para recuperar contraseña" >
                                            No recuerdo la contraseña
                                        </button>
                                        <button type="submit" className="form-primary-button" title="clic para guardar ingreso" >
                                            <FontAwesomeIcon icon="paper-plane" size="lg" style={{ paddingRight: '5' }} /> Ingresar
                                        </button>
                                    </div>
                                </form>
                                : this.state.showRegister
                                    ? <form onSubmit={this.createAccount} className={showRegister}>
                                        <div className="form-group">
                                            <label className="form-item form-label">Usuario</label>
                                            <div className="form-item">
                                                <input type="text" className="form-item form-value" required name="accountLoginUser" onChange={this.inputChange} />
                                            </div>
                                        </div>
                                        <div className="form-group">
                                            <label className="form-item form-label">Contraseña</label>
                                            <div className="form-item">
                                                <input type="password" className="form-item form-value" required name="accountLoginPassword" onChange={this.inputChange} />
                                            </div>
                                        </div>
                                        <div className="form-group">
                                            <label className="form-item form-label">Nombre Negocio/Empresa</label>
                                            <div className="form-item">
                                                <input type="text" className="form-item form-value" required name="companyName" onChange={this.inputChange} />
                                            </div>
                                        </div>
                                        <div className="form-group">
                                            <label className="form-item form-label">Correo Electronico</label>
                                            <div className="form-item">
                                                <input type="text" className="form-item form-value" required name="companyEmail" onChange={this.inputChange} />
                                            </div>
                                        </div>
                                        <div className="form-group">
                                            <label className="form-item form-label">Teléfono</label>
                                            <div className="form-item">
                                                <input type="number" className="form-item form-value" required name="companyPhoneNumber" onChange={this.inputChange} />
                                            </div>
                                        </div>
                                        <div className="form-group-buttons">
                                            <button type="submit" className="form-primary-button" title="clic para guardar ingreso" >
                                                <FontAwesomeIcon icon="plus" size="lg" style={{ paddingRight: '5' }} /> Crear
                                                </button>
                                        </div>
                                    </form>
                                    : this.state.showChangePassword
                                        ? <form className={showChangePassword} onSubmit={this.changePasswordMail}>
                                            <div className="form-group">
                                                <label className="form-item form-label">Cambio de contraseña</label>
                                                <small className="paragraph margin-bottom">
                                                    Ingresa el correo de tu cuenta, se te enviara un enlace donde podrás realizar
                                                    el cambio de tu contraseña.
                                                </small>
                                                <div className="form-item">
                                                    <input type="text" placeholder="Ingresa tu correo" required className="form-item form-value" name="companyEmail" onChange={this.inputChange} />
                                                </div>
                                            </div>
                                            <div className="form-group-buttons">
                                                <button type="submit" className="form-primary-button" title="clic para enviar correo" >
                                                    <FontAwesomeIcon icon="paper-plane" size="lg" style={{ paddingRight: '5' }} /> Enviar
                                                </button>
                                            </div>
                                        </form>
                                        : <span></span>
                        }

                    </div>
                    <Footer />
                </div>
                {
                    this.state.redirect
                    ? <Redirect to="/Dashboard" />
                    : <SnackBar ref={this.snackbarRef} />
                }
                {
                    this.state.loading
                    ? <Loading></Loading>
                    :""
                }
            </div>
        )
    }
}