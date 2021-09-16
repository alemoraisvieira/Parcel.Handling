using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Parcel.Handling.Application.Dto
{
    public class Package
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Weight { get; set; }
        public int IdDepartment { get; set; }
        public string NameDepartment { get; set; }
    }
}
