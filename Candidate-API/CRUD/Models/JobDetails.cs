namespace CRUD.Models
{
    public class JobDetails
    {
        public required string Id { get; set; }
        public string JobTitle {  get; set; }
        public string Domain { get; set; }
        public int NumberOfPosition {  get; set; }  
        public string PositionType {  get; set; }
        public int MinExp {  get; set; }
        public int MaxExp { get; set; }
        public string Qualification {  get; set; }
        public int MinBudget {  get; set; }
        public int MaxBudget { get; set; }
        public string WorkNature {  get; set; }
        public string Technology {  get; set; }
        public string City {  get; set; }
        public string JobDescription {  get; set; }
    }
}
