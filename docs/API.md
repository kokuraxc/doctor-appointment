# Doctor Appointment System API

## Contents
- [Slots](#slots)
  - [Get all slots](#get-all-slots)
  - [Get available slots](#get-available-slots)
  - [Create new slot](#create-new-slot)
- [Appoints](#appointments)
  - [Create new appointment](#create-a-new-appointment)
  - [Get all appointments](#get-all-appointments)
  - [Get appointments for doctor](#get-upcoming-appointments-for-doctor)
  - [Get appointments for patient](#get-appointments-for-patient)
  - [Complete an appointment](#complete-an-appointment)
  - [Cancel an appointment](#cancel-an-appointment)
- [Patients](#patients)
  - [Create a patient](#create-new-patient)
  - [Get all patients](#get-all-patients)


## Slots

> ### Get all slots

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

> ### Get available slots

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

> ### Create new slot

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
---

## Appointments

> ### Create a new appointment

```js
POST {{host}}/Appointments
```

#### Request

```json
{
    "SlotId": "af677d4a-8459-433a-ace5-bc7ccae86c95",
    "PatientId": "63090b84-7bf1-490e-af28-4c5ecec8d5fe"
}
```

#### Response

```json
{
  "id": "1705371f-d391-41d0-ac5a-b04934b42554",
  "slotId": "af677d4a-8459-433a-ace5-bc7ccae86c95",
  "patientId": "63090b84-7bf1-490e-af28-4c5ecec8d5fe",
  "patientName": "123 Patient",
  "reserveAt": "2023-07-10T10:00:00",
  "status": "Confirmed"
}
```

> ### Get all appointments

```js
GET {{host}}/Appointments
```

#### Request

#### Response

```json
[
  {
    "id": "a6238a5b-0f51-4457-9562-530c3d78a966",
    "slotId": "38139270-fa8d-45f6-87fe-4e65f204eb86",
    "patientId": "63090b84-7bf1-490e-af28-4c5ecec8d5fe",
    "patientName": "123 Patient",
    "reserveAt": "2023-12-10T00:00:00",
    "status": "Completed"
  },
  {
    "id": "80e7f95d-2f57-42bb-b98f-dcb776bbec5a",
    "slotId": "51cbf59c-a0a0-4c77-a518-694fea5be0e0",
    "patientId": "63090b84-7bf1-490e-af28-4c5ecec8d5fe",
    "patientName": "123 Patient",
    "reserveAt": "2023-05-10T00:00:00",
    "status": "Confirmed"
  },
  {
    "id": "1705371f-d391-41d0-ac5a-b04934b42554",
    "slotId": "af677d4a-8459-433a-ace5-bc7ccae86c95",
    "patientId": "63090b84-7bf1-490e-af28-4c5ecec8d5fe",
    "patientName": "123 Patient",
    "reserveAt": "2023-07-10T10:00:00",
    "status": "Confirmed"
  }
]
```

> ### Get upcoming appointments for doctor

```js
GET {{host}}/Appointments/doctor
```

#### Request

#### Response

```json
[
  {
    "id": "1705371f-d391-41d0-ac5a-b04934b42554",
    "slotId": "af677d4a-8459-433a-ace5-bc7ccae86c95",
    "patientId": "63090b84-7bf1-490e-af28-4c5ecec8d5fe",
    "patientName": "123 Patient",
    "reserveAt": "2023-07-10T10:00:00",
    "status": "Confirmed"
  }
]
```

> ### Get appointments for patient

```js
GET {{host}}/Appointments/patient/{{patientId}}
```

#### Request

#### Response

```json
[
  {
    "id": "a6238a5b-0f51-4457-9562-530c3d78a966",
    "slotId": "38139270-fa8d-45f6-87fe-4e65f204eb86",
    "patientId": "63090b84-7bf1-490e-af28-4c5ecec8d5fe",
    "patientName": "123 Patient",
    "reserveAt": "2023-12-10T00:00:00",
    "status": "Completed"
  },
  {
    "id": "80e7f95d-2f57-42bb-b98f-dcb776bbec5a",
    "slotId": "51cbf59c-a0a0-4c77-a518-694fea5be0e0",
    "patientId": "63090b84-7bf1-490e-af28-4c5ecec8d5fe",
    "patientName": "123 Patient",
    "reserveAt": "2023-05-10T00:00:00",
    "status": "Confirmed"
  },
  {
    "id": "1705371f-d391-41d0-ac5a-b04934b42554",
    "slotId": "af677d4a-8459-433a-ace5-bc7ccae86c95",
    "patientId": "63090b84-7bf1-490e-af28-4c5ecec8d5fe",
    "patientName": "123 Patient",
    "reserveAt": "2023-07-10T10:00:00",
    "status": "Confirmed"
  }
]
```

> ### Complete an appointment

```js
POST {{host}}/Appointments/{{appointmentId}}/Complete
```

#### Request

#### Response

```json
{
  "id": "80e7f95d-2f57-42bb-b98f-dcb776bbec5a",
  "slotId": "51cbf59c-a0a0-4c77-a518-694fea5be0e0",
  "patientId": "63090b84-7bf1-490e-af28-4c5ecec8d5fe",
  "patientName": "123 Patient",
  "reserveAt": "2023-05-10T00:00:00",
  "status": "Completed"
}
```

> ### Cancel an appointment

```js
POST {{host}}/Appointments/{{appointmentId}}/Cancel
```

#### Request

#### Response

```json
{
  "id": "80e7f95d-2f57-42bb-b98f-dcb776bbec5a",
  "slotId": "51cbf59c-a0a0-4c77-a518-694fea5be0e0",
  "patientId": "63090b84-7bf1-490e-af28-4c5ecec8d5fe",
  "patientName": "123 Patient",
  "reserveAt": "2023-05-10T00:00:00",
  "status": "Cancelled"
}
```

---

## Patients

> ### Create new patient

```js
POST {{host}}/Patients
```

#### Request

```json
{
    "FirstName" : "123",
    "LastName" : "Patient"
}
```

#### Response

```json
{
  "id": "63090b84-7bf1-490e-af28-4c5ecec8d5fe",
  "firstName": "123",
  "lastName": "Patient"
}
```

> ### Get all patients

```js
GET {{host}}/Patients
```

#### Request

#### Response

```json
[
  {
    "id": "63090b84-7bf1-490e-af28-4c5ecec8d5fe",
    "firstName": "123",
    "lastName": "Patient"
  },
  {
    "id": "1cf42128-e216-4aa2-9bcc-8e930c8fa12b",
    "firstName": "456",
    "lastName": "Patient"
  },
  {
    "id": "83689067-aa2b-4492-831f-66957c87c355",
    "firstName": "789",
    "lastName": "Patient"
  }
]
```