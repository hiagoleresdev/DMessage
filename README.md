# DMessage 🚀

Projeto de estudos em .NET para mensageria assíncrona com **RabbitMQ**.

## 🚀 Como rodar

### 1. Subir o RabbitMQ (Docker)
Na pasta do seu arquivo `docker-compose.yml`, execute:
```bash
docker compose up -d
```
* **Painel Web:** [http://localhost:15672](http://localhost:15672) (`dmessage` / `dmessage123`)

### 2. Iniciar o Consumer (Ouvinte)
Em um terminal, navegue até a pasta do projeto Consumer e execute:
```bash
cd DMessage.Consumer
dotnet run
```

### 3. Executar o Producer (Enviador)
Em um **segundo terminal**, navegue até a pasta do Producer e execute:
```bash
cd DMessage.Producer
dotnet run
```
*A mensagem enviada aparecerá instantaneamente no terminal do Consumer!*
