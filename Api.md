# KT API

- [Student](#student)
  - [Endpoints](#endpoints)
  - [Student Response](#student-request)

## Student

#### Endpoints
```js
GET {{host}}/students/
```
```js
GET {{host}}/students/{{id:guid}}
```
```js
POST {{host}}/students/
```
```js
DELETE {{host}}/students/{{id:guid}}
```

#### Create Student Request
```json
{
  "forename": "Joe",
  "surname": "Bloggs"
}
```

#### Student Response
```json
{
  "id": "2bf954eb-b3e7-4e53-b535-4ecedee53d7e",
  "forename": "Joe",
  "surname": "Bloggs"
}
```
