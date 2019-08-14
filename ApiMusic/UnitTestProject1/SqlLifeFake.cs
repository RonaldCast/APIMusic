using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Persistent;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest
{
    public class SqlLifeFake
    {

        private DbContextOptions<ApplicationDbContext> options;

        public SqlLifeFake()
        {
            options = GetDbContextOptions;
        }

        public ApplicationDbContext GetDbContext()
        {
            var context = new ApplicationDbContext(options);
            //creando el esquema 
            context.Database.EnsureCreated();
            return context;
        }

        private DbContextOptions<ApplicationDbContext> GetDbContextOptions
        {
            get
            {
                //base de dato en memoria 
                var connection = new SqliteConnection("DataSource=:memory:");
                connection.Open();

                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                       .UseSqlite(connection)
                       .Options;

                return options;
            }
            
           

        }
    }
}
