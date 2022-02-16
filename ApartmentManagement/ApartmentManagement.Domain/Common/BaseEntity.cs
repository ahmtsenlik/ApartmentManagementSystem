﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagement.Domain.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime LastModified { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
