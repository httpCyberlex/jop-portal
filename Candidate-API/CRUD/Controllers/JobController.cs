using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;


namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : Controller
    {
        private readonly IConfiguration configuration;
        
        public JobController(IConfiguration Configuration)
        {
            configuration = Configuration;
        }

        SqlCommand CMD;

    }
}
