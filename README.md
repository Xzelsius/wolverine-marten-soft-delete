# Wolverine with Marten Soft-Delete Issue

Restore of a soft-deleted document does not work.

## Setup

This repro requires a working PostgreSQL server and database.
Simply run this command to create a new PostgreSQL server in Docker

```
docker run --name wolverine-repro -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=postgres -p 5432:5432 -d postgres
```

## Reproduction Steps

1. Go to Swagger UI (http://localhost:5255/swagger/index.html)
2. Create a new Todo
3. Delete the Todo
4. Restore the Todo

## Teardown

Remove the created PostgreSQL server with this command

```
docker rm -f -v wolverine-repro
```
