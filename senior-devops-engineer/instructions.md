# Take-Home Task: Senior Software Engineer (Managed Services / DevOps)

## Background

We run a large ERP whose REST API is coupled to Windows. We are moving it, step by
step, off Windows and onto Linux containers. The interesting part of that work is not
Docker syntax; it is deciding what actually needs Windows, cutting the false
coupling, and keeping the genuinely Windows-only pieces cleanly separated instead of
silently dropping them.

The service in [`app/`](./app) is a small, honest stand-in for that situation. Your
job is to make it run in a **Linux container** and ship it through a pipeline.

Everything runs **locally**. You do **not** need an Azure account or any cloud
credentials.

## What we provide

An ASP.NET Core service (.NET 8) that builds and tests on any OS but is coupled to
Windows in three places. See [`app/README.md`](./app/README.md) for the full layout.
In short:

- The **composition root** (`ApiModuleCatalog`) constructs every module directly, so
  the shared library is dragged to `net8.0-windows` even though most of it does not
  need Windows.
- The **host** reads config from the Windows registry and logs to the Windows Event
  Log, so it cannot start on Linux.
- Two modules (`Documents` via GDI+, `Printers`) **genuinely** need Windows. One
  module (`Stats`) sits in the Windows assembly but uses **no** Windows API.

## What to build

**Required**

1. **Make the service run without Windows.** Cut the Windows coupling so it builds and
   runs on Linux. That means the registry-based configuration and the Windows Event
   Log logging have to go, and the Windows-only modules have to be separated from the
   rest. Which module stays and which does not:

   | Module | Include in the Linux build |
   | --- | --- |
   | `Items`, `Customers` | Yes |
   | `Stats` | Yes |
   | `Documents`, `Printers` | No |

   The Windows build has to stay functional: keep the excluded modules working on
   Windows, do not delete them.

2. **Package it as a Linux container** that starts and serves the kept endpoints, with
   a working health check.

**Bonus (pick one, not both)**

If you have time, do **one** of the following. Either is enough; there is no need to
do both.

- **Ship it through a pipeline.** A GitHub Actions workflow that builds, tests, and
  publishes the image.
- **Prepare it for Kubernetes.** A Helm chart that deploys the container to a local
  cluster (`kind`/`minikube`).

Do what you can well and note what you would do next. A clean slice and a running
Linux image is a strong submission on its own.

## Deliverables

- The refactored source, the `Dockerfile`, and your bonus piece if you did one (the
  workflow or the Helm chart).
- A short **README** (about half a page) with your key decisions and trade-offs: how
  you found and cut the coupling, what you kept in the Windows supplement and why, how
  config and secrets are handled, and **what would change for a real Azure production
  setup** (self-hosted runners, secret storage, registry, observability).
- A short **runbook**: how to build the image, run it (and deploy it, if you did the
  bonus), verify `/healthz`, and roll back.
- A short **reflection** (2 to 3 sentences or bullet points each):
  - **Observability**: what telemetry, metrics, and alerting you would add, and why.
  - **The exclusion list**: what you left out of the Linux image and how you would
    serve those Windows-only capabilities in a cloud world.
- An **`ai-journey/` folder** documenting how you used AI: the plan you worked from,
  your key prompts, the tools/models/skills/MCP servers you used, and where you
  overrode the output. See the [top-level README](../README.md#ai-journey-required).
  This is required and weighs significantly in the evaluation.

## Time box

Scope this to roughly **2 to 4 hours**. Going over is optional and not expected. If
you run short, deliver the slice and the Linux image well and note what you would do
next rather than rushing the bonus.

## What we evaluate

The focus is decoupling judgment and delivery-platform quality, not feature scope. We
look at:

- **A clean slice.** Is the shared library free of Windows references and building for
  Linux afterwards, with `Stats` kept and the Windows modules still working on Windows?
  Did you cut the coupling rather than `#if`-guard or stub it?
- **Container hygiene.** Multi-stage build, small image, non-root, pinned base, a
  working healthcheck.
- **The bonus, if you did one.** A readable pipeline, or a parameterized Helm chart
  with probes and limits.
- **Operability.** A runbook someone else could deploy and roll back from.
- **AI journey.** How deliberately you directed AI tools and checked their output.

## What you do NOT need to do

- No real cloud. Everything runs locally.
- No rewrite. This is a slice, not a redesign; keep the endpoints as they are.
- No production-grade secrets management. Show the approach; do not stand up a vault.
- No exhaustive test coverage. Keep the provided tests green and add one or two around
  your slice if it helps.

## Submitting

See the [top-level README](../README.md#submitting).
