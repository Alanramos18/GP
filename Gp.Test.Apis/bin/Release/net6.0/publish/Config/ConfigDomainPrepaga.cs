namespace Gp.EndPoint.Repository.Config
{
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using Gp.EndPoint.Entity;
    using Microsoft.Extensions.DependencyInjection;
    using Gp.EndPoint.Repository.Context;

    public class ConfigDomainPrepaga
    {
        public static void ConfigurationDomain(IServiceProvider serviceProvider,string jsonData, IConfiguration configuration)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
                List<EndPoint>? endPointItems = JsonConvert.DeserializeObject<List<EndPoint>>(jsonData, settings);

                using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    EndPointContext? context = serviceScope.ServiceProvider.GetService<EndPointContext>();
                
                    if (context != default && endPointItems != default)
                    {
                        context.AddRange(endPointItems);
                        context.SaveChanges();
                    }
                }
        }
    }
}
