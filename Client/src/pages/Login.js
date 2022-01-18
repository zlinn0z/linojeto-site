import React, { useState } from "react";
import lock from "../assets/icones/lock.svg";
import user from "../assets/icones/user.svg";
import { Input } from "../components/Input.js";


export const Login = () => {

    const [login, setLogin] = useState('');
    const [senha, setSenha] = useState('');
    const [isLoading, setLoading] = useState(false);

    const executeLogin = evento => {
        evento.preventDefault();
        setLoading(true);
        console.log('login', login)
        console.log('senha', senha)

        setTimeout(() => {
            setLoading(false);
        }, 3000)
    }

    return (
        <main className="container">
            <div>
                <h2>Login</h2>
                <form action="">
                    <Input
                        srcImg={user}
                        altImg={"Ícone usuário"}
                        inputType="text"
                        inputName="login"
                        inputPlaceholder="Informe seu usuário"
                        value={login}
                        setValue={setLogin}
                    />
                    <Input
                        srcImg={lock}
                        altImg={"Ícone senha"}
                        inputType="password"
                        inputName="password"
                        inputPlaceholder="Informe sua senha"
                        value={senha}
                        setValue={setSenha}
                    />              
                    <button onClick={executeLogin} disabled={isLoading}>{isLoading === true ? '...Carregando' : 'Entrar'}</button>
                </form>
            </div>
            <div className="footer">
                <span>Ou conecte com as Redes Sociais</span>
                <div className="social-fields">
                    <div className="social-field twitter">
                        <a href="https://twitter.com/">
                            <i className="fab fa-twitter"></i>
                        Conecte-se com o Twitter
                        </a>
                    </div>
                    <div className="social-field facebook">
                        <a href="https://www.facebook.com/">
                            <i className="fab fa-facebook-f"></i>
                        Conecte-se com o Facebook
                        </a>
                    </div>
                </div>
            </div>
        </main>
    );
}