using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartDCWebApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Last_Name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    User_Name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Phone_No_Code = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true),
                    Phone_No = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Status = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: false),
                    Created_On = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Modified_By = table.Column<int>(type: "int", nullable: true),
                    Modified_On = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_ID);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Company_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    GST_No = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Address1 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Address2 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Pin_Code = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Phone_No_Code = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    Phone_No = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Alt_Phone_No_Code = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true),
                    Alt_Phone_No = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Status = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: false),
                    Created_On = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Modified_By = table.Column<int>(type: "int", nullable: true),
                    Modified_On = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Company_ID);
                    table.ForeignKey(
                        name: "FK___Companies___Created_By",
                        column: x => x.Created_By,
                        principalTable: "Users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Customer_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    GST_No = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Address1 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Address2 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Pin_Code = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Phone_No_Code = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    Phone_No = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Alt_Phone_No_Code = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true),
                    Alt_Phone_No = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Status = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: false),
                    Created_On = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Modified_By = table.Column<int>(type: "int", nullable: true),
                    Modified_On = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Customer_ID);
                    table.ForeignKey(
                        name: "FK___Customers___Created_By",
                        column: x => x.Created_By,
                        principalTable: "Users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Purchase_Details",
                columns: table => new
                {
                    Purchase_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company_ID = table.Column<int>(type: "int", nullable: false),
                    Customer_ID = table.Column<int>(type: "int", nullable: false),
                    Purchase_Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Style_No = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    DC_No = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Vehicle_No = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: false),
                    Created_On = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Modified_By = table.Column<int>(type: "int", nullable: true),
                    Modified_On = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase_Details", x => x.Purchase_ID);
                    table.ForeignKey(
                        name: "FK___Purchase_Details___Company_ID",
                        column: x => x.Company_ID,
                        principalTable: "Companies",
                        principalColumn: "Company_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK___Purchase_Details___Created_By",
                        column: x => x.Created_By,
                        principalTable: "Users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK___Purchase_Details___Customer_ID",
                        column: x => x.Customer_ID,
                        principalTable: "Customers",
                        principalColumn: "Customer_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Delivery_Details",
                columns: table => new
                {
                    Delivery_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company_ID = table.Column<int>(type: "int", nullable: false),
                    Customer_ID = table.Column<int>(type: "int", nullable: false),
                    Purchase_ID = table.Column<int>(type: "int", nullable: false),
                    Delivery_Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Party_DC_No = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Challan_No = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Vehicle_No = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: false),
                    Created_On = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Modified_By = table.Column<int>(type: "int", nullable: true),
                    Modified_On = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery_Details", x => x.Delivery_ID);
                    table.ForeignKey(
                        name: "FK___Delivery_Details___Company_ID",
                        column: x => x.Company_ID,
                        principalTable: "Companies",
                        principalColumn: "Company_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK___Delivery_Details___Created_By",
                        column: x => x.Created_By,
                        principalTable: "Users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK___Delivery_Details___Customer_ID",
                        column: x => x.Customer_ID,
                        principalTable: "Customers",
                        principalColumn: "Customer_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK___Delivery_Details___Purchase_ID",
                        column: x => x.Purchase_ID,
                        principalTable: "Purchase_Details",
                        principalColumn: "Purchase_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Purchase_Detail_Particulars",
                columns: table => new
                {
                    Purchase_Detail_Particular_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Purchase_ID = table.Column<int>(type: "int", nullable: false),
                    Serial_No = table.Column<int>(type: "int", nullable: false),
                    Particulars = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Wash_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: false),
                    Created_On = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Modified_By = table.Column<int>(type: "int", nullable: true),
                    Modified_On = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase_Detail_Particulars", x => x.Purchase_Detail_Particular_ID);
                    table.ForeignKey(
                        name: "FK___Purchase_Detail_Particulars___Created_By",
                        column: x => x.Created_By,
                        principalTable: "Users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK___Purchase_Detail_Particulars___Purchase_ID",
                        column: x => x.Purchase_ID,
                        principalTable: "Purchase_Details",
                        principalColumn: "Purchase_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Delivery_Detail_Particulars",
                columns: table => new
                {
                    Delivery_Detail_Particular_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Delivery_ID = table.Column<int>(type: "int", nullable: false),
                    Serial_No = table.Column<int>(type: "int", nullable: false),
                    Particulars = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Wash_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Return_Quantity = table.Column<int>(type: "int", nullable: false),
                    Pending_Quantity = table.Column<int>(type: "int", nullable: true),
                    Remarks = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Created_By = table.Column<int>(type: "int", nullable: false),
                    Created_On = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Modified_By = table.Column<int>(type: "int", nullable: true),
                    Modified_On = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery_Detail_Particulars", x => x.Delivery_Detail_Particular_ID);
                    table.ForeignKey(
                        name: "FK___Delivery_Detail_Particulars___Created_By",
                        column: x => x.Created_By,
                        principalTable: "Users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK___Delivery_Detail_Particulars___Delivery_ID",
                        column: x => x.Delivery_ID,
                        principalTable: "Delivery_Details",
                        principalColumn: "Delivery_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Created_By",
                table: "Companies",
                column: "Created_By");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Created_By",
                table: "Customers",
                column: "Created_By");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_Detail_Particulars_Created_By",
                table: "Delivery_Detail_Particulars",
                column: "Created_By");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_Detail_Particulars_Delivery_ID",
                table: "Delivery_Detail_Particulars",
                column: "Delivery_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_Details_Company_ID",
                table: "Delivery_Details",
                column: "Company_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_Details_Created_By",
                table: "Delivery_Details",
                column: "Created_By");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_Details_Customer_ID",
                table: "Delivery_Details",
                column: "Customer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_Details_Purchase_ID",
                table: "Delivery_Details",
                column: "Purchase_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_Detail_Particulars_Created_By",
                table: "Purchase_Detail_Particulars",
                column: "Created_By");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_Detail_Particulars_Purchase_ID",
                table: "Purchase_Detail_Particulars",
                column: "Purchase_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_Details_Company_ID",
                table: "Purchase_Details",
                column: "Company_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_Details_Created_By",
                table: "Purchase_Details",
                column: "Created_By");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_Details_Customer_ID",
                table: "Purchase_Details",
                column: "Customer_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Delivery_Detail_Particulars");

            migrationBuilder.DropTable(
                name: "Purchase_Detail_Particulars");

            migrationBuilder.DropTable(
                name: "Delivery_Details");

            migrationBuilder.DropTable(
                name: "Purchase_Details");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
