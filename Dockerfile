FROM microsoft/dotnet:sdk AS build

RUN mkdir /app

COPY . .

RUN dotnet publish \
        --output /app \
        ./CarrierPidgeon/CarrierPidgeon.csproj

FROM microsoft/dotnet:2.1-runtime-alpine

RUN mkdir /app
WORKDIR /app

COPY --from=build /app .

CMD [ "dotnet", "./CarrierPidgeon.dll" ]