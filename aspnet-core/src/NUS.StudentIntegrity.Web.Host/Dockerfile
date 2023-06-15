FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/NUS.StudentIntegrity.Web.Host/NUS.StudentIntegrity.Web.Host.csproj", "src/NUS.StudentIntegrity.Web.Host/"]
COPY ["src/NUS.StudentIntegrity.Web.Core/NUS.StudentIntegrity.Web.Core.csproj", "src/NUS.StudentIntegrity.Web.Core/"]
COPY ["src/NUS.StudentIntegrity.Application/NUS.StudentIntegrity.Application.csproj", "src/NUS.StudentIntegrity.Application/"]
COPY ["src/NUS.StudentIntegrity.Core/NUS.StudentIntegrity.Core.csproj", "src/NUS.StudentIntegrity.Core/"]
COPY ["src/NUS.StudentIntegrity.EntityFrameworkCore/NUS.StudentIntegrity.EntityFrameworkCore.csproj", "src/NUS.StudentIntegrity.EntityFrameworkCore/"]
WORKDIR "/src/src/NUS.StudentIntegrity.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/NUS.StudentIntegrity.Web.Host", "src/NUS.StudentIntegrity.Web.Host"]
COPY ["src/NUS.StudentIntegrity.Web.Core", "src/NUS.StudentIntegrity.Web.Core"]
COPY ["src/NUS.StudentIntegrity.Application", "src/NUS.StudentIntegrity.Application"]
COPY ["src/NUS.StudentIntegrity.Core", "src/NUS.StudentIntegrity.Core"]
COPY ["src/NUS.StudentIntegrity.EntityFrameworkCore", "src/NUS.StudentIntegrity.EntityFrameworkCore"]
WORKDIR "/src/src/NUS.StudentIntegrity.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "NUS.StudentIntegrity.Web.Host.dll"]
