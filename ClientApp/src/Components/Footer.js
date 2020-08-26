import React from 'react'

function Footer(props) {
    let classFooter;
    props.fixed
    ? classFooter = "gn-footer gn-footer-fixed"
    : classFooter = "gn-footer"
    return(
        <footer className={classFooter}>
            <div className="gn-footer-item">
                © 2020 Seven Design todos los derechos reservados
            </div>
            <div className="gn-footer-item">
                <button type="button" className="gn-footer-button" title="clic para ver politicas de privacidad" >
                    Privacidad
                </button>
                <button type="button" className="gn-footer-button" title="clic para ver terminos y condiciones" >
                    Terminos & Condiciones
                </button>
            </div>
        </footer>
    )
}
export default Footer