
# EcoHome.EnergyInsights.API

## Descrição do Projeto

O **EcoHome.EnergyInsights.API** é uma API voltada para fornecer insights personalizados sobre o consumo de energia elétrica. A solução busca ajudar usuários a economizar energia, detectar anomalias no consumo e acompanhar metas e relatórios detalhados. Este projeto utiliza tecnologias como **.NET 8**, **Entity Framework Core**, e **ML.NET** para integrar funcionalidades analíticas e de aprendizado de máquina.

---

## Integrantes

- Caio Ribeiro Rodrigues - RM: 99759
- Guilherme Riofrio Quaglio - RM: 550137
- Elen Cabral - RM: 98790
- Mary Speranzini - RM: 550242
- Eduardo Jablinski - RM: 550975 

## Funcionalidades

- **Insights Personalizados**: Gere insights detalhados baseados em dados de consumo.
- **Dicas de Economia de Energia**: Criação, leitura, atualização e exclusão de dicas úteis para reduzir o consumo de energia.
- **Detecção de Anomalias**: Identifique padrões inesperados de consumo com ML.NET.
- **Relatórios Detalhados**: Gere relatórios com base em dados de consumo para análise.
- **Definição de Metas de Consumo**: Estabeleça e acompanhe metas personalizadas.
- **Notificações**: Envie notificações e alertas para os usuários.

---

## Tecnologias Utilizadas

- **.NET 8**
- **Entity Framework Core**
- **Oracle Database**
- **ML.NET**
- **Swagger** para documentação interativa
- **xUnit** e **Moq** para testes automatizados

---

## Estrutura do Projeto

O projeto segue os princípios de **Clean Architecture**, organizado nas seguintes camadas:

1. **Presentation Layer**: Controladores da API.
2. **Application Layer**: Serviços de aplicação e integração com ML.NET.
3. **Domain Layer**: Entidades e interfaces de domínio.
4. **Infrastructure Layer**: Repositórios e configuração de banco de dados.

---

## Configuração e Instalação

### Pré-requisitos

- .NET 8 SDK
- Banco de Dados Oracle
- IDE como Visual Studio ou VS Code
- Docker (opcional para configuração do banco de dados local)

### Passos de Instalação

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-repositorio/EcoHome.EnergyInsights.API.git
   ```
2. Navegue até o diretório:
   ```bash
   cd EcoHome.EnergyInsights.API
   ```
3. Configure a string de conexão no `appsettings.json`:
   ```json
   {
       "ConnectionStrings": {
           "DefaultConnection": "Your Oracle DB Connection String"
       }
   }
   ```
4. Execute as migrações para criar o banco de dados:
   ```bash
   dotnet ef database update --project EcoHome.EnergyInsights.Infrastructure.Data --startup-project EcoHome.EnergyInsights.API
   ```
5. Inicie a aplicação:
   ```bash
   dotnet run --project EcoHome.EnergyInsights.API
   ```

---

## Documentação da API

A API possui uma documentação interativa acessível via Swagger:

```
http://localhost:5066/swagger/index.html
```

### Exemplos de Endpoints

#### Criar uma Dica de Economia de Energia
- **Endpoint**: `POST /api/EnergySavingTip`  
- **Body**:
  ```json
  {
    "title": "Desligue aparelhos da tomada",
    "description": "Desligue aparelhos que não estão em uso para evitar desperdício.",
    "createdAt": "2024-11-21T10:00:00Z",
    "isActive": true
  }
  ```

#### Detectar Anomalias no Consumo
- **Endpoint**: `POST /api/AnomalyDetection/detect`  
- **Body**:
  ```json
  [
    { "hourOfDay": 1, "consumption": 10.5 },
    { "hourOfDay": 2, "consumption": 200.5 }
  ]
  ```

#### Treinar o Modelo de Anomalias
- **Endpoint**: `POST /api/AnomalyDetection/train`  
- **Descrição**: Treina o modelo com base nos dados do arquivo `AnomalyDetectionData.csv`.

#### Listar Relatórios
- **Endpoint**: `GET /api/Report`  
- **Resposta**:
  ```json
  [
    {
      "id": 1,
      "reportType": "Resumo Mensal",
      "data": "Base64EncodedData",
      "generatedAt": "2024-11-21T00:00:00Z"
    }
  ]
  ```

---

## Testes Automatizados

Os testes garantem a qualidade e a confiabilidade do projeto, cobrindo:

- **Controllers**: Testes para cada ação dos controladores.
- **Services**: Testes unitários com comportamento mockado.
- **ML.NET**: Testes do treinamento e detecção de anomalias.

### Executando os Testes

1. Navegue até o diretório de testes:
   ```bash
   cd EcoHome.EnergyInsights.Tests
   ```
2. Execute os testes:
   ```bash
   dotnet test
   ```

### Exemplos de Casos Testados

- **AnomalyDetectionController**:
  - Detecção de anomalias com dados válidos.
  - Retorno esperado ao treinar o modelo com um caminho de dados inválido.
- **EnergySavingTipService**:
  - Retorno de todas as dicas.
  - Adição de uma nova dica.

---

## Como Contribuir

1. Faça um fork do repositório.
2. Crie uma branch para sua feature:
   ```bash
   git checkout -b minha-feature
   ```
3. Commit suas alterações:
   ```bash
   git commit -m "Adiciona nova feature"
   ```
4. Faça o push da branch:
   ```bash
   git push origin minha-feature
   ```
5. Abra um Pull Request.

---

Esperamos que esta API ajude a promover eficiência energética e sustentabilidade!
