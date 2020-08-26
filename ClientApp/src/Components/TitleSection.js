import React, {Component} from 'react'
import PropTypes from 'prop-types'

export class TitleSection extends Component{
    static propTypes = {
        title : PropTypes.string
    }
    render(){
        const {title} = this.props
        return(

            <div className="container-title-section">
                <h2 className="title-section" >
                    {title}
                </h2>
            </div>
        )
    }
}