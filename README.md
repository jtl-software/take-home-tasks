# JTL Take-Home Tasks

This repository holds the take-home tasks we use as one step in our hiring process.
Each task is a small, self-contained problem meant to show how you structure and
reason about real software. We care far more about clarity, structure, and judgment
than about how many features you finish.

## Which task should I do?

Do **only** the task for the role you applied for. Your contact will tell you which
one that is.

| Role | Folder | Focus |
| --- | --- | --- |
| Senior Software Engineer (Backend) | [`senior-backend-engineer/`](./senior-backend-engineer/instructions.md) | .NET modular monolith, DDD, CQRS |
| Senior Software Engineer (Frontend) | [`senior-frontend-engineer/`](./senior-frontend-engineer/instructions.md) | React + TypeScript, Turborepo, TanStack |
| Senior Software Engineer (Managed Services / DevOps) | [`senior-devops-engineer/`](./senior-devops-engineer/instructions.md) | Windows-to-Linux containerization, CI/CD |

Open the `instructions.md` in your folder. It has the full task, the requirements,
and how we evaluate it.

## How it works

1. Create your own repository from this one (see **Submitting** below).
2. Solve the task for your track in that repository.
3. Write a short README explaining your key decisions and trade-offs.
4. Add an `ai-journey/` folder documenting how you used AI (see **AI journey** below). This is required and evaluated.
5. Share the link with your contact.

We then read your solution and discuss it with you in a follow-up conversation.
You will always hear back from us.

## Ground rules

- **Time box.** Each task is scoped to roughly **2 to 4 hours**. Going over that is
  optional and not expected. A smaller, well-executed solution beats a rushed,
  complete one.
- **Scope.** Build the core the task asks for. Do not gold-plate. Each task lists
  explicitly what you do **not** need to spend time on.
- **Tools.** Use the languages, frameworks, and libraries stated in your task. Where
  the task leaves a choice open, pick what you would pick at work and say why.
- **AI tools.** Using AI assistants is allowed and encouraged. We are interested in
  *how* you use them, not whether you do. Documenting this is a required deliverable
  and a significant part of the evaluation (see **AI journey** below).
- **Purpose.** These tasks exist only to evaluate your work. Nothing you submit is
  used in our products.

## AI journey (required)

We work with AI tools every day and we want to see how you do too. Alongside your
solution, add an `ai-journey/` folder. It weighs significantly in the evaluation, on
par with the code itself.

Include:

- **The plan.** Any plan file, task breakdown, or agent plan you worked from. If your
  tool produced one, share it as-is.
- **The prompts.** The key prompts or instructions you gave, enough for us to follow
  your thinking. A raw transcript is fine; a curated `prompts.md` is better.
- **The toolchain.** A list of the AI tools, models, skills, and MCP servers you
  used, and what each was for.
- **Your judgment.** A few sentences on where AI helped, where it was wrong or
  unhelpful, and where you overrode it.

There is no "right" amount of AI. A candidate who leaned on it heavily and one who
barely touched it can both score well. What we evaluate is the judgment visible in
how you directed it and checked its output.

## Submitting

Preferred: use the green **"Use this template"** button on this repository to create
your own copy, solve the task there, and share the link with your contact. A private
repository with our reviewers invited is fine; a public one is also fine.

No GitHub account? Send a zip of your solution to your contact instead. A zip loses
your commit history, which is useful signal, so prefer a repository if you can.

Please do **not** open a pull request against this repository. Other candidates would
be able to see your solution.

## Questions

If anything is unclear, ask early. Reach out to your contact and we will respond
quickly. A good clarifying question is a positive signal, not a negative one.
