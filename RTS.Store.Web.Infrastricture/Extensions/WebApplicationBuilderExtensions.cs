namespace RTS.Store.Web.Infrastricture.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using RTS.Store.Data.Models;
    using System;
    using System.Data;
    using System.Linq;
    using System.Reflection;

    using static Common.GeneralApplicationConstants;
    public static class WebApplicationBuilderExtensions
    {


        public static void AddApplicationServices(this IServiceCollection service, Type serviceType)
        {
            Assembly? serviceAssembly = Assembly.GetAssembly(serviceType);

            if (serviceAssembly == null)
            {
                throw new InvalidOperationException("Invalid service type provieded!");
            }

            Type[] serviceTypes = serviceAssembly.GetTypes()
                .Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
                .ToArray();

            foreach (Type st in serviceTypes)
            {
                Type? interfaceType = st.GetInterface($"I{st.Name}");
                if (interfaceType == null)
                {
                    throw new InvalidOperationException($"No interface is provider for the service with name: {st.Name}");
                }

                service.AddScoped(interfaceType, st);
            }

        }

        //private static readonly IdentityRole<Guid> role = new IdentityRole<Guid>(AdminRoleName);
        public static  IApplicationBuilder SeedAdministrator(this IApplicationBuilder app)
        {
            
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();
            
            IServiceProvider serviceProvider = scopedServices.ServiceProvider;
            
            UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            
            Task.Run(async () =>
            {
                var rolExist = await roleManager.RoleExistsAsync(AdminRoleName);
                if (rolExist)
                {
                    return;
                }
            
                IdentityRole role = new IdentityRole(AdminRoleName);
            
                await roleManager.CreateAsync(role);
            
                var user = await userManager.FindByNameAsync("admin");
                if (user == null)
                {
                    user = new ApplicationUser()
                    {
                        UserName = "admin",
                        Email = "admin@example.com"
                    };
            
                    await userManager.CreateAsync(user, "admin123");
                    await userManager.AddToRoleAsync(user, role.Name);
                }
            
            })
                .GetAwaiter()
                .GetResult();
            
            return app;

        }
    }
}
