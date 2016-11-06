#!/bin/sh
dotnet publish -c release

cd bin/release/netcoreapp1.0/publish
docker build -t adotest .

docker run -d -p 5000:5000 adotest

echo "Test the website on port 5000"