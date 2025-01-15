using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CRUD.Controllers
{
    public class CandidateController : Controller
    {
        private readonly IConfiguration configuration;

        public CandidateController(IConfiguration Configuration)
        {
            configuration = Configuration;
        }

        SqlConnection CON = new SqlConnection();
        SqlCommand CMD = new SqlCommand();

        [Route("Get/Candidate")]
        [HttpGet]
        public ActionResult<List<CandidateDetails>> GetCandidate()
        {
            var candidates = new List<CandidateDetails>();
            CON = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
            CMD = new SqlCommand("SELECT * FROM CandidateDetails", CON);

            try
            {
                CON.Open();

                using (var reader = CMD.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var candidate = new CandidateDetails
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            MobileNumber = reader.GetString(reader.GetOrdinal("MobileNumber")),
                            Designation = reader.GetString(reader.GetOrdinal("Designation")),
                            Experience = reader.GetString(reader.GetOrdinal("Experience")),
                            Location = reader.GetString(reader.GetOrdinal("Location")),
                            PrimaryTechnology = reader.GetString(reader.GetOrdinal("PrimaryTechnology")),
                            TechnologyRate = reader.GetInt32(reader.GetOrdinal("TechnologyRate")),
                            LinkedInURL = reader.GetString(reader.GetOrdinal("LinkedInURL")),
                            Pancard = reader.GetString(reader.GetOrdinal("Pancard")),
                            HighestQualification = reader.GetString(reader.GetOrdinal("HighestQualification")),
                            EngagementType = reader.GetString(reader.GetOrdinal("EngagementType")),
                            Availability = reader.GetString(reader.GetOrdinal("Availability")),
                            CandidateType = reader.GetString(reader.GetOrdinal("CandidateType")),
                            CurrentCompany = reader.GetString(reader.GetOrdinal("CurrentCompany")),
                            NoticePeriodi = reader.GetString(reader.GetOrdinal("NoticePeriodi")),
                            CurrentCTC = reader.GetString(reader.GetOrdinal("CurrentCTC")),
                            ExpectedCTC = reader.GetString(reader.GetOrdinal("ExpectedCTC")),
                            PreferredLocation = reader.GetString(reader.GetOrdinal("PreferredLocation")),
                            LastWorkingDay = reader.GetString(reader.GetOrdinal("LastWorkingDay")),
                            
                        };

                        candidates.Add(candidate);
                    }
                }

                return Ok(candidates);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"SQL error occurred: {ex.Message}");
            }
            finally
            {
                CON.Close();
            }
        }

        [Route("Add/Candidate")]
        [HttpPost]
        public ActionResult addCandidate([FromBody] CandidateDetails candidate)
        {
            CON = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
            CMD = new SqlCommand("INSERT INTO CandidateDetails ( FirstName, LastName, Email, MobileNumber, Designation, Experience, Location, PrimaryTechnology, TechnologyRate, LinkedInURL, Pancard, HighestQualification, EngagementType, Availability, CandidateType, CurrentCompany, NoticePeriodi, CurrentCTC, ExpectedCTC, PreferredLocation, LastWorkingDay  ) VALUES(@FirstName, @LastName, @Email, @MobileNumber, @Designation, @Experience, @Location, @PrimaryTechnology, @TechnologyRate,  @LinkedInURL, @Pancard, @HighestQualification, @EngagementType, @Availability, @CandidateType, @CurrentCompany, @NoticePeriodi, @CurrentCTC, @ExpectedCTC, @PreferredLocation, @LastWorkingDay)", CON);
            try
            {
                CON.Open();
                CMD.Parameters.AddWithValue("@FirstName", candidate.FirstName);
                CMD.Parameters.AddWithValue("@LastName", candidate.LastName);
                CMD.Parameters.AddWithValue("@Email", candidate.Email);
                CMD.Parameters.AddWithValue("@MobileNumber", candidate.MobileNumber);
                CMD.Parameters.AddWithValue("@Designation", candidate.Designation);
                CMD.Parameters.AddWithValue("@Experience", candidate.Experience);
                CMD.Parameters.AddWithValue("@Location", candidate.Location);
                CMD.Parameters.AddWithValue("@PrimaryTechnology", candidate.PrimaryTechnology);
                CMD.Parameters.AddWithValue("@TechnologyRate", candidate.TechnologyRate);
                CMD.Parameters.AddWithValue("@LinkedInURL", candidate.LinkedInURL);
                CMD.Parameters.AddWithValue("@Pancard", candidate.Pancard);
                CMD.Parameters.AddWithValue("@HighestQualification", candidate.HighestQualification);
                CMD.Parameters.AddWithValue("@EngagementType", candidate.EngagementType);
                CMD.Parameters.AddWithValue("@Availability", candidate.Availability);
                CMD.Parameters.AddWithValue("@CandidateType", candidate.CandidateType);
                CMD.Parameters.AddWithValue("@CurrentCompany", candidate.CurrentCompany);
                CMD.Parameters.AddWithValue("@NoticePeriodi", candidate.NoticePeriodi);
                CMD.Parameters.AddWithValue("@CurrentCTC", candidate.CurrentCTC);
                CMD.Parameters.AddWithValue("@ExpectedCTC", candidate.ExpectedCTC);
                CMD.Parameters.AddWithValue("@PreferredLocation", candidate.PreferredLocation);
                CMD.Parameters.AddWithValue("@LastWorkingDay", candidate.LastWorkingDay);

                int value = CMD.ExecuteNonQuery();

                if (value > 0)
                {
                    return Ok(new {message = "Candidate added Successfully !"});
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create candidate.");
                }
                
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"SQL error occurred: {ex.Message}");
            }
            finally
            {
                CON.Close();
            }
        }

        [Route("Update/Details")]
        [HttpPut]
        public ActionResult updateDetails([FromBody] UpdateDetails update)
        {

            CON = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
            CMD = new SqlCommand("UPDATE CandidateDetails SET FirstName = @FirstName, LastName = @LastName, Email = @Email, MobileNumber = @MobileNumber, Designation = @Designation, Experience = @Experience, Location = @Location, PrimaryTechnology = @PrimaryTechnology, LinkedInURL = @LinkedInURL, Pancard = @Pancard, HighestQualification = @HighestQualification, EngagementType = @EngagementType, Availability = @Availability, CandidateType = @CandidateType, CurrentCompany = @CurrentCompany, NoticePeriodi = @NoticePeriodi, CurrentCTC = @CurrentCTC, ExpectedCTC = @ExpectedCTC, PreferredLocation = @PreferredLocation, LastWorkingDay = @LastWorkingDay", CON);


            try
            {
                CON.Open();
                CMD.Parameters.AddWithValue("@FirstName", update.FirstName);
                CMD.Parameters.AddWithValue("@LastName", update.LastName);
                CMD.Parameters.AddWithValue("@Email", update.Email);
                CMD.Parameters.AddWithValue("@MobileNumber", update.MobileNumber);
                CMD.Parameters.AddWithValue("@Designation", update.Designation);
                CMD.Parameters.AddWithValue("@Experience", update.Experience);
                CMD.Parameters.AddWithValue("@Location", update.Location);
                CMD.Parameters.AddWithValue("@PrimaryTechnology", update.PrimaryTechnology);
                CMD.Parameters.AddWithValue("@LinkedInURL", update.LinkedInURL);
                CMD.Parameters.AddWithValue("@Pancard", update.Pancard);
                CMD.Parameters.AddWithValue("@HighestQualification", update.HighestQualification);
                CMD.Parameters.AddWithValue("@EngagementType", update.EngagementType);
                CMD.Parameters.AddWithValue("@Availability", update.Availability);
                CMD.Parameters.AddWithValue("@CandidateType", update.CandidateType);
                CMD.Parameters.AddWithValue("@CurrentCompany", update.CurrentCompany);
                CMD.Parameters.AddWithValue("@NoticePeriodi", update.NoticePeriodi);
                CMD.Parameters.AddWithValue("@CurrentCTC", update.CurrentCTC);
                CMD.Parameters.AddWithValue("@ExpectedCTC", update.ExpectedCTC);
                CMD.Parameters.AddWithValue("@PreferredLocation", update.PreferredLocation);
                CMD.Parameters.AddWithValue("@LastWorkingDay", update.LastWorkingDay);
                

                int success = CMD.ExecuteNonQuery();

                if (success > 0)
                {
                   return Ok(new { message = "Details Updated Successfully" });

                }
                else
                {
                    return BadRequest("Oops ! Details cannot be updated !");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"SQL error occurred: {ex.Message}");
            }
            finally 
            {
                CON.Close();
            }

        }

        [Route("Delete/Candidate")]
        [HttpDelete]

        public ActionResult deleteCandidate([FromBody] Delete delete)
        {
            CON = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
            
            CMD = new SqlCommand("DELETE FROM CandidateDetails WHERE @Id = Id", CON);
            
            try
            {
                CON.Open();
                CMD.Parameters.AddWithValue("@Id", delete.Id);
                int sucess = CMD.ExecuteNonQuery();

                if (sucess > 0)
                {
                    return Ok(new{message = "Deleted Successfully !"});

                }
                else
                {
                    return BadRequest("Oops ! operation not performed.");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"SQL error occured: { ex.Message}");
            }
            finally
            {
                CON.Close();
            }
        }
    }
}
