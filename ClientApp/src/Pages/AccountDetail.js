import React, { Component } from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { SnackBar } from '../Components/SnackBar';
import UserAvatar from '../Images/svg/user-avatar-m.svg'
import { TitleForm } from '../Components/TitleForm'
import { Loading } from '../Components/Loading';
import { Redirect } from 'react-router-dom'

export class AccountDetail extends Component {
    constructor(props) {
        super(props)
        document.title = 'Cuenta - Gestión de Negocio'
        this.state = {
            accountID: 0,
            accountLoginUser: "",
            accountLoginPassword: "",
            accountLoginPasswordDecrypt:"",
            companyName: "",
            companyImage: "",
            companyEmail: "",
            companyPhoneNumber: "",
            createdDate: "--/--/----",
            showPassword: false,
            file: null,
            loading: true,
            deleteAccount: false
        }
        this.updateAccount = this.updateAccount.bind(this)
        this.inputChange = this.inputChange.bind(this)
        this.goBack = this.goBack.bind(this)
        this.showPassword = this.showPassword.bind(this)
        this.uploadAccountImage = this.uploadAccountImage.bind(this)
        this.deleteAccount = this.deleteAccount.bind(this)
    }

    showPassword() {
        let toggle = this.state.showPassword === true ? false : true
        this.setState({
            showPassword: toggle
        })
    }
        
    //Referencia para el componente que muestra los mensajes
    snackbarRef = React.createRef();

    //Ciclo de vida de montaje del componente
    componentDidMount() {
        fetch(`Accounts/GetAccount`)
        .then(response => {
            if (response.redirected) {
                window.location.href = response.url
            }
            return response.json();
        })
        .then(account => {
            this.setState({
                accountID: account.accountID,
                accountLoginUser: account.accountLoginUser,
                accountLoginPassword: account.accountLoginPassword,
                accountLoginPasswordDecrypt : account.accountLoginPasswordDecrypt,
                companyName: account.companyName,
                companyEmail: account.companyEmail,
                companyPhoneNumber: account.companyPhoneNumber,
                companyImage: account.companyImage,
                createdDate: account.createdDate,
                loading: false
            })
        }).catch(error => {
            this.snackbarRef.current.openSnackBar('', 'Hubo un error inesperado');
        });
    }

    inputChange(event) {
        this.setState({ [event.target.name]: event.target.value });
    }

    updateAccount(event) {
        event.preventDefault();

        let account = {
            "AccountID": this.state.accountID,
            "AccountLoginUser": this.state.accountLoginUser,
            "AccountLoginPasswordDecrypt": this.state.accountLoginPasswordDecrypt,
            "CompanyName": this.state.companyName,
            "CompanyEmail": this.state.companyEmail,
            "CompanyPhoneNumber": this.state.companyPhoneNumber
        }

        fetch(`Accounts/UpdateAccount`,
        {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(account)
        })
        .then(response => {
            if (response.redirected) {
                window.location.href = response.url
            }
            return response.json();
        })
        .then(data => {
            this.snackbarRef.current.openSnackBar('success', 'Información Actualizada');
        }).catch(error => {
            alert(error.message)
            console.log(error.message)
        });
    }

    uploadAccountImage(event) {

        event.preventDefault()
        let formData = new FormData();
        formData.append('File', event.target.files[0]);

        fetch(`Accounts/UpdateAccountImage `,
            {
                method: 'POST',
                body: formData
            })
            .then(response => {
                if (response.redirected) {
                   window.location.href = response.url
                }
                return response.json();
            })
            .then(data => {
                this.setState({
                    companyImage: data.companyImage
                })
                this.snackbarRef.current.openSnackBar('success', 'Información Actualizada');
            }).catch(error => {
                alert(error.message)
                console.log(error.message)
            });
    }

    deleteAccount(event) {
        event.preventDefault();

        let account = {
            "AccountID": this.state.accountID,
            "AccountLoginUser": this.state.accountLoginUser,
        }

        fetch(`Accounts/DeleteAccount`,
            {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(account)
            })
            .then(response => {
                if (response.redirected) {
                   window.location.href = response.url
                }
                return response.json();
            })
            .then(data => {
                this.snackbarRef.current.openSnackBar('success', 'Su cuenta fue eliminada');
                setTimeout(() => {
                    this.setState({ deleteAccount: true })
                }, 3000);
            }).catch(error => {
                alert(error.message)
                console.log(error.message)
            });
    }

