FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

RUN dotnet tool install -g Microsoft.Web.LibraryManager.Cli
RUN ln -s ~/.dotnet/tools/libman /usr/local/bin/libman

WORKDIR /src
COPY ["src/NUS.StudentIntegrity.Web.Mvc/NUS.StudentIntegrity.Web.Mvc.csproj", "src/NUS.StudentIntegrity.Web.Mvc/"]
COPY ["src/NUS.StudentIntegrity.Web.Core/NUS.StudentIntegrity.Web.Core.csproj", "src/NUS.StudentIntegrity.Web.Core/"]
COPY ["src/NUS.StudentIntegrity.Application/NUS.StudentIntegrity.Application.csproj", "src/NUS.StudentIntegrity.Application/"]
COPY ["src/NUS.StudentIntegrity.Core/NUS.StudentIntegrity.Core.csproj", "src/NUS.StudentIntegrity.Core/"]
COPY ["src/NUS.StudentIntegrity.EntityFrameworkCore/NUS.StudentIntegrity.EntityFrameworkCore.csproj", "src/NUS.StudentIntegrity.EntityFrameworkCore/"]
WORKDIR "/src/src/NUS.StudentIntegrity.Web.Mvc"
RUN dotnet restore 

WORKDIR /src
COPY ["src/NUS.StudentIntegrity.Web.Mvc", "src/NUS.StudentIntegrity.Web.Mvc"]
COPY ["src/NUS.StudentIntegrity.Web.Core", "src/NUS.StudentIntegrity.Web.Core"]
COPY ["src/NUS.StudentIntegrity.Application", "src/NUS.StudentIntegrity.Application"]
COPY ["src/NUS.StudentIntegrity.Core", "src/NUS.StudentIntegrity.Core"]
COPY ["src/NUS.StudentIntegrity.EntityFrameworkCore", "src/NUS.StudentIntegrity.EntityFrameworkCore"]
WORKDIR "/src/src/NUS.StudentIntegrity.Web.Mvc"
RUN libman restore
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "NUS.StudentIntegrity.Web.Mvc.dll"]