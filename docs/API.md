# Doctor Appointment System API

## Slots

### Get all slots

```js
GET {{host}}/slots
```

#### Request

#### Response

```json
[
  {
    "id": "6d36e994-3be3-4603-abb0-39e99183fe6b",
    "startDate": "2023-06-18T16:01:32.0470365+08:00",
    "doctorName": "doctor Name 1",
    "isReserved": false,
    "cost": 12.34
  },
  {
    "id": "86f88fa1-e49b-4e32-ab5e-44bf810f412f",
    "startDate": "2023-06-18T16:01:32.0470395+08:00",
    "doctorName": "doctor Name 2",
    "isReserved": false,
    "cost": 98.34
  },
  {
    "id": "6bec9af4-0990-4e20-a230-b647b3c129ce",
    "startDate": "2023-06-18T16:01:32.0470398+08:00",
    "doctorName": "doctor Name 3",
    "isReserved": true,
    "cost": 98.34
  }
]
```

### Get available slots

```js
GET {{host}}/Slots/available
```

#### Request

#### Response

```json
[
  {
    "id": "ee8b1d09-f594-40f9-973e-845424e17a86",
    "startDate": "2023-06-18T16:02:42.5228185+08:00",
    "doctorName": "doctor Name 1",
    "isReserved": true,
    "cost": 12.34
  },
  {
    "id": "342f5002-74ed-4bf9-9509-9203981dc0d7",
    "startDate": "2023-06-18T16:02:42.522822+08:00",
    "doctorName": "doctor Name 2",
    "isReserved": false,
    "cost": 98.34
  }
]
```

### Create new slot

```js
POST {{host}}/Slots
```

#### Request

```json
{
    "StartDate": "2015-10-10T00:00:00",
    "DoctorName": "doctor x",
    "IsReserved": false,
    "Cost": 56.782
}
```

#### Response

```json
{
  "id": "0c17135f-8e21-4d27-80d6-83d203f3e1de",
  "startDate": "2015-10-10T00:00:00",
  "doctorName": "doctor x",
  "isReserved": false,
  "cost": 56.782
}
```

## Appointments

## Patients