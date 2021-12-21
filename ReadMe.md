## Commands from the root

### Build

```sh
dotnet build -o .\geektrust\geektrust\
``` 

### Run unit tests

```sh
dotnet test --collect="XPlat Code Coverage"
``` 

### Execute

```sh
 dotnet .\geektrust\geektrust\geektrust.dll "C:\Temp\tameOfThrones.txt"
``` 