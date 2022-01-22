import React from "react";


export const Footer = () => {
    return (
        <div className="footer">
            <button><span>+</span>Adicionar...</button>
            <span className="CR">© Copyright {new Date().getFullYear()} Lino's Corporation. Todos os direitos reservados.</span>
        </div>
    )
}