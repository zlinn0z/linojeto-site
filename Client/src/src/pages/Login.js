import React from "react";

export const Login = () => {
    return (
        <main className="container">
            <div>
                <h2>Login</h2>
                <form action="">
                    <div className="input-field">
                        <input type="text" name="login" placeholder="Informe seu usuário" />
                        <div className="underline"></div>
                    </div>
                    <div className="input-field">
                        <input type="password" name="password" placeholder="Informe sua senha" />
                        <div className="underline"></div>
                    </div>
                    
                    <button>Entrar</button>
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