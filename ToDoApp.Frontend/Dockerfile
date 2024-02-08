#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ToDoApp.Frontend/ToDoApp.Frontend.csproj", "ToDoApp.Frontend/"]
RUN dotnet restore "ToDoApp.Frontend/ToDoApp.Frontend.csproj"
COPY . .
WORKDIR "/src/ToDoApp.Frontend"
RUN dotnet build "ToDoApp.Frontend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToDoApp.Frontend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToDoApp.Frontend.dll"]