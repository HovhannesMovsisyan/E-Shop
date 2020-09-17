using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class AppDbContext: IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):
            base(options) { }

        public DbSet<SportsGood> Goods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCardItem> ShoppingCardItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Football" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "Basketball" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "Tennis" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 4, CategoryName = "Voleyball" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 5, CategoryName = "Boxing" });

            modelBuilder.Entity<SportsGood>().HasData(new SportsGood
            {
                GoodsId = 1,
                Name = "Ball for Football",
                Price = 2.87M,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
                  "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
                  "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi " +
                  "ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit",
                CategoryId = 1,
                IsOnSale = true,
                IsInStock = false,
                ImageUrl = "\\Images\\ball.png",
                ImageThumbnailUrl = "\\Images\\thumbnails\\ball-small.png",
            });
            modelBuilder.Entity<SportsGood>().HasData(new SportsGood
            {
                GoodsId = 2,
                Name = "Football Gloves",
                Price = 3.95M,
                Description = "Venenatis tellus in metus vulputate eu scelerisque felis imperdiet proin. Quisque egestas diam in arcu cursus. Sed viverra tellus in hac. Quis commodo odio aenean sed adipiscing diam donec adipiscing.",
                CategoryId = 1,
                ImageUrl = "\\Images\\gloves.png",
                ImageThumbnailUrl = "\\Images\\thumbnails\\gloves-small.png",
                IsInStock = true,
                IsOnSale = true
            });
            modelBuilder.Entity<SportsGood>().HasData(new SportsGood
            {
                GoodsId = 3,
                Name = "Football Shoes",
                Price = 5.75M,
                Description = "Turpis egestas pretium aenean pharetra magna ac placerat vestibulum. Sed faucibus turpis in eu mi bibendum neque egestas. At in tellus integer feugiat scelerisque. Elementum integer enim neque volutpat ac tincidunt.",
                CategoryId = 1,
                ImageUrl = "\\Images\\shoes.png",
                ImageThumbnailUrl = "\\Images\\thumbnails\\shoes-small.png",
                IsInStock = true,
                IsOnSale = false
            });
            modelBuilder.Entity<SportsGood>().HasData(new SportsGood
            {
                GoodsId = 4,
                Name = "Basketball Ball",
                Price = 3.95M,
                Description = "Vitae congue eu consequat ac felis donec et. Praesent semper feugiat nibh sed pulvinar proin gravida hendrerit. Vel eros donec ac odio. A lacus vestibulum sed arcu non odio euismod lacinia at. Nisl suscipit adipiscing bibendum est ultricies integer. Nec tincidunt praesent semper feugiat nibh.",
                CategoryId = 2,
                ImageUrl = "\\Images\\basketball.png",
                ImageThumbnailUrl = "\\Images\\thumbnails\\basketball-small.png",
                IsInStock = true,
                IsOnSale = true
            });
            modelBuilder.Entity<SportsGood>().HasData(new SportsGood
            {
                GoodsId = 5,
                Name = "T-Shirt for Basketball",
                Price = 7.00M,
                Description = "Purus sit amet luctus venenatis lectus magna fringilla. Consectetur lorem donec massa sapien faucibus et molestie ac. Sagittis nisl rhoncus mattis rhoncus urna neque viverra.",
                CategoryId = 2,
                ImageUrl = "\\Images\\basketballshirt.png",
                ImageThumbnailUrl = "\\Images\\thumbnails\\basketballshirt-small.png",
                IsInStock = true,
                IsOnSale = false
            });
            modelBuilder.Entity<SportsGood>().HasData(new SportsGood
            {
                GoodsId = 6,
                Name = "Shoes for Basketball",
                Price = 11.25M,
                Description = "Ultrices vitae auctor eu augue ut. Leo vel fringilla est ullamcorper eget. A diam maecenas sed enim ut. Massa tincidunt dui ut ornare lectus. Nullam non nisi est sit amet facilisis magna. ",
                CategoryId = 2,
                ImageUrl = "\\Images\\basketballshoes.png",
                ImageThumbnailUrl = "\\Images\\thumbnails\\basketballshoes-small.png",
                IsInStock = true,
                IsOnSale = true
            });
            modelBuilder.Entity<SportsGood>().HasData(new SportsGood
            {
                GoodsId = 7,
                Name = "Ball for Tennis",
                Price = 3.95M,
                Description = "Diam sit amet nisl suscipit adipiscing bibendum est ultricies integer. Molestie at elementum eu facilisis sed odio morbi quis commodo. Odio facilisis mauris sit amet massa vitae tortor condimentum lacinia. Urna porttitor rhoncus dolor purus non enim praesent elementum facilisis.",
                CategoryId = 3,
                ImageUrl = "\\Images\\tennisball.png",
                ImageThumbnailUrl = "\\Images\\thumbnails\\tennisball-small.png",
                IsInStock = true,
                IsOnSale = true
            });
            modelBuilder.Entity<SportsGood>().HasData(new SportsGood
            {
                GoodsId = 8,
                Name = "Dress for Tennis Players",
                Price = 1.95M,
                Description = "Posuere ac ut consequat semper viverra nam libero justo laoreet. Ultrices dui sapien eget mi proin sed libero enim. Etiam non quam lacus suspendisse faucibus interdum. Amet nisl suscipit adipiscing bibendum est ultricies integer quis.",
                CategoryId = 3,
                ImageUrl = "\\Images\\tennisdress.png",
                ImageThumbnailUrl = "\\Images\\thumbnails\\tennisdress-small.png",
                IsInStock = true,
                IsOnSale = false
            });
            modelBuilder.Entity<SportsGood>().HasData(new SportsGood
            {
                GoodsId = 9,
                Name = "Rocket for Tennis Players",
                Price = 13.95M,
                Description = "Ut ornare lectus sit amet est placerat in egestas. Iaculis nunc sed augue lacus viverra vitae. Bibendum ut tristique et egestas quis ipsum suspendisse ultrices gravida. Accumsan tortor posuere ac ut consequat semper viverra.",
                CategoryId = 3,
                ImageUrl = "\\Images\\tennisraket.png",
                ImageThumbnailUrl = "\\Images\\thumbnails\\tennisraket-small.png",
                IsInStock = true,
                IsOnSale = true
            });
            modelBuilder.Entity<SportsGood>().HasData(new SportsGood
            {
                GoodsId = 10,
                Name = "For Voleyball",
                Price = 1.95M,
                Description = "Vitae congue eu consequat ac felis donec et odio. Tellus orci ac auctor augue mauris augue. Feugiat sed lectus vestibulum mattis ullamcorper velit sed. Sit amet consectetur adipiscing elit pellentesque habitant morbi tristique senectus. Sed pulvinar proin gravida hendrerit lectus a.",
                CategoryId = 4,
                ImageUrl = "\\Images\\voleyballcanc.png",
                ImageThumbnailUrl = "\\Images\\thumbnails\\voleyballcanc-small.png",
                IsInStock = true,
                IsOnSale = true
            });
            modelBuilder.Entity<SportsGood>().HasData(new SportsGood
            {
                GoodsId = 11,
                Name = "Kneepad For Voleyball",
                Price = 12.95M,
                Description = "Hac habitasse platea dictumst quisque sagittis purus sit. Dui nunc mattis enim ut. Mauris commodo quis imperdiet massa tincidunt nunc pulvinar sapien et.",
                CategoryId = 4,
                ImageUrl = "\\Images\\voleyballkneepad.png",
                ImageThumbnailUrl = "\\Images\\thumbnails\\voleyballkneepad-small.png",
                IsInStock = true,
                IsOnSale = true
            });
            modelBuilder.Entity<SportsGood>().HasData(new SportsGood
            {
                GoodsId = 12,
                Name = "Ball For Voleyball",
                Price = 21.95M,
                Description = "Pulvinar neque laoreet suspendisse interdum consectetur libero id faucibus. Ultrices vitae auctor eu augue ut lectus arcu bibendum at. Vulputate eu scelerisque felis imperdiet proin fermentum.",
                CategoryId = 4,
                ImageUrl = "\\Images\\voleyball.png",
                ImageThumbnailUrl = "\\Images\\thumbnails\\voleyball-small.png",
                IsInStock = true,
                IsOnSale = true
            });
            modelBuilder.Entity<SportsGood>().HasData(new SportsGood
            {
                GoodsId = 13,
                Name = "Boxing Gloves",
                Price = 6.95M,
                Description = "Vestibulum mattis ullamcorper velit sed ullamcorper morbi tincidunt ornare massa. Arcu cursus euismod quis viverra.",
                CategoryId = 5,
                ImageUrl = "\\Images\\boxgloves.png",
                ImageThumbnailUrl = "\\Images\\thumbnails\\boxgloves-small.png",
                IsInStock = true,
                IsOnSale = false
            });
            modelBuilder.Entity<SportsGood>().HasData(new SportsGood
            {
                GoodsId = 14,
                Name = "Helmet For Boxing",
                Price = 2.95M,
                Description = "Blandit massa enim nec dui nunc mattis enim ut tellus. Duis at consectetur lorem donec massa sapien faucibus et. At auctor urna nunc id cursus metus. Ut enim blandit volutpat maecenas volutpat blandit.",
                CategoryId = 5,
                ImageUrl = "\\Images\\boxinghelmet.png",
                ImageThumbnailUrl = "\\Images\\thumbnails\\boxinghelmet-small.png",
                IsInStock = true,
                IsOnSale = true
            });
            modelBuilder.Entity<SportsGood>().HasData(new SportsGood
            {
                GoodsId = 15,
                Name = "Boxing Shorts",
                Price = 16.95M,
                Description = "Nisi lacus sed viverra tellus in. Morbi non arcu risus quis varius quam quisque id. Cras adipiscing enim eu turpis egestas. Tristique nulla aliquet enim tortor. Quisque id diam vel quam. Id faucibus nisl tincidunt eget nullam.",
                CategoryId = 5,
                ImageUrl = "\\Images\\boxingshorts.png",
                ImageThumbnailUrl = "\\Images\\thumbnails\\boxingshorts-small.png",
                IsInStock = true,
                IsOnSale = false
            });
        }
    }
}
