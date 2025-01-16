using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _77CarRental.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        }
        

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           

            modelBuilder.Entity<Customer>().HasData(
            new Customer { CustomerId = 1, FirstName = "Kholoud", LastName = "Habash", Email = "Kholoudy24@hotmail.com", Phone = "0552121254" },
            new Customer { CustomerId = 2, FirstName = "Noura", LastName = "Al Shamsi", Email = "Fatima@hotmail.com", Phone = "0529287929" },
            new Customer { CustomerId = 3, FirstName = "Zayed", LastName = "Al Hosani", Email = "Zayed-AlHosani@outlook.com", Phone = "0567777129" },
            new Customer { CustomerId = 4, FirstName = "Aisha", LastName = "Al Shamsi", Email = "Aisha-AlShamsi@outlook.com", Phone = "0501770144" }
            );

            modelBuilder.Entity<Car>().HasData(
            new Car { CarId = 1, Make = "Toyota", Model = "Camry", Year = 2020, Color = "Silver", Price = 100,  CarStatus = "Reserved", ImagePath="Sedan01.png"},
            new Car { CarId = 2, Make = "Mercedes", Model = "E Class", Year = 2019, Color = "Red", Price = 350, CarStatus = "Available" ,ImagePath = "Sedan01.png" },
            new Car { CarId = 3, Make = "Nissan" , Model ="Sentra" , Year = 2017, Color = "Black", Price = 120, CarStatus = "Maintenance" ,ImagePath = "sentraBlack2017.png" }
            );


            modelBuilder.Entity<Reservation>().HasData(
              new Reservation { ReservationId = 1, CustomerId = 1, CarId = 1, Start_Date = DateTime.Now.AddDays(0), End_Date = DateTime.Now.AddDays(3), ReservationStatus = "Completed" },
              new Reservation { ReservationId = 2, CustomerId = 2, CarId = 2, Start_Date = DateTime.Now.AddDays(0), End_Date = DateTime.Now.AddDays(4), ReservationStatus = "Completed" },
              new Reservation { ReservationId = 3, CustomerId = 3, CarId = 3, Start_Date = DateTime.Now.AddDays(0), End_Date = DateTime.Now.AddDays(5), ReservationStatus = "Completed" }
            );

            modelBuilder.Entity<Review>().HasData(
            new Review { ReviewId = 1, ReservationId = 1, Rating = 5, Comment = "Excellent service and car condition.", ReviewDate = DateTime.Now.AddDays(3) },
            new Review { ReviewId = 2, ReservationId = 2, Rating = 4, Comment = "Very satisfied with the booking process.", ReviewDate = DateTime.Now.AddDays(4) }
            );
            //---------------------------- Seeding Roles and Admin Account Data ----------------------------//
            var adminroleId = Guid.NewGuid().ToString();

            //Seeding a 'Admin' role to AspNetRoles table
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = adminroleId,
                    Name = "Administrator",
                    NormalizedName = "Administrator".ToUpper()
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Member",
                    NormalizedName = "Member".ToUpper()
                }
            );
            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<Users>();

            //Seeding the User to AspNetUsers table
            var userid = Guid.NewGuid().ToString();
            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    Id = userid, // GUID created earlier as primary key
                    UserName = "admin@77Rental.com",
                    NormalizedUserName = "admin@77Rental.com".ToUpper(),
                    FirstName = "Zayed",
                    LastName = "Maatouq",
                    Email = "admin@77Rental.com",
                    PasswordHash = hasher.HashPassword(null, "Password!")
                }
            );
            //Assigning the Admin User to the Administrator role
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = adminroleId,
                    UserId = userid
                }
            );

            //end of seeding
        }
    }
}
