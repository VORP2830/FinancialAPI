# Documentação da API de Controle Financeiro

Esta é a documentação da API de Controle Financeiro, desenvolvida para ajudar os usuários a gerenciar suas finanças pessoais. A API oferece as seguintes funcionalidades:

## Funcionalidades

1. **Criação de Movimentação**
   - Permite ao usuário criar movimentações, sejam elas receitas ou despesas.

2. **Atualização de Movimentação**
   - Permite ao usuário atualizar informações de uma movimentação existente.

3. **Exclusão de Movimentação**
   - Permite ao usuário excluir uma movimentação existente.

4. **Listagem de Movimentações**
   - Permite ao usuário listar movimentações, com a capacidade de aplicar filtros por data.

5. **Exibição do Saldo**
   - Permite ao usuário visualizar seu saldo atual.

6. **Cadastro de Usuário**
   - Permite ao usuário se cadastrar na aplicação.

7. **Login**
   - Permite ao usuário fazer login na aplicação.

## Requisitos

A API atende aos seguintes requisitos:

- Filtro na listagem de movimentações por data (data inicial e data final).
- Paginação na listagem de movimentações.
- Arquitetura minimamente escalável.
- Cobertura mínima de testes automatizados.
- Autenticação:
  - Cadastro de usuário.
  - Login.
  - Necessidade do usuário estar autenticado para a realização das atividades citadas no contexto.
- Dockerizar a aplicação.

## Endpoints

### Health Controller

Endpoint para verificar a saúde da aplicação.

- **GET /api/health**

### Movement Controller

Controller responsável pelas operações relacionadas a movimentações financeiras.

- **GET /api/movement**
  - Listar todas as movimentações com opções de filtro e paginação.

- **GET /api/movement/{id}**
  - Obter detalhes de uma movimentação específica.

- **GET /api/movement/GetBalance**
  - Obter o saldo atual do usuário.

- **POST /api/movement**
  - Criar uma nova movimentação.

- **PUT /api/movement**
  - Atualizar uma movimentação existente.

- **DELETE /api/movement/{id}**
  - Excluir uma movimentação.

### User Controller

Controller responsável pelas operações relacionadas aos usuários.

- **POST /api/user/Register**
  - Cadastrar um novo usuário.

- **POST /api/user/Login**
  - Realizar login na aplicação.

- **GET /api/user**
  - Obter informações do usuário autenticado.

- **PUT /api/user**
  - Atualizar informações do usuário autenticado.

## Modelos de Dados

### MovementDTO

Modelo de dados para representar uma movimentação financeira.

- `Id` (long): Identificador único da movimentação.
- `Description` (string): Descrição da movimentação.
- `PaymentDate` (DateTime): Data da movimentação.
- `CharPaymentType` (string): Tipo de pagamento.
- `Value` (double): Valor da movimentação.

### UserDTO

Modelo de dados para representar um usuário.

- `Id` (long): Identificador único do usuário.
- `Name` (string): Nome do usuário.
- `UserName` (string): Nome de usuário para login.
- `Password` (string): Senha do usuário (senha vazia no cadastro).

### UserLoginDTO

Modelo de dados para representar informações de login de um usuário.

- `UserName` (string): Nome de usuário para login.
- `Password` (string): Senha do usuário.

## Exemplos de Uso

Aqui estão alguns exemplos de como usar os endpoints da API:

- **Cadastro de Usuário:**
  ```
  POST /api/user/Register
  {
    "Name": "John Doe",
    "UserName": "johndoe",
    "Password": "password123"
  }
  ```

- **Login:**
  ```
  POST /api/user/Login
  {
    "UserName": "johndoe",
    "Password": "password123"
  }
  ```

- **Listar Todas as Movimentações:**
  ```
  GET /api/movement
  ```

- **Criar uma Nova Movimentação:**
  ```
  POST /api/movement
  {
    "Description": "Salário",
    "PaymentDate": "2023-11-05",
    "CharPaymentType": "R",
    "Value": 3000.0
  }
  ```

- **Atualizar uma Movimentação:**
  ```
  PUT /api/movement
  {
    "Id": 1,
    "Description": "Novo Salário",
    "PaymentDate": "2023-11-10",
    "CharPaymentType": "D",
    "Value": 3500.0
  }
  ```

- **Excluir uma Movimentação:**
  ```
  DELETE /api/movement/1
  ```

- **Obter Saldo Atual:**
  ```
  GET /api/movement/GetBalance
  ```

Lembre-se de autenticar-se corretamente para acessar as funcionalidades restritas.