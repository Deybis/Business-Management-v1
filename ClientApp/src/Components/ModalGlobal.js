import React from 'react'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'

function ModalGlobal(props){

      let classCss = props.showModal === true
                  ? "modal-container show"
                  : "modal-container"

    return(
        <div className={classCss} >            
          <div className="modal-content">
            <h3 className="modal-title">
              {props.title}
            </h3>
            <div className="modal-container-buttons">
              <button onClick={() => props.closeModal()} className="form-secondary-button">
                <FontAwesomeIcon icon="times-circle"  size="lg" style={{ paddingRight: '5' }} /> Cerrar
              </button>
              <button onClick={()=> props.confirm(props.id)} className="form-primary-button">
                <FontAwesomeIcon icon="check-circle"  size="lg" style={{ paddingRight: '5' }} /> Aceptar
              </button>
            </div>
          </div> 
        </div>
    );    
}

export default ModalGlobal
