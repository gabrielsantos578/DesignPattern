# Sistema de Gerenciamento de Tarefas

Este é um sistema simples de gerenciamento de tarefas, construído usando ASP.NET Core. O sistema permite a criação, atualização, remoção e consulta de tarefas através de uma API RESTful.

## Executando os Testes

Os testes unitários para a API estão localizados na pasta `Tests` do projeto. Eles são implementados usando NUnit e Moq para mocks de serviços.

### No Visual Studio

1. Abra o Test Explorer.
2. Clique em "Run All" para executar todos os testes unitários.

### No Visual Studio Code ou via linha de comando

Use `dotnet test` no terminal integrado para executar todos os testes.

## Testes Implementados

### TaskController

A `TaskController` gerencia operações CRUD para tarefas usando métodos HTTP padrão (GET, POST, PUT, DELETE). Abaixo estão os testes implementados para validar o comportamento da `TaskController`:

- **Obter todas as tarefas (`GetAll`):**
  - Verifica se todas as tarefas são retornadas com sucesso.
  - Verifica o código de status `200 OK`.

- **Obter tarefa por ID (`GetById`):**
  - Verifica se uma tarefa específica é retornada corretamente quando buscada pelo ID.
  - Verifica o código de status `200 OK`.
  - Verifica o retorno `404 Not Found` se a tarefa não existe.

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

Esta documentação fornece uma visão geral clara de como configurar o ambiente de desenvolvimento, executar os testes e descreve os testes específicos implementados para cada operação na `TaskController`. Certifique-se de adaptar as instruções e descrições conforme necessário para corresponder ao seu projeto específico.
