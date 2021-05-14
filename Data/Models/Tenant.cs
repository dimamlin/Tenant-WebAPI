namespace TestTask.Data.Models
{
    public class Tenant
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public int FlatNunmber { get; set; }

        public bool IsTenant { get; set; }

        public int ApartmentsId { get; set; }

        public Apartments Apartments { get; set; }
    }
}
