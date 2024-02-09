# API de Gerenciamento de Usuários

Esta API permite realizar operações de gerenciamento de usuários, como cadastro, edição, exclusão, recuperação de senha, exportação de usuários, entre outras funcionalidades.

## Rotas Disponíveis

### Obter Usuários
- **GET** `/usuario/ObterUsuarios`
  - Retorna a lista de usuários de acordo com os filtros aplicados.
  - Parâmetros:
    - `filtro`: Objeto JSON contendo os critérios de pesquisa (opcional).
    - `login`: Booleano indicando se a requisição é para realizar login (opcional).

### Obter Usuário por ID
- **GET** `/usuario/ObterUsuarioPorId`
  - Retorna as informações de um usuário específico com base no ID fornecido.
  - Parâmetros:
    - `id`: ID do usuário.

### Cadastrar Usuário
- **POST** `/usuario/CadastrarUsuario`
  - Cadastra um novo usuário com as informações fornecidas.
  - Corpo da requisição: Objeto JSON contendo os dados do usuário.

### Editar Usuário
- **PUT** `/usuario/EditarUsuario`
  - Edita as informações de um usuário existente com base no ID fornecido.
  - Parâmetros:
    - `id`: ID do usuário.
  - Corpo da requisição: Objeto JSON contendo os dados do usuário atualizados.

### Excluir Usuário
- **DELETE** `/usuario/ExcluirUsuario`
  - Exclui um usuário com base no ID fornecido.
  - Parâmetros:
    - `id`: ID do usuário.

### Recuperar Senha
- **GET** `/usuario/RecuperarSenha`
  - Recupera a senha de um usuário com base no CPF e nome da mãe fornecidos.
  - Parâmetros:
    - `cpf`: CPF do usuário.
    - `nomeMae`: Nome da mãe do usuário.

### Exportar Usuários
- **GET** `/usuario/ExportarUsuarios`
  - Exporta a lista de usuários em formato CSV.

### Excluir Usuários
- **DELETE** `/usuario/ExcluirUsuarios`
  - Exclui vários usuários com base nos IDs fornecidos.
  - Corpo da requisição: Lista de IDs dos usuários a serem excluídos.

### Bloquear Usuário
- **PUT** `/usuario/Bloquear`
  - Bloqueia um usuário com base no ID fornecido.
  - Parâmetros:
    - `usuarioId`: ID do usuário.

### Ativar Usuário
- **PUT** `/usuario/Ativar`
  - Ativa um usuário previamente bloqueado com base no ID fornecido.
  - Parâmetros:
    - `usuarioId`: ID do usuário.

## Login
- Precisará enviar login e senha válidos que estão persistidos em memória.