var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();


app.Use(async (Context, next) =>
{
    app.Logger.LogInformation("Inline Middleware 1 start");
    await next(Context);
    app.Logger.LogInformation("Inline Middleware 1 End");
});

app.Use(async (Context, next) =>
{
    app.Logger.LogInformation("Inline Middleware 2 start");
    await next(Context);

    app.Logger.LogInformation("Inline Middleware 2 End");
});


app.Run();
