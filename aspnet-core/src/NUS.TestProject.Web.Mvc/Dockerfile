FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

RUN dotnet tool install -g Microsoft.Web.LibraryManager.Cli
RUN ln -s ~/.dotnet/tools/libman /usr/local/bin/libman

WORKDIR /src
COPY ["src/NUS.TestProject.Web.Mvc/NUS.TestProject.Web.Mvc.csproj", "src/NUS.TestProject.Web.Mvc/"]
COPY ["src/NUS.TestProject.Web.Core/NUS.TestProject.Web.Core.csproj", "src/NUS.TestProject.Web.Core/"]
COPY ["src/NUS.TestProject.Application/NUS.TestProject.Application.csproj", "src/NUS.TestProject.Application/"]
COPY ["src/NUS.TestProject.Core/NUS.TestProject.Core.csproj", "src/NUS.TestProject.Core/"]
COPY ["src/NUS.TestProject.EntityFrameworkCore/NUS.TestProject.EntityFrameworkCore.csproj", "src/NUS.TestProject.EntityFrameworkCore/"]
WORKDIR "/src/src/NUS.TestProject.Web.Mvc"
RUN dotnet restore 

WORKDIR /src
COPY ["src/NUS.TestProject.Web.Mvc", "src/NUS.TestProject.Web.Mvc"]
COPY ["src/NUS.TestProject.Web.Core", "src/NUS.TestProject.Web.Core"]
COPY ["src/NUS.TestProject.Application", "src/NUS.TestProject.Application"]
COPY ["src/NUS.TestProject.Core", "src/NUS.TestProject.Core"]
COPY ["src/NUS.TestProject.EntityFrameworkCore", "src/NUS.TestProject.EntityFrameworkCore"]
WORKDIR "/src/src/NUS.TestProject.Web.Mvc"
RUN libman restore
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "NUS.TestProject.Web.Mvc.dll"]
