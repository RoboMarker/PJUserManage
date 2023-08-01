
using UserManageRepository;
using UserManageRepository.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMenuService, MenuService>();
BuilderExtender.AddDbContexts(builder);//將註冊地方更改為UserManageRepository專案


#region cors
var MyAllowSpecificOrigins = "server";

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:8080", "http://localhost:8081")
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .AllowCredentials();
        });
});
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//cors
app.UseCors(MyAllowSpecificOrigins);


app.UseAuthentication();//身分驗證
app.UseAuthorization();//授權
app.MapControllers();
app.Run();
