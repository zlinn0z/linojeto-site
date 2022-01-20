import React from "react";
import exit from "../assets/icones/exit.svg";
//import sairDesktop from '../assets/icones/sairDesktop.svg';

export const Header = props => {

    const nameComplete = localStorage.getItem('usuarioNome');
    const firstName = nameComplete.split(' ')[0] || '';

    return (
        <div className="container-header">
            <h2>LINOJETO</h2>
            <button><span>+</span>Teste Botão</button>
            <div className="mobile">
                <span>{'Olá, ' + firstName}</span>
                <img src={exit} alt="Deslogar" onClick={props.sair}/>
            </div> 
            <div className="desktop">
                <span>{'Olá, ' + firstName}</span>
                <img src={exit} alt="Deslogar" onClick={props.sair}/>
            </div> 
        </div>
    )
}