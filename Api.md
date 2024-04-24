# KT API

- [Student](#student)
  - [Endpoints](#endpoints-student)
  - [Student Response](#student-request)
- [Qualification](#qualification)
  - [Endpoints](#endpoints-qualification)
  - [Qualification Response](#qualification-response)

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
  "surname": "Bloggs",
  "dateOfBirth": "1990-01-01",
  "contactDetails" : {
  "email": "
  "phoneNumber": "01234567890"
  },
  "address": {
	"line1": "1 Test Street",
	"line2": "Test Town",
	"city": "Test City",
	"postcode": "TE5 7PC"
  }
}
```

#### Student Response
```json
{
  "id": "2bf954eb-b3e7-4e53-b535-4ecedee53d7e",
  "forename": "Joe",
  "surname": "Bloggs",
  "dateOfBirth": "1990-01-01",
  "contactDetails" : {
	"email": "testemail@email.com",
	"phoneNumber": "01234567890"
  },
  "address": {
	  "line1": "1 Test Street",
	  "line2": "Test Town",
	  "city": "Test City",
	  "postcode": "TE5 7PC"
  }
}
```

## Qualification

#### Endpoints
```js
GET {{host}}/qualifications/
```
```js
GET {{host}}/qualifications/{{id:guid}}
```
```js
POST {{host}}/qualifications/
```
```js
DELETE {{host}}/qualifications/{{id:guid}}
```

#### Create Qualification Request
```json
{
  "title": "Maths",
  "description": "Maths A Level",
  "qualificationType": 0,
  "startDate": "2019-09-01","
  "expectedEndDate": "2021-06-01",
  "actualEndDate": "2021-06-01",
  "awardingOrganisation": 0,
  "level": 3
}
```

#### Qualification Response
```json
{
  "id": "2bf954eb-b3e7-4e53-b535-4ecedee53d7e",
  "title": "Maths",
  "description": "Maths A Level",
  "qualificationType": 0,
  "startDate": "2019-09-01",
  "expectedEndDate": "2021-06-01",
  "actualEndDate": "2021-06-01",
  "awardingOrganisation": 0,
  "level": 3
}
```
