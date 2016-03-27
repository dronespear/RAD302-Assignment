namespace RAD302Assignment.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RAD302Assignment.Models.InfomationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(RAD302Assignment.Models.InfomationContext context)
        {
            List<PeopleIndex> InfoIndex = new List<PeopleIndex>()
            {
                new PeopleIndex { Name = "Kay Damme", Age = 22},
                new PeopleIndex { Name = "Jack Dreamlander", Age = 40},
                new PeopleIndex { Name = "Lisa Jones", Age = 39},
                new PeopleIndex { Name = "Sam Jones", Age = 47},
                new PeopleIndex { Name = "John Shane", Age = 43},
                new PeopleIndex { Name = "Sarah Jackel", Age = 27},
                new PeopleIndex { Name = "Jim Stones", Age = 23},
                new PeopleIndex { Name = "Anna Stones", Age = 25},
                new PeopleIndex { Name = "Jay Stones", Age = 26},
                new PeopleIndex { Name = "Kim Tonnies", Age = 34}
            };

            InfoIndex.ForEach(c => context.People.Add(c));

            List<PersonInfo> Persons = new List<PersonInfo>()
            {
                new PersonInfo { FirstName = "Kay", LastName = "Damme", Gender = "Male", Age = 22, Nationality = "American", Job = "Engineer"},
                new PersonInfo { FirstName = "Jack", LastName = "Dreamlander", Gender = "Male", Age = 40, Nationality = "Berlin", Job = "Dentist"},
                new PersonInfo { FirstName = "Lisa", LastName = "Jones", Gender = "Female", Age = 39, Nationality = "Irish", Job = "College Lecturer"},
                new PersonInfo { FirstName = "Sam", LastName = "Jones", Gender = "Female", Age = 47, Nationality = "Spanish", Job = "Childminder"},
                new PersonInfo { FirstName = "John", LastName = "Shane", Gender = "Male", Age = 43, Nationality = "Irish", Job = "Software Designer"},
                new PersonInfo { FirstName = "Sarah", LastName = "Jackel", Gender = "Female", Age = 27, Nationality = "German", Job = "3D Designer"},
                new PersonInfo { FirstName = "Jim", LastName = "Stones", Gender = "Male", Age = 23, Nationality = "French", Job = "Carpenter"},
                new PersonInfo { FirstName = "Anna", LastName = "Stones", Gender = "Female", Age = 25, Nationality = "American", Job = "Software Engineer"},
                new PersonInfo { FirstName = "Jay", LastName = "Stones", Gender = "Male", Age = 26, Nationality = "Polish", Job = "Construction Worker"},
                new PersonInfo { FirstName = "Kim", LastName = "Tonnies", Gender = "Female", Age = 34, Nationality = "Australian", Job = "Teacher"}
            };

            Persons.ForEach(s => context.PersonInfo.Add(s));
        }
    }
}
