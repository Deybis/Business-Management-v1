import React, {Component} from 'react'
import NotFoundImage from '../Images/notfound.png'


export class NotFound extends Component {
    goBack(){
        window.history.back()
    }
    render(){
        return(
            <div className="viewport-container">
                <div className="viewport-center">
                    <div className="viewport-item-header">
                        Página no encontrada
                    </div>
                    <div className="viewport-item-image">
                        <img className="item-image" src={NotFoundImage} alt="404"/>
                    </div>
                    <div className="viewport-item-footer">
                        <button className="primary-button" onClick={this.goBack}>
                            Regresar
                        </button>
                    </div>
                </div>
            </div>
        )
    }
}