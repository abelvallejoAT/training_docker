FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["dockertraining_compose_abel_vallejo/dockertraining_compose_abel_vallejo.csproj", "dockertraining_compose_abel_vallejo/"]
RUN dotnet restore "dockertraining_compose_abel_vallejo/dockertraining_compose_abel_vallejo.csproj"
COPY . .
WORKDIR "/src/dockertraining_compose_abel_vallejo"
RUN dotnet build "dockertraining_compose_abel_vallejo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dockertraining_compose_abel_vallejo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dockertraining_compose_abel_vallejo.dll"]