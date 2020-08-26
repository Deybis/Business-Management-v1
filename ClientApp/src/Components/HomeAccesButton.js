import React, {Component} from 'react'
import PropTypes from 'prop-types'
import {Link} from 'react-router-dom'

export class HomeAccesButton extends Component{

    static propTypes = {
        title: PropTypes.string,
        alt: PropTypes.string,
        source: PropTypes.string,
        description: PropTypes.string,
        url: PropTypes.string
    }

    render(){

        const { title,alt,source,description,url} = this.props

        return(
            <Link to={url} className="panel-item-button">
                <div className="item-button-image">
                    <figure className="button-image-container">
                        <img  className="button-image"
                            src={source} 
                            alt={alt}/>
                    </figure> 
                </div>
                <div className="item-button-information">
                    <h2 className="button-title">
                        {title}
                    </h2>
                    <span className="button-description">
                        {description}
                    </span>
                </div>

            </Link>
        )
    }
}