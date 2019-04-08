using MyApp.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyApp.API.Data
{
    public class DataContext : IdentityDbContext<User, Role, int, 
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, 
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions<DataContext>  options) : base (options) {}

        public DbSet<Value> Values { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Message> Messages { get; set; }
        public virtual DbSet<College> Colleges { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<RelationType> RelationTypes { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentAcademic> StudentAcademics { get; set; }
        public virtual DbSet<StudentDocument> StudentDocuments { get; set; }
        public virtual DbSet<StudentEnrollment> StudentEnrollments { get; set; }
        public virtual DbSet<StudentFee> StudentFees { get; set; }
        public virtual DbSet<StudentPlacement> StudentPlacements { get; set; }
        public virtual DbSet<StudentRelation> StudentRelations { get; set; }
        public virtual DbSet<StudentSemester> StudentSemesters { get; set; }
        public virtual DbSet<SubDistrict> SubDistricts { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRole>(userRole => 
            {
                userRole.HasKey(ur => new {ur.UserId, ur.RoleId});

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            builder.Entity<Like>()
                .HasKey(k => new {k.LikerId, k.LikeeId});

            builder.Entity<Like>()
                .HasOne(u => u.Likee)
                .WithMany(u => u.Likers)
                .HasForeignKey(u => u.LikeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Like>()
                .HasOne(u => u.Liker)
                .WithMany(u => u.Likees)
                .HasForeignKey(u => u.LikerId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.Entity<Message>()
                .HasOne(u => u.Sender)
                .WithMany(m => m.MessagesSent)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Message>()
                .HasOne(u => u.Recipient)
                .WithMany(m => m.MessagesReceived)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Photo>().HasQueryFilter(p => p.IsApproved);

            builder.Entity<College>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.ContactNumber).HasMaxLength(50);

                entity.HasOne(d => d.CollegeDistrictNavigation)
                    .WithMany(p => p.Colleges)
                    .HasForeignKey(d => d.DistrictId)
                    .HasConstraintName("FK_Colleges_Districts");
            });

/*             var collegeData = System.IO.File.ReadAllText("Data/SeedCollegeData.json");
            var colleges = JsonConvert.DeserializeObject<List<College>>(collegeData);
            int cCount = colleges.Count; 
            
            builder.Entity<College>().HasData(colleges);*/

            builder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });
            
            builder.Entity<Country>().HasData(new Country{ Id = 1, Name = "India"});

            builder.Entity<State>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.States)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_States_Countries");
            });


            builder.Entity<State>().HasData(
                new State { Id = 1, Name = "Andaman and Nicobar Island", CountryId = 1},
                new State { Id = 2, Name = "Andhra Pradesh", CountryId = 1},
                new State { Id = 3, Name = "Arunachal Pradesh", CountryId = 1},
                new State { Id = 4, Name = "Assam", CountryId = 1},
                new State { Id = 5, Name = "Bihar", CountryId = 1},
                new State { Id = 6, Name = "Chandigarh", CountryId = 1},
                new State { Id = 7, Name = "Chhattisgarh", CountryId = 1},
                new State { Id = 8, Name = "Dadra and Nagar Haveli", CountryId = 1},
                new State { Id = 9, Name = "Daman and Diu", CountryId = 1},
                new State { Id = 10, Name = "Delhi", CountryId = 1},
                new State { Id = 11, Name = "Goa", CountryId = 1},
                new State { Id = 12, Name = "Gujarat", CountryId = 1},
                new State { Id = 13, Name = "Haryana", CountryId = 1},
                new State { Id = 14, Name = "Himachal Pradesh", CountryId = 1},
                new State { Id = 15, Name = "Jammu and Kashmir", CountryId = 1},
                new State { Id = 16, Name = "Jharkhand", CountryId = 1},
                new State { Id = 17, Name = "Karnataka", CountryId = 1},
                new State { Id = 18, Name = "Kerala", CountryId = 1},
                new State { Id = 19, Name = "Lakshadweep", CountryId = 1},
                new State { Id = 20, Name = "Madhya Pradesh", CountryId = 1},
                new State { Id = 21, Name = "Maharashtra", CountryId = 1},
                new State { Id = 22, Name = "Manipur", CountryId = 1},
                new State { Id = 23, Name = "Meghalaya", CountryId = 1},
                new State { Id = 24, Name = "Mizoram", CountryId = 1},
                new State { Id = 25, Name = "Nagaland", CountryId = 1},
                new State { Id = 26, Name = "Odisha", CountryId = 1},
                new State { Id = 27, Name = "Puducherry", CountryId = 1},
                new State { Id = 28, Name = "Punjab", CountryId = 1},
                new State { Id = 29, Name = "Rajasthan", CountryId = 1},
                new State { Id = 30, Name = "Sikkim", CountryId = 1},
                new State { Id = 31, Name = "Tamil Nadu", CountryId = 1},
                new State { Id = 32, Name = "Telangana", CountryId = 1},
                new State { Id = 33, Name = "Tripura", CountryId = 1},
                new State { Id = 34, Name = "Uttar Pradesh", CountryId = 1},
                new State { Id = 35, Name = "Uttarakhand", CountryId = 1},
                new State { Id = 36, Name = "West Bengal", CountryId = 1});

            builder.Entity<District>(entity =>
            {
                entity.HasOne(d => d.State)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Districts_States");
            });

            builder.Entity<District>().HasData(
                new District { Id = 515, Name = "Ariyalur", StateId = 31},
                new District { Id = 516, Name = "Chennai", StateId = 31},
                new District { Id = 517, Name = "Coimbatore", StateId = 31},
                new District { Id = 518, Name = "Cuddalore", StateId = 31},
                new District { Id = 519, Name = "Dharmapuri", StateId = 31},
                new District { Id = 520, Name = "Dindigul", StateId = 31},
                new District { Id = 521, Name = "Erode", StateId = 31},
                new District { Id = 522, Name = "Kanchipuram", StateId = 31},
                new District { Id = 523, Name = "Kanyakumari", StateId = 31},
                new District { Id = 524, Name = "Karur", StateId = 31},
                new District { Id = 525, Name = "Krishnagiri", StateId = 31},
                new District { Id = 526, Name = "Madurai", StateId = 31},
                new District { Id = 527, Name = "Nagapattinam", StateId = 31},
                new District { Id = 528, Name = "Namakkal", StateId = 31},
                new District { Id = 529, Name = "Nilgiris", StateId = 31},
                new District { Id = 530, Name = "Perambalur", StateId = 31},
                new District { Id = 531, Name = "Pudukkottai", StateId = 31},
                new District { Id = 532, Name = "Ramanathapuram", StateId = 31},
                new District { Id = 533, Name = "Salem", StateId = 31},
                new District { Id = 534, Name = "Sivagangai", StateId = 31},
                new District { Id = 535, Name = "Thanjavur", StateId = 31},
                new District { Id = 536, Name = "Theni", StateId = 31},
                new District { Id = 537, Name = "Tuticorin", StateId = 31},
                new District { Id = 538, Name = "Tiruchirapalli", StateId = 31},
                new District { Id = 539, Name = "Thirunelveli", StateId = 31},
                new District { Id = 540, Name = "Tiruppur", StateId = 31},
                new District { Id = 541, Name = "Thiruvallur", StateId = 31},
                new District { Id = 542, Name = "Thiruvannamalai", StateId = 31},
                new District { Id = 543, Name = "Thiruvarur", StateId = 31},
                new District { Id = 544, Name = "Vellore", StateId = 31},
                new District { Id = 545, Name = "Viluppuram", StateId = 31},
                new District { Id = 546, Name = "Virudhunagar", StateId = 31});

            builder.Entity<Course>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Name).HasMaxLength(256);
            });

