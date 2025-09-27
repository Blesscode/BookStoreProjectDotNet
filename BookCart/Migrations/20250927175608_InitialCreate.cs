using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookCart.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Category = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CoverFileName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookID);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    CartId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.CartId);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CartItem__488B0B0AA0297D1C", x => x.CartItemId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__19093A2B46B8DFC9", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerOrderDetails",
                columns: table => new
                {
                    OrderDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__9DD74DBD81D9221B", x => x.OrderDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerOrders",
                columns: table => new
                {
                    OrderId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    CartTotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__C3905BCF96C8F1E7", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "UserMaster",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Username = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    Gender = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: false),
                    UserTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserMast__1788CCAC2694A2ED", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    UserTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTypeName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.UserTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Wishlist",
                columns: table => new
                {
                    WishlistId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlist", x => x.WishlistId);
                });

            migrationBuilder.CreateTable(
                name: "WishlistItems",
                columns: table => new
                {
                    WishlistItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WishlistId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Wishlist__171E21A16A5148A4", x => x.WishlistItemId);
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "BookID", "Author", "Category", "CoverFileName", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Jon Skeet", "Programming", "csharp.jpg", 45.99m, "C# in Depth" },
                    { 2, "Robert C. Martin", "Programming", "cleancode.jpg", 39.99m, "Clean Code" },
                    { 3, "Andrew Hunt", "Programming", "pragprog.jpg", 42.50m, "The Pragmatic Programmer" },
                    { 4, "Erich Gamma", "Programming", "designpatterns.jpg", 49.00m, "Design Patterns" },
                    { 5, "Thomas H. Cormen", "Computer Science", "algorithms.jpg", 59.99m, "Introduction to Algorithms" }
                });

            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "CartId", "DateCreated", "UserID" },
                values: new object[,]
                {
                    { "CART001", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "CART002", new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "CART003", new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { "CART004", new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { "CART005", new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "CartItemId", "CartId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, "CART001", 101, 2 },
                    { 2, "CART002", 102, 1 },
                    { 3, "CART003", 103, 3 },
                    { 4, "CART004", 104, 2 },
                    { 5, "CART005", 105, 1 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Books" },
                    { 3, "Clothing" },
                    { 4, "Home & Kitchen" },
                    { 5, "Toys" }
                });

            migrationBuilder.InsertData(
                table: "CustomerOrderDetails",
                columns: new[] { "OrderDetailsId", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, "ORD001", 199.99m, 101, 1 },
                    { 2, "ORD001", 100.00m, 102, 1 },
                    { 3, "ORD002", 75.25m, 103, 2 },
                    { 4, "ORD003", 75.75m, 104, 1 },
                    { 5, "ORD004", 105.05m, 105, 2 }
                });

            migrationBuilder.InsertData(
                table: "CustomerOrders",
                columns: new[] { "OrderId", "CartTotal", "DateCreated", "UserID" },
                values: new object[,]
                {
                    { "ORD001", 299.99m, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "ORD002", 150.50m, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "ORD003", 75.75m, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { "ORD004", 210.10m, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { "ORD005", 500.00m, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "UserMaster",
                columns: new[] { "UserID", "FirstName", "Gender", "LastName", "Password", "UserTypeID", "Username" },
                values: new object[,]
                {
                    { 1, "John", "Male", "Doe", "Admin@123", 1, "admin" },
                    { 2, "Jane", "Female", "Smith", "User@123", 2, "jane123" },
                    { 3, "Robert", "Male", "King", "Pass@123", 2, "robertK" },
                    { 4, "Emily", "Female", "Johnson", "Pass@123", 3, "emilyJ" },
                    { 5, "Michael", "Male", "Brown", "Pass@123", 4, "mikeB" }
                });

            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "UserTypeID", "UserTypeName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" },
                    { 3, "Manager" },
                    { 4, "Guest" },
                    { 5, "Vendor" }
                });

            migrationBuilder.InsertData(
                table: "Wishlist",
                columns: new[] { "WishlistId", "DateCreated", "UserID" },
                values: new object[,]
                {
                    { "WISH001", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { "WISH002", new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { "WISH003", new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { "WISH004", new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { "WISH005", new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "WishlistItems",
                columns: new[] { "WishlistItemId", "ProductId", "WishlistId" },
                values: new object[,]
                {
                    { 1, 101, "WISH001" },
                    { 2, 102, "WISH002" },
                    { 3, 103, "WISH003" },
                    { 4, 104, "WISH004" },
                    { 5, 105, "WISH005" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "CustomerOrderDetails");

            migrationBuilder.DropTable(
                name: "CustomerOrders");

            migrationBuilder.DropTable(
                name: "UserMaster");

            migrationBuilder.DropTable(
                name: "UserType");

            migrationBuilder.DropTable(
                name: "Wishlist");

            migrationBuilder.DropTable(
                name: "WishlistItems");
        }
    }
}
