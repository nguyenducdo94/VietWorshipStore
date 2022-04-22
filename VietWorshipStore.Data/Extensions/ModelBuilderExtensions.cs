using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VietWorshipStore.Data.Entities;
using VietWorshipStore.Data.Enums;

namespace VietWorshipStore.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
               new AppConfig() { Key = "HomeTitle", Value = "This is home page of eShopSolution" },
               new AppConfig() { Key = "HomeKeyword", Value = "This is keyword of eShopSolution" },
               new AppConfig() { Key = "HomeDescription", Value = "This is description of eShopSolution" }
               );
            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi-VN", Name = "Tiếng Việt", IsDefault = true },
                new Language() { Id = "en-US", Name = "English", IsDefault = false });

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 1,
                    Status = Status.Active,
                },
                 new Category()
                 {
                     Id = 2,
                     IsShowOnHome = true,
                     ParentId = null,
                     SortOrder = 2,
                     Status = Status.Active
                 });

            modelBuilder.Entity<CategoryTranslation>().HasData(
                  new CategoryTranslation() { Id = 1, CategoryId = 1, Name = "Hương Lộc Hồng", LanguageId = "vi-VN", SeoAlias = "huong-loc-hong", SeoDescription = "Sản phẩm hương thơm Lộc Hồng", SeoTitle = "ản phẩm hương thơm Lộc Hồng" },
                  new CategoryTranslation() { Id = 2, CategoryId = 1, Name = "Hương vòng Hà Nội", LanguageId = "vi-VN", SeoAlias = "huong-vong-ha-noi", SeoDescription = "Sản phẩm hương vòng thơm Hà Nội", SeoTitle = "Sản phẩm hương vòng thơm Hà Nội" },
                  new CategoryTranslation() { Id = 3, CategoryId = 2, Name = "Đinh tiền Hà Bắc", LanguageId = "vi-VN", SeoAlias = "dinh-tien-ha-bac", SeoDescription = "Sản phẩm đinh tiền Hà Bắc", SeoTitle = "Sản phẩm đinh tiền Hà Bắc" },
                  new CategoryTranslation() { Id = 4, CategoryId = 2, Name = "Đinh vàng Hà Bắc", LanguageId = "vi-VN", SeoAlias = "dinh-vang-ha-bac", SeoDescription = "Sản phẩm đinh vàng Hà Bắc", SeoTitle = "Sản phẩm đinh vàng Hà Bắc" }
                    );

            modelBuilder.Entity<Product>().HasData(
                new Product() { Id = 1, DateCreated = DateTime.Now, OriginalPrice = 10000, Price = 11000, Stock = 100, ViewCount = 0, },
                new Product() { Id = 2, DateCreated = DateTime.Now, OriginalPrice = 9000, Price = 10000, Stock = 100, ViewCount = 0, },
                new Product() { Id = 3, DateCreated = DateTime.Now, OriginalPrice = 5000, Price = 6000, Stock = 100, ViewCount = 0, },
                new Product() { Id = 4, DateCreated = DateTime.Now, OriginalPrice = 5000, Price = 6000, Stock = 100, ViewCount = 0, }
                );

            modelBuilder.Entity<ProductTranslation>().HasData(
                 new ProductTranslation()
                 {
                     Id = 1,
                     ProductId = 1,
                     Name = "Hương Lộc Hồng thơm",
                     LanguageId = "vi-VN",
                     SeoAlias = "huong-loc-hong-thom",
                     SeoDescription = "Hương Lộc Hồng thơm",
                     SeoTitle = "Hương Lộc Hồng thơm",
                     Details = "Hương Lộc Hồng thơm",
                     Description = "Hương Lộc Hồng thơm"
                 });

            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() { ProductId = 1, CategoryId = 1 },
                new ProductInCategory() { ProductId = 2, CategoryId = 1 },
                new ProductInCategory() { ProductId = 3, CategoryId = 2 },
                new ProductInCategory() { ProductId = 4, CategoryId = 2 }
                );

            // any guid
            var roleId = new Guid("06202FAD-A16A-4CDE-AEF7-1D1C643809E4");
            var adminId = new Guid("0FEE3FD0-383F-4A9F-9FF6-B207F7C3D9EB");

            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "dosieunhan@gmail.com",
                NormalizedEmail = "dosieunhan@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin@123"),
                SecurityStamp = string.Empty,
                FirstName = "Do",
                LastName = "Nguyen",
                Dob = new DateTime(1994, 09, 04)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
        }
    }
}
