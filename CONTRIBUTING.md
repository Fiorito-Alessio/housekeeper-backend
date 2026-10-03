
# Contributing to HouseKeeper

This document describes how changes are made to this repository. It is intentionally short and will grow with the project.

## Workflow overview

1.  Every change starts from an issue.
2.  Create a branch from `main` for that issue.
3.  Open a pull request back into `main`.
4.  Squash and merge once the pull request is ready.

## Branching strategy

This project follows **GitHub Flow**:

-   `main` is the only long-lived branch. It must always be stable.
-   Each issue gets its own short-lived branch, created from `main`.
-   Direct pushes to `main` are not allowed: every change goes through a pull request.

### Branch naming

```
<type>/<issue-number>-<short-description>

```

The type uses the same values as commits (see below). The description is short, lowercase and uses hyphens.

Examples:

-   `feat/12-household-creation`
-   `fix/27-task-due-date-validation`
-   `docs/3-contributing`

## Commit strategy

Commits follow the [Conventional Commits](https://www.conventionalcommits.org/) specification:

```
<type>(<optional scope>): <description>

```

-   The description is written in English, in the imperative mood and in lowercase, with no trailing period.
-   The scope is optional and names the part of the application affected (for example `tasks`, `auth`, `households`).

### Types


| Type | Use it for |
| --- | --- |
| `feat` | A new feature |
| `fix` | A bug fix |
| `docs` | Documentation only |
| `test` | Adding or updating tests only |
| `refactor` | A code change that neither adds a feature nor fixes a bug |
| `chore` | Maintenance: tooling, configuration, dependencies |

Examples:

-   `feat(tasks): add task completion endpoint`
-   `fix(auth): reject expired invitation links`
-   `docs: add contributing guidelines`

Commits on a feature branch can be work in progress: only the pull request title ends up in the history of `main` (see below).

## Merging strategy

Pull requests are merged with **squash and merge**:

-   All commits of the branch become a single commit on `main`.
-   That commit takes the title of the pull request, so **the pull request title must follow the Conventional Commits format**.
-   The pull request description references its issue with `Closes #<issue-number>`, so the issue is closed automatically on merge.
-   The branch is deleted automatically after the merge.

This keeps the history of `main` clean: one commit per change, each one linked to an issue.
