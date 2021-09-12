using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SmartDCWebApi.Models
{
    public partial class SmartDCContext : DbContext
    {
        public SmartDCContext()
        {
        }

        public SmartDCContext(DbContextOptions<SmartDCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DeliveryDetail> DeliveryDetails { get; set; }
        public virtual DbSet<DeliveryDetailParticular> DeliveryDetailParticulars { get; set; }
        public virtual DbSet<PurchaseDetail> PurchaseDetails { get; set; }
        public virtual DbSet<PurchaseDetailParticular> PurchaseDetailParticulars { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=LAPTOP-31F58AJN\\MSSQLSERVER01;Initial Catalog=SmartDC;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.CompanyId).HasColumnName("Company_ID");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AltPhoneNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Alt_Phone_No");

                entity.Property(e => e.AltPhoneNoCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("Alt_Phone_No_Code");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Company_Name");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_On")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GstNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GST_No");

                entity.Property(e => e.ModifiedBy).HasColumnName("Modified_By");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_On");

                entity.Property(e => e.PhoneNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Phone_No");

                entity.Property(e => e.PhoneNoCode)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("Phone_No_Code");

                entity.Property(e => e.PinCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Pin_Code");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK___Companies___Created_By");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AltPhoneNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Alt_Phone_No");

                entity.Property(e => e.AltPhoneNoCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("Alt_Phone_No_Code");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_On")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Name");

                entity.Property(e => e.GstNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GST_No");

                entity.Property(e => e.ModifiedBy).HasColumnName("Modified_By");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_On");

                entity.Property(e => e.PhoneNo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Phone_No");

                entity.Property(e => e.PhoneNoCode)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("Phone_No_Code");

                entity.Property(e => e.PinCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Pin_Code");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK___Customers___Created_By");
            });

            modelBuilder.Entity<DeliveryDetail>(entity =>
            {
                entity.HasKey(e => e.DeliveryId);

                entity.ToTable("Delivery_Details");

                entity.Property(e => e.DeliveryId).HasColumnName("Delivery_ID");

                entity.Property(e => e.ChallanNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Challan_No");

                entity.Property(e => e.CompanyId).HasColumnName("Company_ID");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_On")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Delivery_Date");

                entity.Property(e => e.ModifiedBy).HasColumnName("Modified_By");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_On");

                entity.Property(e => e.PartyDcNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Party_DC_No");

                entity.Property(e => e.PurchaseId).HasColumnName("Purchase_ID");

                entity.Property(e => e.VehicleNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Vehicle_No");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.DeliveryDetails)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK___Delivery_Details___Company_ID");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.DeliveryDetails)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK___Delivery_Details___Created_By");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.DeliveryDetails)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK___Delivery_Details___Customer_ID");

                entity.HasOne(d => d.Purchase)
                    .WithMany(p => p.DeliveryDetails)
                    .HasForeignKey(d => d.PurchaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK___Delivery_Details___Purchase_ID");
            });

            modelBuilder.Entity<DeliveryDetailParticular>(entity =>
            {
                entity.ToTable("Delivery_Detail_Particulars");

                entity.Property(e => e.DeliveryDetailParticularId).HasColumnName("Delivery_Detail_Particular_ID");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_On")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeliveryId).HasColumnName("Delivery_ID");

                entity.Property(e => e.ModifiedBy).HasColumnName("Modified_By");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_On");

                entity.Property(e => e.Particulars)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PendingQuantity).HasColumnName("Pending_Quantity");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReturnQuantity).HasColumnName("Return_Quantity");

                entity.Property(e => e.SerialNo).HasColumnName("Serial_No");

                entity.Property(e => e.Status)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.WashType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Wash_Type");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.DeliveryDetailParticulars)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK___Delivery_Detail_Particulars___Created_By");

                entity.HasOne(d => d.Delivery)
                    .WithMany(p => p.DeliveryDetailParticulars)
                    .HasForeignKey(d => d.DeliveryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK___Delivery_Detail_Particulars___Delivery_ID");
            });

            modelBuilder.Entity<PurchaseDetail>(entity =>
            {
                entity.HasKey(e => e.PurchaseId);

                entity.ToTable("Purchase_Details");

                entity.Property(e => e.PurchaseId).HasColumnName("Purchase_ID");

                entity.Property(e => e.CompanyId).HasColumnName("Company_ID");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_On")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.DcNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DC_No");

                entity.Property(e => e.ModifiedBy).HasColumnName("Modified_By");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_On");

                entity.Property(e => e.PurchaseDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Purchase_Date");

                entity.Property(e => e.StyleNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Style_No");

                entity.Property(e => e.VehicleNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Vehicle_No");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.PurchaseDetails)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK___Purchase_Details___Company_ID");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.PurchaseDetails)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK___Purchase_Details___Created_By");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.PurchaseDetails)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK___Purchase_Details___Customer_ID");
            });

            modelBuilder.Entity<PurchaseDetailParticular>(entity =>
            {
                entity.ToTable("Purchase_Detail_Particulars");

                entity.Property(e => e.PurchaseDetailParticularId).HasColumnName("Purchase_Detail_Particular_ID");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_On")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedBy).HasColumnName("Modified_By");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_On");

                entity.Property(e => e.Particulars)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PurchaseId).HasColumnName("Purchase_ID");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SerialNo).HasColumnName("Serial_No");

                entity.Property(e => e.Status)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.WashType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Wash_Type");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.PurchaseDetailParticulars)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK___Purchase_Detail_Particulars___Created_By");

                entity.HasOne(d => d.Purchase)
                    .WithMany(p => p.PurchaseDetailParticulars)
                    .HasForeignKey(d => d.PurchaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK___Purchase_Detail_Particulars___Purchase_ID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_On")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("First_Name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.ModifiedBy).HasColumnName("Modified_By");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_On");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Phone_No");

                entity.Property(e => e.PhoneNoCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("Phone_No_Code");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("User_Name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
