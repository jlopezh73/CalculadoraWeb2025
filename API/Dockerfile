FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /OperacionesAPI

#Copiar todos los archivos del proyecto
COPY . ./
#Restaurar los paquetes dentro del contenedor
RUN dotnet restore
#Construir el proyecto en versión release
RUN dotnet publish -c Release -o out

# Se construye la imagen
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /OperacionesAPI
COPY --from=build-env /OperacionesAPI/out .
ENTRYPOINT ["dotnet", "API.dll"]