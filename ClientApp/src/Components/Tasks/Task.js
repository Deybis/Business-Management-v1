import React, { Component } from 'react'
import { Link } from 'react-router-dom'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'

export class Task extends Component {

  render() {
    return (
      <div id={this.props.taskID} className="panel-list-item">
        <div className="panel-list-icon">
          <FontAwesomeIcon icon="check-circle" size="lg" />
        </div>
        <div className="panel-list-text">
          <div className="panel-list-value">
            {this.props.taskName}
          </div>
          <div className="panel-list-value">
            <FontAwesomeIcon className="icon-primary" icon="calendar-alt" style={{ marginRight: '3' }} /> {this.props.taskDate.slice(0, 10).split('-').reverse().join('/')}
          </div>
        </div>
        <div className="panel-badge">
          {this.props.taskStatusName}
        </div>
        {
          this.props.showButtons
            ? <div className="panel-list-button-container">
              <Link className="card-user-button" title="clic para editar tarea" to={`/TaskDetail/${this.props.taskID}`}>
                <FontAwesomeIcon icon="pencil-alt" size="sm" style={{ color: 'steelblue' }} />
              </Link>
              <button title="clic para eliminar tarea" className="card-user-button" onClick={() => { this.props.showModal(this.props.taskID) }}>
                <FontAwesomeIcon icon="trash" size="sm" style={{ color: 'tomato' }} />
              </button>
            </div>
            : ""
        }
      </div>
    )
  }
}