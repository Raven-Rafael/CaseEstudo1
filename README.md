
# 🍕 Projeto Pizza Hat — Fullstack .NET + Angular


---

## ✅ Requisitos

- [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download)
- [Node.js](https://nodejs.org/en/) (v18+)
- Angular CLI (`npm install -g @angular/cli`)
- PostgreSQL (via Docker ou instalado localmente)

---

## ⚙️ Como rodar o backend (API)

1. Acesse a pasta `apps/api/`
2. Execute:

```bash
dotnet run
```

3. A API estará disponível em `http://localhost:5093`
4. Acesse o Swagger: [http://localhost:5093/swagger](http://localhost:5093/swagger)

---

## 💻 Como rodar o frontend (Angular)

1. Acesse a pasta `apps/web/`
2. Instale as dependências:

```bash
npm install
```

3. Rode o projeto:

```bash
ng serve
```

4. Acesse: [http://localhost:4200](http://localhost:4200)

---

## 🐘 Banco de dados (PostgreSQL)

Configuração padrão usada:

- **Usuário:** admin
- **Senha:** admin
- **Banco:** pizzaria_db
- **Porta:** 5432

---

## 👥 Cadastro e login

- Página de cadastro: `/cadastro`
- Página de login: `/login`
- Após login, o nome do usuário aparece no topo com botão de logout

---

## 🛠️ Extras técnicos

- CORS habilitado para frontend Angular
- AutoMapper configurado para entidades → DTOs
- Frontend responsivo com Angular Material e SCSS
- Backend estruturado com Entity Framework Core

---

Desenvolvido para fins de estudo e avaliação.
