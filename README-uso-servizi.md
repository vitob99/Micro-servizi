## Utilizzo pratico dei microservizi

### Avvio dello stack

```bash
cd "/Users/gorlitzer/Desktop/nextbyte"
docker compose up --build
```

Servizi esposti:

- User Service: `http://localhost:8080`
- Billing Service: `http://localhost:8081`
- Deploy Service: `http://localhost:8082`

Swagger:

- `http://localhost:8080/swagger`
- `http://localhost:8081/swagger`
- `http://localhost:8082/swagger`

---

### 1. User Service

#### 1.1. Creare un utente

`POST http://localhost:8080/users`

Body:

```json
{
  "email": "alice@example.com",
  "name": "Alice"
}
```

Risposta attesa:

```json
{
  "id": 1,
  "email": "alice@example.com",
  "name": "Alice",
  "credits": 0
}
```

#### 1.2. Leggere un utente

`GET http://localhost:8080/users/1`

Risposte possibili:

- 200 OK → utente con crediti
- 404 Not Found → se l'utente non esiste

---

### 2. Billing Service

#### 2.1. Pagare una subscription (ricarica crediti)

`POST http://localhost:8081/subscriptions/pay`

Body:

```json
{
  "userId": 1,
  "amount": 10.0
}
```

Regola: **1 euro = 10 crediti** → 10 euro = 100 crediti.

Risposta attesa (semplificata):

```json
{
  "payment": {
    "id": 1,
    "userId": 1,
    "amount": 10.0,
    "createdAt": "..."
  },
  "creditsAdded": 100,
  "userCredits": {
    "id": 1,
    "credits": 100
  }
}
```

Errori possibili:

- 404 Not Found se l'utente non esiste.

#### 2.2. Consumare crediti direttamente

`POST http://localhost:8081/usage/consume`

Body:

```json
{
  "userId": 1,
  "resourceUnits": 5
}
```

Regola: **1 unità = 1 credito**.

- Se i crediti sono sufficienti:

```json
{
  "newBalance": 95
}
```

- Se i crediti NON sono sufficienti:

```json
{
  "message": "crediti insufficienti"
}
```

---

### 3. Deploy Service

#### 3.1. Effettuare un deploy

`POST http://localhost:8082/deploy`

Body:

```json
{
  "userId": 1,
  "productId": "vm-small",
  "resourceUnits": 20
}
```

Comportamento:

1. Registra un `Deployment` nel proprio database.
2. Chiama `billing-service` per scalare i crediti (`/usage/consume`).
3. Restituisce il risultato del deploy.

Rispetto ai crediti:

- Se i crediti BASTANO:

```json
{
  "message": "Deploy eseguito e crediti scalati",
  "deployment": {
    "id": 1,
    "userId": 1,
    "productId": "vm-small",
    "resourceUnits": 20,
    "createdAt": "..."
  }
}
```

- Se i crediti NON bastano:

```json
{
  "message": "Deploy non autorizzato: crediti insufficienti",
  "id": 1,
  "userId": 1,
  "productId": "vm-small",
  "resourceUnits": 20
}
```

---

### 4. Esempio di flusso completo (da terminale con curl)

#### 4.1. Crea un utente

```bash
curl -X POST http://localhost:8080/users \
  -H "Content-Type: application/json" \
  -d '{"email":"alice@example.com","name":"Alice"}'
```

#### 4.2. Paga una subscription da 10€

```bash
curl -X POST http://localhost:8081/subscriptions/pay \
  -H "Content-Type: application/json" \
  -d '{"userId":1,"amount":10.0}'
```

#### 4.3. Verifica l'utente e i crediti

```bash
curl http://localhost:8080/users/1
```

#### 4.4. Effettua un deploy che consuma 20 crediti

```bash
curl -X POST http://localhost:8082/deploy \
  -H "Content-Type: application/json" \
  -d '{"userId":1,"productId":"vm-small","resourceUnits":20}'
```

#### 4.5. Prova un deploy con crediti insufficienti

- Ripeti la chiamata con un valore di `resourceUnits` più alto del saldo residuo
- Oppure consuma prima i crediti con `POST /usage/consume` e poi prova un nuovo deploy

