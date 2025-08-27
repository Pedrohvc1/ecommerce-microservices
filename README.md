# 📦 Estrutura do Projeto: ECommerceMicroservices

Este projeto segue uma arquitetura de **microserviços com .NET**, com separação por domínio (Estoque, Vendas) e por camadas (Presentation, Domain, Infrastructure, etc).

## 🔖 Estrutura Geral

```plaintext
ECommerceMicroservices.sln
└── src/
    ├── ECommerce.StockService/
    │   ├── 1-Presentation/
    │   │   └── ECommerce.StockService.API/
    │   ├── 2-Domain/
    │   │   ├── ECommerce.StockService.Domain.Application/
    │   │   └── ECommerce.StockService.Domain.Core/
    │   ├── 3-Infrastructure/
    │   │   ├── ECommerce.StockService.Infrastructure.Data/
    │   │   └── ECommerce.StockService.Infrastructure.Services/
    │   ├── 4-CrossCutting/
    │   │   └── ECommerce.StockService.CrossCutting.Exceptions/
    │   └── 5-Test/
    │       └── ECommerce.StockService.Tests/
    │
    ├── ECommerce.SalesService/
    │   ├── 1-Presentation/
    │   ├── 2-Domain/
    │   ├── 3-Infrastructure/
    │   ├── 4-CrossCutting/
    │   └── 5-Test/
    │
    ├── ECommerce.ApiGateway/
    │
    └── ECommerce.Shared/
```

### ✅ Descrição dos Componentes

| Caminho                                                    | Responsabilidade |
|-----------------------------------------------------------|------------------|
| `ECommerce.StockService/1-Presentation/API`                     | API do microserviço de Estoque |
| `ECommerce.StockService/2-Domain/Domain.Application`            | Camada de aplicação do Estoque |
| `ECommerce.StockService/2-Domain/Domain.Core`                   | Domínio central do Estoque |
| `ECommerce.StockService/3-Infrastructure/Infrastructure.Data`   | Infraestrutura de dados do Estoque |
| `ECommerce.StockService/3-Infrastructure/Infrastructure.Services`| Serviços externos do Estoque |
| `ECommerce.StockService/4-CrossCutting/CrossCutting.Exceptions` | Tratamento de exceções do Estoque |
| `ECommerce.StockService/5-Test/Tests`                           | Testes automatizados do Estoque |
| `ECommerce.SalesService/1-Presentation`                         | API do microserviço de Vendas |
| `ECommerce.SalesService/2-Domain`                               | Camada de domínio de Vendas |
| `ECommerce.SalesService/3-Infrastructure`                       | Infraestrutura de Vendas |
| `ECommerce.SalesService/4-CrossCutting`                         | Tratamento de exceções de Vendas |
| `ECommerce.SalesService/5-Test`                                 | Testes automatizados de Vendas |
| `ECommerce.ApiGateway/`                                         | Roteador principal das requisições |
| `ECommerce.Shared/`                                             | Bibliotecas reutilizáveis (ex: JWT, Messaging) |

### 🛠️ Funcionalidades e melhorias implementadas

- Estrutura de pastas e projetos padronizada para StockService e SalesService, seguindo o mesmo padrão de camadas.
- Todos os projetos configurados para .NET 9.
- Swagger configurado e funcional nas APIs (StockService.API e ApiGateway).
- Projeto ApiGateway simplificado, mas já preparado para documentação via Swagger.
- Projetos de teste com xUnit e coverlet configurados.
- ECommerce.Shared preparado para bibliotecas compartilhadas (ex: autenticação, mensageria).
- Solution (.sln) organizada refletindo a estrutura de pastas dos microserviços.

## 📌 Tecnologias Utilizadas

- .NET 9
- ASP.NET Core
- Entity Framework Core
- RabbitMQ
- JWT Authentication
- Docker

## 📦 Como rodar

Em breve: docker-compose e instruções de execução.

