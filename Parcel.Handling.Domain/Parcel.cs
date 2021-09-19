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
        public string NameSender { get; set; }
        [Required]
        public string NameReceipient { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        public double Value { get; set; }
        [Required]
        public string NameDepartment { get; set; }
    }
}
