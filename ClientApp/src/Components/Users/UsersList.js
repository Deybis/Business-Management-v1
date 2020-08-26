import React, {Component} from 'react'
import PropTypes from 'prop-types'
import { User } from '../Users/User'
import {TitleSection} from '../TitleSection'
import { Link } from 'react-router-dom'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import ModalGlobal from "../ModalGlobal"
import {SnackBar} from '../SnackBar';

export class UsersList extends Component{

    constructor(props){
        super(props)
        this.state = {
            showModal: false,
            userID:0,
        }
        this.showModal =  this.showModal.bind(this)
        this.closeModal =  this.closeModal.bind(this)
        this.confirm =  this.confirm.bind(this)
    }

    //Referencia para el componente que muestra los mensajes
    snackbarRef = React.createRef();

    static propTypes = {
      users: PropTypes.array
    }

    showModal(id){
        this.setState({
            showModal:true,
            userID : id
        })      
    }

    closeModal() {
        this.setState({
            showModal: false,
        });
    }

    confirm(id){
        fetch(`Users/Delete/?id=${id}`)
        .then(res => res.json())
        .then(user => {
            this.setState({
                showModal: false,
            });
            this.snackbarRef.current.openSnackBar('success','Usuario Eliminado');
            this.props.refresh()
         }).catch(error => {
            this.snackbarRef.current.openSnackBar('','Hubo un error inesperado,no se pudo eliminar');
        });
    }

    render(){
        const { users } = this.props

        return(
            <div className="user-main-container">
                <div className="header-section">
                    <TitleSection title="Usuarios"/>
                    <div className="header-item">                    
                        <div className="header-information">
                            <span>Total Usuarios</span><span className="header-badge header-badge-default">{users.length}</span>
                        </div>
                        <Link className="primary-button" title="clic para agregar usuario" to={`/UserDetail/${this.state.userID}`}>
                            <FontAwesomeIcon icon="plus" size="lg" style={{ paddingRight: '5' }} /> Agregar usuario
                        </Link>
                    </div>
                </div>

                <div className="user-list">
                {
                    users.map(user =>{
                        return (
                            <div key={user.userID} className="card-users-item">
                                <User     
                                    userID={user.userID}                      
                                    userName={user.userName}  
                                    userLogin={user.userLogin}
                                    userImage={user.userImage}
                                    genderID={user.genderID}
                                    showModal={this.showModal}
                                />
                            </div>  
                        ) 
                    })                  
                }
                </div>
              <ModalGlobal id={this.state.userID} title="¿Desea eliminar este usuario?" showModal={this.state.showModal} closeModal={this.closeModal} confirm={this.confirm} ></ModalGlobal>    
              {
                <SnackBar ref = {this.snackbarRef}/>
              }  
            </div>
        )
    }
}