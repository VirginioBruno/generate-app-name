using Bogus;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/generate/{type}", (string type) => {
    if (type.Equals("cool-name"))
        return new Faker<string>()
        .CustomInstantiator(f => $"app-{f.Vehicle.Model().ToLower().Replace(" ", "-")}" )
        .Generate();

    return $"app-{Guid.NewGuid()}";
});

app.Run();
