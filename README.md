Para realizar o controle de tarefas, foi desenvolvida aplicação contendo cadastro de tarefas e status, baseando-se em estrutura de quadro utilizada pela metodologia kanban.
A aplicação possui front-end e back-end totalmente desacoplados, possuindo uma solução separada para desenvolvimento de cada camada.

_______________________________________________________________________________________________________________________________________________________________________________________

FRONT-END
_______________________________________________________________________________________________________________________________________________________________________________________

** Tecnologias utilizadas: Angular6, Angular Material, Bootstrap4
** Projeto disponível no diretório: ..\SuperoTasks-Presenter\supero-tasks-app

- Para executar o projeto executar console de comando e navegar até a raiz do diretório: cd supero-tasks-app;
- Executar o comando "npm install" para fazer o download dos pacotes necessários;
- Executar o comando "ng serve" para compilar a aplicação e levantar servidor local node;
- A aplicação estará disponível na url: http://localhost:4200
_______________________________________________________________________________________________________________________________________________________________________________________

BACK-END
_______________________________________________________________________________________________________________________________________________________________________________________

** Tecnologias utilizadas: ASP.NET Core WebAPI, Entity Framework 6, Arquitetura baseada em DDD
** Projeto disponível no diretório: ..\SuperoTasks-WebAPICore

** DATABASE
Banco de dados configurado para utilizar banco de dados embutido, localizado em ..\SuperoTasks-WebAPICore\SuperoTasks.WebAPICore.Data\App_Data

obs: 
- Se necessário alterar o banco de dados, executar os scripts de criação de banco disponíveis em: ..\SuperoTasks-WebAPICore\SuperoTasks.WebAPICore.Data\Scripts;
- Em seguida alterar o arquivo ..\SuperoTasks-WebAPICore\SuperoTasks.WebAPICore.Data\Context\SuperoTasksContext.cs, configurando o banco desejado.

** API
- Para executar o projeto abrir o arquivo da solution disponível no diretório: ..\SuperoTasks-WebAPICore\SuperoTasks-WebAPICore.sln;
- Compilar e rodar aplicação utilizando os menus ou atalho de teclas 'F5';
- A aplicação estará disponível na url: http://localhost:62824/
_______________________________________________________________________________________________________________________________________________________________________________________

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
