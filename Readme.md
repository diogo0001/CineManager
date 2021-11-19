# Sistema de gerenciamento de cinemas

Sistema onde o usuário faz o login como admin e pode:

- Cadastrar, editar, e remover filmes
- Cadastrar e remover sessões
- Visualizar as salas

#### Login

Para o login as credenciais são:
- Email: contato@cinemanager.com
- Password: cinemanager

<img src="https://github.com/diogo0001/CineManager/blob/master/Media/login.gif" width="700" height="400"> 

#### Salas
<img src="https://github.com/diogo0001/CineManager/blob/master/Media/rooms.gif" width="700" height="400"> 

#### Filmes
<img src="https://github.com/diogo0001/CineManager/blob/master/Media/movies.gif" width="700" height="400"> 

#### Sessões
<img src="https://github.com/diogo0001/CineManager/blob/master/Media/sessions.gif" width="700" height="400"> 


## Requisitos

- Um novo filme só poderá ser cadastrado se ainda não tiver nenhum registro (não duplicar)
- Ao remover um filme, só será permitido se não houver sessões vinculadas.
- Ao cadastrar uma sessão, não podem haver conflitos de horários nas salas.
- Uma sessão só poderá ser removida se faltar mais de 10 dias.

## Preparando o ambiente para execução

### Frontend

O frontend foi feito com Vuejs e o plugin Vuetify para os estilos. <br>

Para instalar as dependências é necessário ter o NodeJs instalado (v 12+). <br>
Na pasta do repositório, vá na pasta 'cine-manager-client' e rode o comando:

```bash
npm install
```

Execute o comando para levantar a aplicação:

```bash
npm run serve
```

Obs: Para rodar a aplicação é preciso estar com o backend também rodando.

### Backend

O backend foi feito com ASP.NET e o Entity Framework para o banco Sql Server.<br>
As dependências para o backend são:

- .NET 5.0
- Microsoft.AspNetCore.Mvc 5.0
- Microsoft.AspNetCore.Mvc.NewtonsoftJson 5.0
- Microsoft.EntityFrameworkCore 5.0 
- Microsoft.EntityFrameworkCore.Design 5.0
- Microsoft.EntityFrameworkCore.SqlServer 5.0
- SQL Server 18

Antes de subir a aplicação, é preciso criar o banco de dados. Faça isso executando o comando a seguir na pasta 'cine-manager-server':

```bash
dotnet ef database update
```

Abra o Sql Server Managment Studio e verifique se o banco 'cinemaganer_local_db' foi criado. Execute os scripts da pasta 'DbScripts' para carregar os dados iniciais. Estes dados são pra facilitar a visualização, sem necessariamente atenterem os requisitos do sistema. Mas alguns dados são importantes, como as salas e os dados de usuário admim.<br>
Após o banco estar OK, é só subir o servidor:

```bash
dotnet run
```

## Itens ainda não implementados ou com problemas

- Melhorar estilos
- Carregamento das imagens dos filmes
- Correto sistema de autenticação e autorização do login - foi feito um sistema bem ingênuo de acesso ao banco.
- Validações dos inputs - foram feitas algumas validações básicas
- Toasts com mensagens dos status das ações - foram testadas algumas opções que não funcionaram
- Bugs
- Testes
