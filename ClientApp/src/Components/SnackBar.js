import React,{Component} from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'

export class SnackBar extends Component{

    state = {
        isActive: false
    }     

    openSnackBar = (type,message) => {
        this.message = message
        this.type = type
        this.setState({ isActive: true }, () => {
          setTimeout(() => {
            this.setState({ isActive: false });
          }, 5000);
        });
    }
    
    render() {
        const { isActive } = this.state;
        let icon = ""
        let color = ""
        switch (this.type) {
            case "success":
                icon =  'check-circle'
                color= '#1EC88D'
                break;
            case "caution":
                icon =  'exclamation-triangle'
                color= '#FDC719'
                break;
            default:
                icon =  'times-circle'
                color= '#FE5B5B'
                break;
        }
        return (         
            <div className={ isActive ? "snackbar show" : "snackbar"}>
                <div className="snackbar-icon">
                    <FontAwesomeIcon icon={icon} size="lg" style={{ color:''+ color +''}}/>
                </div>
                {this.message}
            </div>           
        )
    }  
}
