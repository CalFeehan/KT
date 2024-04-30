# KT API

- [Learner](#Learner)
  - [Endpoints](#endpoints-Learner)
  - [Learner Response](#Learner-request)
- [Qualification](#qualification)
  - [Endpoints](#endpoints-qualification)
  - [Qualification Response](#qualification-response)

## Learner

#### Endpoints
```js
GET {{host}}/learners/
```
```js
GET {{host}}/learners/{{id:guid}}
```
```js
POST {{host}}/learners/
```
```js
DELETE {{host}}/learners/{{id:guid}}
```

#### Create Learner Request
```json
{
  "forename": "Joe",
  "surname": "Bloggs",
  "dateOfBirth": "1990-01-01",
  "contactDetails" : {
    "email": "email@email.com",
    "phone": "01234567890",
    "contactPreference": 0
  },
  "address": {
    "line1": "1 Test Street",
    "line2": "Test Town",
    "city": "Test City",
    "postcode": "TE5 7PC"
  },
}
```

#### Learner Response
```json
{
  "id": "2bf954eb-b3e7-4e53-b535-4ecedee53d7e",
  "forename": "Joe",
  "surname": "Bloggs",
  "dateOfBirth": "1990-01-01",
  "contactDetails" : {
    "email": "testemail@email.com",
    "phoneNumber": "01234567890",
    "contactPreference": 0
  },
  "address": {
    "line1": "1 Test Street",
    "line2": "Test Town",
    "city": "Test City",
    "postcode": "TE5 7PC"
  }
}
```
