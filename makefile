PROJECT_NAME ?= SolarCoffee
ORG_NAME ?= SolarCoffee
REPO_NAME ?= SolarCoffee

.PHONY: migrations db

migrations:
	cd ./SolarCoffee.data && dotnot ef --startup-project ../SolarCoffee.web/ migrations add $(model_name) && de ..

db:
	cd ./SolarCoffee.data && dotnot ef --startup-project ../SolarCoffee.web/ database update && cd ..