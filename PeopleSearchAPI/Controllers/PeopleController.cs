using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using PeopleSearchAPI.Models;

namespace PeopleSearchAPI.Controllers
{
    public class PeopleController : ApiController
    {
        //Properly handle the HTTP OPTIONS call from the front-end.
        //NOTE:  see the customHeaders section in Web.config
        //for the necessary headers that must be returned on both the OPTIONS and GET calls.
        [HttpOptions]
        [ResponseType(typeof(void))]
        public IHttpActionResult Options()
        {
            return Ok();
        }

        //JSON is the default format for the data sent back, but XML is an option also
        public HttpResponseMessage Get(string format = "json")
        {
            //Call GetPeople to get the data from the database
            IEnumerable<Person> people = SQLiteDataAccess.GetPeople();

            //Format the list of records returned from the database into the requested format
            //JSON or XML.
            if (format == "json")
            {
                //Format for JSON and return
                var content = new ObjectContent<IEnumerable<Person>>(people, Configuration.Formatters.JsonFormatter);
                return new HttpResponseMessage()
                {
                    Content = content
                };
            }
            else
            {
                //Format for XML and return
                var content = new ObjectContent<IEnumerable<Person>>(people, Configuration.Formatters.XmlFormatter);
                return new HttpResponseMessage()
                {
                    Content = content
                };
            }
        }
    }
}
