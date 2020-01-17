using FFinder.Core.Authentication;
using FFinder.Entity.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FFinder.DAL.Concrete.EntityFramework
{
    public class SqlDbContext : IdentityDbContext<AuthIdentityUser, AuthIdentityRole, string>
    {
        
        public SqlDbContext()
        {
        }

        public SqlDbContext(DbContextOptions<SqlDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthIdentityUser>(b =>
                {
                    b.Property(e => e.Firstname).IsRequired().HasMaxLength(100);
                    b.Property(e => e.Lastname).IsRequired().HasMaxLength(100);
                    b.Property(e => e.Town).IsRequired().HasMaxLength(100);
                    b.Property(e => e.City).IsRequired().HasMaxLength(100);
                    b.Property(e => e.Country).IsRequired().HasMaxLength(100);
                    b.Property(e => e.IsActive).HasDefaultValueSql("0");
            
                    b.Property(x => x.AboutMe).HasMaxLength(500);
                    b.Property(x => x.FacebookUrl).HasMaxLength(250);
                    b.Property(x => x.TwitterUrl).HasMaxLength(250);
                    b.Property(x => x.ViberUrl).HasMaxLength(250);
                    b.Property(x => x.InstagramUrl).HasMaxLength(250);
                    b.Property(x => x.LinkedInUrl).HasMaxLength(250);
                    b.HasMany(d => d.Followers)
                        .WithOne(p => p.User1)
                        .HasConstraintName("FK_Followers_User").OnDelete(DeleteBehavior.NoAction);
                


                }
            );

            modelBuilder.Entity<Comment>(b =>
            {
                b.Property(e => e.CommentBody).IsRequired().HasMaxLength(250);
                b.Property(e => e.CommentId).HasDefaultValueSql("NEWID()");
                b.Property(e => e.OwnerId).IsRequired().HasMaxLength(450);
                b.Property(e => e.PostId).IsRequired().HasMaxLength(450);
                b.Property(e => e.CommentDate).HasColumnName("datetime").IsRequired().HasMaxLength(250);
                b.HasMany(x=>x.Rates).WithOne(x=>x.Comment).HasConstraintName("FK_Comment_CommentRates").OnDelete(DeleteBehavior.NoAction);
                b.HasOne(x => x.Owner).WithMany(x => x.Comments).HasConstraintName("FK_Comments_User").OnDelete(DeleteBehavior.NoAction);


            });
            modelBuilder.Entity<CommentRate>(b =>
            {
                b.Property(e => e.OwnerId).IsRequired().HasMaxLength(450);
                b.Property(e => e.CommentRateId).HasDefaultValueSql("NEWID()");
                b.Property(e => e.CommentId).IsRequired().HasMaxLength(450);
                b.Property(e => e.IsActive).IsRequired().HasMaxLength(250);
                b.Property(e => e.IsLike).IsRequired();
                b.Property(e => e.RateDate).IsRequired().HasMaxLength(250).HasColumnName("datetime");
                b.HasOne(x => x.Owner).WithMany(x => x.CommentRates).HasConstraintName("FK_CommentRates_User").OnDelete(DeleteBehavior.NoAction);


            });
            modelBuilder.Entity<Post>(b =>
            {
                b.Property(e => e.PostId).HasDefaultValueSql("NEWID()");
                b.Property(e => e.IsActive).IsRequired();
                b.Property(e => e.OwnerId).IsRequired().HasMaxLength(450);
                b.Property(e => e.PostBody).IsRequired().HasMaxLength(250);
                b.Property(e => e.PublishDate).IsRequired().HasMaxLength(250).HasColumnName("datetime");
                b.Property(e => e.PostImageUrl).HasMaxLength(250);
                b.HasOne(x => x.Owner).WithMany(x => x.Posts).HasConstraintName("FK_Posts_User").OnDelete(DeleteBehavior.NoAction);
                b.HasMany(e => e.Comments).WithOne(x => x.Post).HasConstraintName("FK_Comments_Post").OnDelete(DeleteBehavior.NoAction); 
                b.HasMany(e => e.Rates).WithOne(x => x.Post).HasConstraintName("FK_Rates_Post").OnDelete(DeleteBehavior.NoAction);

            });
            modelBuilder.Entity<PostRate>(b =>
            {
                b.Property(e => e.PostId).IsRequired().HasMaxLength(450);
                b.Property(e => e.PostRateId).HasDefaultValueSql("NEWID()");
                b.Property(e => e.IsActive).IsRequired();
                b.Property(e => e.OwnerId).IsRequired().HasMaxLength(450);
                b.Property(e => e.IsLike).IsRequired();
                b.Property(e => e.RateDate).IsRequired().HasMaxLength(250).HasColumnName("datetime");
                b.HasOne(x => x.Owner).WithMany(x => x.PostRates).HasConstraintName("FK_PostRates_User").OnDelete(DeleteBehavior.NoAction);


            });
            modelBuilder.Entity<Follower>(b =>
            {
                b.Property(e => e.User1Id).IsRequired().HasMaxLength(450);
                b.Property(e => e.FollowerId).HasDefaultValueSql("NEWID()");
                b.Property(e => e.IsActive).IsRequired();
                b.Property(e => e.IsAccepted).IsRequired();
                b.Property(e => e.User2Id).IsRequired().HasMaxLength(450);
               

            });


            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(TokenBase.Connection);
            }
        }

    }
}