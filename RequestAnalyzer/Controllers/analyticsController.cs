using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class analyticsController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get(long timestamp)
        {
            DataTable dt = new DatabaseHandler().getReport(new DateTime(1970, 1, 1).AddMilliseconds(timestamp));
            string res = $"unique_users,{dt.Rows[0]["UserNameCount"].ToString()}\nclicks={dt.Rows[0]["IsClickCount"].ToString()}\nimpressions,{dt.Rows[0]["Impression"].ToString()}";
            return res;
        }
        private void addData(long timestamp, string u, bool isClick)
        {
            DatabaseHandler da = new DatabaseHandler();

            da.Add(new DateTime(1970, 1, 1).AddMilliseconds(timestamp), u, isClick);
        }

        // POST api/values
        [HttpPost]
        public void Post(long timestamp, string user, bool isClick)
        {
            Task.Run(() => { addData(timestamp, user, isClick); });
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
