using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API_Mission10_Oliveira.Data;
    public class BowlingContext : DbContext
{
    public BowlingContext(DbContextOptions<BowlingContext> options) : base(options)
    {

    }
    public DbSet<Bowler> Bowlers { get; set; }
    public DbSet<Team> Teams { get; set; }
}
