import React from "react";
import notItem from "../assets/icones/notFound.svg";

export const List = () => {
    return (
        <div className="container-list">
            <img src={notItem} alt="Nenhuma atividade encontrada"/>
            <p>Você não tem atividades para serem exibidas =(</p>
        </div>
    )
}