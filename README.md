# ORION — Copiloto de Liderança Humana

## Resumo
Pequena descrição do propósito (já colocar o texto do seu propósito).

## Tecnologias
- .NET 7 (ou 8)
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server (LocalDB / Azure SQL)
- Swagger / Swashbuckle

## Estrutura do Repositório
/Orion.Api
  /Controllers
  /DTOs
  /Models
  /Data
  /Services
  Program.cs
  appsettings.json
/Orion.sln
/README.md
/diagrams/orion-flow.drawio
/video/demo.mp4 (link no README)


## Versionamento da API
- Endpoint base: `/api/v1/`
- Política: breaking changes => nova versão (v2)

## Endpoints principais (exemplos)
- `GET /api/v1/leaders` — Lista líderes (200)
- `GET /api/v1/leaders/{id}` — Recupera líder (200/404)
- `POST /api/v1/leaders` — Cria líder (201)
- `PUT /api/v1/leaders/{id}` — Atualiza líder (204/404)
- `DELETE /api/v1/leaders/{id}` — Remove líder (204/404)

## Como rodar localmente
1. `dotnet restore`
2. Atualize `appsettings.json` com sua connection string
3. `dotnet ef database update`
4. `dotnet run`
5. Acesse `https://localhost:5001/swagger`

## Migrations
Comandos: ...
## Documentação adicional
- Fluxo da aplicação (link para `diagrams/orion-flow.drawio` ou PNG)
- Vídeo demonstrativo: <link do YouTube> (máx 5 minutos)

## Considerações de design
- Modelos, DTOs, validação, tratamento de erros global
- Proteção: autenticação (opcional para entrega 1)

## Contato / Autores
- Seu nome, matrícula, disciplina, professor, data


# ORION — Copiloto de Liderança Humana


![Architecture](diagrams/orion-flow.png)


## Tecnologias utilizadas
- .NET 7 Web API
- SQL Server + EF Core
- Swagger
- API Versioning


## Instruções para rodar
- Configure sua connection string no `appsettings.json`.
- Execute `dotnet ef database update`.
- Execute `dotnet run`.


## Documentação da API
- Swagger UI disponível em `/swagger`.
- Versionamento nas rotas: `/api/v1/leaders`.


## Vídeo de demonstração
- Link: <coloque aqui seu vídeo no YouTube>


## Fluxo da aplicação
- Arquivo Draw.io em `diagrams/orion-flow.drawio`.



API v1 — Simples e direta

Endpoints: /api/v1/leaders

Responsável por: Operações básicas com a entidade Leader (líder).

Retorno: Somente os dados da entidade Leader (id, nome, etc.).

Relacional: Não busca os times ou membros — mostra apenas os campos do líder.

📌 Exemplo de retorno no GET (/api/v1/leaders/1):

{
  "id": 1,
  "name": "Alice Silva",
  "role": "Gerente de Projetos"
}

🔸 API v2 — Completa e contextual

Endpoints: /api/v2/leaders

Responsável por: Operações com líderes, mas com contexto completo: inclui seus times e os membros desses times.

Relacional: Usa Include e ThenInclude para buscar:

Leader → Teams → Members

📌 Exemplo de retorno no GET (/api/v2/leaders/1):

{
  "id": 1,
  "name": "Alice Silva",
  "role": "Gerente de Projetos",
  "teams": [
    {
      "id": 10,
      "name": "Time de Backend",
      "members": [
        { "id": 101, "name": "João", "role": "Dev" },
        { "id": 102, "name": "Maria", "role": "Dev" }
      ]
    }
  ]
}

📑 Resumo d
