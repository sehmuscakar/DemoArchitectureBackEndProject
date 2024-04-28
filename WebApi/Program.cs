using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);
//Autofac.Extensions.DependencyInjection bu 
// ve Autofac kütüphaneleri eklemen laýzm bu katmana 

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder=>builder.RegisterModule(new AutofacBusinessModule()));//dependis enjekjýn  mantýðýný burayada entegre etik



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton<IOperationClaimService, OperationClaimManager>(); // yukarda baþka bir yerde tanýmladýðýmýzý entegre etik yukardaki da mimariye uygun solid filan
//builder.Services.AddSingleton<IOperationClaimDal, EfOperationClaimDal>();// Autofac ile Dependency Injection baðýmlýlýklarý azaltýk
////bu mantýk sayesinde dependis enjektionile hem class lara baðlý olmadýk hemde solid prensiplerine göre projeyi ayaða kaldýrdýk

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
