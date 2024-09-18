# User Service API

![Build Status](https://img.shields.io/badge/Build-Passing-brightgreen)
![.NET](https://img.shields.io/badge/.NET-5.0-blue)

## Descrição

API para gerenciamento de usuários com funcionalidades completas de criação, atualização, recuperação e exclusão. Este projeto inclui serviços de integração, repositórios e testes unitários para garantir a funcionalidade e a integridade do sistema.

## Funcionalidades

- **Criação de Usuário**: Adiciona novos usuários ao sistema.
- **Atualização de Usuário**: Modifica informações de usuários existentes.
- **Recuperação de Usuário**: Obtém detalhes de um usuário específico.
- **Exclusão de Usuário**: Remove usuários do sistema.
- **Pesquisa de Usuário**: Permite busca por e-mail e nome.
- **Validação de Dados**: Assegura que todos os campos obrigatórios estejam preenchidos e válidos.

## Tecnologias Utilizadas

- **.NET 5.0**: Framework de desenvolvimento para criação da API.
- **Entity Framework Core**: ORM para acesso e manipulação de dados no banco de dados.
- **AutoMapper**: Biblioteca para mapeamento entre objetos de domínio e DTOs.
- **Xunit**: Framework de teste para garantir a qualidade do código.
- **Moq**: Biblioteca para criação de mocks e testes unitários.

## Estrutura do Projeto

- **Application**: Contém serviços e lógicas de aplicação.
- **Domain**: Define as entidades e interfaces do domínio.
- **Infrastructure**: Implementa acesso a dados e repositórios.
- **Tests**: Contém testes unitários para validar a funcionalidade da API.

## Instalação

# Clone o repositório
git clone https://github.com/pedrobertani/user-service-api.git

# Navegue até o diretório do projeto
cd user-service-api

# Restaure os pacotes NuGet
dotnet restore

# Compile o projeto
dotnet build

# Execute os testes
dotnet test

## Contribuição

Contribuições são bem-vindas! Se você tiver sugestões ou melhorias, por favor, faça um fork do repositório e envie um pull request.

## Referências

Este projeto foi desenvolvido com base no curso "Construindo APIs Robustas com .NET + Azure!" disponível no YouTube. Embora o projeto siga os conceitos e práticas apresentados no curso, ele foi adaptado e customizado conforme as necessidades específicas do desenvolvimento.

- [Construindo APIs Robustas com .NET + Azure!](https://www.youtube.com/watch?v=TovPavZjxOw&list=PLdhhExru1TXcTTm-Mpfg2tN5B_rOTNvzy&index=1&t=21s&pp=iAQB)
  
## Swagger
![image](https://github.com/user-attachments/assets/892b1c72-134a-4846-8546-f9924b1e0758)

## Testes
![image](https://github.com/user-attachments/assets/b6b77c0a-d9c0-4b41-8f9e-5bce327674d4)
