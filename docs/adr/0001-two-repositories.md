# ADR 0001: Split the frontend and the backend into two repositories

- **Status:** Accepted
- **Date:** 2026-10-02

## Context

HouseKeeper is made of two applications built with different ecosystems:

- a REST API in C# / .NET 10;
- a web interface in TypeScript / React, built with Vite.

The code has to live somewhere, and two layouts are common for this kind of project. The choice is made at the very start because moving code between repositories later is costly (history, CI, issues, links).

The project is developed by a single person, first as a learning project, and is meant to be shown as a portfolio.

## Options considered

### Option 1: a single repository (monorepo)

Both applications live in one repository, for example under `backend/` and `frontend/`.

- A feature that touches both sides fits in a single pull request.
- One CI configuration, one set of conventions, one place to look.
- The CI must filter by folder to avoid rebuilding everything on each change.
- Both toolchains (.NET and Node) sit side by side at the root.

### Option 2: two repositories (polyrepo)

The frontend and the backend each have their own repository: `housekeeper-backend` and `housekeeper-frontend`.

- Each application has its own lifecycle: versions, releases and deployments are independent.
- Each CI only knows one ecosystem and stays simple.
- The boundary between the two applications is enforced: the frontend can only talk to the backend through its HTTP API.
- Each repository follows the conventions of its own ecosystem.
- Each repository showcases one skill on its own.

## Decision

We use **two separate repositories** (option 2).

- **Organization by concern:** each repository contains only what relates to its application, its code, its tooling and its conventions.
- **Independent changes:** a change to the backend or the frontend can be made, reviewed and released without necessarily affecting the other.
- **Both options are viable for a project of this size.** Neither has a decisive advantage here, and a choice had to be made early. The polyrepo was chosen because it matches the two points above; the trade-offs listed below are accepted.

## Consequences

### Positive

- Each repository has a focused CI and its own conventions.
- The API is the only link between the two applications, which keeps the architecture honest.
- Each repository can be read and evaluated on its own.

### Negative

- A feature that touches both sides requires two pull requests that must be coordinated.
- The API contract can drift between the two repositories without anything signaling it.
- Configuration is duplicated: two CI pipelines, two `CONTRIBUTING.md` files, two sets of repository settings.

### Mitigations

- Planning is centralized in a single GitHub Project spanning both repositories.
- The roadmap lives only in the backend repository, as the single source of truth.
- To prevent contract drift, the backend will publish an OpenAPI specification, and the frontend will generate its API client from it.
