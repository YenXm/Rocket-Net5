# Rocket_REST_API_NET5

Project built with dotnet 5.0.12

## \***\*New Endpoint\*\***

### **Get** **Endpoint**

[GetElevatorInformation](https://github.com/YenXm/Rocket-Net5/blob/2da1a3a7033111debd3359cc337deef0789e10d4/Controllers/informationsController.cs#L33)

[GetElevatorStatus](https://github.com/YenXm/Rocket-Net5/blob/59c4abb9d96772d1524643d6ae67f5fa151c0588/Controllers/ElevatorsController.cs#L57)

[ChangeElevatorStatus](https://github.com/YenXm/Rocket-Net5/blob/59c4abb9d96772d1524643d6ae67f5fa151c0588/Controllers/ElevatorsController.cs#L93)

I do not have a endpoint that return a list of elevetor employee, instead I have a endpoint that verify a given email addresses against the database.

[VerifyEmail](https://github.com/YenXm/Rocket-Net5/blob/ba24e20a6aea0979aef08adb670dbcfd04007993/Controllers/EmployeesController.cs#L104)

## Get Request

| resource                                | description                                                                                                        |
| :-------------------------------------- | :----------------------------------------------------------------------------------------------------------------- |
| `/Batteries`                            | Retreive list of all batteries                                                                                     |
| `/buildings`                            | Retreive list of all buildings                                                                                     |
| `/Columns`                              | Retrieve the current status of a specific column                                                                   |
| `/elevators`                            | Retreive list of all elevators                                                                                     |
| `/Employees`                            | Retreive list of all employees                                                                                     |
| `/intervention`                         | Retreive list of all interventions                                                                                 |
| `/Leads`                                | Retreive list of all leads created in the last 30 days who have not yet become customers                           |
| `/Users`                                | Retreive list of all users                                                                                         |
| `/addresses/{id}`                       | Retrieve all informations from a specific address                                                                  |
| `/Batteries/{id}`                       | Retrieve all informations from a specific battery                                                                  |
| `/buildings/{id}`                       | Retrieve all informations from a specific building                                                                 |
| `/Employees/{id}`                       | Retrieve all informations from a specific employee                                                                 |
| `/elevators/{id}`                       | Retrieve all informations from a specific elevator                                                                 |
| `/intervention/{id}`                    | Retrieve all informations from a specific intervention                                                             |
| `/Users/{id}`                           | Retrieve all informations from a specific user                                                                     |
| `/Batteries/{id}/status`                | Retrieve the current status of a specific battery                                                                  |
| `/Columns/{id}/status`                  | Retrieve the current status of a specific column                                                                   |
| `/elevators/{id}/status`                | Retrieve the current status of a specific elevator                                                                 |
| `/Batteries/update/{id}/{status}`       | Change the status of a specific battery                                                                            |
| `/Columns/update/{id}/{status}`         | Change the status of a specific column                                                                             |
| `/elevators/update/{id}/{status}`       | Change the status of a specific elevator                                                                           |
| `/buildings/count`                      | Amount of buildings                                                                                                |
| `/elevators/count`                      | Amount of elevators                                                                                                |
|                                         |
| `/buildings/get-intervention-buildings` | Retrieve a Retreive list of buildings that contain at least one battery, column or elevator requiring intervention |
|
| `/Employees/verification/{email}`       | Check if the email is found among the employees                                                                    |
|
| `/elevators/elevators-not-in-use`       | Retreive list of all elevators with status !"Online"                                                               |
| `/elevators/elevators-not-in-use/count` | amount of elevators with status !"Online"                                                                          |
|
| `/intervention/pending`                 | Retreive list of all interventions with status pending                                                             |
|
| `/question/1/{id}`                      | Unavailable                                                                                                        |
| `/question/2/{id}`                      | Unavailable                                                                                                        |
| `/question/3/{id}`                      | Unavailable                                                                                                        |
|
| `/information`                          | return count of various entities in the database                                                                   |
| `/information/HashSetCount`             | Benchmarking                                                                                                       |
| `/information/DistinctCount`            | Benchmarking                                                                                                       |
| `/information/SqlAndDistinctCount`      | Benchmarking                                                                                                       |
| `/information/SqlCount`                 | Benchmarking                                                                                                       |
| `/information/WhereCount`               | Benchmarking                                                                                                       |
| `/information/SqlWhereCount`            | Benchmarking                                                                                                       |
| `/information/DirectCount`              | Benchmarking                                                                                                       |

## Deployement

The app is deployed on azure at this addresses: https://rocketapiyenxm.azurewebsites.net/api

## Benchmarking

Most Endpoint in the information controller were made for benchmarking.

More information abount benchmarking: https://github.com/YenXm/Rocket-NET5-Benchmarking.git
