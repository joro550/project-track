using ProjectTrack.Application.Authentication;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication("Custom")
    .AddScheme<AuthOptions, CustomAuthenticationHandler>("Custom", o => o.Validate());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();
