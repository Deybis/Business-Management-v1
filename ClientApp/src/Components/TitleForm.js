import React, {Component} from 'react'
import PropTypes from 'prop-types'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'

export class TitleForm extends Component{
    static propTypes = {
        title : PropTypes.string,
        iconName : PropTypes.string
    }
    render(){
        const {title} = this.props
        return(

            <div className="form-title-container">
                <div className="form-title-icon-container">
                <FontAwesomeIcon icon={this.props.iconName}  className="icon-primary" />
                </div>
                <h2 className="form-title" >
                    {title}
                </h2>
            </div>
        )
    }
}