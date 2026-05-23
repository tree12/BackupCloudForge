# Aigner — EDIFACT Integration System

A .NET Core Web API that bridges **KTM** (motorcycle manufacturer) and supplier **Aigner GmbH** by translating between business application data and the **UN/EDIFACT D96A** standard. Users continue to work inside their existing accounting / ERP system; the API handles all EDIFACT encoding, decoding, validation, persistence, and transmission transparently.

All source code lives under the [`aigner/`](aigner/) folder.

> Reference: [Project description](https://montree-dev.netlify.app/html/edifact)

---

## 1. Problem It Solves

UN/EDIFACT is an internationally recognized standard for electronic business documents, but the raw payload is not human-readable and is hard to author or edit by hand. This system:

- Accepts inbound EDIFACT messages from KTM, parses them, validates them, and stores them as structured business entities in SQL Server.
- Lets users read and edit those entities through their normal business tools.
- On demand, rebuilds valid EDIFACT messages from the stored entities and sends them back to KTM (via the Ecosio EDI hub).
- Removes the need for end-users to understand EDIFACT segments, qualifiers, or code lists.

---

## 2. Supported Message Types (EDIFACT D96A)

| Code     | Direction        | Purpose                                      |
| -------- | ---------------- | -------------------------------------------- |
| `ORDERS` | Inbound          | Purchase Order from KTM                      |
| `ORDCHG` | Inbound          | Purchase Order Change                        |
| `DELFOR` | Inbound          | Delivery Schedule / JIT call-off             |
| `ORDRSP` | Outbound         | Purchase Order Response / Confirmation       |
| `DESADV` | Outbound         | Despatch Advice (ASN)                        |
| `INVOIC` | Outbound         | Invoice                                      |

Each message type is mapped to a dedicated entity (`EdiOrder`, `EdiOrderChange`, `EdiScheduleAgreement`, `EdiOrderConfirmation`, `EdiDeliveryNote`, `EdiInvoice`) that inherits from a common `EdiMasterMessage` base.

---

## 3. Architecture

```
            ┌───────────────────┐                ┌───────────────────┐
            │       KTM         │                │  Ecosio EDI Hub   │
            │ (sender/receiver) │ ◀──EDIFACT──▶  │                   │
            └─────────▲─────────┘                └─────────▲─────────┘
                      │                                    │
                      │ HTTPS POST (EDIFACT body)          │ HTTPS POST
                      │                                    │
            ┌─────────┴────────────────────────────────────┴─────────┐
            │                   EDI.Web (ASP.NET Core)               │
            │  ┌────────────────────────────────────────────────┐    │
            │  │ EdiController                                  │    │
            │  │  • POST  /api/Edi  → parse + persist           │    │
            │  │  • GET   /api/Edi/downloadEdiFile              │    │
            │  │  • Auth (Basic / token)                        │    │
            │  └───────────────┬────────────────────────────────┘    │
            │  ┌───────────────┴──────────┐  ┌──────────────────┐    │
            │  │ EdifactReader (EdiFabric)│  │ Background Job   │    │
            │  │  parse + validate D96A   │  │  watches status  │    │
            │  └───────────────┬──────────┘  │  = "TO_SEND" and │    │
            │                  │             │  sends to Ecosio │    │
            │  ┌───────────────┴──────────┐  └──────────────────┘    │
            │  │ EdiService               │                          │
            │  │  map ↔ domain entities   │                          │
            │  └───────────────┬──────────┘                          │
            └──────────────────┼─────────────────────────────────────┘
                               │ EF Core
                       ┌───────┴───────┐
                       │  SQL Server   │
                       │  (Aigner2 DB) │
                       └───────────────┘
```

### Inbound flow

1. KTM (or the Ecosio hub) posts an EDIFACT payload to `POST /api/Edi`.
2. The request is logged to the database (`RequestLog`).
3. `EdifactReader` from EdiFabric parses the stream, validates against the D96A templates, and yields `IEdiItem` objects.
4. The `UNB` / `UNZ` envelope is checked, the message type (`TSORDERS`, `TSORDCHG`, `TSDELFOR`, `TSORDRSP`, `TSDESADV`, `TSINVOIC`) is detected, and the message is converted into the matching domain entity.
5. The entity is saved with `Status = RECEIVED`.

### Outbound flow

1. A background service polls entities whose status is `TO_SEND` at a configurable interval (`AdjustEdiStatus.IntervalInSeconds`).
2. For each one, `CreateEdiDocument()` rebuilds a valid EDIFACT message from the stored data.
3. `ConvertEdiFact.WriteFile(...)` produces the wire-format file, which is transmitted to the configured Ecosio endpoint.
4. `GET /api/Edi/downloadEdiFile` lets an operator pull a ZIP archive of generated EDIFACT files for inspection.

### Reference data

Code lists (qualifiers, units of measure, etc.) embedded in the EDIFACT specification are extracted via regex and seeded into the database, so the UI can display human-readable labels alongside raw codes.

---

## 4. Repository Layout

Everything below lives under [`aigner/`](aigner/).

```
aigner/
├─ Aigner.sln                 Main solution (EDI Web API + supporting projects)
├─ AignerTest.sln             Test-harness solution
├─ CSActiveX.sln              C# ActiveX solution
│
├─ EDI/                       EDIFACT integration — the core of the system
│  ├─ EDI.Web/                ASP.NET Core Web API (EdiController, Startup, Services, Models)
│  ├─ EDI.App/                Companion console application
│  ├─ EDI.DataAccess/         EF Core entities (EdiOrder, EdiInvoice, EdiScheduleAgreement, …)
│  ├─ EDI.Web.Test/           Integration / unit tests for the Web API
│  ├─ EDI Templates/          EdiFabric message templates (EDIFACT, EANCOM, HIPAA, X12, VDA, …)
│  ├─ DLLs/                   EdiFabric runtime DLLs per target framework
│  ├─ Data/                   Sample EDIFACT message files (orders, ordchg, ordrsp, delfor, invoic)
│  ├─ EdiFabric.10.2.1.nupkg  EdiFabric package
│  └─ eula.pdf                EdiFabric license
│
├─ AignerDLL/                 Shared utility library
│  ├─ DB/                     DB base classes (DBBase, DBBaseObject, FileTable)
│  ├─ DataObjects/            Attribute-based ORM helpers (Field, PrimaryKey, AutoID, Table)
│  └─ Service/                FileService, MailService
│
├─ AignerTest/                WinForms test harness
├─ Console/                   Standalone console utilities
├─ FileMgr/                   WinForms file-manager (file properties, open-with dialog, etc.)
├─ ActiveX/                   Legacy ActiveX components (with its own solution and Setup project)
├─ CSActiveX/                 C# ActiveX control
└─ packages/                  NuGet package cache (legacy projects)
```

The EDIFACT system is rooted at [`aigner/EDI/`](aigner/EDI/). The other projects in `aigner/` are supporting tools and shared infrastructure used by the Aigner desktop environment.

---

## 5. Technology Stack

- **.NET 7** (with .NET 5 build targets retained for some sub-projects)
- **ASP.NET Core** Web API
- **Entity Framework Core** with **SQL Server**
- **[EdiFabric](https://edifabric.com/)** (commercial library, v10.2.1) — EDIFACT parsing, validation, and serialization against the D96A template set
- **log4net** — application logging
- **Microsoft.Extensions.Hosting** — background service for outbound dispatch
- **Dependency injection** throughout (services registered in `Startup`)
- Basic authentication header → bearer-style token verification for the Ecosio integration

---

## 6. Configuration

[`aigner/EDI/EDI.Web/appsettings.json`](aigner/EDI/EDI.Web/appsettings.json) drives runtime behaviour:

| Key                                       | Purpose                                                          |
| ----------------------------------------- | ---------------------------------------------------------------- |
| `ConnectionStrings:DBConnectionString`    | SQL Server connection (database `Aigner2`)                       |
| `UserInfo[]`                              | API users + per-user Ecosio `SendInfo` (URL, username, password) |
| `EdiConfig:EdiSecretKey`                  | EdiFabric license / serial key                                   |
| `EdiConfig:EcosioUrl`                     | Default Ecosio hub URL                                           |
| `EdiConfig:UserName` / `Password`         | Default Ecosio credentials                                       |
| `AdjustEdiStatus:IntervalInSeconds`       | Outbound polling interval (default 300 s)                        |
| `Logging:LogLevel`                        | Log levels per category                                          |

> **Note:** the committed file contains sample credentials and a sample license key. Override them with environment variables or a local `appsettings.Development.json` before running in any shared environment.

---

## 7. Getting Started

### Prerequisites

- Windows with Visual Studio 2022 (or `dotnet` 7 SDK)
- SQL Server (Express or full) reachable from the API host
- A valid **EdiFabric** license key (set via `EdiConfig:EdiSecretKey`)
- An Ecosio account if you want to exercise outbound transmission

### Build

```powershell
# from the repository root
dotnet restore aigner/Aigner.sln
dotnet build   aigner/Aigner.sln -c Debug
```

Or open [`aigner/Aigner.sln`](aigner/Aigner.sln) in Visual Studio and build.

### Database

1. Create an empty database (default name: `Aigner2`) on your SQL Server instance.
2. Point `ConnectionStrings:DBConnectionString` at it.
3. EF Core migrations create the required tables on first run.

### Run the Web API

```powershell
dotnet run --project aigner/EDI/EDI.Web/EDI.Web.csproj
```

The API listens on the URLs configured in `launchSettings.json` / `appsettings.json`.

### Key Endpoints

| Method | Route                          | Description                                                            |
| ------ | ------------------------------ | ---------------------------------------------------------------------- |
| POST   | `/api/Edi`                     | Receive an inbound EDIFACT payload from KTM (authenticated)            |
| POST   | `/api/Edi/testAuthentication`  | Validate username / password against configured users                  |
| POST   | `/api/Edi/testTokenFromWeb`    | Acquire a token from the configured Ecosio endpoint                    |
| GET    | `/api/Edi/downloadEdiFile`     | Regenerate EDIFACT files from stored entities and download as a ZIP    |

All non-`AllowAnonymous` endpoints require an authenticated principal (configured via the `UserInfo` list).

---

## 8. Testing

- Sample EDIFACT messages live in [`aigner/EDI/Data/`](aigner/EDI/Data/):
  - `orders-d.96a-ktm_1_0.txt`
  - `ordchg-d.96a-ktm_1_0.txt`
  - `ordrsp-d.96a-ktm_1_0.txt`
  - `delfor-d.96a-ktm_1_0.txt`
  - `invoic-d.96a-ktm_1_0.txt`
- The `EDI.Web.Test` project contains the automated test suite. Run with:

  ```powershell
  dotnet test aigner/EDI/EDI.Web.Test/EDI.Web.Test.csproj
  ```

- `AignerTest` provides a WinForms harness for manual exploration of the parsing / file-generation utilities.

---

## 9. Project Status

- Active development branch: `AddFreeTextTo10` (extends free-text handling on line items).
- Production runtime: ASP.NET Core on Windows; SQL Server back-end.
- EdiFabric template set: `EdiFabric.Templates.Edifact` (D96A).