/*             var courseData = System.IO.File.ReadAllText("Data/SeedCourseData.json");
            var courses = JsonConvert.DeserializeObject<List<Course>>(courseData);
            builder.Entity<Course>().HasData(courses); */

            builder.Entity<DocumentType>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            builder.Entity<DocumentType>().HasData(
                    new DocumentType { Id = 1, Code = "SSLC Mark", DocumentDesc = "10th Mark Sheet"},
                    new DocumentType { Id = 2, Code = "12th Mark", DocumentDesc = "12th Mark Sheet"},
                    new DocumentType { Id = 3, Code = "Ration Card", DocumentDesc = "Family Member Details"},
                    new DocumentType { Id = 4, Code = "Birth Certificate", DocumentDesc = "Birth Certificate"},
                    new DocumentType { Id = 5, Code = "Aadhaar", DocumentDesc = "Aadhaar Details"},
                    new DocumentType { Id = 6, Code = "UG Degree", DocumentDesc = "Under Grduate Degree Certificate"});

            builder.Entity<PaymentType>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(25);
            });
            
            builder.Entity<PaymentType>().HasData(	
                    new PaymentType { Id = 1, Code = "Cash", PaymentDesc = "Cash"},
                    new PaymentType { Id = 2, Code = "Cheque", PaymentDesc = "Cheque"},
                    new PaymentType { Id = 3, Code = "DD", PaymentDesc = "Demand Draft"});            

            builder.Entity<RelationType>(entity =>
            {
                entity.Property(e => e.Relation)
                    .IsRequired()
                    .HasColumnName("RelationType")
                    .HasMaxLength(50);

                entity.Property(e => e.RelationTypeDesc).HasMaxLength(50);
            });

            builder.Entity<RelationType>().HasData(		
                    new RelationType { Id = 1, Relation = "Father", RelationTypeDesc = "Parent"},
                    new RelationType { Id = 2, Relation = "Mother", RelationTypeDesc = "Parent"},
                    new RelationType { Id = 3, Relation = "GrandParent", RelationTypeDesc = "Grand Father , Grand Mother"},
                    new RelationType { Id = 4, Relation = "Guardian", RelationTypeDesc = "Uncle, Aunt"},
                    new RelationType { Id = 5, Relation = "Sister", RelationTypeDesc = "Sibling"},
                    new RelationType { Id = 6, Relation = "Brother", RelationTypeDesc = "Sibling"});
                    
            builder.Entity<Semester>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.SemesterDesc).HasMaxLength(256);

                entity.Property(e => e.SemesterEndMonth).HasMaxLength(10);

                entity.Property(e => e.SemesterStartMonth).HasMaxLength(10);
            });

            builder.Entity<Semester>().HasData(		
                    new Semester { Id = 1, Code = "Sem 1", SemesterStartMonth = "Jun", SemesterEndMonth = "Nov"},
                    new Semester { Id = 2, Code = "Sem 2", SemesterStartMonth = "Dec", SemesterEndMonth = "Apr"},
                    new Semester { Id = 3, Code = "Sem 3", SemesterStartMonth = "Jun", SemesterEndMonth = "Nov"},
                    new Semester { Id = 4, Code = "Sem 4", SemesterStartMonth = "Dec", SemesterEndMonth = "Apr"},
                    new Semester { Id = 5, Code = "Sem 5", SemesterStartMonth = "Jun", SemesterEndMonth = "Nov"},
                    new Semester { Id = 6, Code = "Sem 6", SemesterStartMonth = "Dec", SemesterEndMonth = "Apr"},
                    new Semester { Id = 7, Code = "Sem 7", SemesterStartMonth = "Jun", SemesterEndMonth = "Nov"},
                    new Semester { Id = 8, Code = "Sem 8", SemesterStartMonth = "Dec", SemesterEndMonth = "Apr"},
                    new Semester { Id = 9, Code = "Year 1", SemesterStartMonth = "Jun", SemesterEndMonth = "Apr"},
                    new Semester { Id = 10, Code = "Year 2", SemesterStartMonth = "Jun", SemesterEndMonth = "Apr"},
                    new Semester { Id = 11, Code = "Year 3", SemesterStartMonth = "Jun", SemesterEndMonth = "Apr"},
                    new Semester { Id = 12, Code = "Year 4", SemesterStartMonth = "Jun", SemesterEndMonth = "Apr"},
                    new Semester { Id = 13, Code = "Year 5", SemesterStartMonth = "Jun", SemesterEndMonth = "Apr"});            

            builder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.BloodGroup).HasMaxLength(80);

                entity.Property(e => e.Caste).HasMaxLength(80);

                entity.Property(e => e.Cfssn)
                    .HasColumnName("CFSSN")
                    .HasMaxLength(50);

                entity.Property(e => e.CountryOfBirth).HasMaxLength(100);

                entity.Property(e => e.CurrentCity).HasMaxLength(255);

                entity.Property(e => e.CurrentDistrict).HasMaxLength(255);

                entity.Property(e => e.DisabilityType).HasMaxLength(100);

                entity.Property(e => e.EmailId).HasMaxLength(256);

                entity.Property(e => e.FatherName).HasMaxLength(80);

                entity.Property(e => e.FirstName).HasMaxLength(80);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.IsAllSemSupport).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsCollege).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(80);

                entity.Property(e => e.MobileNumber1).HasMaxLength(50);

                entity.Property(e => e.MobileNumber2).HasMaxLength(50);

                entity.Property(e => e.MotherTongue).HasMaxLength(80);

                entity.Property(e => e.Nationality).HasMaxLength(80);

                entity.Property(e => e.PermanentCity).HasMaxLength(255);

                entity.Property(e => e.PermanentDistrict).HasMaxLength(255);

                entity.Property(e => e.PhoneWithStdCode).HasMaxLength(255);

                entity.Property(e => e.PlaceOfBirth).HasMaxLength(100);

                entity.Property(e => e.PrevCfssn)
                    .HasColumnName("PrevCFSSN")
                    .HasMaxLength(50);

                entity.Property(e => e.Religion).HasMaxLength(80);

                entity.Property(e => e.StateOfBirth).HasMaxLength(100);

                entity.HasOne(d => d.CurrentCityNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.CurrentCityId)
                    .HasConstraintName("FK_Students_SubDistricts");

                entity.HasOne(d => d.CurrentDistrictNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.CurrentDistrictId)
                    .HasConstraintName("FK_Students_Districts");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.InverseIdNavigation)
                    .HasForeignKey<Student>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Students_Students");
            });

            builder.Entity<StudentAcademic>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AcademicGroup).HasMaxLength(80);

                entity.Property(e => e.MediumOfInstruction).HasMaxLength(50);

                entity.Property(e => e.Percentage).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.SchoolBoardType).HasMaxLength(50);

                entity.Property(e => e.SchoolCity).HasMaxLength(80);

                entity.Property(e => e.SchoolDistrict).HasMaxLength(80);

                entity.Property(e => e.SchoolName).HasMaxLength(256);

                entity.Property(e => e.Standard).HasMaxLength(10);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.InverseIdNavigation)
                    .HasForeignKey<StudentAcademic>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentAcademics_StudentAcademics");

                entity.HasOne(d => d.SchoolCityNavigation)
                    .WithMany(p => p.StudentAcademics)
                    .HasForeignKey(d => d.SchoolCityId)
                    .HasConstraintName("FK_StudentAcademics_SubDistricts");

                entity.HasOne(d => d.SchoolDistrictNavigation)
                    .WithMany(p => p.StudentAcademics)
                    .HasForeignKey(d => d.SchoolDistrictId)
                    .HasConstraintName("FK_StudentAcademics_Districts");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentAcademics)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_StudentAcademics_Students");
            });

            builder.Entity<StudentDocument>(entity =>
            {
                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.StudentDocuments)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentDocuments_Students");
            });

            builder.Entity<StudentEnrollment>(entity =>
            {
                entity.HasOne(d => d.College)
                    .WithMany(p => p.StudentEnrollments)
                    .HasForeignKey(d => d.CollegeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentEnrollments_Colleges");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StudentEnrollments)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentEnrollments_Courses");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentEnrollments)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentEnrollments_Students");
            });

            builder.Entity<StudentFee>(entity =>
            {
                entity.Property(e => e.BankDetails).HasMaxLength(256);

                entity.Property(e => e.ChequeNumber).HasMaxLength(256);

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.StudentFees)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentFees_PaymentTypes");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentFees)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentFees_Students");
            });

            builder.Entity<StudentPlacement>(entity =>
            {
                entity.Property(e => e.Organisation).HasMaxLength(256);

                entity.Property(e => e.PlacementStartDate).HasMaxLength(256);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentPlacements)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentPlacements_Students");
            });

            builder.Entity<StudentRelation>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AnnualIncome).HasMaxLength(50);

                entity.Property(e => e.CompanyName).HasMaxLength(50);

                entity.Property(e => e.MobileNumber).HasMaxLength(50);

                entity.Property(e => e.Occupation).HasMaxLength(50);

                entity.Property(e => e.PermanentAddress).HasMaxLength(50);

                entity.Property(e => e.PermanentCity).HasMaxLength(50);

                entity.Property(e => e.PermanentDistrict).HasMaxLength(50);

                entity.Property(e => e.PermanentPincode).HasMaxLength(50);

                entity.Property(e => e.PermanentState).HasMaxLength(50);

                entity.Property(e => e.PhoneWithStdcode)
                    .HasColumnName("PhoneWithSTDCode")
                    .HasMaxLength(50);

                entity.Property(e => e.RelationName).HasMaxLength(50);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.InverseIdNavigation)
                    .HasForeignKey<StudentRelation>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentRelations_StudentRelations");

                entity.HasOne(d => d.PermanentCityNavigation)
                    .WithMany(p => p.StudentRelations)
                    .HasForeignKey(d => d.PermanentCityId)
                    .HasConstraintName("FK_StudentRelations_SubDistricts");

                entity.HasOne(d => d.PermanentDistrictNavigation)
                    .WithMany(p => p.StudentRelations)
                    .HasForeignKey(d => d.PermanentDistrictId)
                    .HasConstraintName("FK_StudentRelations_Districts");

                entity.HasOne(d => d.PermanentStateNavigation)
                    .WithMany(p => p.StudentRelations)
                    .HasForeignKey(d => d.PermanentStateId)
                    .HasConstraintName("FK_StudentRelations_States");

                entity.HasOne(d => d.RelationType)
                    .WithMany(p => p.StudentRelations)
                    .HasForeignKey(d => d.RelationTypeId)
                    .HasConstraintName("FK_StudentRelations_RelationTypes");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentRelations)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_StudentRelations_Students");
            });

            builder.Entity<StudentSemester>(entity =>
            {
                entity.Property(e => e.SemesterGrade).HasColumnType("numeric(10, 0)");

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.StudentSemesters)
                    .HasForeignKey(d => d.SemesterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentSemesters_Semesters");

                entity.HasOne(d => d.StudentEnroll)
                    .WithMany(p => p.StudentSemesters)
                    .HasForeignKey(d => d.StudentEnrollId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentSemesters_StudentEnrollments");
            });

            builder.Entity<SubDistrict>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.District)
                    .WithMany(p => p.SubDistricts)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubDistricts_Districts");
            });

/*             var subDistrictData = System.IO.File.ReadAllText("Data/SeedSubDistrictData.json");
            var subDistricts = JsonConvert.DeserializeObject<List<SubDistrict>>(subDistrictData);
            builder.Entity<SubDistrict>().HasData(subDistricts); */ 

        }
    }
}