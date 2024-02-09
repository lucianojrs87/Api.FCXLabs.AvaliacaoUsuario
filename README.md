# API de Gerenciamento de Usu�rios

Esta API permite realizar opera��es de gerenciamento de usu�rios, como cadastro, edi��o, exclus�o, recupera��o de senha, exporta��o de usu�rios, entre outras funcionalidades.

## Rotas Dispon�veis

### Obter Usu�rios
- **GET** `/usuario/ObterUsuarios`
  - Retorna a lista de usu�rios de acordo com os filtros aplicados.
  - Par�metros:
    - `filtro`: Objeto JSON contendo os crit�rios de pesquisa (opcional).
    - `login`: Booleano indicando se a requisi��o � para realizar login (opcional).

### Obter Usu�rio por ID
- **GET** `/usuario/ObterUsuarioPorId`
  - Retorna as informa��es de um usu�rio espec�fico com base no ID fornecido.
  - Par�metros:
    - `id`: ID do usu�rio.

### Cadastrar Usu�rio
- **POST** `/usuario/CadastrarUsuario`
  - Cadastra um novo usu�rio com as informa��es fornecidas.
  - Corpo da requisi��o: Objeto JSON contendo os dados do usu�rio.

### Editar Usu�rio
- **PUT** `/usuario/EditarUsuario`
  - Edita as informa��es de um usu�rio existente com base no ID fornecido.
  - Par�metros:
    - `id`: ID do usu�rio.
  - Corpo da requisi��o: Objeto JSON contendo os dados do usu�rio atualizados.

### Excluir Usu�rio
- **DELETE** `/usuario/ExcluirUsuario`
  - Exclui um usu�rio com base no ID fornecido.
  - Par�metros:
    - `id`: ID do usu�rio.

### Recuperar Senha
- **GET** `/usuario/RecuperarSenha`
  - Recupera a senha de um usu�rio com base no CPF e nome da m�e fornecidos.
  - Par�metros:
    - `cpf`: CPF do usu�rio.
    - `nomeMae`: Nome da m�e do usu�rio.

### Exportar Usu�rios
- **GET** `/usuario/ExportarUsuarios`
  - Exporta a lista de usu�rios em formato CSV.

### Excluir Usu�rios
- **DELETE** `/usuario/ExcluirUsuarios`
  - Exclui v�rios usu�rios com base nos IDs fornecidos.
  - Corpo da requisi��o: Lista de IDs dos usu�rios a serem exclu�dos.

### Bloquear Usu�rio
- **PUT** `/usuario/Bloquear`
  - Bloqueia um usu�rio com base no ID fornecido.
  - Par�metros:
    - `usuarioId`: ID do usu�rio.

### Ativar Usu�rio
- **PUT** `/usuario/Ativar`
  - Ativa um usu�rio previamente bloqueado com base no ID fornecido.
  - Par�metros:
    - `usuarioId`: ID do usu�rio.

## Login
- Precisar� enviar login e senha v�lidos que est�o persistidos em mem�ria.