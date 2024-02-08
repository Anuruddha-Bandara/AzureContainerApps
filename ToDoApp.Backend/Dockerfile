#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ToDoApp.Backend/ToDoApp.Backend.csproj", "ToDoApp.Backend/"]
RUN dotnet restore "ToDoApp.Backend/ToDoApp.Backend.csproj"
COPY . .
WORKDIR "/src/ToDoApp.Backend"
RUN dotnet build "ToDoApp.Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToDoApp.Backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToDoApp.Backend.dll"]