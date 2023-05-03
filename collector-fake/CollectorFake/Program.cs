using CollectorFake.Jobs;

namespace CollectorFake
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddHostedService<FakeCollector>();

            builder.Configuration.AddEnvironmentVariables();

            var app = builder.Build();

            app.MapControllers();
            app.Run();
        }
    }
}