echo "Building name-sorter project..."
dotnet build
echo "Creating Unix executable file..."
dotnet publish -c Release -r linux-x64 /p:PublishSingleFile=true /p:PublishTrimmed=true
echo "Creating alias..."
echo "alias name-sorter='$(pwd)/bin/Release/net7.0/name-sorter'" >> ~/.bashrc
source ~/.bashrc
echo "Done!"