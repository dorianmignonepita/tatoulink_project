﻿namespace tatoulink.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
        public string LastJobs { get; set; }
    }
}
