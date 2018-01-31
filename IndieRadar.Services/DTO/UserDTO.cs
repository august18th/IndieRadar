using System;

namespace IndieRadar.Services.DTO
{
    public class UserDTO
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String UserName { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }

        public Int32 RoleId { get; set; }
    }
}