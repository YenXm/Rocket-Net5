# Rocket_REST_API_NET5

Project built with dotnet 5.0.12


## __**New Endpoint**__

### __Get__ __Endpoint__
[GetElevatorInformation](https://github.com/YenXm/Rocket-Net5/blob/2da1a3a7033111debd3359cc337deef0789e10d4/Controllers/informationsController.cs#L33)

[GetElevatorStatus](https://github.com/YenXm/Rocket-Net5/blob/59c4abb9d96772d1524643d6ae67f5fa151c0588/Controllers/ElevatorsController.cs#L57)

| resource      | description                       |
|:--------------|:----------------------------------|
| `\information`      | return count of various entities in the database
| `\elevators\id`      | return the status of the given elevator id


## Deployement
The app is deployed on azure at this addresses: https://rocketapiyenxm.azurewebsites.net/api

## Benchmarking
Most Endpoint in the information controller were made for benchmarking. 

More information abount benchmarking: https://github.com/YenXm/Rocket-NET5-Benchmarking.git
