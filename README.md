# livraria

Este projeto disponibiliza um sistema web que gerencia uma Livraria, possuindo funcionalidades de listagem, inclusão,
edição e exclusão de livros.

#Tecnologias:

c# 6.0
.NET Framework > 4.5
Entity Framework 6.0
Web API 2
Visual Studio 2015.
Arquitetura em camadas, a saber:

Biblios.Model: Entidades de negócio.
Biblios.Bl: Camada de regras de negócios. Aqui ocorre uso da camada de acesso ao database.
Biblios.Data: Camda que acessa o banco de dadaos. Nesta camada está instalado o Entity Framework.
Biblios.Api: Api que disponibiliza serviços para o cliente, neste caso o Web App Biblios. É no Web.config desse projeto que fica
a connectionstring.
Biblios.WebLivraria(2): Site que expõe a interface de gerenciamento da livraria.


#Como executar o projeto
 
 O Sistema Biblios é constituído de um site que consome uma API, portanto ao rodar o projeto no visual studio, deve-ser configurar
 O Multiple StartUp Projects para a Biblios.WebLivraria(2) e Biblios.Api. 

