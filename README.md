# Auth API

## About the Project

The **Auth API** is a study project that implements a complete authentication and authorization system using **ASP.NET Core**. The main goal is to document the learning journey and progress within the .NET ecosystem, showcasing the development of a robust security system with features such as user registration, login with **JSON Web Tokens (JWT)**, and policy-based access control.

The application was developed using **.NET 8** and adheres to best architectural practices, including the use of **DTOs (Data Transfer Objects)**, dependency injection, object mapping with **AutoMapper**, and identity management with **ASP.NET Core Identity**. To simplify setup and ensure accessibility, the project is fully containerized with **Docker** and **Docker Compose**.

## Features

The API implements a complete authentication and authorization flow, including:

### Authentication (`/api/auth`):
- **User Registration** (`/register`): Allows new users to register by providing a username, password, and date of birth.
- **User Login** (`/login`): Authenticates users and returns a JWT token for accessing protected routes.

### Access Control (`/api/access`):
- **Public Endpoint** (`/public`): A freely accessible route for any user, authenticated or not.
- **Private Endpoint** (`/private`): A protected route that can only be accessed by authenticated users who meet a custom authorization policy. In this case, the "AtLeast18" policy requires the user to be at least 18 years old.

## Technologies Used

- **Backend**: .NET 8
- **Framework**: ASP.NET Core Web API
- **Database**: MySQL 8.0
- **ORM**: Entity Framework Core
- **Identity Management**: ASP.NET Core Identity
- **Authentication**: JSON Web Tokens (JWT)
- **Object Mapping**: AutoMapper
- **Containerization**: Docker and Docker Compose
- **API Documentation**: Swagger (OpenAPI)

## Prerequisites

- **.NET 8 SDK** (for local execution without Docker)
- **Docker** and **Docker Compose** (recommended method)

## How to Run (with Docker)

The easiest and recommended way to run the project is using Docker.

1. **Clone the repository**:
   ```bash
   git clone <YOUR_REPOSITORY_URL>
   cd auth-api
   ```

2. **Run Docker Compose**:
   In the project root folder, execute the following command. It will build the API image, download the MySQL image, and start both containers in a dedicated network.
   ```bash
   docker-compose up --build
   ```
   The `--build` parameter ensures the API image is always built from the latest Dockerfile.

3. **Access the API**:
   - The API will be available at: `http://localhost:5092`
   - The interactive Swagger UI documentation will be available at: `http://localhost:5092/swagger`

The `docker-compose.yaml` also configures a volume for the database, ensuring data persistence between executions. **Entity Framework** migrations are applied automatically when the application starts, setting up the database without manual intervention.

## How to Run (Locally, without Docker)

If you prefer to run the application directly on your machine, follow the steps below.

1. **Clone the repository**:
   ```bash
   git clone <YOUR_REPOSITORY_URL>
   cd auth-api
   ```

2. **Set up a MySQL instance**:
   - Ensure you have a MySQL server running.
   - Create a database (schema) named `usersdb`.

3. **Configure User Secrets**:
   To keep your credentials secure, this project uses **User Secrets**. Open a terminal in the project folder and run the following commands, replacing the example values:
   ```bash
   dotnet user-secrets set "ConnectionStrings:UserConnection" "server=localhost;database=usersdb;user=root;password=YOUR_PASSWORD_HERE"
   dotnet user-secrets set "SymetricSecurityKey" "YOUR_SUPER_SECRET_KEY_HERE"
   ```

4. **Apply Database Migrations**:
   Navigate to the project folder in the terminal and run the **dotnet-ef** CLI command to create the database tables.
   ```bash
   dotnet ef database update
   ```

5. **Run the Application**:
   ```bash
   dotnet run
   ```

6. **Access the API**:
   - The API will be available at: `http://localhost:5092`
   - The Swagger UI documentation will be available at: `http://localhost:5092/swagger`

## API Endpoints

Below are the main endpoints available for interaction. For more details and to test the API, refer to the Swagger documentation.

| Method | Route                    | Description                                                              |
|--------|--------------------------|--------------------------------------------------------------------------|
| POST   | `/api/auth/register`     | Registers a new user.                                                    |
| POST   | `/api/auth/login`        | Authenticates a user and returns a JWT token.                            |
| GET    | `/api/access/public`     | Public endpoint that does not require authentication.                     |
| GET    | `/api/access/private`    | Private endpoint that requires authentication and a minimum age of 18.    |

# Auth API

## Sobre o Projeto

O **Auth API** é um projeto de estudo que implementa um sistema de autenticação e autorização completo utilizando **ASP.NET Core**. O objetivo principal é documentar a jornada de aprendizado e evolução com o ecossistema .NET, demonstrando a construção de um sistema de segurança robusto com funcionalidades como registro, login com **JSON Web Tokens (JWT)** e controle de acesso baseado em políticas customizadas.

