#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TaskManageH.WebService/TaskManageH.WebService.csproj", "TaskManageH.WebService/"]
COPY ["TaskManageH.Aplicacao[/TaskManageH.Aplicacao.csproj", "TaskManageH.Aplicacao[/"]
COPY ["TaskManageH.Dominio/TaskManageH.Dominio.csproj", "TaskManageH.Dominio/"]
COPY ["TaskManageH.Infraestrutura/TaskManageH.Infraestrutura.csproj", "TaskManageH.Infraestrutura/"]
RUN dotnet restore "./TaskManageH.WebService/TaskManageH.WebService.csproj"
COPY . .
WORKDIR "/src/TaskManageH.WebService"
RUN dotnet build "./TaskManageH.WebService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TaskManageH.WebService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskManageH.WebService.dll"]