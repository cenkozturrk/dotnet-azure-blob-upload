using BlobImageUploadApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Swagger Conf
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI Conf
builder.Services.AddScoped<BlobService>();
builder.Services.AddSingleton(x =>
    new QueueService(
        builder.Configuration.GetConnectionString("QueueStorage"),
        "jobs"
    )
);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
