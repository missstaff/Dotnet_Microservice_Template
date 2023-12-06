FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /Backend/Api

COPY ["Backend/Api/Api.csproj", "./"]
RUN dotnet restore "Api.csproj"

COPY . ./
WORKDIR "/Backend/Api"
RUN dotnet publish "Backend/Api/Api.csproj" -c Release -o out

#Final Image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /api
EXPOSE 80

# Copy the published application from the build image
COPY --from=build-env Backend/Api/out .
ENTRYPOINT ["dotnet", "Api.dll"]
