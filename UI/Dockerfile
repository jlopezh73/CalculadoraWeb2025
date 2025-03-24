FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /OperacionesApp

#Copiar todos los archivos del proyecto
COPY . ./
#Restaurar los paquetes dentro del contenedor
RUN dotnet restore
#Construir el proyecto en versión release
RUN dotnet publish -c Release -o out

# Se construye la imagen
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /OperacionesApp
COPY --from=build-env /OperacionesApp/out .
ENTRYPOINT ["dotnet", "UI.dll"]