    goBack() {
        this.props.history.goBack();
    }
    render() {
        let iconPasswordButton = !this.state.showPassword ? "eye" : "eye-slash";
        let companyImage = 'data:image/png;base64,' + this.state.companyImage + ''
        return (
            this.state.loading
                ? <Loading></Loading>
                : this.state.deleteAccount
                    ? <Redirect to="/" />
                    : <div>
                        <div className="account-cover"></div>
                        <div className="account-detail-container">
                            <div className="detail-item account-detail">
                                <div className="detail-image-container">
                                    {
                                        this.state.companyImage === "" || this.state.companyImage === null
                                            ? <img className="detail-image" src={UserAvatar} alt="logo" />
                                            : <img className="detail-image" title="tamaño recomendado 200x200" src={companyImage} alt={"logo-" + this.state.companyName} />
                                    }
                                    <input className="detail-image-edit" type="file" required onChange={this.uploadAccountImage} />
                                </div>
                                <div className="account-detail-name">
                                    {this.state.companyName} <FontAwesomeIcon className="icon-primary" icon="check-circle" size="sm" style={{ marginLeft: '3px' }} />
                                </div>
                                <div className="detail-plan-container">
                                    <span className="account-detail-plan">Plan Gratuito</span>
                                </div>
                                <div className="account-detail-date">
                                    <FontAwesomeIcon icon="calendar-alt" className="icon-primary" style={{ marginRight: '5px' }} /> {this.state.createdDate.slice(0, 10).split('-').reverse().join('/')}
                                </div>
                                <button className="detail-account-delete" onClick={this.deleteAccount} title="Eliminar cuenta">
                                    <FontAwesomeIcon icon="trash" />
                                </button>
                            </div>

                            <form className="detail-item detail-information-container" onSubmit={this.updateAccount} >
                                <TitleForm title="Datos de tu cuenta" iconName="user-alt"></TitleForm>
                                <br />
                                <div className="form-row">
                                    <div className="form-group">
                                        <label className="form-item form-label">
                                            Nombre Empresa / Negocio
                                        </label>
                                        <div className="form-item">
                                            <input type="text" required className="form-item form-value" defaultValue={this.state.companyName} name="companyName" onChange={this.inputChange} />
                                        </div>
                                    </div>
                                    <div className="form-group">
                                        <label className="form-item form-label">
                                            Correo
                                        </label>
                                        <div className="form-item">
                                            <input type="text" required className="form-item form-value" defaultValue={this.state.companyEmail} name="companyEmail" onChange={this.inputChange} />
                                        </div>
                                    </div>
                                </div>
                                <div className="form-row">
                                    <div className="form-group">
                                        <label className="form-item form-label">
                                            Número Telefono
                                        </label>
                                        <div className="form-item">
                                            <input type="text" required className="form-item form-value" defaultValue={this.state.companyPhoneNumber} name="companyPhoneNumber" onChange={this.inputChange} />
                                        </div>
                                    </div>
                                    <div className="form-group">
                                        <label className="form-item form-label">
                                            Contraseña
                                        </label>
                                        <div className="form-item">
                                            {
                                                this.state.showPassword
                                                    ? <input type="text" required className="form-item form-value" defaultValue={this.state.accountLoginPasswordDecrypt} name="accountLoginPasswordDecrypt" onChange={this.inputChange} />
                                                    : <input type="password" required className="form-item form-value" defaultValue={this.state.accountLoginPasswordDecrypt} name="accountLoginPasswordDecrypt" onChange={this.inputChange} />
                                            }
                                            <button type="button" className="show-password-button" onClick={this.showPassword}>
                                                <FontAwesomeIcon icon={iconPasswordButton} />
                                            </button>
                                        </div>
                                    </div>
                                </div>
                                <div className="form-group-buttons">
                                    <button type="button" className="form-secondary-button" title="Regresar" onClick={this.goBack}>
                                        <FontAwesomeIcon icon="times-circle" size="lg" style={{ paddingRight: '5' }} />Cancelar
                            </button>
                                    <button type="submit" className="form-primary-button" title="clic para guardar gasto">
                                        <FontAwesomeIcon icon="save" size="lg" style={{ paddingRight: '5' }} /> Guardar
                            </button>
                                </div>
                            </form>
                            {
                                <SnackBar ref={this.snackbarRef} />
                            }
                        </div>

                    </div>
        )
    }
}