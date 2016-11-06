FROM microsoft/dotnet:onbuild



RUN mkdir -p /app
WORKDIR /app
COPY . /app
ENTRYPOINT ["dotnet", "/app/Testing.dll"]
