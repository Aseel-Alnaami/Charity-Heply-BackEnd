using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Charity.Core.Data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Charity> Charities { get; set; } = null!;
        public virtual DbSet<Contactu> Contactus { get; set; } = null!;
        public virtual DbSet<Donation> Donations { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<Paymentinfo> Paymentinfos { get; set; } = null!;
        public virtual DbSet<Problem> Problems { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Testimonial> Testimonials { get; set; } = null!;
        public virtual DbSet<Userinfo> Userinfos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=DESKTOP-6PHK2D8)(PORT=1521))(CONNECT_DATA=(SID=xe)));User Id=C##Charity;Password=123;Persist Security Info=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("C##CHARITY")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORIES");

                entity.HasIndex(e => e.Categoryname, "SYS_C008554")
                    .IsUnique();

                entity.Property(e => e.Categoryid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CATEGORYID");

                entity.Property(e => e.Categoryname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORYNAME");

                entity.Property(e => e.Profit)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PROFIT");
            });

            modelBuilder.Entity<Charity>(entity =>
            {
                entity.ToTable("CHARITIES");

                entity.Property(e => e.Charityid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CHARITYID");

                entity.Property(e => e.Categoryid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CATEGORYID");

                entity.Property(e => e.Charityimg)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CHARITYIMG");

                entity.Property(e => e.Charityname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CHARITYNAME");

                entity.Property(e => e.Createddate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEDDATE")
                    .HasDefaultValueSql("SYSDATE");

                entity.Property(e => e.Currentdonation)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CURRENTDONATION")
                    .HasDefaultValueSql("0\n");

                entity.Property(e => e.Description)
                    .HasColumnType("CLOB")
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Goals)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("GOALS");

                entity.Property(e => e.Latitude)
                    .HasColumnType("NUMBER(10,6)")
                    .HasColumnName("LATITUDE");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Longitude)
                    .HasColumnType("NUMBER(10,6)")
                    .HasColumnName("LONGITUDE");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .HasDefaultValueSql("'Pending'");

                entity.Property(e => e.Target)
                    .HasColumnType("NUMBER(10,2)")
                    .HasColumnName("TARGET");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Charities)
                    .HasForeignKey(d => d.Categoryid)
                    .HasConstraintName("SYS_C008567");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Charities)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("SYS_C008566");
            });

            modelBuilder.Entity<Contactu>(entity =>
            {
                entity.HasKey(e => e.Contactid)
                    .HasName("SYS_C008593");

                entity.ToTable("CONTACTUS");

                entity.Property(e => e.Contactid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CONTACTID");

                entity.Property(e => e.Contactdate)
                    .HasColumnType("DATE")
                    .HasColumnName("CONTACTDATE")
                    .HasDefaultValueSql("SYSDATE");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Message)
                    .HasColumnType("CLOB")
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");
            });

            modelBuilder.Entity<Donation>(entity =>
            {
                entity.ToTable("DONATIONS");

                entity.Property(e => e.Donationid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DONATIONID");

                entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER(10,2)")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.Charityid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CHARITYID");

                entity.Property(e => e.Donationdate)
                    .HasColumnType("DATE")
                    .HasColumnName("DONATIONDATE")
                    .HasDefaultValueSql("SYSDATE");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Charity)
                    .WithMany(p => p.Donations)
                    .HasForeignKey(d => d.Charityid)
                    .HasConstraintName("SYS_C008574");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Donations)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("SYS_C008573");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("INVOICES");

                entity.Property(e => e.Invoiceid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("INVOICEID");

                entity.Property(e => e.Amount)
                    .HasColumnType("NUMBER(10,2)")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.Charityid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CHARITYID");

                entity.Property(e => e.Invoicedate)
                    .HasColumnType("DATE")
                    .HasColumnName("INVOICEDATE")
                    .HasDefaultValueSql("SYSDATE");

                entity.Property(e => e.Type)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.Charity)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.Charityid)
                    .HasConstraintName("SYS_C008600");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("SYS_C008599");
            });

            modelBuilder.Entity<Paymentinfo>(entity =>
            {
                entity.HasKey(e => e.Cardid)
                    .HasName("SYS_C008580");

                entity.ToTable("PAYMENTINFO");

                entity.Property(e => e.Cardid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CARDID");

                entity.Property(e => e.Cardnumber)
                    .HasColumnType("CLOB")
                    .HasColumnName("CARDNUMBER");

                entity.Property(e => e.Createddate)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEDDATE")
                    .HasDefaultValueSql("SYSDATE ");

                entity.Property(e => e.Cvvnumber)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CVVNUMBER");

                entity.Property(e => e.Balance)
                    .HasPrecision(4)
                    .HasColumnName("BALANCE");

               
            });

            modelBuilder.Entity<Problem>(entity =>
            {
                entity.ToTable("PROBLEMS");

                entity.Property(e => e.Problemid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PROBLEMID");

                entity.Property(e => e.Problemtext)
                    .HasColumnType("CLOB")
                    .HasColumnName("PROBLEMTEXT");

                entity.Property(e => e.Reportdate)
                    .HasColumnType("DATE")
                    .HasColumnName("REPORTDATE")
                    .HasDefaultValueSql("SYSDATE");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Problems)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("SYS_C008605");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLES");

                entity.HasIndex(e => e.Rolename, "SYS_C008521")
                    .IsUnique();

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROLENAME");
            });

            modelBuilder.Entity<Testimonial>(entity =>
            {
                entity.ToTable("TESTIMONIAL");

                entity.Property(e => e.Testimonialid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TESTIMONIALID");

                entity.Property(e => e.Content)
                    .HasColumnType("CLOB")
                    .HasColumnName("CONTENT");

                entity.Property(e => e.Rating)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RATING");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .HasDefaultValueSql("'Pending' ");

                entity.Property(e => e.Submitteddate)
                    .HasColumnType("DATE")
                    .HasColumnName("SUBMITTEDDATE")
                    .HasDefaultValueSql("SYSDATE   ");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Testimonials)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("SYS_C008588");
            });

            modelBuilder.Entity<Userinfo>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("SYS_C008547");

                entity.ToTable("USERINFO");

                entity.HasIndex(e => e.Username, "SYS_C008548")
                    .IsUnique();

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERID");

                entity.Property(e => e.Dateadded)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEADDED")
                    .HasDefaultValueSql("SYSDATE\n");

                entity.Property(e => e.Dateofbirth)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEOFBIRTH");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.Profilepicture)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PROFILEPICTURE");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Userinfos)
                    .HasForeignKey(d => d.Roleid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SYS_C008549");
            });

            modelBuilder.HasSequence("ROLES_SEQ");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
