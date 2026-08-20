# Take-Home Task: Senior Software Engineer (Backend)

## The task

Build a small .NET service organized as a **Modular Monolith**, using
**FastEndpoints**, **CQRS**, and **Domain-Driven Design (DDD)**.

The system has two modules that expose the following APIs.

**User module**
- Create a user by username.
- Retrieve a user by their ID.

**WorkItem module**
- Create a work item with a name and an assignee (user ID).
- Retrieve all work items assigned to a given user ID.

## Technical requirements

- Built on **.NET 8**.
- **FastEndpoints** for the API layer.
- **DDD-oriented** design.
- **CQRS** (choice of library is up to you).
- Free choice of database. In-memory is fine.

## Deliverables

- The source code in your repository.
- A short **README** (about half a page) that explains your key architectural
  decisions and trade-offs: how you drew the module boundaries, how commands and
  queries flow through the system, and anything you would do differently with more
  time.
- Instructions to build and run the service locally, plus how to exercise the four
  endpoints (for example via `.http` file, curl, or Swagger).
- An **`ai-journey/` folder** documenting how you used AI: the plan you worked from,
  your key prompts, the tools/models/skills/MCP servers you used, and where you
  overrode the output. See the [top-level README](../README.md#ai-journey-required).
  This is required and weighs significantly in the evaluation.

## Time box

Scope this to roughly **2 to 4 hours**. Going over is optional and not expected.

## What we evaluate

The focus is architectural quality and clarity, not feature scope. We look at:

- **Module boundaries.** Are the two modules genuinely separated, with clear
  contracts between them and no leaking of internals?
- **DDD.** Are domain concepts modeled deliberately (entities, value objects,
  invariants) rather than as anemic data bags?
- **CQRS.** Is the command/query split clean and consistent?
- **FastEndpoints usage.** Are endpoints thin, with logic pushed into the right
  layer?
- **Maintainability and testability.** Could another engineer extend this and write
  tests against it without fighting the structure?
- **Clarity.** Naming, project/folder layout, and a README that makes the design
  legible.
- **AI journey.** How deliberately you directed AI tools and checked their output,
  as shown in your `ai-journey/` folder.

## What you do NOT need to do

- No authentication, authorization, or user management beyond the two endpoints.
- No CI/CD pipeline.
- No production concerns like logging infrastructure, metrics, or containerization.
- No exhaustive test coverage. A few tests that show how you would test the design
  are worth more than chasing a coverage number.
- No UI.

## Submitting

See the [top-level README](../README.md#submitting).
