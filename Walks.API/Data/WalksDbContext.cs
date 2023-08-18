using System;
using Microsoft.EntityFrameworkCore;
using Walks.API.Models;

namespace Walks.API.Data
{
	public class WalksDbContext : DbContext
	{
		public WalksDbContext(DbContextOptions<WalksDbContext> dbContextOptions) : base(dbContextOptions)
		{
		}

		public DbSet<Difficulty> Difficulties { get; set; }
		public DbSet<Region> Regions { get; set; }
		public DbSet<Walk> Walks { get; set; }
	}
}

