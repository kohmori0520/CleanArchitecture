# Clean Architecture テンプレート - 日本語ガイド

このプロジェクトは、ASP.NET CoreでClean Architectureパターンを実装するための練習用テンプレートです。

## 📚 目次

- [プロジェクト概要](#プロジェクト概要)
- [Clean Architectureとは](#clean-architectureとは)
- [プロジェクト構造](#プロジェクト構造)
- [各プロジェクトの役割](#各プロジェクトの役割)
- [使用されている主要な技術](#使用されている主要な技術)
- [主要なデザインパターン](#主要なデザインパターン)
- [実行方法](#実行方法)
- [学習リソース](#学習リソース)

---

## プロジェクト概要

このテンプレートは、**Clean Architecture**と**ドメイン駆動設計（DDD）**の原則に基づいて構築されています。
スティーブ・スミス（@ardalis）氏によって作成・メンテナンスされており、.NET Coreでエンタープライズアプリケーションを構築する際のベストプラクティスを学ぶことができます。

### 主な特徴

- ✅ **疎結合な設計**: 各レイヤーが独立しており、テストが容易
- ✅ **依存性の逆転**: 依存関係が常に内側（Core）に向かう
- ✅ **SOLID原則**: メンテナンス性の高いコード
- ✅ **.NET 9対応**: 最新のC#機能を活用
- ✅ **実践的なサンプル**: `sample/`フォルダに実装例を収録

---

## Clean Architectureとは

Clean Architectureは、以下のような別名でも知られています：
- ヘキサゴナルアーキテクチャ（Hexagonal Architecture）
- ポート＆アダプターパターン（Ports and Adapters）
- オニオンアーキテクチャ（Onion Architecture）

### 基本原則

1. **依存性の方向**: 外側のレイヤーは内側のレイヤーに依存するが、逆はない
2. **ビジネスロジックの保護**: ドメインロジックはインフラの詳細から独立
3. **テスタビリティ**: UIやDBなしでビジネスロジックをテスト可能
4. **柔軟性**: フレームワークやデータベースの変更が容易

```
┌────────────────────────────────────┐
│         Web (UI/API)               │  ← 外側：ユーザーインターフェース
├────────────────────────────────────┤
│      Infrastructure                │  ← 外側：外部システムとの接続
├────────────────────────────────────┤
│        Use Cases                   │  ← 中間：アプリケーションロジック
├────────────────────────────────────┤
│    Core (Domain Model)             │  ← 中心：ビジネスロジック
└────────────────────────────────────┘
     ↑ すべての依存関係がこちらに向かう
```

---

## プロジェクト構造

```
CleanArchitect/
├── src/                                    # メインプロジェクト
│   ├── Clean.Architecture.Core/            # ドメインモデル（中心）
│   ├── Clean.Architecture.UseCases/        # ユースケース層
│   ├── Clean.Architecture.Infrastructure/  # インフラ層
│   ├── Clean.Architecture.Web/             # Web API層
│   └── Clean.Architecture.AspireHost/      # .NET Aspireホスト
│
├── sample/                                 # サンプル実装（ToDoアプリ）
│   ├── src/
│   │   ├── NimblePros.SampleToDo.Core/
│   │   ├── NimblePros.SampleToDo.UseCases/
│   │   ├── NimblePros.SampleToDo.Infrastructure/
│   │   └── NimblePros.SampleToDo.Web/
│   └── tests/                              # サンプルのテスト
│
├── tests/                                  # テストプロジェクト
│   ├── Clean.Architecture.UnitTests/       # 単体テスト
│   ├── Clean.Architecture.IntegrationTests/ # 統合テスト
│   └── Clean.Architecture.FunctionalTests/  # 機能テスト
│
└── docs/                                   # ドキュメント
    └── architecture-decisions/             # アーキテクチャ決定記録（ADR）
```

---

## 各プロジェクトの役割

### 🎯 Clean.Architecture.Core（中心層）

**役割**: ビジネスロジックとドメインモデルの定義

**含まれるもの**:
- **エンティティ（Entities）**: ビジネスの中心となるオブジェクト
  - 例: `Contributor.cs` - 貢献者を表すエンティティ
- **集約（Aggregates）**: 関連するエンティティのグループ
- **値オブジェクト（Value Objects）**: 不変のドメインオブジェクト
  - 例: `PhoneNumber` - 電話番号を表す値オブジェクト
- **ドメインイベント（Domain Events）**: ドメイン内で発生する重要なイベント
- **仕様（Specifications）**: エンティティのクエリ条件を定義
- **インターフェース**: 外部依存の抽象化

**重要**: 
- 外部への依存を**一切持たない**
- Entity FrameworkやASP.NET Coreへの参照は含まれない
- すべてのプロジェクトがこのプロジェクトに依存する

### 📋 Clean.Architecture.UseCases（アプリケーション層）

**役割**: アプリケーションの具体的なユースケースを実装

**含まれるもの**:
- **Commands（コマンド）**: データを変更する操作
  - 例: `CreateContributorCommand` - 新しい貢献者を作成
- **Queries（クエリ）**: データを読み取る操作
  - 例: `ListContributorsQuery` - 貢献者一覧を取得
- **ハンドラ**: 各コマンド/クエリの処理ロジック
- **DTOs**: データ転送オブジェクト

**特徴**:
- **CQRS**パターンに従って整理
- UIやインフラに依存しないため、テストが容易
- MediatRを使用してハンドラを実行

### 🔧 Clean.Architecture.Infrastructure（インフラ層）

**役割**: 外部システムとの統合と技術的な実装

**含まれるもの**:
- **データアクセス**: Entity Framework Core実装
  - `AppDbContext.cs` - データベースコンテキスト
  - `EfRepository.cs` - リポジトリの実装
- **外部サービス**: メール送信、ファイルアクセスなど
  - `MimeKitEmailSender.cs` - メール送信の実装
- **設定**: 依存性注入の構成

**重要**: 
- Coreプロジェクトで定義されたインターフェースを実装
- 具体的な技術（EF Core、SendGrid等）に依存

### 🌐 Clean.Architecture.Web（プレゼンテーション層）

**役割**: HTTP APIエンドポイントの公開

**含まれるもの**:
- **API Endpoints**: FastEndpointsを使用
  - `ContributorCreate.cs` - 貢献者作成エンドポイント
  - `ContributorGetById.cs` - 貢献者取得エンドポイント
- **リクエスト/レスポンス型**: **REPRパターン**を採用
- **Program.cs**: アプリケーションのエントリーポイント
- **設定ファイル**: `appsettings.json`

**特徴**:
- FastEndpointsによる高速でシンプルなAPI構築
- Swagger/OpenAPI対応
- バリデーションはFluentValidationで実施

---

## 使用されている主要な技術

### フレームワーク・ライブラリ

| 技術 | 用途 | プロジェクト |
|------|------|--------------|
| **.NET 9** | 基盤フレームワーク | 全体 |
| **FastEndpoints** | APIエンドポイント | Web |
| **MediatR** | CQRS実装 | UseCases |
| **Entity Framework Core** | データアクセス（ORM） | Infrastructure |
| **Ardalis.Specification** | リポジトリパターン | Core/Infrastructure |
| **Ardalis.GuardClauses** | 入力検証 | Core |
| **Ardalis.Result** | 結果パターン | UseCases |
| **Ardalis.SmartEnum** | タイプセーフな列挙型 | Core |
| **Serilog** | ロギング | Web |
| **FluentValidation** | バリデーション | Web |
| **xUnit** | テストフレームワーク | Tests |

### デザインパターン

- **Repository Pattern**: データアクセスの抽象化
- **Specification Pattern**: クエリロジックのカプセル化
- **CQRS**: コマンドとクエリの分離
- **REPR Pattern**: Request-Endpoint-Response（FastEndpoints）
- **Domain Events**: ドメイン内のイベント駆動設計
- **Dependency Injection**: 依存性の注入

---

## 主要なデザインパターン

### 1. ドメインイベント（Domain Events）

エンティティ内で重要なイベントが発生した際に、他のコンポーネントに通知する仕組み。

**例**: `Contributor`が削除されたときにメール通知を送る

```csharp
// Core/ContributorAggregate/Events/ContributorDeletedEvent.cs
public class ContributorDeletedEvent : DomainEventBase
{
  public int ContributorId { get; set; }
}

// Core/ContributorAggregate/Handlers/ContributorDeletedHandler.cs
public class ContributorDeletedHandler : INotificationHandler<ContributorDeletedEvent>
{
  public async Task Handle(ContributorDeletedEvent domainEvent, CancellationToken cancellationToken)
  {
    // メール送信などの処理
    logger.LogInformation("Contributor {id} was deleted.", domainEvent.ContributorId);
  }
}
```

### 2. Specificationパターン

再利用可能なクエリ条件を定義する。

```csharp
// Core/ContributorAggregate/Specifications/ContributorByIdSpec.cs
public class ContributorByIdSpec : Specification<Contributor>
{
  public ContributorByIdSpec(int contributorId)
  {
    Query.Where(contributor => contributor.Id == contributorId);
  }
}

// 使用例
var spec = new ContributorByIdSpec(id);
var contributor = await repository.FirstOrDefaultAsync(spec);
```

### 3. CQRSパターン

コマンド（書き込み）とクエリ（読み取り）を分離。

```csharp
// UseCases/Contributors/Create/CreateContributorCommand.cs
public record CreateContributorCommand(string Name) : ICommand<Result<int>>;

// UseCases/Contributors/List/ListContributorsQuery.cs
public record ListContributorsQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<ContributorDTO>>>;
```

### 4. Repositoryパターン

データアクセスを抽象化し、ドメインモデルから技術的な詳細を隠蔽。

```csharp
// Core/Interfaces/IRepository.cs (Ardalis.SharedKernelで定義)
public interface IRepository<T> where T : IAggregateRoot
{
  Task<T?> GetByIdAsync<TId>(TId id);
  Task<List<T>> ListAsync();
  Task<T> AddAsync(T entity);
  Task UpdateAsync(T entity);
  Task DeleteAsync(T entity);
}
```

---

## 実行方法

### 前提条件

- .NET 9 SDK以上
- お好みのIDE（Visual Studio、Rider、VS Codeなど）
- （オプション）Docker（データベース用）

### ステップ1: プロジェクトの実行

```bash
# Webプロジェクトのディレクトリに移動
cd src/Clean.Architecture.Web

# アプリケーションを実行
dotnet run
```

アプリケーションが起動したら、ブラウザで以下にアクセス：
- API: `https://localhost:7010/api/contributors`
- Swagger UI: `https://localhost:7010/swagger`

### ステップ2: サンプルプロジェクトの実行

```bash
# サンプルWebプロジェクトに移動
cd sample/src/NimblePros.SampleToDo.Web

# 実行
dotnet run
```

### ステップ3: テストの実行

```bash
# すべてのテストを実行
dotnet test

# 特定のテストプロジェクトを実行
cd tests/Clean.Architecture.UnitTests
dotnet test
```

### データベースマイグレーション

```bash
# マイグレーションの追加
dotnet ef migrations add InitialCreate -c AppDbContext \
  -p ../Clean.Architecture.Infrastructure/Clean.Architecture.Infrastructure.csproj \
  -s Clean.Architecture.Web.csproj -o Data/Migrations

# データベースの更新
dotnet ef database update -c AppDbContext \
  -p ../Clean.Architecture.Infrastructure/Clean.Architecture.Infrastructure.csproj \
  -s Clean.Architecture.Web.csproj
```

---

## 学習リソース

### 推奨される学習順序

1. **基礎を理解する**
   - SOLID原則を学ぶ
   - Clean Architectureの概念を理解する
   
2. **このプロジェクトを探索する**
   - `sample/`フォルダのToDoアプリを確認
   - 各レイヤーの役割を理解する
   
3. **実装を試す**
   - 新しいエンティティを追加してみる
   - CRUDエンドポイントを作成してみる
   
4. **応用する**
   - 独自のプロジェクトでテンプレートを使用

### 参考リンク

**Clean Architecture関連**:
- [Clean Architectureについて（Uncle Bob）](https://8thlight.com/blog/uncle-bob/2012/08/13/the-clean-architecture.html)
- [DDD Fundamentalsコース（Pluralsight）](https://www.pluralsight.com/courses/fundamentals-domain-driven-design)

**SOLID原則**:
- [SOLID Principles for C# Developers](https://www.pluralsight.com/courses/csharp-solid-principles)

**その他の資料**:
- [元のGitHubリポジトリ](https://github.com/ardalis/CleanArchitecture)
- [NimblePros Academy - Clean Architectureコース](https://academy.nimblepros.com/p/learn-clean-architecture)

### 使用されているNuGetパッケージ

- [Ardalis.ApiEndpoints](https://github.com/ardalis/apiendpoints)
- [Ardalis.GuardClauses](https://github.com/ardalis/guardclauses)
- [Ardalis.Result](https://github.com/ardalis/result)
- [Ardalis.SharedKernel](https://github.com/ardalis/Ardalis.SharedKernel)
- [Ardalis.SmartEnum](https://github.com/ardalis/SmartEnum)
- [Ardalis.Specification](https://github.com/ardalis/specification)
- [FastEndpoints](https://fast-endpoints.com/)

---

## コードの読み方

### サンプルエンティティの例

```csharp
// Core/ContributorAggregate/Contributor.cs
public class Contributor : EntityBase, IAggregateRoot
{
  // コンストラクタで必須項目を初期化
  public Contributor(string name)
  {
    UpdateName(name);
  }
  
  // プロパティはprivate set（カプセル化）
  public string Name { get; private set; } = default!;
  public ContributorStatus Status { get; private set; } = ContributorStatus.NotSet;
  public PhoneNumber? PhoneNumber { get; private set; }
  
  // 状態変更はメソッドを通じて行う
  public Contributor UpdateName(string newName)
  {
    // GuardClausesで入力検証
    Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
    return this;
  }
}

// 値オブジェクトの例
public class PhoneNumber(string countryCode, string number, string? extension) : ValueObject
{
  public string CountryCode { get; private set; } = countryCode;
  public string Number { get; private set; } = number;
  public string? Extension { get; private set; } = extension;
  
  // 等価性の定義
  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return CountryCode;
    yield return Number;
    yield return Extension ?? String.Empty;
  }
}
```

### API Endpointの例

```csharp
// Web/Contributors/ContributorCreate.cs
public class ContributorCreate(IMediator mediator) 
  : Endpoint<CreateContributorRequest, CreateContributorResponse>
{
  public override void Configure()
  {
    Post("/api/contributors");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CreateContributorRequest req, CancellationToken ct)
  {
    var command = new CreateContributorCommand(req.Name);
    var result = await mediator.Send(command);
    
    if (result.IsSuccess)
    {
      await SendCreatedAtAsync<ContributorGetById>(
        new { id = result.Value },
        new CreateContributorResponse { Id = result.Value },
        cancellation: ct);
    }
    else
    {
      await SendNotFoundAsync(ct);
    }
  }
}
```

---

## バリデーションについて

このプロジェクトでは、**防御的プログラミング**の観点から複数の場所でバリデーションを実施します。

### バリデーションの階層

1. **APIエンドポイント（Web）**
   - FluentValidationを使用してリクエストを検証
   - ユーザー入力の基本的なチェック

2. **ユースケース（UseCases）**
   - MediatRパイプラインでコマンド/クエリを検証
   - ビジネスルールの確認

3. **ドメインモデル（Core）**
   - GuardClausesを使用して不正な状態を防止
   - 不変条件（Invariants）の維持

```csharp
// 1. Web層でのバリデーション（FluentValidation）
public class CreateContributorRequestValidator : Validator<CreateContributorRequest>
{
  public CreateContributorRequestValidator()
  {
    RuleFor(x => x.Name)
      .NotEmpty()
      .MinimumLength(2);
  }
}

// 2. Core層での防御（GuardClauses）
public Contributor UpdateName(string newName)
{
  Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
  return this;
}
```

---

## よくある質問（FAQ）

### Q1: Controllers や Razor Pagesは使えますか？

**A**: はい、可能です。このテンプレート（バージョン9以降）はFastEndpointsをデフォルトで使用していますが、Controllersや Razor Pagesも追加できます。

```csharp
// Program.csに追加
builder.Services.AddControllers();
app.MapControllers();

// またはRazor Pages
builder.Services.AddRazorPages();
app.MapRazorPages();
```

### Q2: UseCasesプロジェクトは必須ですか？

**A**: いいえ、シンプルなプロジェクトでは省略可能です。その場合、ロジックをWebプロジェクトに直接配置できます。ただし、以下のメリットがあります：
- テストが容易
- UIから独立したビジネスロジック
- 横断的関心事（ロギング、キャッシュ等）の適用が容易

### Q3: どのデータベースを使えますか？

**A**: デフォルトはSQLiteですが、SQL Server、PostgreSQL、MySQLなど、Entity Framework Coreがサポートするすべてのデータベースが使用可能です。

```csharp
// SQL Serverに変更する例
// InfrastructureServiceExtensions.cs
options.UseSqlServer(connectionString);
```

### Q4: SharedKernelとは何ですか？

**A**: 複数のプロジェクト（境界づけられたコンテキスト）で共有される共通コードです。このテンプレートでは、[Ardalis.SharedKernel](https://github.com/ardalis/Ardalis.SharedKernel) NuGetパッケージを使用しています。

独自のSharedKernelが必要な場合は、別プロジェクトとして作成し、NuGetパッケージとして配布することが推奨されます。

---

## プロジェクトの拡張例

### 新しいエンティティの追加

1. **Coreプロジェクト**にエンティティを作成
```csharp
// Core/ProjectAggregate/Project.cs
public class Project : EntityBase, IAggregateRoot
{
  public Project(string name)
  {
    Name = Guard.Against.NullOrEmpty(name);
  }
  
  public string Name { get; private set; }
}
```

2. **UseCasesプロジェクト**にコマンド/クエリを追加
```csharp
// UseCases/Projects/CreateProject.cs
public record CreateProjectCommand(string Name) : ICommand<Result<int>>;
```

3. **Webプロジェクト**にエンドポイントを追加
```csharp
// Web/Projects/ProjectCreate.cs
public class ProjectCreate : Endpoint<CreateProjectRequest, CreateProjectResponse>
{
  // エンドポイントの実装
}
```

4. **Infrastructureプロジェクト**でDBContextを更新
```csharp
// Infrastructure/Data/AppDbContext.cs
public DbSet<Project> Projects => Set<Project>();
```

---

## まとめ

このClean Architectureテンプレートは、以下を学ぶための優れた出発点です：

✅ **Clean Architectureの原則**  
✅ **ドメイン駆動設計（DDD）**  
✅ **SOLID原則の実践**  
✅ **.NET Coreのベストプラクティス**  
✅ **テスタブルなコード設計**  

### 次のステップ

1. `sample/`フォルダのToDoアプリを実行して動作を確認
2. 既存のコードを読んで各パターンの使い方を理解
3. 新しいエンティティやユースケースを追加して実践
4. 学習リソースで理論を深める
5. 独自のプロジェクトでこのテンプレートを活用

---

## ライセンス

このプロジェクトはMITライセンスの下で公開されています。

## クレジット

- **作者**: Steve Smith ([@ardalis](https://twitter.com/ardalis))
- **組織**: [NimblePros](https://nimblepros.com/)
- **元のリポジトリ**: [https://github.com/ardalis/CleanArchitecture](https://github.com/ardalis/CleanArchitecture)

---

📝 **注意**: このドキュメントは学習目的で作成された日本語の解説です。最新の情報は[公式リポジトリ](https://github.com/ardalis/CleanArchitecture)を参照してください。

