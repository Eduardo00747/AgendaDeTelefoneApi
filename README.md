# AgendaDeTelefoneApi

## Objetivo do projeto

O objetivo deste projeto é criar uma API RESTful simples para gerenciar uma agenda de contatos telefônicos. A API permite realizar operações básicas de CRUD (Criar, Ler, Atualizar e Deletar) para os contatos.

## Tecnologias usadas

*   **.NET 8:** A mais recente versão do framework de desenvolvimento da Microsoft.
*   **ASP.NET Core:** Para a construção da Web API.
*   **Entity Framework Core:** Como ORM (Object-Relational Mapper) para a interação com o banco de dados.
*   **MySQL:** Banco de dados relacional utilizado para persistir os dados (via `Pomelo.EntityFrameworkCore.MySql`).
*   **Swagger (OpenAPI):** Para documentação e teste interativo dos endpoints da API.

## Funcionalidade do projeto

A API expõe os seguintes endpoints para manipulação de contatos:

*   `POST /Contato`: Cria um novo contato.
*   `GET /Contato/{id}`: Obtém um contato específico pelo seu ID.
*   `GET /Contato/ObterporNome?nome={nome}`: Busca contatos cujo nome contenha o termo pesquisado.
*   `PUT /Contato/{id}`: Atualiza as informações de um contato existente.
*   `DELETE /Contato/{id}`: Remove um contato da agenda.

O modelo de dados para um `Contato` é composto por:
*   `Id` (int): Identificador único.
*   `Nome` (string): Nome do contato.
*   `Telefone` (string): Número de telefone.
*   `Ativo` (bool): Indica se o contato está ativo ou não.

## Como utilizar o projeto localmente

Siga os passos abaixo para executar o projeto em sua máquina local.

1.  **Clone o repositório:**
    ```bash
    git clone https://github.com/seu-usuario/AgendaDeTelefoneApi.git
    cd AgendaDeTelefoneApi
    ```

2.  **Instale o .NET SDK:**
    Certifique-se de que você tem o [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) instalado.

3.  **Configure o Banco de Dados:**
    *   Abra o arquivo `MeuApp/appsettings.Development.json`.
    *   Altere a `DefaultConnection` para apontar para a sua instância do banco de dados MySQL.

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;Database=agenda_db;Uid=root;Pwd=sua_senha;"
      }
    }
    ```

4.  **Aplique as Migrations:**
    Execute o comando abaixo no terminal, dentro da pasta `MeuApp`, para criar as tabelas no banco de dados:
    ```bash
    dotnet ef database update
    ```

5.  **Execute a aplicação:**
    Ainda na pasta `MeuApp`, execute o comando:
    ```bash
    dotnet run
    ```

6.  **Acesse a API:**
    Abra seu navegador e acesse `https://localhost:<porta>/swagger` (a porta geralmente é `7000` ou similar, verifique o output do terminal). Você verá a interface do Swagger, onde poderá testar todos os endpoints.

## Estrutura do projeto

O projeto está organizado da seguinte forma:

```
AgendaDeTelefoneApi/
├── MeuApp/
│   ├── Controllers/
│   │   └── ContatoController.cs  # Onde ficam os endpoints da API.
│   ├── Context/
│   │   └── AgendaContexto.cs     # O DbContext do Entity Framework.
│   ├── Entity/
│   │   └── Contato.cs            # A classe que representa a entidade Contato.
│   ├── Migrations/               # Arquivos de migração do banco de dados.
│   ├── appsettings.json          # Arquivos de configuração.
│   └── Program.cs                # Ponto de entrada da aplicação, configuração de serviços.
└── MeuApp.sln                    # Solução do Visual Studio.
```

## Possíveis melhorias futuras

*   **Autenticação e Autorização:** Implementar um sistema de login (ex: JWT) para proteger os endpoints.
*   **Paginação:** Adicionar paginação na listagem de contatos para melhor performance com grandes volumes de dados.
*   **Validação de Dados:** Utilizar Data Annotations ou FluentValidation para validar os dados de entrada na criação e atualização de contatos.
*   **Testes:** Criar testes unitários e de integração para garantir a qualidade e a estabilidade do código.
*   **Containerização:** Adicionar um `Dockerfile` para permitir que a aplicação seja executada em containers Docker.
*   **Tratamento de Erros:** Implementar um middleware global para tratamento de exceções e retorno de mensagens de erro padronizadas.
