﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vektorel.Muzayede.Entities.Definition;
using Vektorel.Muzayede.Entities.Finance;
using Vektorel.Muzayede.Entities.Identity;

namespace Vektorel.Muzayede.Data;

public class MuzayedeContext : IdentityDbContext<User>
{
    public MuzayedeContext(DbContextOptions<MuzayedeContext> contextOptions) : base(contextOptions)
    {
    }

    public DbSet<Board> Boards { get; set; }
    public DbSet<BoardProduct> BoardProducts { get; set; }
    public DbSet<Proposal> Proposals { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductPrice> ProductPrices { get; set; }
    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<WalletHistory> WalletHistory { get; set; }
}
