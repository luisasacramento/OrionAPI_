# ORION — Copiloto de Liderança Humana

## Integrantes
- Gabriel Aparecido Cassalho Xavier RM99794
- Gustavo Vegi RM550188
- Luisa dos Santos Neves  RM551889

## Resumo
Reinventar o papel da liderança no futuro do trabalho, unindo inteligência artificial e inteligência emocional para criar líderes mais empáticos, estratégicos e humanos.
Como se cada líder tivesse um mentor digital de empatia e performance, sempre preparado com o contexto completo da equipe.

## Tecnologias
- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger

## Estrutura do Repositório
/Orion.Api  
  /Controllers  
  /Data 
  /Models  
  /Services  
  Program.cs
  appsettings.json

## Endpoints principais
- `GET /api/v1/leaders` — Lista líderes (200)
- `GET /api/v1/leaders/{id}` — Recupera líder (200/404)
- `POST /api/v1/leaders` — Cria líder (201)
- `PUT /api/v1/leaders/{id}` — Atualiza líder (204/404)
- `DELETE /api/v1/leaders/{id}` — Remove líder (204/404)

## Como rodar localmente
1. `dotnet restore`
2. Atualize `appsettings.json` com sua connection string
3. Criação de DB SQL Server (Fizemos a criação pelo Azure Data Studio integrado no VSCode), mas dá para fazer pelo CLI com o comando `sqlcmd`
```SQL
-- Criação da tabela de Leaders
CREATE TABLE Leaders (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Role NVARCHAR(100) NOT NULL
);

-- Criação da tabela de Teams
CREATE TABLE Teams (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    LeaderId INT NOT NULL,
    FOREIGN KEY (LeaderId) REFERENCES Leaders(Id)
    ON DELETE CASCADE
);

-- Criação da tabela de Members
CREATE TABLE Members (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    TeamId INT NOT NULL,
    FOREIGN KEY (TeamId) REFERENCES Teams(Id)
    ON DELETE CASCADE
);

-- Inserts de exemplo (opcional)
INSERT INTO Leaders (Name, Role) VALUES ('Ana Souza', 'Tech Lead');
INSERT INTO Teams (Name, LeaderId) VALUES ('Time Alpha', 1);
INSERT INTO Members (Name, TeamId) VALUES ('Carlos Silva', 1);
```

4. `dotnet run`
5. Acesse `https://localhost:5016/swagger`

## Documentação adicional
- Swagger UI disponível em `/swagger`.
- Versionamento nas rotas: `/api/v1/leaders` & `/api/v2/leaders`7
- Fluxo da aplicação (link para `diagrams/orion-flow.drawio` ou PNG)
- Vídeo demonstrativo: <link do YouTube> (máx 5 minutos)


## Fluxo da aplicação
- Arquivo Draw.io em `diagrams/orion-flow.drawio`.


## Exemplo para Testes na API 
### 1. Criar um Líder (POST)

**Rota:**  
`POST /api/v1/leaders`

**Corpo da requisição:**
```json
{
  "name": "Ana Souza",
  "role": "Tech Lead"
}
```

### 2. Listar todos os Líders (GET)

**Rota:**
`GET /api/v1/leaders`

Resposta exemplo:
```json
[
  {
    "id": 1,
    "name": "Ana Souza",
    "role": "Tech Lead",
    "teams": []
  }
]
```

### 3. Buscar Líder pelo ID (GET)

**Rota:**
`GET /api/v1/leaders/{id}`

Resposta exemplo:
```json
{
  "id": 1,
  "name": "Ana Souza",
  "role": "Tech Lead",
  "teams": []
}
```

### 4. Atualizar Líder (PUT)

**Rota:**
`PUT /api/v1/leaders/{id}`

Corpo da requisição:
```json
{
  "name": "Ana Paula Souza",
  "role": "Senior Tech Lead"
}
```

### 5. Deletar Líder (DELETE)

**Rota:**
`DELETE /api/v1/leaders/{id}`

