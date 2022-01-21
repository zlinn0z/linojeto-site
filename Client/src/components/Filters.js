import React from "react";
import filter from "../assets/icones/filters.svg";

export const Filters = () => {
    return (
        <div className="container-filter">
            <div className="title">
                <span>Filtros</span>
                <img src={filter} alt="Filtrar"/>
                <div className="form">
                    <div>
                        <label>Data Inicial:</label>
                        <input type="date"/>
                    </div>
                    <div>
                        <label>Data Final:</label>
                        <input type="date"/>
                    </div>
                    <div className="line" />
                    <div>
                        <label>Escolha:</label>
                        <select>
                            <option value={0}>Selecione...</option>
                            <option value={1}>Leska</option>
                            <option value={2}>Ned</option>
                        </select>
                    </div>
                </div>
            </div>
        </div>
    )
}