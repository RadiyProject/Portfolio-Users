"http://localhost:8080/swagger" для доступа к сваггеру
"make up" для развёртывания проекта в контейнере докер. Опции ENV=dev, ENV=stage, ENV=prod. По умолчанию используется ENV=dev. Архитектура в соответствующем docker-compose выставлена ARM (для ускорения работы контейнеров на моём устройстве)
"make down" для свёртывания проекта и закрытия работающих контейнеров
"make restart" для перезапуска проекта в контейнере докер
"make controller CONTROLLER={название_контроллера}" для создания файла контроллера в проекте
"make db" для подключения к БД запущенного контейнера
"make migration-add MIGRATION={название_миграции}" для создания новой миграции при помощи контейнера
"make migrate" для применения миграции при помощи контейнера
"make dotnet-ef-init" для служебных целей (обеспечивает целостность работы migration-add и migrate)