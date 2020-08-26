import React, {Component} from 'react'
import PropTypes from 'prop-types'
import Search from '../Images/svg/not-result.svg'

export class NotResult extends Component{
    static propTypes = {
        description: PropTypes.string
    }
    render(){
        const { description } = this.props
        return(
            <div className="result-container">
                <div className="result-content">               
                    <div className="result-image-container">
                        <img className="result-image" src={Search} alt="search-result"/> 
                    </div>
                    <div className="result-information">
                        NO SE ENCONTRÓ {description}  
                    </div>  
                </div>   
            </div>
        )
    }
}