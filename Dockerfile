FROM mcr.microsoft.com/dotnet/sdk:8.0.101	AS build

WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .

COPY ./Persist/**.csproj ./Persist/
COPY ./Ressources/**.csproj ./Ressources/
COPY ./Presentation/**.csproj ./Presentation/
COPY ./Services/**.csproj ./Services/
COPY ./Test/**.csproj ./Test/
COPY ./.config ./.config

RUN echo "⏬ RESTORE" > /dev/null
RUN dotnet restore
RUN dotnet tool restore

# copy everything else
COPY ./ ./

# BUILD
RUN echo "🔨 BUILD" > /dev/null
RUN dotnet build -c release --no-restore

# UNIT TEST + REPORT
RUN echo "🧪 LET HIM COOK" > /dev/null
RUN dotnet test -c release --no-build  /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura  /p:CoverletOutput="../artifacts/coverage.xml" --test-adapter-path:. --logger:"junit;LogFilePath=../artifacts/test-result.xml;MethodFormat=Class;FailureBodyFormat=Verbose"
RUN dotnet reportgenerator "-reports:./artifacts/test-result.xml" "-targetdir:./artifacts/testreport" "-reporttypes:Html"

# RESHARPER ANALYSE
RUN dotnet jb inspectcode ./n-tier-app.sln -f="xml" --output='./artifacts/inspectcode.xml' --no-build

RUN dotnet fsi ./Ressources/Report/Script/xslt.fsx ./artifacts/inspectcode.xml ./Ressources/Report/Template/ic.xslt ./artifacts/inspectcode.html
RUN dotnet fsi ./Ressources/Report/Script/xslt.fsx ./artifacts/test-result.xml ./Ressources/Report/Template/unitTest.xslt "artifacts/test-result.html"
COPY ./Ressources/Report/img/xunit-coverlet-icon.png ./artifacts/xunit-coverlet-icon.png