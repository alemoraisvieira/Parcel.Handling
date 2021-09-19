using System;
using System.Collections.Generic;
using System.Text;

namespace Parcel.Handling.Application.Dto
{
    public class Address
    {

        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
    }
}
