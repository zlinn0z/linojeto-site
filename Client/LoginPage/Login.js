function accessAccount(){
    var nome = document.getElementById('username').value
    var senha = document.getElementById('password').value

    if(nome == "" && senha == ""){
        alert('Nossa, digita alguma coisa ae 4Head!')
    } else if (nome != "" && senha == ""){
        alert('Faltou uma senha ae, não?')  
    } else if (nome == "" && senha != ""){
        alert('Quem tem a Kappacidade de não digitar um user?')
    } else {
        switch(nome){
            case "LeskaGamer":
                alert('Olha só se não é a Amiga da Vizinhança!')
                break;
            case "NedStark15":
                alert('A melhor Lux desse Braseeel entrou!')
                break;
            case "cftrplayer":
                alert('DEEEEEUS CFTR HandsUp!')
                break;
            case 'k4rui':
                alert('Parabéns, você acabou de derrubar o site por 600 segundos!')
                break;
            default:
                alert('Seja bem-vindo(a) ao Linojeto!')
        }

        location.href = "../HomePage/HomePage.html" 
    } 
}