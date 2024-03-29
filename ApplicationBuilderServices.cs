namespace JWTAuthenticationAuthorization;

public static class ApplicationBuilderServices
{
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        builder.RegisterSqlDatabase();
        builder.RegisterRepositories();
        builder.RegisterJWTServices();
        builder.RegisterIdentityServices();

    }


    public static void RegisterSqlDatabase(this WebApplicationBuilder builder)
    { 
        string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        if (connectionString == null) return; 

        builder.Services.AddDbContext<ApplicationDbContext>(c =>
                       c.UseSqlServer(connectionString));
    }


    public static void RegisterRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IMailKitService, MailKitService>();
    }

    public static void RegisterJWTServices(this WebApplicationBuilder builder)
    {

        JwtOptions jwtOption = builder.Configuration.GetSection("Jwt").Get<JwtOptions>();
        builder.Services.AddSingleton(jwtOption);

        builder.Services.AddAuthentication().AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
        {
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidIssuer = jwtOption.Issuer,

                ValidateAudience = true,
                ValidAudience = jwtOption.Audience,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOption.SigningKey)),
            };
        });

    }

    public static void RegisterIdentityServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                 .AddEntityFrameworkStores<ApplicationDbContext>()
                 .AddDefaultTokenProviders();

        builder.Services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequiredLength = 8;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.SignIn.RequireConfirmedEmail = true;
        });

        EmailConfigurations emailConfigurations = builder.Configuration.GetSection("emailConfigurations").Get<EmailConfigurations>();
        builder.Services.AddSingleton(emailConfigurations);
    }
}
