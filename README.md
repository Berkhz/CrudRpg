
# RPG Manager - CRUD de Personagens e Itens Mágicos

Sistema de gerenciamento de um jogo de RPG, permitindo o cadastro de **Personagens** e **Itens Mágicos**, com regras específicas para associação e distribuição de atributos.

---

## 🧠 Tecnologias utilizadas

- C#
- ASP.NET Web API
- Entity Framework Core
- SQL Server (via LocalDB)
- Camadas: Controller | Business | Repository | Model

---

## 📌 Funcionalidades

### 🔸 Personagem
- ✅ Cadastrar Personagem
- ✅ Atualizar Nome do Aventureiro
- ✅ Listar todos os Personagens
- ✅ Buscar Personagem por ID
- ✅ Remover Personagem
- ✅ Buscar Amuleto do Personagem

### 🔹 Item Mágico
- ✅ Cadastrar Item Mágico
- ✅ Listar todos os Itens Mágicos
- ✅ Buscar Item Mágico por ID
- ✅ Adicionar Item Mágico ao Personagem
- ✅ Listar Itens Mágicos por Personagem
- ✅ Remover Item Mágico do Personagem

---

## 🧙 Regras de Negócio

### Personagem
- Pode distribuir **até 10 pontos** entre **Força** e **Defesa**
- Só pode ter **1 amuleto**
- Possui uma lista de itens mágicos associados

### Item Mágico
- Tipos permitidos: `Arma`, `Armadura`, `Amuleto`
- Arma: Defesa obrigatoriamente **0**
- Armadura: Força obrigatoriamente **0**
- Amuleto: Pode ter Força e Defesa, mas só **1 por personagem**
- Força e Defesa: **mínimo 1**, **máximo 10**

---

## 📦 Endpoints (API)

Base URL: `/api`

### Personagem
| Verbo | Rota | Descrição |
|-------|------|-----------|
| POST | /Personagem/AdicionarPersonagem | Cria um novo personagem |
| GET  | /Personagem/ListarPersonagens | Lista todos os personagens |
| GET  | /Personagem/ListarPersonagemPorId?id={id} | Busca personagem por ID |
| PUT  | /Personagem/AtualizarNomeAventureiro?id={id}&novoNomeAventureiro={nome} | Atualiza nome aventureiro |
| DELETE | /Personagem/DeletarPersonagem?id={id} | Remove personagem |
| GET | /Personagem/BuscarAmuletoDoPersonagem?id={id} | Retorna o amuleto do personagem |

### Item Mágico
| Verbo | Rota | Descrição |
|-------|------|-----------|
| POST | /ItemMagico/AdicionarItemMagico | Cria um novo item mágico |
| GET  | /ItemMagico/ListarItensMagicos | Lista todos os itens mágicos |
| GET  | /ItemMagico/ListarItemMagicoPorId?id={id} | Busca item por ID |
| PUT  | /ItemMagico/AdicionarItemMagicoAoPersonagem?id={idPersonagem}&idItemMagico={idItem} | Associa item ao personagem |
| GET  | /ItemMagico/ListarItemMagicoPorPersonagem?id={id}&idItemMagico={idItem} | Lista item por personagem |
| DELETE | /ItemMagico/RemoverItemMagicoDoPersonagem?id={idPersonagem}&idItemMagico={idItem} | Remove item do personagem |

---

## ▶️ Como rodar o projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/Berkhz/CrudRpg.git
   ```

2. Execute as migrations e crie o banco:
   ```bash
   dotnet ef database update
   ```

3. Inicie o projeto:
   ```bash
   dotnet run
   ```

4. Acesse os endpoints via [Swagger UI](https://localhost:51928/swagger) ou outro client HTTP (ex: Postman)

---

## 📘 Testes com Swagger

Com o projeto rodando, acesse:

```
https://localhost:{porta}/swagger
```

> O Swagger fornece uma interface gráfica para testar todos os endpoints da API.

---

## 🗃️ Banco de Dados

- A aplicação usa o **SQL Server LocalDB**
- O banco será criado automaticamente com o comando `dotnet ef database update`
- Nome do banco: `RpgDB`

---

## 📁 Estrutura do Projeto

```
Rpg
├── Src
│   ├── Model
│   ├── Business
│   ├── Business.Interface
│   ├── DTOs
│   ├── Repository
│   ├── Repository.Interface
│   ├── Services.Api
│   └── Context
```

---

## 👤 Autor

Desenvolvido por **Kauan Bertalha**  
Engenharia de Software - UniCesumar  
Abril/2025
