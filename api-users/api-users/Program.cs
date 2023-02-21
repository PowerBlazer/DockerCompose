var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(option => option.AddPolicy("CorsPolicy", builder =>
{
    builder.WithOrigins("http://localhost:3000");
}));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

var summaries = new[]
{
    new {Name = "Vlad"},
    new {Name= "Tonya"},
    new {Name = "Colya"}
};

app.MapGet("api/users", () =>
{
    return summaries;
});


app.Run();

