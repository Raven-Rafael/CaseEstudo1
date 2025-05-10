# 🍕 CaseEstudo1 - API da Pizzaria

Este projeto é uma API RESTful para gerenciamento de pedidos, pizzas e bebidas. Desenvolvido com ASP.NET Core e PostgreSQL.

---

## 🚀 Como rodar o projeto

1. **Clone o repositório**
2. **Abra o terminal na pasta raiz**
3. **Execute o comando**:

```bash
docker-compose up -d --build
```

4. Acesse a API no navegador:  
👉 [http://localhost:5093/swagger](http://localhost:5093/swagger)

---

## ⚙️ Requisitos

- Docker e Docker Compose instalados

---

## 🧪 Testando conexão

Para verificar se está rodando corretamente, você pode usar:

```bash
docker logs pizzaria_api
```

---

## 📝 Variáveis de ambiente

Use um arquivo `.env` na raiz do projeto com o seguinte conteúdo:

```
POSTGRES_USER=admin
POSTGRES_PASSWORD=admin
POSTGRES_DB=pizzaria_db
API_PORT=5093
```

---

## 🛠 Scripts úteis

### ✅ Subir projeto:
```bash
docker-compose up -d --build
```

### ❌ Parar containers e limpar volumes:
```bash
docker-compose down -v
```

---

## 🧠 Dica

> Se você rodar a API dentro do Docker, o `Program.cs` deve conter a linha:  
```csharp
app.Urls.Add("http://*:80");
```

Isso garante que o container escute corretamente na porta 80, como definido no `docker-compose.yml`.

---

## 📦 Estrutura esperada

```
CaseEstudo1/
├── apps/
│   ├── api/
│   ├── docker/
│   └── web/ (opcional)
├── docker-compose.yml
├── .env
└── README.md
```

---

