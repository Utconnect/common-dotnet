#!/bin/bash

# Check if both version and API key are provided as arguments
if [ $# -ne 2 ]; then
    echo "Error: Please provide both version number and API key."
    echo "Usage: $0 <version> <api_key>"
    exit 1
fi

VERSION=$1
API_KEY=$2

# Set the GitHub NuGet source name (as configured in your NuGet.config)
GITHUB_SOURCE="https://nuget.pkg.github.com/utconnect/index.json"

# Array of project paths
PROJECTS=(
    "./src/Common/Common.csproj"
    "./src/Common.Configurations/Common.Configurations.csproj"
    "./src/Common.Exceptions/Common.Exceptions.csproj"
    "./src/Common.Extensions/Common.Extensions.csproj"
    "./src/Common.Helpers/Common.Helpers.csproj"
    "./src/Common.Http/Common.Http.csproj"
    "./src/Common.Identity/Common.Identity.csproj"
    "./src/Common.Infrastructure.Db/Common.Infrastructure.Db.csproj"
    "./src/Common.Logging/Common.Logging.csproj"
    "./src/Common.MediatR/Common.MediatR.csproj"
)

echo "Pushing packages with version: $VERSION"

# Loop through each project
for PROJECT in "${PROJECTS[@]}"
do
    echo "Processing $PROJECT"
    
    # Build the project
    dotnet build "$PROJECT" -c Release

    # Pack the project
    dotnet pack "$PROJECT" -c Release -p:PackageVersion=$VERSION -o ./nupkgs

    # Get the package name
    PACKAGE_NAME=Utconnect.$(basename "$PROJECT" .csproj)

    # Push the package to GitHub NuGet
    dotnet nuget push "./nupkgs/${PACKAGE_NAME}.${VERSION}.nupkg" --source "$GITHUB_SOURCE" --api-key "$API_KEY"

    echo "Finished processing $PROJECT"
    echo "------------------------"
done

echo "All packages have been pushed to GitHub NuGet"