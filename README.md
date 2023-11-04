## Contexto

Um estudante a fim de poupar gastos e controlar suas finanças pessoais resolveu desenvolver um aplicativo para lhe ajudar nessa missão. Após um estudo de caso ele mapeou as seguintes funcionalidades:

- Criação da movimentação (receitas e despesas);
- Atualização da movimentação;
- Exclusão da movimentação;
- Listagem de movimentações;
- Exibição do saldo.

## Requisitos

- Filtro na listagem de movimentações por data (data inicial e data final);
- Paginação na listagem de movimentações.
- Arquitetura minimamente escalável;
- Cobertura mínima de testes automatizados.
- Autenticação:
  - Cadastro de usuário;
  - Login;
  - Necessidade do usuário estar autenticado para a realização das atividades citadas no contexto.
- Dockerizar a aplicação;