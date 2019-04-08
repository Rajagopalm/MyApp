using System.Collections.Generic;
using System.Linq;
using MyApp.API.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

using System;
using Microsoft.Extensions.DependencyInjection;
using JsonNet.ContractResolvers;
using Microsoft.EntityFrameworkCore;

namespace MyApp.API.Data
{
    public class Seed
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public Seed(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedUsers()
        {
            if (!_userManager.Users.Any())
            {
                var userData = System.IO.File.ReadAllText("Data/SeedUserData.json");
                var users = JsonConvert.DeserializeObject<List<User>>(userData);

                var roles = new List<Role>
                {
                    new Role{Name = "Member"},
                    new Role{Name = "Admin"},
                    new Role{Name = "Moderator"},
                    new Role{Name = "VIP"},
                };

                foreach (var role in roles)
                {
                    _roleManager.CreateAsync(role).Wait();
                }

                foreach (var user in users)
                {
                    user.Photos.SingleOrDefault().IsApproved = true;
                    _userManager.CreateAsync(user, "password").Wait();
                    _userManager.AddToRoleAsync(user, "Member").Wait();
                }

                var adminUser = new User
                {
                    UserName = "Admin"
                };

                IdentityResult result = _userManager.CreateAsync(adminUser, "password").Result;

                if (result.Succeeded)
                {
                    var admin = _userManager.FindByNameAsync("Admin").Result;
                    _userManager.AddToRolesAsync(admin, new[] {"Admin", "Moderator"}).Wait();
                }
            }
        }

        public void Seedit(IServiceProvider serviceProvider) 
        {
                JsonSerializerSettings settings = new JsonSerializerSettings {ContractResolver = new PrivateSetterContractResolver()};
                
                string jsonData = System.IO.File.ReadAllText("Data/SeedCollegeData.json");
                List<College> colleges = JsonConvert.DeserializeObject<List<College>>(jsonData, settings);
                using (
                var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var context = serviceScope
                                .ServiceProvider.GetService<DataContext>();
                    if (!context.Colleges.Any()) {
                        //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Colleges ON");
                        context.AddRange(colleges);
                        context.SaveChanges();
                        //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Colleges OFF");

                    }
                }

                jsonData = System.IO.File.ReadAllText("Data/SeedSubDistrictData.json");
                List<SubDistrict> subDistricts = JsonConvert.DeserializeObject<List<SubDistrict>>(jsonData, settings);
                using (
                var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var context = serviceScope
                                .ServiceProvider.GetService<DataContext>();
                    if (!context.SubDistricts.Any()) {
                        //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Colleges ON");
                        context.AddRange(subDistricts);
                        context.SaveChanges();
                        //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Colleges OFF");

                    }
                }

                jsonData = System.IO.File.ReadAllText("Data/SeedCourseData.json");
                List<Course> courses = JsonConvert.DeserializeObject<List<Course>>(jsonData, settings);
                using (
                var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var context = serviceScope
                                .ServiceProvider.GetService<DataContext>();
                    if (!context.Courses.Any()) {
                        //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Colleges ON");
                        context.AddRange(courses);
                        context.SaveChanges();
                        //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Colleges OFF");

                    }
                }
        }


    }


}