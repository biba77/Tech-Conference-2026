var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddOpenApi();
var registrations = new List<RegistrationData>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.UseCors("AllowAngular");

app.MapPost("/register", (RegistrationData data) =>
{
    // Step 1: required fields
    if (
        string.IsNullOrWhiteSpace(data.Name) ||
        string.IsNullOrWhiteSpace(data.Email) ||
        string.IsNullOrWhiteSpace(data.University) ||
        string.IsNullOrWhiteSpace(data.Phone)
    )
    {
        return Results.BadRequest(new { message = "All required fields must be completed." });
    }

    // Step 2: email must contain @ and a dot after it
    if (!data.Email.Contains("@") || !data.Email.Contains("."))
    {
        return Results.BadRequest(new { message = "Invalid email address." });
    }

    // Step 3: phone must be 10-15 digits only
    if (data.Phone.Length < 10 || data.Phone.Length > 15 || !data.Phone.All(char.IsDigit))
    {
        return Results.BadRequest(new { message = "Phone number must be 10 to 15 digits." });
    }

    registrations.Add(data);
    Console.WriteLine($"Name: {data.Name}");
    Console.WriteLine($"Email: {data.Email}");
    Console.WriteLine($"University: {data.University}");
    Console.WriteLine($"Phone: {data.Phone}");
    Console.WriteLine($"Interest: {data.Interest}");
    Console.WriteLine($"Total Registrations: {registrations.Count}");

    return Results.Ok(new { message = "Registration successful!" });
});

app.MapGet("/registrations", () => registrations);

app.Run();

record RegistrationData(string Name, string Email, string University, string Phone, string Interest);