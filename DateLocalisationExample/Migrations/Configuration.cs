namespace DateLocalisationExample.Migrations
{
    using CsvHelper;
    using DateExample.DataModel;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<DateExample.DataModel.Week11Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DateExample.DataModel.Week11Context context)
        {
            Random gen = new Random();
            DateTime start = new DateTime(2015, 01, 01);
            int range = (DateTime.Today - start).Days;

            Assembly assembly = Assembly.GetExecutingAssembly();
            // Assembly name and resource stored in assembly
            string resourceName = "DateLocalisationExample.StudentList1.csv";
            // Get the embedded resource from the assembly
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {   // create a stream reader
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    // create a csv reader dor the stream
                    CsvReader csvReader = new CsvReader(reader);
                    csvReader.Configuration.HasHeaderRecord = false;
                    csvReader.Configuration.MissingFieldFound = null;
                    var students = csvReader.GetRecords<Models.StudentData>().ToList();
                    foreach (var student in students)
                    {
                        context.Students.AddOrUpdate(new Student
                        {
                            StudentNumber = student.StudentNumber,
                            Firstname = student.Firstname,
                            Surname = student.Surname,
                            DateRegistered = start.AddDays(gen.Next(range))
                        });
                        
                    }
                }
            }

            

            



            CultureInfo cultureinfo = CultureInfo.CreateSpecificCulture("en-IE");

            context.Dates.AddOrUpdate(new LocalDate[] {
            new LocalDate
            {
                StartDate = DateTime.ParseExact("25/03/2017","dd/MM/yyyy",cultureinfo),
                EndDate = DateTime.ParseExact("01/02/2017","dd/MM/yyyy",cultureinfo),

            },
            });
        }
    }
}
