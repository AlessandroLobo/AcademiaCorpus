using AcademiaCorpus.Models;
using Microsoft.EntityFrameworkCore;

namespace AcademiaCorpus.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    //Criando tabelas no bando de dados
    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Treino> Treinos { get; set; }

}
