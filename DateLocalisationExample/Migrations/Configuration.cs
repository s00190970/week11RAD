namespace DateLocalisationExample.Migrations
{
    using DateExample.DataModel;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DateExample.DataModel.DateContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DateExample.DataModel.DateContext context)
        {
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
