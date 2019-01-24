FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["ProjectContactAPI/ProjectContactAPI.csproj", "ProjectContactAPI/"]
RUN dotnet restore "ProjectContactAPI/ProjectContactAPI.csproj"
COPY . .
WORKDIR "/src/ProjectContactAPI"
RUN dotnet build "ProjectContactAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ProjectContactAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ProjectContactAPI.dll"]