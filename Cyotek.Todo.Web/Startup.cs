using Cyotek.Todo.Data;
using Cyotek.Todo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cyotek.Todo
{
  public class Startup
  {
    #region Constructors

    public Startup(IConfiguration configuration)
    {
      this.Configuration = configuration;
    }

    #endregion

    #region Properties

    public IConfiguration Configuration { get; }

    #endregion

    #region Methods

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseDatabaseErrorPage();
      }
      else
      {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseCookiePolicy();

      app.UseAuthentication();

      app.UseMvc();
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.Configure<CookiePolicyOptions>(options =>
                                              {
                                                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                                                options.CheckConsentNeeded = context => true;
                                                options.MinimumSameSitePolicy = SameSiteMode.None;
                                              });

      services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(this.Configuration.GetConnectionString("DefaultConnection")));

      services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

      services.AddScoped<ITodoItemService, TodoItemService>();

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    }

    #endregion
  }
}
