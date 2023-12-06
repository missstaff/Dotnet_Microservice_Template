FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# RUN dotnet ef migrations add "Initial" 
# RUN dotnet ef database update 

COPY ["App/App.csproj", "./"]
RUN dotnet restore "App.csproj"

COPY . ./
WORKDIR "/App"
RUN dotnet publish "App/App.csproj" -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 80

# Copy the published application from the build image
COPY --from=build-env App/out .
ENTRYPOINT ["dotnet", "App.dll"]