using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace WebAPI.Core.Context
{
    [ExcludeFromCodeCoverage]
    public class ContextGenerator : IContextGenerator
    {
        private readonly IConfiguration _configuration;
        private readonly ILoggerFactory _loggerFactory;        

        public ContextGenerator(ILoggerFactory loggerFactory, IConfiguration configuration)
        {
            _loggerFactory = loggerFactory;
            _configuration = configuration;
        }
  

        public ChangeLogContext GenerateContext()
        {
            var connection = _configuration.GetConnectionString("ChangeLogConnection");

            var builder = new DbContextOptionsBuilder()
                    .UseLoggerFactory(_loggerFactory)
                    .EnableSensitiveDataLogging()
                    .UseSqlServer(connection)
                ;

            return new ChangeLogContext(builder.Options);
        }
    }
}
