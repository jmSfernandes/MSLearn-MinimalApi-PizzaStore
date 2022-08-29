#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MSLearn_MinimalApi_PizzaStore/MSLearn_MinimalApi_PizzaStore.csproj", "MSLearn_MinimalApi_PizzaStore/"]
RUN dotnet restore "MSLearn_MinimalApi_PizzaStore/MSLearn_MinimalApi_PizzaStore.csproj"
COPY . .
WORKDIR "/src/MSLearn_MinimalApi_PizzaStore"
RUN dotnet build "MSLearn_MinimalApi_PizzaStore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MSLearn_MinimalApi_PizzaStore.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MSLearn_MinimalApi_PizzaStore.dll"]