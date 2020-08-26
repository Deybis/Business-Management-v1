import React from 'react'
import Verificated from '../Images/svg/verificated.svg'
import Logo from '../Images/logo-dark.png';
import NotResult from '../Images/svg/not-result.svg';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'

function ActivateAccountsContent(props) {
    return (
        <div className="activate-account-container">
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
                <div className="activate-account-content">
                    <div className="account-content-image">
                        {
                            props.accountActivate
                            ? <img src={Verificated} alt="cuenta verificada" />
                            : <img src={NotResult} alt="error verificación" />
                        }
                        
                    </div>
                    <div className="account-content-text">
                        <h2 className="account-content-title">{props.title}</h2>
                        {
                            props.accountActivate
                            ? <p className="account-content-description">Tu cuenta ha sido <strong className="highlight-verificated"> <FontAwesomeIcon icon="check-circle" size="lg" style={{ marginRight: '1' }} />  verificada </strong>, puedes ingresar utilizando tus credenciales.</p>
                            : <p className="account-content-description">Tu cuenta no se pudo verificar, vuelve a intentarlo.</p>
                        }                        
                        <a className="form-primary-button" href="/">{props.buttonText}</a>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default ActivateAccountsContent