#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TicTacToeApi/TicTacToeApi.csproj", "TicTacToeApi/"]
RUN dotnet restore "TicTacToeApi/TicTacToeApi.csproj"
COPY . .
WORKDIR "/src/TicTacToeApi"
RUN dotnet build "TicTacToeApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TicTacToeApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TicTacToeApi.dll"]