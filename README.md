# Minha Primeira API - Cadastro de Usuários

Olá!

Esta API foi criada por mim como material de estudos sobre API.

O objetivo é criar uma API simples para que eu possa demonstrar meu conhecimento e também disponibilizar uma api gratuita e de fácil acesso para estudos de Front-end.

## Como configurar

Por padrão, a API não carrega consigo um banco de dados, fazendo necessário que seja gerado um banco de dados via código para ela. 
Eu deixei configurado para gerar um banco de dados em arquivo Sql Lite (database.db) via migrations do entity framework, portanto você pode gerar ele por linha de comando , seja pelo prompt, terminal ou por dentro do seu editor de preferência, ou alterar o arquivo DatabaseContext.cs para o banco de sua preferência.

Para tal , utilize o comando :
```
dotnet ef database update --context DatabaseContext
```
ou se for usar via o console do Nuget
```
Update-Database -Context DatabaseContext
```
Esses comandos farão a criação do banco e configuração das tabelas para que você possa usar os comandos de **Get , Post ,Put, Delete**.

*Obs: A API já vem configurada com o Swagger, mas você pode usar o Postman e outros recursos à vontade para testar* 
## Tecnologias utilizadas



**Back-end:** C# , EntityFramework (ver.7) , SqlLite , MVC, Swagger



## Utilização da API

#### Retorna todos os usuários

```http
  GET /v1/users
```

#### Retorna um item

```http
  GET /v1/users/{id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `int` | **Obrigatório**. O ID do item que você quer encontrar |

#### Adicionar registro

```http
  POST /v1/users
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `name`      | `string` | **Obrigatório**. O nome do Usuário |
| `email`      | `string` | **Obrigatório**. O email do Usuário |
| `password`      | `string` | **Obrigatório**. A senha do Usuário |

#### Obs: apesar do retorno dos campos , o campo id e o campo de data da criação são gerados automaticamente, não necessitando preenchimento
## Autor
Elder Crivelari Teixeira
- [Linkedin](https://www.linkedin.com/in/eldercrivelariteixeira/)

- [Github - Apesar de você estar aqui já](https://github.com/ElderCrivelari/)
