using static Class_Project.Employee;

namespace Class_Project.DTO
{
    public class ShowDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public Status_Enum Status { get; set; }
        public Role_Enum Role { get; set; }
        public string? CreatedDate { get; set; }
        public string? ModifyDate { get; set; }
        public string? DeletedDate { get; set; }
    }
}
