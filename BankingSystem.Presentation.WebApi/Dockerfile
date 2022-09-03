FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app 
#
# copy csproj and restore as distinct layers
COPY *.sln .
COPY BankingSystem.Presentation.WebApi/*.csproj ./BankingSystem.Presentation.WebApi/
COPY BankingSystem.Core.Services/*.csproj ./BankingSystem.Core.Services/
COPY BankingSystem.Core.Model/*.csproj ./BankingSystem.Core.Model/
COPY BankingSystem.Infrastructure.Repository/*.csproj ./BankingSystem.Infrastructure.Repository/
COPY BankingSystem.UnitTesting/*.csproj ./BankingSystem.UnitTesting/
#
RUN dotnet restore 
#
# copy everything else and build app
COPY BankingSystem.Presentation.WebApi/. ./BankingSystem.Presentation.WebApi/
COPY BankingSystem.Core.Services/. ./BankingSystem.Core.Services/
COPY BankingSystem.Core.Model/. ./BankingSystem.Core.Model/
COPY BankingSystem.Infrastructure.Repository/. ./BankingSystem.Infrastructure.Repository/
COPY BankingSystem.UnitTesting/. ./BankingSystem.UnitTesting/
#
WORKDIR /app/BankingSystem.Presentation.WebApi
RUN dotnet publish -c Release -o out 
#
# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app/BankingSystem.Presentation.WebApi/out ./
ENTRYPOINT ["dotnet", "BankingSystem.Presentation.WebApi.dll"]
