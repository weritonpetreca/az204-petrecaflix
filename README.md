# PetrecaFlix

O PetrecaFlix é uma aplicação baseada em arquitetura serverless utilizando Azure Functions para gerenciar um catálogo de filmes.

## Visão Geral

Este projeto consiste em uma API simples para realizar operações CRUD (Criar, Ler, Atualizar, Deletar) em um catálogo de filmes, além de uma interface de frontend para interagir com a API.

## Funcionalidades (Azure Functions)

A aplicação é composta pelas seguintes Azure Functions:

- **`fnGetAllMovies`**:
  - **Descrição:** Retorna uma lista de todos os filmes cadastrados.
  - **Endpoint (Exemplo):** `GET /api/movies`

- **`fnGetMovieDetail`**:
  - **Descrição:** Retorna os detalhes de um filme específico com base em seu ID.
  - **Endpoint (Exemplo):** `GET /api/movies/{id}`

- **`fnPostDatabase`**:
  - **Descrição:** Adiciona um novo filme ao banco de dados.
  - **Endpoint (Exemplo):** `POST /api/movies`

- **`fnPostDataStorage`**:
  - **Descrição:** Realiza o upload de arquivos ou dados (como imagens de pôsteres de filmes) para um serviço de armazenamento (Azure Blob Storage).
  - **Endpoint (Exemplo):** `POST /api/storage/upload`

## Frontend

- **`front/index.html`**: Uma página web estática simples que serve como interface para consumir as Azure Functions, permitindo visualizar a lista de filmes, ver detalhes e, possivelmente, adicionar novos filmes.

## Tecnologias Utilizadas

- **Backend:**
  - C#
  - .NET 8
  - Azure Functions
- **Frontend:**
  - HTML
- **Cloud:**
  - Microsoft Azure (Functions, Storage, etc.)

## Como Executar

1.  **Pré-requisitos:**
    - [.NET SDK](https://dotnet.microsoft.com/download)
    - [Azure Functions Core Tools](https://github.com/Azure/azure-functions-core-tools)
    - Conta do Azure com as configurações de armazenamento e banco de dados necessárias.

2.  **Configuração:**
    - Clone o repositório.
    - Configure as strings de conexão e outras variáveis de ambiente nos arquivos `local.settings.json` de cada projeto de função.

3.  **Execução:**
    - Navegue até a pasta de cada função (ex: `fnGetAllMovies/`) e execute o comando `func start` para iniciar o host local das Azure Functions.
    - Abra o arquivo `front/index.html` em um navegador para interagir com a aplicação.
