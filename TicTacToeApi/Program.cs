using Microsoft.EntityFrameworkCore;
using TicTacToeApi.Data.Repositories.Abstract;
using TicTacToeApi.Entities.Concrete;
using TicTacToeApi.Data.Repositories.Concrete;
using TicTacToeApi.Services.Concrete;
using TicTacToeApi.Services.Abstract;
using TicTacToeApi.Entities.Concrete.TicTacToe;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<GamesDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetSection("ConnectionStrings")["DefaultConnection"]));
builder.Services.AddControllers();
builder.Services.AddScoped<IBaseRepository<BoardTicTacToe>, TicTacToeRepository>();
builder.Services.AddScoped<IPlayerRepository<TicTacToePlayer>, PlayerReposotory>();
builder.Services.AddScoped<IPlayerService,PlayerService>();
builder.Services.AddScoped<IGameService,TicTacToeService>();
builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = 5000;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
