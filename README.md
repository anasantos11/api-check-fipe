# Check Fipe - API Web com ASP.NET Core 3.0

Criada uma API Web com ASP.NET Core com serviços para consultas de dados na tabela Fipe. 

Foram consumidos dados da [API de Consulta da Tabela Fipe](http://fipeapi.appspot.com/) e providos novos serviços para consultar marcas, modelos, anos e dados de um veículo específico na tabela Fipe. 
As consultas de um veículo em específico são armazenadas e, com isso, são providos dois outros serviços: um para visualizar as consultas realizadas e outro para saber os 3 veículos mais buscados. 

A API foi implantada no Microsoft Azure e pode ser acessada através deste [link](https://api-check-fipe.azurewebsites.net/swagger).

O projeto pode ser executado em sua máquina pelo Visual Studio Professional, Visual Studio Code e Visual Studio para Mac, conforme orientações desta [página](https://docs.microsoft.com/pt-br/aspnet/core/tutorials/first-web-api?view=aspnetcore-3.0&tabs=visual-studio) que foram resumidas no texto abaixo.

**Visual Studo Professional**

*Pré-requisitos*

  - Visual Studio 2019 com carga de trabalho ASP.NET e desenvolvimento Web
  - SDK do .NET Core 3,0 ou posterior
  
*Teste API*

  - Pressione CTRL+F5 para executar o aplicativo. O Visual Studio inicia um navegador e navega para https://localhost:<port>, em que <port> é um número de porta escolhido aleatoriamente. Altere a URL para https://localhost:<port>/swagger, para visualizar o documento do swagger.

  
**Visual Studio Code**

*Pré-requisitos*

  - Visual Studio Code
  - C# para Visual Studio Code (versão mais recente)
  - SDK do .NET Core 3,0 ou posterior
  
*Teste API*

  - Pressione CTRL+F5 para executar o aplicativo. Em um navegador, acesse a URL https://localhost:<port>/swagger para visualizar o documento do swagger.
  
**Visual Studio para Mac**

*Pré-requisitos*

  - Visual Studio para Mac versão 8.0 ou posterior
  - SDK do .NET Core 3,0 ou posterior
  
*Teste API*

  - Selecione Executar > Iniciar com Depuração para iniciar o aplicativo. O Visual Studio para Mac inicia um navegador e navega para https://localhost:<port>, em que <port> é um número de porta escolhido aleatoriamente. Altere a URL para https://localhost:<port>/swagger, para visualizar o documento do swagger.
