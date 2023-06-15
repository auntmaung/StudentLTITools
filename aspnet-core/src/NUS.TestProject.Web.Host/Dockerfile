FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/NUS.TestProject.Web.Host/NUS.TestProject.Web.Host.csproj", "src/NUS.TestProject.Web.Host/"]
COPY ["src/NUS.TestProject.Web.Core/NUS.TestProject.Web.Core.csproj", "src/NUS.TestProject.Web.Core/"]
COPY ["src/NUS.TestProject.Application/NUS.TestProject.Application.csproj", "src/NUS.TestProject.Application/"]
COPY ["src/NUS.TestProject.Core/NUS.TestProject.Core.csproj", "src/NUS.TestProject.Core/"]
COPY ["src/NUS.TestProject.EntityFrameworkCore/NUS.TestProject.EntityFrameworkCore.csproj", "src/NUS.TestProject.EntityFrameworkCore/"]
WORKDIR "/src/src/NUS.TestProject.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/NUS.TestProject.Web.Host", "src/NUS.TestProject.Web.Host"]
COPY ["src/NUS.TestProject.Web.Core", "src/NUS.TestProject.Web.Core"]
COPY ["src/NUS.TestProject.Application", "src/NUS.TestProject.Application"]
COPY ["src/NUS.TestProject.Core", "src/NUS.TestProject.Core"]
COPY ["src/NUS.TestProject.EntityFrameworkCore", "src/NUS.TestProject.EntityFrameworkCore"]
WORKDIR "/src/src/NUS.TestProject.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "NUS.TestProject.Web.Host.dll"]
