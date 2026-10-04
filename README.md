# HouseKeeper

Sharing a home usually means splitting everyday chores, one way or another. The goal is to find a balance so that everyone feels good in the household. There are plenty of ways to get organized: a whiteboard, a small notebook, an Excel sheet… But couldn't we build something simple, intuitive and modern? And couldn't we make these chores more engaging than a plain "they need to be done"?

**HouseKeeper** is a shared household management app. It aims to make organizing as easy and intuitive as possible, and will eventually add a playful touch that makes you actually want to do your chores.

> 🚧 **Status:** under development. V1 is not available yet.

## Features (V1)

The first version deliberately focuses on the essentials:

- **User accounts**: sign up and sign in.
- **Households**: create a household and invite members.
- **Tasks**: create, edit and delete tasks, either assigned to a member or shared by the whole household, and mark them as done.

The playful side, recurring tasks and notifications will come in later versions. For the big picture, see the [roadmap](ROADMAP.md).

## Architecture

HouseKeeper is split into two repositories:

- **housekeeper-backend** (this repository): the REST API.
- **[housekeeper-frontend](https://github.com/Fiorito-Alessio/housekeeper-frontend)**: the web interface.

## Tech stack

| Area | Technology |
| --- | --- |
| Language and framework | C# · .NET 10 · ASP.NET Core |
| Database | PostgreSQL · Entity Framework Core |
| Testing | xUnit |
| Containers | Docker · Docker Compose |
| Continuous integration | GitHub Actions |

## Getting started

### Prerequisites

- [Docker](https://www.docker.com/) with Docker Compose v2: the app only runs in containers, even in development.
- [.NET 10 SDK](https://dotnet.microsoft.com/download): only needed to build and test outside Docker (IDE, `dotnet test`). The exact version is pinned in [`global.json`](global.json).

### Running the project

1. Create your local environment file from the template, then change the password:

   ```bash
   cp .env.example .env
   ```

   `.env` is ignored by Git: never commit it.

2. Build the images and start the stack:

   ```bash
   docker compose up --build
   ```

   The database starts first; the API waits until it is healthy.

3. The API listens on <http://localhost:8080> (bound to `127.0.0.1` only, so it is not reachable from the rest of your network).

To stop the stack, press `Ctrl+C` or run `docker compose down`. Database data is kept in a Docker volume between runs; to start from an empty database, run `docker compose down -v` (this deletes all local data).

### Running the tests

```bash
dotnet test
```

## Contributing

Code, branch and commit conventions are described in [CONTRIBUTING.md](CONTRIBUTING.md).

## Background

HouseKeeper is a personal project for learning fullstack development. It also showcases real-world project practices: milestone planning, continuous integration, testing, code review and a focus on security.
