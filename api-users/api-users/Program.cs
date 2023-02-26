var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ITest, Test2>();
builder.Services.AddSingleton<ITest,Test>();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("test", (ITest test) =>
{
    return test.Test1();
});

app.Run();


class Test:ITest
{
    public string Test1() { return "string"; }
}

class Test2 : ITest
{
    public string Test1() { return "value"; }
}

interface ITest
{
    string Test1();
}

