using System.Collections.Generic;
using System.Linq;
using MyApp.API.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

using System;
using Microsoft.Extensions.DependencyInjection;
using JsonNet.ContractResolvers;

namespace MyApp.API.Data
{
   public static class DataImporter {
        public static void Seedit(IServiceProvider serviceProvider) 
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
                    context.AddRange(colleges);
                    context.SaveChanges();
                    }
                }
        }

        public static bool EnsureCollegeData(DataContext context)
        {
            bool hasData = false;
            try {
                hasData = context.Colleges.Any();
            } catch {
                context.Database.EnsureCreated(); // just create the schema - no migrations
                hasData = context.Colleges.Any();
            }

            if (!hasData) {
                string json = System.IO.File.ReadAllText("Data/SeedCollegeData.json");
                return ImportCollegesFromJson(context, json) > 0;
            }

            return true;
        }

        public static bool EnsureCourseData(DataContext context)
        {
            bool hasData = false;
            try {
                hasData = context.Courses.Any();
            } catch {
                context.Database.EnsureCreated(); // just create the schema - no migrations
                hasData = context.Courses.Any();
            }

            if (!hasData) {
                string json = System.IO.File.ReadAllText("Data/SeedCourseData.json");
                return ImportCoursesFromJson(context, json) > 0;
            }

            return true;
        }

        public static bool EnsureSubDistrictData(DataContext context)
        {
            bool hasData = false;
            try {
                hasData = context.SubDistricts.Any();
            } catch {
                context.Database.EnsureCreated(); // just create the schema - no migrations
                hasData = context.SubDistricts.Any();
            }

            if (!hasData) {
                string json = System.IO.File.ReadAllText("Data/SeedSubDistrictData.json");
                return ImportSubDistrictsFromJson(context, json) > 0;
            }

            return true;
        }        
        /// <summary>
        /// Imports data from json
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static int ImportCollegesFromJson(DataContext context, string json)
        {
            var colleges = JsonConvert.DeserializeObject<College[]>(json);

            foreach (var college in colleges)
            {
                 // clear out primary/identity keys so insert works
                college.Id = 0;
                //var existingCollege = context.Colleges.Where(a => a.CollegeName == college.CollegeName).FirstOrDefault();
                //if (existingCollege == null) {
                    context.Add(college);
                //}

                try {
                    context.SaveChanges();
                } catch {
                    Console.WriteLine("Error adding: " + college.Id);
                }
            }
            return 1;
        }
        public static int ImportCoursesFromJson(DataContext context, string json)
        {
            var courses = JsonConvert.DeserializeObject<Course[]>(json);

            foreach (var course in courses)
            {
                 // clear out primary/identity keys so insert works
                course.Id = 0;
                var existingCourse = context.Courses.Where(a => a.Name == course.Name).FirstOrDefault();
                if (existingCourse == null) {
                    context.Add(course);
                }

                try {
                    context.SaveChanges();
                } catch {
                    Console.WriteLine("Error adding: " + course.Id);
                }
            }
            return 1;
        }

        public static int ImportSubDistrictsFromJson(DataContext context, string json)
        {
            var subDistricts = JsonConvert.DeserializeObject<SubDistrict[]>(json);

            foreach (var subDistrict in subDistricts)
            {
                 // clear out primary/identity keys so insert works
                subDistrict.Id = 0;
                var existingSubDistrict = context.SubDistricts.Where(a => a.Name == subDistrict.Name).FirstOrDefault();
                if (existingSubDistrict == null) {
                    context.Add(subDistrict);
                }

                try {
                    context.SaveChanges();
                } catch {
                    Console.WriteLine("Error adding: " + subDistrict.Id);
                }
            }
            return 1;
        }
    }


}