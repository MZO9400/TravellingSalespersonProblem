FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TravellingSalespersonProblem.csproj", "./"]
RUN dotnet restore "TravellingSalespersonProblem.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "TravellingSalespersonProblem.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TravellingSalespersonProblem.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TravellingSalespersonProblem.dll"]
