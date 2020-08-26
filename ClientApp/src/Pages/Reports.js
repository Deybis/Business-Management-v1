import React, { Component } from 'react'
import { Loading } from '../Components/Loading'
import { TitleSection } from '../Components/TitleSection'
import { TitleForm } from '../Components/TitleForm'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import ReportChart from '../Components/ReportChart'

export class Reports extends Component {
    constructor(props) {
        super(props)
        document.title = 'Estadísticas - Gestión de Negocio'
        this.state = {
            data: [],
            day: 0,
            month: 0,
            year: 0,
            loading: true
        }
        this.inputChange = this.inputChange.bind(this)
        this.getData = this.getData.bind(this)
        this.goBack = this.goBack.bind(this);
    }

    inputChange(event) {
        this.setState({
            [event.target.name]: event.target.value
        })
    }
    componentDidMount() {
        this.getData()
    }

    getData() {
        let criteria = {
            "Day": parseInt(this.state.day),
            "Month": parseInt(this.state.month),
            "Year": parseInt(this.state.year)
        }
        fetch('Reports/GetData', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(criteria)
        })
        .then(response => {
            if (response.status === 401) { //response.redirected
                window.location.href = "/";//response.url
            }
            return response.json();
        })
        .then(report => {
            this.setState({
                data: report,
                loading: false
            })
        }).catch(error => {
            console.log(error.message)
        })
    }
    //Regresar a la página anterior
    goBack() {
        this.props.history.goBack();
    }
    render() {

        return (
            this.state.loading
                ? <Loading></Loading>
                : <section className="gn-area-container">
                    <TitleSection className="title-area" title="Estadísticas" />
                    <aside className="aside-area background-light padding-group border-radius-default box-shadow-default">
                        <TitleForm title="Filtros" iconName="filter"></TitleForm>
                        <div className="form-group margin-top">
                            <label className="form-item form-label">
                                Día
                        </label>
                            <div className="form-item">
                                <select className="form-value" name="day" onChange={this.inputChange}>
                                    <option value="0">Seleccione el día</option>
                                    <option value="1">01</option>
                                    <option value="2">02</option>
                                    <option value="3">03</option>
                                    <option value="4">04</option>
                                    <option value="5">05</option>
                                    <option value="6">06</option>
                                    <option value="7">07</option>
                                    <option value="8">08</option>
                                    <option value="9">09</option>
                                    <option value="10">10</option>
                                    <option value="11">11</option>
                                    <option value="12">12</option>
                                    <option value="13">13</option>
                                    <option value="14">14</option>
                                    <option value="15">15</option>
                                    <option value="16">16</option>
                                    <option value="17">17</option>
                                    <option value="18">18</option>
                                    <option value="19">19</option>
                                    <option value="20">20</option>
                                    <option value="21">21</option>
                                    <option value="22">22</option>
                                    <option value="23">23</option>
                                    <option value="24">24</option>
                                    <option value="25">25</option>
                                    <option value="26">26</option>
                                    <option value="27">27</option>
                                    <option value="28">28</option>
                                    <option value="29">29</option>
                                    <option value="30">30</option>
                                    <option value="31">31</option>
                                </select>
                            </div>
                        </div>
                        <div className="form-group">
                            <label className="form-item form-label">
                                Mes
                        </label>
                            <div className="form-item">
                                <select className="form-value" name="month" onChange={this.inputChange}>
                                    <option value="0">Seleccione el mes</option>
                                    <option value="1">Enero</option>
                                    <option value="2">Febrero</option>
                                    <option value="3">Marzo</option>
                                    <option value="4">Abril</option>
                                    <option value="5">Mayo</option>
                                    <option value="6">Junio</option>
                                    <option value="7">Julio</option>
                                    <option value="8">Agosto</option>
                                    <option value="9">Septiembre</option>
                                    <option value="10">Octubre</option>
                                    <option value="11">Noviembre</option>
                                    <option value="12">Diciembre</option>
                                </select>
                            </div>
                        </div>
                        <div className="form-group">
                            <label className="form-item form-label">
                                Año
                        </label>
                            <div className="form-item">
                                <select className="form-value" name="year" onChange={this.inputChange}>
                                    <option value="0">Seleccione el año</option>
                                    <option value="2018">2018</option>
                                    <option value="2019">2019</option>
                                    <option value="2020">2020</option>
                                    <option value="2021">2021</option>
                                    <option value="2022">2022</option>
                                    <option value="2023">2023</option>
                                </select>
                            </div>
                        </div>
                        <div className="form-group-buttons">
                            <button type="button" className="form-secondary-button" title="Regresar" onClick={this.goBack}>
                                <FontAwesomeIcon icon="times-circle" size="lg" style={{ paddingRight: '5' }} />Cancelar
                            </button>
                            <button type="submit" className="form-primary-button" title="clic para ver gráfico" onClick={this.getData}>
                                <FontAwesomeIcon icon="chart-pie" size="lg" style={{ paddingRight: '5' }} /> Mostrar
                            </button>
                        </div>
                    </aside>
                    <main className="main-area padding-group background-light border-radius-default box-shadow-default">
                        <ReportChart data={this.state.data} title={"Ingresos vrs Gastos"}></ReportChart>
                    </main>
                </section>

        )
    }
}