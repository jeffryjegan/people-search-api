using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SQLite;
using System.Threading.Tasks;
using Dapper;

namespace PeopleSearchAPI.Models
{
    public class SQLiteDataAccess
    {
        public static IEnumerable<Person> GetPeople()
        {
            //Set the dbLocation to the current working directory (base + bin\\) and the filename.
            //string dbLocation = @"C:\users\hairbrush\source\repos\PeopleSearchAPI\PeopleSearchAPI\bin\PeopleDB.db";
            string dbLocation = AppDomain.CurrentDomain.BaseDirectory + "bin\\PeopleDB.db";

            //The using statement ensures that, whether the code completes or crashes,
            //the database connection is closed.
            using (IDbConnection db = new SQLiteConnection(
                connectionString:
                @"Data Source=" + dbLocation))
            {
                String query = "select * from People";
                //Use the query above and the command below to get all the records from the database.
                IEnumerable<Person> peopleResponse = db.Query<Person>(query);
                return peopleResponse;
            }
        }
    }
}