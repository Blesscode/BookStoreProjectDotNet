using Microsoft.EntityFrameworkCore;

namespace BookCart.Models
{
    public partial class BookDBContext : DbContext
    {
        public BookDBContext()
        {
        }

        public BookDBContext(DbContextOptions<BookDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<CartItems> CartItems { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<CustomerOrderDetails> CustomerOrderDetails { get; set; }
        public virtual DbSet<CustomerOrders> CustomerOrders { get; set; }
        public virtual DbSet<UserMaster> UserMaster { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }
        public virtual DbSet<Wishlist> Wishlist { get; set; }
        public virtual DbSet<WishlistItems> WishlistItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //pervious data

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.Author)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CoverFileName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.CartId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<CartItems>(entity =>
            {
                entity.HasKey(e => e.CartItemId)
                    .HasName("PK__CartItem__488B0B0AA0297D1C");

                entity.Property(e => e.CartId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__Categori__19093A2B46B8DFC9");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerOrderDetails>(entity =>
            {
                entity.HasKey(e => e.OrderDetailsId)
                    .HasName("PK__Customer__9DD74DBD81D9221B");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<CustomerOrders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Customer__C3905BCF96C8F1E7");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CartTotal).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<UserMaster>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserMast__1788CCAC2694A2ED");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");

                entity.Property(e => e.UserTypeName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Wishlist>(entity =>
            {
                entity.Property(e => e.WishlistId)
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<WishlistItems>(entity =>
            {
                entity.HasKey(e => e.WishlistItemId)
                    .HasName("PK__Wishlist__171E21A16A5148A4");

                entity.Property(e => e.WishlistId)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false);
            });

            //adding new changes:
            // ---------------- User Types ----------------
            modelBuilder.Entity<UserType>().HasData(
                new UserType { UserTypeId = 1, UserTypeName = "Admin" },
                new UserType { UserTypeId = 2, UserTypeName = "User" },
                new UserType { UserTypeId = 3, UserTypeName = "Manager" },
                new UserType { UserTypeId = 4, UserTypeName = "Guest" },
                new UserType { UserTypeId = 5, UserTypeName = "Vendor" }
            );

            // ---------------- Users ----------------
            modelBuilder.Entity<UserMaster>().HasData(
                new UserMaster { UserId = 1, FirstName = "John", LastName = "Doe", Username = "admin", Password = "Admin@123", Gender = "Male", UserTypeId = 1 },
                new UserMaster { UserId = 2, FirstName = "Jane", LastName = "Smith", Username = "jane123", Password = "User@123", Gender = "Female", UserTypeId = 2 },
                new UserMaster { UserId = 3, FirstName = "Robert", LastName = "King", Username = "robertK", Password = "Pass@123", Gender = "Male", UserTypeId = 2 },
                new UserMaster { UserId = 4, FirstName = "Emily", LastName = "Johnson", Username = "emilyJ", Password = "Pass@123", Gender = "Female", UserTypeId = 3 },
                new UserMaster { UserId = 5, FirstName = "Michael", LastName = "Brown", Username = "mikeB", Password = "Pass@123", Gender = "Male", UserTypeId = 4 }
            );

            // ---------------- Categories ----------------
            modelBuilder.Entity<Categories>().HasData(
                new Categories { CategoryId = 1, CategoryName = "Electronics" },
                new Categories { CategoryId = 2, CategoryName = "Books" },
                new Categories { CategoryId = 3, CategoryName = "Clothing" },
                new Categories { CategoryId = 4, CategoryName = "Home & Kitchen" },
                new Categories { CategoryId = 5, CategoryName = "Toys" }
            );

            // ---------------- Books ----------------
            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "C# in Depth", Author = "Jon Skeet", Category = "Programming", Price = 45.99m, CoverFileName = "https://plus.unsplash.com/premium_photo-1750075345490-1d9d908215c3?q=80&w=494&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                new Book { BookId = 2, Title = "Clean Code", Author = "Robert C. Martin", Category = "Programming", Price = 39.99m, CoverFileName = "07492ea6-09fb-46e9-8c9b-8a8f51afe989qq.jpg" },
                new Book { BookId = 3, Title = "The Pragmatic Programmer", Author = "Andrew Hunt", Category = "Programming", Price = 42.50m, CoverFileName = "pragprog.jpg" },
                new Book { BookId = 4, Title = "Design Patterns", Author = "Erich Gamma", Category = "Programming", Price = 49.00m, CoverFileName = "designpatterns.jpg" },
                new Book { BookId = 5, Title = "Introduction to Algorithms", Author = "Thomas H. Cormen", Category = "Computer Science", Price = 59.99m, CoverFileName = "algorithms.jpg" }
            );

            // ---------------- Carts ----------------
            modelBuilder.Entity<Cart>().HasData(
                new Cart { CartId = "CART001", UserId = 2, DateCreated = new DateTime(2025, 1, 1) },
                new Cart { CartId = "CART002", UserId = 3, DateCreated = new DateTime(2025, 1, 2) },
                new Cart { CartId = "CART003", UserId = 4, DateCreated = new DateTime(2025, 1, 3) },
                new Cart { CartId = "CART004", UserId = 5, DateCreated = new DateTime(2025, 1, 4) },
                new Cart { CartId = "CART005", UserId = 2, DateCreated = new DateTime(2025, 1, 5) }
            );

            // ---------------- Cart Items ----------------
            modelBuilder.Entity<CartItems>().HasData(
                new CartItems { CartItemId = 1, CartId = "CART001", ProductId = 101, Quantity = 2 },
                new CartItems { CartItemId = 2, CartId = "CART002", ProductId = 102, Quantity = 1 },
                new CartItems { CartItemId = 3, CartId = "CART003", ProductId = 103, Quantity = 3 },
                new CartItems { CartItemId = 4, CartId = "CART004", ProductId = 104, Quantity = 2 },
                new CartItems { CartItemId = 5, CartId = "CART005", ProductId = 105, Quantity = 1 }
            );

            // ---------------- Wishlists ----------------
            modelBuilder.Entity<Wishlist>().HasData(
                new Wishlist { WishlistId = "WISH001", UserId = 2, DateCreated = new DateTime(2025, 1, 1) },
                new Wishlist { WishlistId = "WISH002", UserId = 3, DateCreated = new DateTime(2025, 1, 2) },
                new Wishlist { WishlistId = "WISH003", UserId = 4, DateCreated = new DateTime(2025, 1, 3) },
                new Wishlist { WishlistId = "WISH004", UserId = 5, DateCreated = new DateTime(2025, 1, 4) },
                new Wishlist { WishlistId = "WISH005", UserId = 2, DateCreated = new DateTime(2025, 1, 5) }
            );

            // ---------------- Wishlist Items ----------------
            modelBuilder.Entity<WishlistItems>().HasData(
                new WishlistItems { WishlistItemId = 1, WishlistId = "WISH001", ProductId = 101 },
                new WishlistItems { WishlistItemId = 2, WishlistId = "WISH002", ProductId = 102 },
                new WishlistItems { WishlistItemId = 3, WishlistId = "WISH003", ProductId = 103 },
                new WishlistItems { WishlistItemId = 4, WishlistId = "WISH004", ProductId = 104 },
                new WishlistItems { WishlistItemId = 5, WishlistId = "WISH005", ProductId = 105 }
            );

            // ---------------- Orders ----------------
            modelBuilder.Entity<CustomerOrders>().HasData(
                new CustomerOrders { OrderId = "ORD001", UserId = 2, DateCreated = new DateTime(2025, 1, 1), CartTotal = 299.99m },
                new CustomerOrders { OrderId = "ORD002", UserId = 3, DateCreated = new DateTime(2025, 1, 2), CartTotal = 150.50m },
                new CustomerOrders { OrderId = "ORD003", UserId = 4, DateCreated = new DateTime(2025, 1, 3), CartTotal = 75.75m },
                new CustomerOrders { OrderId = "ORD004", UserId = 5, DateCreated = new DateTime(2025, 1, 4), CartTotal = 210.10m },
                new CustomerOrders { OrderId = "ORD005", UserId = 2, DateCreated = new DateTime(2025, 1, 5), CartTotal = 500.00m }
            );

            // ---------------- Order Details ----------------
            modelBuilder.Entity<CustomerOrderDetails>().HasData(
                new CustomerOrderDetails { OrderDetailsId = 1, OrderId = "ORD001", ProductId = 101, Quantity = 1, Price = 199.99m },
                new CustomerOrderDetails { OrderDetailsId = 2, OrderId = "ORD001", ProductId = 102, Quantity = 1, Price = 100.00m },
                new CustomerOrderDetails { OrderDetailsId = 3, OrderId = "ORD002", ProductId = 103, Quantity = 2, Price = 75.25m },
                new CustomerOrderDetails { OrderDetailsId = 4, OrderId = "ORD003", ProductId = 104, Quantity = 1, Price = 75.75m },
                new CustomerOrderDetails { OrderDetailsId = 5, OrderId = "ORD004", ProductId = 105, Quantity = 2, Price = 105.05m }
            );



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
