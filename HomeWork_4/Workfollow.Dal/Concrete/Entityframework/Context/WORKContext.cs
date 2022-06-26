using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Workfollow.Entity.Models;

#nullable disable

namespace Workfollow.Dal.Concrete.Entityframework.Context
{
    public partial class WORKContext : DbContext
    {
        // 1.Yontem
        IConfiguration configuration;
        public WORKContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // 2.Yontem bunlar yorum satiri 
        //optionsBuilder ve if acik sekilde oldugunda da calisir
        //optionsBuilder.UseSqlServer("Server=NIRVANA;Database=WORK;Trusted_Connection=True;");
        //public WORKContext()
        //{
        //}

        //public WORKContext(DbContextOptions<WORKContext> options)
        //    : base(options)
        //{
        //}

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<JobList> JobLists { get; set; }
        public virtual DbSet<Messaging> Messagings { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
                //1.Yontem optionsBuilder yorum satiri olur if de yorum satiri olur

                //optionsBuilder.UseSqlServer("Server=NIRVANA;Database=WORK;Trusted_Connection=True;");

                //bu yontemle appsettinsteki her seyi okuyabiliriz
                //GetConnectionString sunu veriyor sqlserverin take onu verir yani yolumuzu
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("SqlServer"));
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.JobListId).HasColumnName("JobListID");

                entity.HasOne(d => d.JobList)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.JobListId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Department_JobList");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.EmployeeEmail)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeePassword)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.EmployeeRegisterId).HasColumnName("EmployeeRegisterID");

                entity.Property(e => e.EmployeeRoleId).HasColumnName("EmployeeRoleID");

                entity.Property(e => e.EmployeeSurname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeTelNumber)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Department");

                entity.HasOne(d => d.EmployeeRole)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmployeeRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Role");
            });

            modelBuilder.Entity<JobList>(entity =>
            {
                entity.ToTable("JobList");

                entity.Property(e => e.JobListId).HasColumnName("JobListID");

                entity.Property(e => e.JobListName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Messaging>(entity =>
            {
                entity.ToTable("Messaging");

                entity.Property(e => e.MessagingId).HasColumnName("MessagingID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.FkEmployeeId).HasColumnName("FkEmployeeID");

                entity.Property(e => e.MessagingText)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.MessagingEmployees)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Messaging_Employee");

                entity.HasOne(d => d.FkEmployee)
                    .WithMany(p => p.MessagingFkEmployees)
                    .HasForeignKey(d => d.FkEmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Messaging_Employee1");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.Messagings)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Messaging_Request");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("Request");

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.FkEmployeeId).HasColumnName("FkEmployeeID");

                entity.Property(e => e.JobListId).HasColumnName("JobListID");

                entity.Property(e => e.RequestContent)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RequestHeader)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RequestJobEndDate).HasColumnType("date");

                entity.Property(e => e.RequestJobStartDate).HasColumnType("date");

                entity.Property(e => e.RequestStatus)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_Department");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.RequestEmployees)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_Employee3");

                entity.HasOne(d => d.FkEmployee)
                    .WithMany(p => p.RequestFkEmployees)
                    .HasForeignKey(d => d.FkEmployeeId)
                    .HasConstraintName("FK_Request_Employee4");

                entity.HasOne(d => d.JobList)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.JobListId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_JobList");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
