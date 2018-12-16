using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using OPWAPP2.DAL;
using OPWAPP2.Models;
namespace OPWAPP2.Controllers
{

    [RoutePrefix("api/WorksApi")]
    public class WorksApiController : ApiController
    {
        public OPWContext2 db = new OPWContext2();

        //GET: api/Works
        public IEnumerable<Work> Get()
        {
            return db.Opwwork2.ToList();
        }
        /*
        // GET: api/WorksApi
        public string GetWorks()
        {
            return ("Use: '/ByID' to returnlist of works");
        }
        */
        


        // GET: api/WorksApi/ByID[ID]
        [Route("ByID/{id}")]
        public IEnumerable<int> GetByKeyWord(int name)
        {
            int projectID = db.Opwwork2.FirstOrDefault(p => p.Project_ID.Equals(name)).Project_ID;
            var results = db.Opwwork2.Where(p => p.Project_ID.Equals(projectID));
            if (results == null)
            {
                return null;
            }

            List<int> worklist = new List<int>();
            foreach (Work d in results)
            {
                worklist.Add(d.Project_ID);
                //worklist.Add(d.Project_Desc);
               // worklist.Add(d.Proj_Act_Cost);
            }
            return worklist;

        }
    }
}