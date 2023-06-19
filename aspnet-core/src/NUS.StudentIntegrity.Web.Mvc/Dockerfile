FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

RUN dotnet tool install -g Microsoft.Web.LibraryManager.Cli
RUN ln -s ~/.dotnet/tools/libman /usr/local/bin/libman

WORKDIR /src
COPY ["NUS.StudentIntegrity.Web.Mvc/NUS.StudentIntegrity.Web.Mvc.csproj", "NUS.StudentIntegrity.Web.Mvc/"]
COPY ["NUS.StudentIntegrity.Web.Core/NUS.StudentIntegrity.Web.Core.csproj", "NUS.StudentIntegrity.Web.Core/"]
COPY ["NUS.StudentIntegrity.Application/NUS.StudentIntegrity.Application.csproj", "NUS.StudentIntegrity.Application/"]
COPY ["NUS.StudentIntegrity.Core/NUS.StudentIntegrity.Core.csproj", "NUS.StudentIntegrity.Core/"]
COPY ["NUS.StudentIntegrity.EntityFrameworkCore/NUS.StudentIntegrity.EntityFrameworkCore.csproj", "NUS.StudentIntegrity.EntityFrameworkCore/"]
WORKDIR "/src/NUS.StudentIntegrity.Web.Mvc"
RUN dotnet restore 

WORKDIR /src
COPY ["NUS.StudentIntegrity.Web.Mvc", "NUS.StudentIntegrity.Web.Mvc"]
COPY ["NUS.StudentIntegrity.Web.Core", "NUS.StudentIntegrity.Web.Core"]
COPY ["NUS.StudentIntegrity.Application", "NUS.StudentIntegrity.Application"]
COPY ["NUS.StudentIntegrity.Core", "NUS.StudentIntegrity.Core"]
COPY ["NUS.StudentIntegrity.EntityFrameworkCore", "NUS.StudentIntegrity.EntityFrameworkCore"]
WORKDIR "/src/NUS.StudentIntegrity.Web.Mvc"
RUN libman restore
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "NUS.StudentIntegrity.Web.Mvc.dll"]
