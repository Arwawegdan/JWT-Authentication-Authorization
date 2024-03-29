var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.RegisterServices(); 
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


ApplicationDbContext applicationDbContext = app.Services.CreateScope()
                                               .ServiceProvider.GetRequiredService<ApplicationDbContext>();

//applicationDbContext.Database.EnsureDeleted();
applicationDbContext.Database.Migrate();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();