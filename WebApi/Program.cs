using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);
//Autofac.Extensions.DependencyInjection bu 
// ve Autofac k�t�phaneleri eklemen la�zm bu katmana 

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder=>builder.RegisterModule(new AutofacBusinessModule()));//dependis enjekj�n  mant���n� burayada entegre etik



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton<IOperationClaimService, OperationClaimManager>(); // yukarda ba�ka bir yerde tan�mlad���m�z� entegre etik yukardaki da mimariye uygun solid filan
//builder.Services.AddSingleton<IOperationClaimDal, EfOperationClaimDal>();// Autofac ile Dependency Injection ba��ml�l�klar� azalt�k
////bu mant�k sayesinde dependis enjektionile hem class lara ba�l� olmad�k hemde solid prensiplerine g�re projeyi aya�a kald�rd�k

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
