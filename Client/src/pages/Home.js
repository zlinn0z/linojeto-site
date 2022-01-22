import React from "react";
import { Filters } from "../components/Filters";
import { Header } from '../components/Header';
import { List } from '../components/List';
import { Footer } from "../components/Footer";

export const Home = props => {

    const sair = () => {
        localStorage.removeItem('accessToken');
        localStorage.removeItem('usuarioNome');
        localStorage.removeItem('usuarioEmail');
        props.setAccessToken('');
    }

    return(
        <>
            <Header sair={sair}/>
            <Filters />
            <List />
            <Footer />
        </>
    );
}