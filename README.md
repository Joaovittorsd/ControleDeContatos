# Cadastro de Contatos

Este é um projeto de cadastro de contatos desenvolvido em C# com ASP.Net Core, projetado para fornecer funcionalidades básicas de CRUD (criação, leitura, atualização e exclusão) de contatos. O projeto é destinado a ser um exemplo básico de uma aplicação web utilizando ASP.Net Core e pode servir como base para projetos mais complexos. Além disso, o sistema inclui recursos avançados de controle de acesso, onde diferentes níveis de permissões são atribuídos aos usuários.

Os usuários administradores têm acesso privilegiado, permitindo-lhes visualizar e gerenciar todos os usuários e seus contatos registrados no sistema. Por outro lado, os usuários padrão possuem acesso restrito, podendo apenas visualizar e gerenciar seus próprios contatos após o login.

⚠️ **Observação:** Este projeto não se concentra no design, mas sim na funcionalidade. Portanto, o design pode ser simples e não otimizado para fins estéticos.

## Funcionalidades

- **Cadastro de Contatos:** Adicione informações de contato, incluindo nome, e-mail e celular.
- **Listagem de Contatos:** Veja a lista de contatos existentes.
- **Edição de Contatos:** Atualize as informações de um contato.
- **Exclusão de Contatos:** Remova contatos que não são mais necessários.

## Tecnologias Utilizadas

- C# e ASP.Net Core (versão .NET 6.0) para o desenvolvimento do back-end.
- HTML, CSS e JavaScript para o desenvolvimento do front-end.
- Entity Framework Core para acesso a dados.
- Banco de dados SQL Server para armazenamento de dados.

## Pré-requisitos

- [.NET Core SDK](https://dotnet.microsoft.com/download) instalado.
- [Visual Studio](https://visualstudio.microsoft.com/) ou [Visual Studio Code](https://code.visualstudio.com/) para desenvolvimento (opcional).
- Banco de dados SQL Server ou outro banco de dados compatível.

## Configuração do Projeto

1. Clone este repositório em sua máquina local.
2. Configure a conexão com o banco de dados no arquivo `appsettings.json`.
3. Abra o projeto em sua IDE preferida.
4. Execute as migrações para criar o banco de dados e o usuario padrão usuario: `admin` senha: `1234`.
5. Inicie o aplicativo.
