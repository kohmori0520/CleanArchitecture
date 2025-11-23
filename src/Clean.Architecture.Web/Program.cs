using Clean.Architecture.UseCases.Contributors.Create;
using Clean.Architecture.Web.Configurations;

var builder = WebApplication.CreateBuilder(args);

var logger = Log.Logger = new LoggerConfiguration()
  .Enrich.FromLogContext()
  .WriteTo.Console()
  .CreateLogger();

logger.Information("Starting web host");

builder.AddLoggerConfigs();

var appLogger = new SerilogLoggerFactory(logger)
    .CreateLogger<Program>();

builder.Services.AddOptionConfigs(builder.Configuration, appLogger, builder);
builder.Services.AddServiceConfigs(appLogger, builder);


builder.Services.AddFastEndpoints()
                .SwaggerDocument(o =>
                {
                  o.ShortSchemaNames = true;
                })
                .AddCommandMiddleware(c =>
                {
                  c.Register(typeof(CommandLogger<,>));
                });

// wire up commands
//builder.Services.AddTransient<ICommandHandler<CreateContributorCommand2,Result<int>>, CreateContributorCommandHandler2>();

#if (aspire)
builder.AddServiceDefaults();
#endif

var app = builder.Build();

// 🔍 デバッグ用: 重要なサービスが登録されているか確認
Console.WriteLine("\n========== DIコンテナに登録されている重要なサービス ==========");

// 直接サービスを取得して確認
try
{
  var mediator = app.Services.GetService<IMediator>();
  Console.WriteLine($"✅ IMediator: {(mediator != null ? mediator.GetType().Name : "NOT FOUND")}");

  var dbContext = app.Services.GetService<Clean.Architecture.Infrastructure.Data.AppDbContext>();
  Console.WriteLine($"✅ AppDbContext: {(dbContext != null ? dbContext.GetType().Name : "NOT FOUND")}");

  var emailSender = app.Services.GetService<Clean.Architecture.Core.Interfaces.IEmailSender>();
  Console.WriteLine($"✅ IEmailSender: {(emailSender != null ? emailSender.GetType().Name : "NOT FOUND")}");

  Console.WriteLine("\n📝 これらのサービスは builder.Services.Add... で登録されています");
  Console.WriteLine("   Endpointのコンストラクタに書くだけで自動的に注入されます！");
}
catch (Exception ex)
{
  Console.WriteLine($"❌ エラー: {ex.Message}");
}

Console.WriteLine("=============================================================\n");

await app.UseAppMiddlewareAndSeedDatabase();

app.Run();

// Make the implicit Program.cs class public, so integration tests can reference the correct assembly for host building
public partial class Program { }
