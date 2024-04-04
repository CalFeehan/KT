# KT API

- [Student](#student)
  - [Endpoints](#endpoints)
  - [Student Request](#student-request)

## Student

#### Endpoints
```js
// ListAsync
GET {{host}}/students/
```

```js
// GetAsync
GET {{host}}/students/{{id:guid}}
```

```js
// DeleteAsync
DELETE {{host}}/students/{{id:guid}}
```

#### Student Request
```json
{
  "id": "2bf954eb-b3e7-4e53-b535-4ecedee53d7e",
  "forename": "Joe",
  "surname": "Bloggs"
}
```
