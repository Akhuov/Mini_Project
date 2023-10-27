﻿using static Class_Project.Employee;

namespace Class_Project.DTO
{
    public class CreateDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Status_Enum Status { get; set; }
        public Role_Enum Role { get; set; }

    }
}
