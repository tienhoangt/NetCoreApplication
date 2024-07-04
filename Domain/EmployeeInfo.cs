using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    [Table("EMPLOYEE_INFO")]
    public class EmployeeInfo
    {
        [Column("id")]
        public Guid Id { get; set; }
        [Column("employee_id")]
        public string EmployeeId { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("email_address")]
        public string EmailAddress { get; set; }
    }
}
