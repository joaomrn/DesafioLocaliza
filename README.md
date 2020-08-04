# DesafioLocaliza
Projeto desenvolvido para o desavio da Localiza

Foi feito uma api e uma aplicação web.

Na controller HomeController, foi implementado o metodo Calcular para obter os divisores e os numeros primos. Foi utilizado o RestCharppara consumir a api,
assim observar qual a porta a api esta sendo instanciada e se necessario alterar a porta no construtor da classe RestClient, conforme o exemplo abaixo:


var client = new RestClient("https://localhost:{Porta}/api/");
