# Sistema de Gerenciamento de Tarefas

Este é um sistema simples de gerenciamento de tarefas, construído em ASP.NET Core. O sistema permite a criação, atualização, remoção e consulta de tarefas através de uma API RESTful.

## Resumo

Esta documentação fornece uma visão abrangente de como configurar o ambiente de desenvolvimento, executar testes, criar o banco de dados e executar o projeto utilizando o Visual Studio. Certifique-se de adaptar as instruções e descrições conforme necessário para corresponder ao seu projeto específico.

## Executando os Testes

Os testes unitários para a API estão localizados na pasta `Tests` do projeto. Eles são implementados usando NUnit e Moq para mocks de serviços.

### No Visual Studio

1. Abra o Test Explorer ou Explorador de Teste.
2. Clique em "Run All" ou "Executar" para executar todos os testes unitários.

### No via linha de comando

Abra o Console do Gerenciado de Pacotes (`Aba Ferramentas > Gerenciador de Pacotes do NuGet > Console do Gerenciado de Pacotes`) e use o comando abaixo no terminal integrado para executar todos os testes.
```
dotnet test
```

## Testes Implementados

### TaskController

A `TaskController` gerencia operações CRUD para tarefas usando métodos HTTP padrão (GET, POST, PUT, DELETE). Abaixo estão os testes implementados na `TaskControllerTest` para validar o comportamento da `TaskController`:

- **Obter todas as tarefas (`GetAll`):**
  - Verifica se todas as tarefas são retornadas com sucesso.
  - Verifica o código de status `200 OK`.

- **Obter tarefa por ID (`GetById`):**
  - Verifica se uma tarefa específica é retornada corretamente quando buscada pelo ID.
  - Verifica o código de status `200 OK`.
  - Verifica o retorno `404 Not Found` se a tarefa não existe.

- **Obter estado da tarefa por ID (`GetState`):**
  - Verifica se o estado atual de uma tarefa é retornado corretamente quando solicitado pelo seu ID.
  - Verifica o código de status `200 OK` quando a tarefa é encontrada e seu estado é retornado.
  - Verifica o código de status `404 Not Found` se a tarefa não puder ser encontrada com o ID fornecido.

- **Criar nova tarefa (`Post`):**
  - Verifica se uma nova tarefa pode ser criada corretamente.
  - Verifica o código de status `201 Created` e a rota de redirecionamento.

- **Atualizar tarefa (`Put`):**
  - Verifica se uma tarefa existente pode ser atualizada com sucesso.
  - Verifica o código de status `200 OK`.
  - Verifica o retorno de `400 Bad Request` se a tarefa não pode ser atualizada.

- **Mover tarefa para "Em Progresso" (`InProgress`):**
  - Verifica se uma tarefa pode ser movida para o estado "Em Progresso".
  - Verifica o código de status `200 OK`.
  - Verifica o retorno de `400 Bad Request` se a operação não for permitida.

- **Concluir tarefa (`Concluded`):**
  - Verifica se uma tarefa pode ser movida para o estado "Concluído".
  - Verifica o código de status `200 OK`.
  - Verifica o retorno de `400 Bad Request` se a operação não for permitida.

- **Cancelar tarefa (`Canceled`):**
  - Verifica se uma tarefa pode ser cancelada.
  - Verifica o código de status `200 OK`.
  - Verifica o retorno de `400 Bad Request` se a operação não for permitida.

- **Remover tarefa (`Remove`):**
  - Verifica se uma tarefa pode ser removida do sistema.
  - Verifica o código de status `200 OK`.
  - Verifica o retorno de `404 Not Found` se a tarefa não existir ou não puder ser removida.

## Executando o Projeto

### Criando o Banco de Dados

1. Abra o Console do Gerenciado de Pacotes (`Aba Ferramentas > Gerenciador de Pacotes do NuGet > Console do Gerenciado de Pacotes`).
2. Execute o comando abaixo para criar o Banco de Dados.
```
update-database
```

### Criando o Banco de Dados

1. Abra o Console do Gerenciado de Pacotes (`Aba Ferramentas > Gerenciador de Pacotes do NuGet > Console do Gerenciado de Pacotes`).
2. Execute o comando abaixo para criar o Banco de Dados.
```
update-database
```

## Executar a Solução

1. Clique no botão run com o nome "https". O Visual Studio irá executar a solução e abrir o Swagger em um navegador.

## Conclusão

Agradeço por sua presença.
