FROM ubuntu/dotnet-aspnet:8.0-24.04_stable	AS build

WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .

COPY ./Persist/**.csproj ./Persist/
COPY ./Presentation/**.csproj ./Presentation/
COPY ./Services/**.csproj ./Services/
COPY ./Test/**.csproj ./Test/
COPY ./.config ./.config
#jveu voir l'arboresence
RUN apt-get update && apt-get install -y tree

# Afficher l'arborescence
RUN tree /source


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
