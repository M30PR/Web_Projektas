using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Data;

#nullable disable

namespace Web_Projektas.Models
{
    public partial class projektas_dbContext : DbContext
    {
        public projektas_dbContext()
        {
        }

        public projektas_dbContext(DbContextOptions<projektas_dbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Contains1> Contains1s { get; set; }
        public virtual DbSet<Nationality> Nationalities { get; set; }
        public virtual DbSet<PopularAuthor> PopularAuthors { get; set; }
        public virtual DbSet<PopularTopic> PopularTopics { get; set; }
        public virtual DbSet<Profession> Professions { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=projektas_db;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("author");

                entity.Property(e => e.AuthorId)
                    .ValueGeneratedNever()
                    .HasColumnName("author_id");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birth_date");

                entity.Property(e => e.DeathDate)
                    .HasColumnType("date")
                    .HasColumnName("death_date");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .IsFixedLength(true);

                entity.Property(e => e.NationalityId).HasColumnName("nationality_id");

                entity.Property(e => e.Photo)
                    .HasColumnType("image")
                    .HasColumnName("photo");

                entity.Property(e => e.ProfesionId).HasColumnName("profesion_id");

                entity.Property(e => e.Surname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("surname")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Nationality)
                    .WithMany(p => p.Authors)
                    .HasForeignKey(d => d.NationalityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("author_nationality_fk");

                entity.HasOne(d => d.Profesion)
                    .WithMany(p => p.Authors)
                    .HasForeignKey(d => d.ProfesionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("author_profession_fk");
            });

            modelBuilder.Entity<Contains1>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.TagsId })
                    .HasName("contains_pk");

                entity.ToTable("contains1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TagsId).HasColumnName("tags_id");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Contains1s)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("contains_quote_fk");

                entity.HasOne(d => d.Tags)
                    .WithMany(p => p.Contains1s)
                    .HasForeignKey(d => d.TagsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("contains_tags_fk");
            });

            modelBuilder.Entity<Nationality>(entity =>
            {
                entity.ToTable("nationality");

                entity.Property(e => e.NationalityId)
                    .ValueGeneratedNever()
                    .HasColumnName("nationality_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<PopularAuthor>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("popular_authors");

                entity.HasIndex(e => e.AuthorId, "popular_authors__idx")
                    .IsUnique();

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.NumberAuthors).HasColumnName("number_authors");

                entity.HasOne(d => d.Author)
                    .WithOne()
                    .HasForeignKey<PopularAuthor>(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("popular_authors_author_fk");
            });

            modelBuilder.Entity<PopularTopic>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("popular_topics");

                entity.HasIndex(e => e.TopicId, "popular_topics__idx")
                    .IsUnique();

                entity.Property(e => e.NumberTopics).HasColumnName("number_topics");

                entity.Property(e => e.TopicId).HasColumnName("topic_id");

                entity.HasOne(d => d.Topic)
                    .WithOne()
                    .HasForeignKey<PopularTopic>(d => d.TopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("popular_topics_topic_fk");
            });

            modelBuilder.Entity<Profession>(entity =>
            {
                entity.HasKey(e => e.ProfesionId)
                    .HasName("profesion_pk");

                entity.ToTable("profession");

                entity.Property(e => e.ProfesionId)
                    .ValueGeneratedNever()
                    .HasColumnName("profesion_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Quote>(entity =>
            {
                entity.ToTable("quote");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.CreatingDate)
                    .HasColumnType("date")
                    .HasColumnName("creating_date");

                entity.Property(e => e.Text)
                    .HasColumnType("text")
                    .HasColumnName("text");

                entity.Property(e => e.TopicId).HasColumnName("topic_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Quotes)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("quote_author_fk");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.Quotes)
                    .HasForeignKey(d => d.TopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("quote_topic_fk");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Quotes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("quote_users_fk");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(e => e.TagsId)
                    .HasName("tags_pk");

                entity.ToTable("tags");

                entity.Property(e => e.TagsId)
                    .ValueGeneratedNever()
                    .HasColumnName("tags_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("topic");

                entity.Property(e => e.TopicId)
                    .ValueGeneratedNever()
                    .HasColumnName("topic_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.EMail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("E-mail")
                    .IsFixedLength(true);

                entity.Property(e => e.LastTimeDate)
                    .HasColumnType("date")
                    .HasColumnName("last_time_date");

                entity.Property(e => e.Password)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("password")
                    .IsFixedLength(true);

                entity.Property(e => e.RegisterDate)
                    .HasColumnType("date")
                    .HasColumnName("register_date");

                entity.Property(e => e.Role)
                    .HasMaxLength(15)
                    .IsFixedLength(true);

                entity.Property(e => e.Username)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("username")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
