#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BudgetPlanner.Service/BudgetPlanner.Service.csproj", "BudgetPlanner.Service/"]
RUN dotnet restore "BudgetPlanner.Service/BudgetPlanner.Service.csproj"
COPY . .
WORKDIR "/src/BudgetPlanner.Service"
RUN dotnet build "BudgetPlanner.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BudgetPlanner.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BudgetPlanner.Service.dll"]