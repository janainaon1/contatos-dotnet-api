using ContatosAPI.Data;
using ContatosAPI.Mappings;
using ContatosAPI.Repositories;
using ContatosAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("ContactsCs");
//builder.Services.AddDbContext<ContactListDbContext>(a => a.UseSqlServer(connectionString));

builder.Services.AddDbContext<ContactListDbContext>(a => a.UseInMemoryDatabase("ContactsDb"));

builder.Services.AddTransient(typeof(IContactRepository<>), typeof(ContactRepository<>));
builder.Services.AddTransient<PersonContactService>();
builder.Services.AddTransient<PhoneContactService>();
builder.Services.AddTransient<EmailContactService>();

builder.Services.AddAutoMapper(typeof(ContactDTOProfile));

builder.Services.AddCors();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ContatosAPI",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Janaina Oliveira",
            Email = "janainaon1@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/janaina-dev/")
        }
    });

    var xmlFile = "ContatosAPI.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseCors(opt => opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
