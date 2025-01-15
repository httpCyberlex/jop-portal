using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.IO.Pipelines;
using System.Net;

namespace CRUD.Controllers
{
    public class MasterController : Controller
    {
        private readonly IConfiguration configuration;

        public MasterController(IConfiguration Configuration)
        {
            configuration = Configuration;
        }  

        SqlConnection CON = new SqlConnection();
        SqlCommand CMD = new SqlCommand();

        [Route("Get/CandidateMaster")]
        [HttpGet]

        public ActionResult<List<CandidateTypeMaster>> GetCandidateMaster()
        {
            var master = new List<CandidateTypeMaster>();
            CON = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
            CMD = new SqlCommand("SELECT * FROM Master_Candidate_Type", CON);

            try
            {
                CON.Open();

                using (var reader = CMD.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var masterDetails = new CandidateTypeMaster
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            CandidateType = reader.GetString(reader.GetOrdinal("CandidateType"))
                        };
                        master.Add(masterDetails);
                    }
                }
                return Ok(master);
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, $"SQL error occured: {ex.Message}");
            }
            finally { CON.Close(); }
        }

        [Route("Get/Availability")]
        [HttpGet]

        public ActionResult<List<AvailabilityMaster>> GetAvailabilityMaster() {
            var master = new List<AvailabilityMaster>();
            CON = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
            CMD = new SqlCommand("SELECT * FROM Availibility_Master", CON);
            try
            {
                CON.Open();

                using (var reader = CMD.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var availability = new AvailabilityMaster
                        {
                            
                            Availability = reader.GetString(reader.GetOrdinal("Availability"))
                        };
                        master.Add(availability);
                    }
                }
                return Ok(master);
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An SQL error occured: {ex.Message}");
            }
            finally { CON.Close(); }
        }

    }
}
