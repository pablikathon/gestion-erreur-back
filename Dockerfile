FROM mcr.microsoft.com/dotnet/nightly/sdk:6.0.100-rc.1-focal AS build

ARG VERSION=0.0.0.1
RUN echo "⚡⚡⚡⚡ DOCKER BUILD IN VERSION $VERSION ⚡⚡⚡⚡" > /dev/null

WORKDIR source

# copy csproj and restore as distinct layers
COPY *.sln .

COPY ./Persist/**.csproj ./Persis/
COPY ./Presentation/**.csproj ./Presentation/
COPY ./Services/**.csproj ./Presentation/
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
RUN dotnet reportgenerator "-reports:./artifacts/coverage.xml" "-targetdir:./artifacts/testreport" "-reporttypes:Html"
