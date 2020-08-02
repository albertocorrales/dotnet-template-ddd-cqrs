# Introduction

MicroserviceTemplate is a service template to create new domains. By using this template you will have the scaffolding for a project which uses Query, Command and Projection.

## How to use this template

To use this template locally follow these steps:

- Update NuGet package by using command `nuget.exe pack MicroserviceTemplate.nuspec`
- Install this template using this command `dotnet new --install MicroserviceTemplate.1.0.0.nupkg`
- In the folder where you want to create your project execute `dotnet new MicroserviceTemplate -o MyCoolMicroservice`
