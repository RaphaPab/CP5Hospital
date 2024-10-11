## Integrantes
- Raphael Pabst rm98525
- Silvio Junior rm550821
- Pedro Braga rm551061
- Eduardo Reis Braga rm551987
- Vinícius Martins Torres Abdala rm99455

---

# Gerenciamento de Pacientes e Planos de Saúde

Este projeto é uma aplicação ASP.NET MVC com Entity Framework, desenvolvida para gerenciar o cadastro de pacientes, planos de saúde e a associação entre ambos que consuma a API de Cadastro de Pacientes e Planos de Saúde criada anteriormente. A aplicação deve permitir que os usuários interajam com a API de forma intuitiva, realizando operações de cadastro, atualização, exclusão e listagem de pacientes e planos de saúde.

## Funcionalidades Principais

### 1. Cadastro de Pacientes
- **Cadastro:** Permite cadastrar novos pacientes através de uma interface simples.
- **Listagem:** Exibe uma lista de todos os pacientes cadastrados, com opções de edição e exclusão.
- **Detalhes:** Tela dedicada para visualizar informações detalhadas de um paciente específico.

### 2. Cadastro de Planos de Saúde
- **Cadastro:** Permite cadastrar novos planos de saúde.
- **Listagem:** Exibe uma lista de todos os planos de saúde cadastrados, com opções de edição e exclusão.
- **Detalhes:** Tela para visualizar as informações detalhadas de um plano de saúde específico.

### 3. Relacionamento entre Pacientes e Planos de Saúde
- **Associar Pacientes a Planos:** Funcionalidade que permite associar um ou mais planos de saúde a um paciente.
- **Remover Associações:** Permite remover a associação entre um paciente e um plano de saúde.
- **Listagem de Associações:** Exibe a lista de planos de saúde associados a um paciente e de pacientes associados a um plano de saúde.

---

Requisitos Técnicos:
 - Utilize o padrão MVC para organizar o código da aplicação.
 - Consuma a API através de requisições HTTP (GET, POST, PUT, DELETE)utilizando a biblioteca HttpClient.
 - Utilize o padrão JSON para o envio e recebimento de dados.
 - A interface deve ser responsiva e intuitiva, proporcionando uma boa experiência ao usuário. UTILIZE BOOTSTRAP E/OU BOOTSWATCH ITEM OBRIGATÓRIO

---

## Como Executar a Aplicação

### Requisitos
- .NET 6.0 SDK ou superior
- Banco de dados SQL Server

### Passos para Rodar a Aplicação
1. Clone este repositório:
   ```bash
   git clone https://github.com/RaphaPab/checkPoint1API

2. Execute as migrações para criar as tabelas no banco de dados:
   ```bash
   dotnet ef database update

3. Execute a aplicação:
   ```bash
   dotnet run

---

### Rode o MVC

 - https://github.com/RaphaPab/CP5Hospital
 - 
### Link do vídeo no YouTube

- https://youtu.be/BWXUsNa1i-E







   
