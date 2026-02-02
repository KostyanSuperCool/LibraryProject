using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace libraryProject.Folder;

public partial class LibraryKiselevContext : DbContext
{
    public LibraryKiselevContext()
    {
    }

    public LibraryKiselevContext(DbContextOptions<LibraryKiselevContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BooksLoan> BooksLoans { get; set; }

    public virtual DbSet<Creator> Creators { get; set; }

    public virtual DbSet<Ganre> Ganres { get; set; }

    public virtual DbSet<LibraryCard> LibraryCards { get; set; }

    public virtual DbSet<PublishingHouse> PublishingHouses { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=library_Kiselev;Username=postgres;Password=1111");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("books_pkey");

            entity.ToTable("books");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.All).HasColumnName("all");
            entity.Property(e => e.Annotation).HasColumnName("annotation");
            entity.Property(e => e.Available).HasColumnName("available");
            entity.Property(e => e.IdCreator).HasColumnName("id_creator");
            entity.Property(e => e.IdGenre).HasColumnName("id_genre");
            entity.Property(e => e.IdPublishing).HasColumnName("id_publishing");
            entity.Property(e => e.Isbn).HasColumnName("ISBN");
            entity.Property(e => e.NameBook).HasColumnName("name_book");
            entity.Property(e => e.Paper).HasColumnName("paper");
            entity.Property(e => e.Photo).HasColumnName("photo");
            entity.Property(e => e.YearOfPublication).HasColumnName("year_of_publication");

            entity.HasOne(d => d.Creator).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdCreator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("books_id_creator_fkey");

            entity.HasOne(d => d.Ganre).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdGenre)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("books_id_genre_fkey");

            entity.HasOne(d => d.PublishingHouse).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdPublishing)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("books_id_publishing_fkey");
        });

        modelBuilder.Entity<BooksLoan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("books_loans_pkey");

            entity.ToTable("books_loans");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActualReturnDate).HasColumnName("actual_return_date");
            entity.Property(e => e.DateOfIssue).HasColumnName("date_of_issue");
            entity.Property(e => e.IdGive)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_give");
            entity.Property(e => e.IdIsbn).HasColumnName("id_isbn");
            entity.Property(e => e.IdLibraryCard).HasColumnName("id_library_card");
            entity.Property(e => e.IdStatus).HasColumnName("id_status");
            entity.Property(e => e.PlannedReturnDate).HasColumnName("planned_return_date");

            entity.HasOne(d => d.Book).WithMany(p => p.BooksLoans)
                .HasForeignKey(d => d.IdIsbn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("books_loans_id_ISBN_fkey");

            entity.HasOne(d => d.LibraryCard).WithMany(p => p.BooksLoans)
                .HasForeignKey(d => d.IdLibraryCard)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("books_loans_id_library_card_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.BooksLoans)
                .HasForeignKey(d => d.IdStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("books_loans_id_status_fkey");
        });

        modelBuilder.Entity<Creator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("creators_pkey");

            entity.ToTable("creators");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Creator1).HasColumnName("creator");
        });

        modelBuilder.Entity<Ganre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ganres_pkey");

            entity.ToTable("ganres");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GenreBook).HasColumnName("genre_book");
        });

        modelBuilder.Entity<LibraryCard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("library_card_pkey");

            entity.ToTable("library_card");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Card).HasColumnName("card");
        });

        modelBuilder.Entity<PublishingHouse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("publishing_house_pkey");

            entity.ToTable("publishing_house");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.HousePublishing).HasColumnName("house_publishing");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Role1).HasColumnName("role");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("statuses_pkey");

            entity.ToTable("statuses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Status1).HasColumnName("status");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdLibraryCard).HasColumnName("id_library_card");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.UserName).HasColumnName("user_name");

            entity.HasOne(d => d.LibraryCard).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdLibraryCard)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_id_library_card_fkey");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_id_role_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
