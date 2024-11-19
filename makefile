# Define variables
STARTUP_PROJECT = ./Moneto.API/Moneto.API.csproj
PROJECT = ./Moneto.Data/Moneto.Data.csproj

# Alias for dotnet ef with default projects
EF = dotnet ef --startup-project $(STARTUP_PROJECT) --project $(PROJECT)

# Targets
migrate:
	$(EF) database update -v

add-migration:
	$(EF) migrations add -v $(name)

remove-migration:
	$(EF) migrations remove -v

list-migrations:
	$(EF) migrations list

revert-migration:
	$(EF) database update $(name) -v

revert-all-migrations:
	$(EF) database update 0 -v