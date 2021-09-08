using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RestaurantReviewer.DataAccess.Entities;
using RestaurantReviewer.Domain;
using System.ComponentModel.DataAnnotations;


namespace Test
{
    public class UnitTest1
    {
        private readonly DbContextOptions options = new DbContextOptionsBuilder<RestaurantReviewer.DataAccess.Entities.PojectzeroContext>().UseSqlite("Filename=test.db").Options;

        //[Fact]
        //public void TestRepo()
        //{
        //    Seed();
        //}
        [Fact]
        public void AddAUserShouldAddAUser()
        {
            //Arrange
            var tesUser = new RestaurantReviewer.Domain.User {
                Id = 10,
                Name = "Bob Smith",
                AccessLvl = 1

            };

            //Act
            var validated = new List<ValidationResult>();
            var result = Validator.TryValidateObject(tesUser, new ValidationContext(tesUser), validated, true);
            //Assert

            Assert.True(result, "Expected to pass");
        }


        //private void Seed()
        //{
        //    using(var context = new Entity.reviewdbContext(options))
        //    {
        //        context.Database.EnsureDeleted();
        //        context.Database.EnsureCreated(); // wipe the tables

        //        context.Users.AddRange(
        //            new Models.User{
        //                Id = 1,
        //                Name = "Frank Stevens",
        //                AcessLvl = 1

        //            }
        //        );
        //    }

        //    context.SaveChanges(); //Does the actual commit
        //}

        //Given
        //When
        //Then
    }
}
