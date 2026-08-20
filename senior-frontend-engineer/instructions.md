# Take-Home Task: Senior Software Engineer (Frontend)

## The task

Build a small frontend application using **React**, **TypeScript**, and **Vite**,
organized as a **Turborepo** monorepo. It covers two connected features.

**User feature**
- A form to create a user by username.
- A detail view of a user by ID.

**ToDoItem feature**
- A form to create a ToDoItem with a title and an assignee (user ID).
- A list of all ToDoItems assigned to a given user.

## Monorepo structure

Split the codebase into clearly separated packages to demonstrate structural
thinking, for example:

- `apps/web` — the shippable application: routing, pages, composition.
- `packages/users` — User feature module: components, hooks, API calls, types.
- `packages/todos` — ToDoItem feature module: components, hooks, API calls, types.
- `packages/shared` (or `core` / `config`) — shared types, utilities, or config
  (for example the TanStack Query client setup, tsconfig, eslint config).

Rules for the boundaries:

- Feature packages must **not** depend on each other directly. Shared logic goes
  through the shared package.
- A minimal `turbo.json` pipeline (build / lint / dev) is fine. Do not invest
  heavily in caching or tooling. The package structure is what matters most.

## Technical requirements

- **React + TypeScript + Vite**, structured as a Turborepo monorepo.
- **Routing via TanStack Router** (required). Show how routes, params, and
  navigation are structured, for example `/users/:id` and `/todos`.
- **Data fetching via TanStack Query.** Backend of your choice: mock API, MSW,
  json-server, or an in-memory fake client. Handle loading and error states and
  caching sensibly.
- **Optimistic update, required specifically for creating a ToDoItem.** The new item
  appears in the list immediately on submit, with correct rollback if the mutation
  fails. This is the key UX and data-consistency signal we want to see.
- **Cross-cutting UI state via Jotai** for at least one concern, for example the
  currently selected user or an active filter.
- **Styling via TailwindCSS**, applied consistently.
- **Clean separation** of business logic, data access, and presentation, reinforced
  by the module boundaries above.
- **Basic accessibility**: semantic HTML, form labels, keyboard operability.
- **Form validation with meaningful error messages.** Library-free or something
  lightweight such as Zod. Your choice, but justify it.

## Deliverables

- The source code in your repository.
- A short **README** (about half a page) explaining your key architectural
  decisions and trade-offs, including **why you split the monorepo the way you did**.
  Write it as if you were handing this to another frontend team.
- A short **reflection** (2 to 3 sentences or bullet points each):
  - **Performance considerations** in your solution, for example re-renders, query
    caching, code-splitting.
  - **Testing strategy** you would apply if this were production code. You do not
    need to implement it, just outline what you would test and how.
- Instructions to install and run the app locally.
- An **`ai-journey/` folder** documenting how you used AI: the plan you worked from,
  your key prompts, the tools/models/skills/MCP servers you used, and where you
  overrode the output. See the [top-level README](../README.md#ai-journey-required).
  This is required and weighs significantly in the evaluation.

## Time box

Scope this to roughly **2 to 4 hours**. Going over is optional and not expected.

## What we evaluate

The focus is the quality of your architectural reasoning and module boundaries, not
feature completeness. We look at:

- **Module boundaries.** Are the feature packages independent, with shared logic
  going through the shared package rather than sideways between features?
- **Routing.** Are routes, params, and navigation structured clearly with TanStack
  Router?
- **Data and UX resilience.** Sensible loading/error/caching handling, and a correct
  optimistic create for ToDoItems with working rollback.
- **State.** Is Jotai used deliberately for cross-cutting UI state, not as a dumping
  ground?
- **Separation of concerns.** Business logic, data access, and presentation are kept
  apart.
- **Accessibility and validation.** Semantic, keyboard-operable forms with helpful
  error messages.
- **Judgment.** Your README and reflection: the trade-offs you name and how you
  justify your choices.
- **AI journey.** How deliberately you directed AI tools and checked their output,
  as shown in your `ai-journey/` folder.

## What you do NOT need to do

- No CI/CD pipeline.
- No real backend. A mock or in-memory API is expected.
- No authentication.
- No pixel-perfect or heavily designed UI. Clean and consistent is enough.
- No exhaustive test coverage. Outlining your testing strategy is what we ask for.

## Submitting

See the [top-level README](../README.md#submitting).
