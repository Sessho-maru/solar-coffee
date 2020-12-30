PROJECT_NAME ?= SolarCoffee
ORG_NAME ?= SolarCoffee
REPO_NAME ?= SolarCoffee

.PHONY: migrations db

migrations:
	cd ./SolarCoffee.data && dotnet ef --startup-project ../SolarCoffee.web/ migrations add $(migration_name) && cd ..

db:
	cd ./SolarCoffee.data && dotnet ef --startup-project ../SolarCoffee.web/ database update && cd ..

drop:
	cd ./SolarCoffee.web && dotnet ef database drop -f -v && cd..