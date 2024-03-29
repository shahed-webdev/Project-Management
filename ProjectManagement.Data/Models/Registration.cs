﻿using System;

namespace ProjectManagement.Data
{
    public class Registration
    {
        public int RegistrationId { get; set; }
        public int? ProjectSectorId { get; set; }
        public string UserName { get; set; }
        public UserType Type { get; set; }
        public string Name { get; set; }
        public string DateofBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public byte[] Image { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public bool IsDeactivated { get; set; }
        public ProjectSector ProjectSector { get; set; }
    }
}