using Microsoft.AspNetCore.Hosting;
using System.Diagnostics.CodeAnalysis;

namespace MicroserviceTemplate.Command
{
    /// <summary>
    /// This class extends from APIGatewayProxyFunction which contains the method FunctionHandlerAsync which is the 
    /// actual Lambda function entry point. 
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class LambdaEntryPoint :
        // When using an ELB's Application Load Balancer as the event source change 
        // the base class to Amazon.Lambda.AspNetCoreServer.ApplicationLoadBalancerFunction
        Amazon.Lambda.AspNetCoreServer.APIGatewayProxyFunction
    {
        /// <summary>
        /// The builder has configuration, logging and Amazon API Gateway already configured. The startup class
        /// needs to be configured in this method using the UseStartup<>() method.
        /// </summary>
        /// <param name="builder"></param>
        protected override void Init(IWebHostBuilder builder)
        {
            builder
                .UseStartup<Startup>();
        }
    }
}
