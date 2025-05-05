var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


//config. swagger p/ teste
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// carga de dados para teste e exemplo
var users = new List<User>();

// Endpoint Minimal Api para criar usuario
app.MapPost("/users", (User user) => 
{
    users.Add(user);
    return Results.Created($"/users/{user.Id}", user);
});

//Endpoint para listar usuario
app.MapGet("/users", () => users);



// Habita swagger
app.UseSwagger();
app.UseSwaggerUI();
app.Run();

// classe model
public record User(int Id, string Name, string Email);
