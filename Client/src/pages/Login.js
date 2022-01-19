import React, { useState } from "react";
import lock from "../assets/icones/lock.svg";
import user from "../assets/icones/user.svg";
import { Input } from "../components/Input.js";
import { executeReq } from "../services/api";


export const Login = props => {

    const [login, setLogin] = useState('');
    const [senha, setSenha] = useState('');
    const [msgError, setMsgError] = useState('');
    const [isLoading, setLoading] = useState(false);

    const executeLogin = async evento => {
        try {
            evento.preventDefault();
            setLoading(true);
        
            const body = {
                login, 
                senha
            };

            const resultado = await executeReq('login', 'POST', body);
            if(resultado?.data?.token){
                localStorage.setItem('accessToken', resultado.data.token);
                localStorage.setItem('usuarioNome', resultado.data.name);
                localStorage.setItem('usuarioEmail', resultado.data.email);
                props.setAccessToken(resultado.data.token);
            }
        }catch(e) {
            console.log(e);
            if(e?.response?.data?.error){
                setMsgError(e.response.data.error);
            }
        }
        setLoading(false);
    }

    return (
        <main className="container">
            <div>
                <h2>Login</h2>
                <form>
                    {msgError && <p>{msgError}</p>}
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