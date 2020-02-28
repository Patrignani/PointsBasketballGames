# README #

Aplicação para registro de pontos de jogo de basquete

### Configuração  (appsettings.json) ###

* Configuration > AutoMigration - valor booleano
    1. caso seja verdadeiro sempre que a aplicação se iniciar o EF core criará/ atualizará o banco. 

### API de requisição  ###

* O caminho base da APIs que serão consumidas pelo front-end se encontra no caminho:
    1. PointsBasketballGames.Web.App > app > utils > constants.js

### Iniciando a aplicação ###

* Execute simultaneamente os projetos:
    1. PointsBasketballGames.Web.App
    2. PointsBasketballGames.App

### IDE ###
* A aplicação está em .net core 3.1.
* Necessário ter visual studio 2019 ou visual code com o sdk 3.1.
