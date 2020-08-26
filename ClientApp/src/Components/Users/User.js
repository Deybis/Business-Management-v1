import React, {Component} from "react"
import PropTypes from 'prop-types'
import { Link } from 'react-router-dom'
import UserAvatarM from '../../Images/svg/user-avatar-m.svg'
import UserAvatarF from '../../Images/svg/user-avatar-f.svg'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'


export class User extends Component{

    static propTypes = {
        userID : PropTypes.number,
        userName : PropTypes.string,
        userLogin : PropTypes.string,
        genderID : PropTypes.number,
        createdDate : PropTypes.string
    }
    
    render(){
        const {userID,userName,userLogin,genderID} = this.props      

        return(
            <div>
                <div className="card-user">
                    <div className="card-user-image-container">
                        {
                            genderID === 1
                            ?<img  className="card-user-image" src={UserAvatarM} alt={userName}/> 
                            :<img  className="card-user-image" src={UserAvatarF} alt={userName}/> 
                        }              
                    </div>
                    <div className="card-user-information">
                        <div className="card-user-item card-user-name">{userName}</div>
                        <div className="card-user-item">
                            <span className="card-user-badge">{userLogin}</span>
                        </div>
                    </div>
                    <div className="card-user-button-container">
                        <Link className="card-user-button" title="clic para editar usuario" to={`/UserDetail/${userID}`}>
                            <FontAwesomeIcon icon="pencil-alt" size="sm" style={{ color: 'steelblue' }} />
                        </Link>
                        <button className="card-user-button" onClick={() =>{this.props.showModal(this.props.userID)}}>
                            <FontAwesomeIcon icon="trash" size="sm" style={{ color: 'tomato' }} />
                        </button>
                        
                    </div>
                </div>
              
            </div>
        )
    }

}