A aplicação foi desenvolvida utilizando **.NET 8** e segue as melhores práticas de arquitetura, como o uso de **DTOs (Data Transfer Objects)**, injeção de dependência, mapeamento de objetos com **AutoMapper** e gerenciamento de identidade com **ASP.NET Core Identity**. Para facilitar o setup e a acessibilidade, o projeto foi totalmente containerizado com **Docker** e **Docker Compose**.

## Funcionalidades

A API implementa um fluxo completo de autenticação e autorização, incluindo:

### Autenticação (`/api/auth`):
- **Registro de Usuários** (`/register`): Permite que novos usuários se cadastrem fornecendo um nome de usuário, senha e data de nascimento.
- **Login de Usuários** (`/login`): Autenticação de usuários que retorna um token JWT para acesso a rotas protegidas.

### Controle de Acesso (`/api/access`):
- **Endpoint Público** (`/public`): Uma rota de acesso livre para qualquer usuário, autenticado ou não.
- **Endpoint Privado** (`/private`): Uma rota protegida que só pode ser acessada por usuários autenticados e que atendam a uma política de autorização customizada. Neste caso, a política "AtLeast18" exige que o usuário tenha no mínimo 18 anos de idade.

## Tecnologias Utilizadas

- **Backend**: .NET 8
- **Framework**: ASP.NET Core Web API
- **Banco de Dados**: MySQL 8.0
- **ORM**: Entity Framework Core
- **Gerenciamento de Identidade**: ASP.NET Core Identity
- **Autenticação**: JSON Web Tokens (JWT)
- **Mapeamento de Objetos**: AutoMapper
- **Containerização**: Docker e Docker Compose
- **Documentação da API**: Swagger (OpenAPI)

## Pré-requisitos

- **.NET 8 SDK** (para execução local sem Docker)
- **Docker** e **Docker Compose** (método recomendado)

## Como Executar (com Docker)

A maneira mais simples e recomendada de executar o projeto é utilizando Docker.

1. **Clone o repositório**:
   ```bash
   git clone <URL_DO_SEU_REPOSITORIO>
   cd auth-api
   ```

2. **Execute o Docker Compose**:
   Na pasta raiz do projeto, execute o comando abaixo. Ele irá construir a imagem da API, baixar a imagem do MySQL e iniciar os dois contêineres em uma rede dedicada.
   ```bash
   docker-compose up --build
   ```
   O parâmetro `--build` garante que a imagem da API seja sempre construída a partir do Dockerfile mais recente.

3. **Acesse a API**:
   - A API estará disponível em: `http://localhost:5092`
   - A documentação interativa do Swagger UI estará disponível em: `http://localhost:5092/swagger`

O `docker-compose.yaml` também configura um volume para o banco de dados, garantindo que os dados persistam entre as execuções. As migrações do **Entity Framework** são aplicadas automaticamente assim que a aplicação inicia, configurando o banco de dados sem necessidade de intervenção manual.

## Como Executar (Localmente, sem Docker)

Se preferir rodar a aplicação diretamente na sua máquina, siga os passos abaixo.

1. **Clone o repositório**:
   ```bash
   git clone <URL_DO_SEU_REPOSITORIO>
   cd auth-api
   ```

2. **Configure uma instância do MySQL**:
   - Certifique-se de que você tem um servidor MySQL em execução.
   - Crie um banco de dados (schema) chamado `usersdb`.

3. **Configure os User Secrets**:
   Para manter suas credenciais seguras, este projeto utiliza **User Secrets**. Abra o terminal na pasta do projeto e execute os comandos abaixo, substituindo os valores de exemplo:
   ```bash
   dotnet user-secrets set "ConnectionStrings:UserConnection" "server=localhost;database=usersdb;user=root;password=SUA_SENHA_AQUI"
   dotnet user-secrets set "SymetricSecurityKey" "SUA_CHAVE_SECRETA_SUPER_SECRETA_AQUI"
   ```

4. **Aplique as Migrações do Banco de Dados**:
   Navegue até a pasta do projeto no terminal e execute o comando da CLI do **dotnet-ef** para criar as tabelas.
   ```bash
   dotnet ef database update
   ```

5. **Execute a Aplicação**:
   ```bash
   dotnet run
   ```

6. **Acesse a API**:
   - A API estará disponível em: `http://localhost:5092`
   - A documentação do Swagger UI estará disponível em: `http://localhost:5092/swagger`

## Endpoints da API

Abaixo estão os principais endpoints disponíveis para interação. Para mais detalhes e para testar a API, consulte a documentação do Swagger.

| Método | Rota                     | Descrição                                                                 |
|--------|--------------------------|---------------------------------------------------------------------------|
| POST   | `/api/auth/register`     | Realiza o cadastro de um novo usuário.                                     |
| POST   | `/api/auth/login`        | Autentica um usuário e retorna um token JWT.                               |
| GET    | `/api/access/public`     | Endpoint público que não requer autenticação.                              |
| GET    | `/api/access/private`    | Endpoint privado que requer autenticação e idade mínima de 18 anos.        |