dotnet tool install --global coverlet.console
dotnet tool install --global dotnet-reportgenerator-globaltool 

rmdir TestResults
mkdir TestResults

dotnet test /p:CollectCoverage=true  /p:CoverletOutput=TestResults/ /p:CoverletOutputFormat=cobertura  /p:Exclude=\"[*]*Adapters*,[*]*Configurations*,[*]*Migrations*,[*]*Models*,[*]*Entities*,[*]*Context*,[*]*Queries*,[*]*Dtos*,[*]*Response*,[*]*Program*,[*]*Constants*,[*]*Validators*,[*]*Exceptions*\"           
reportgenerator "-reports:./TestResults/coverage.cobertura.xml" "-targetdir:./TestResults/coveragereport" -reporttypes:"HTML;HTMLSummary" 