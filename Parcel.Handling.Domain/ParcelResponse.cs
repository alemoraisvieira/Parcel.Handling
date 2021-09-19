using System;
using System.Collections.Generic;
using System.Text;

namespace Parcel.Handling.Domain
{
    public class ParcelResponse
    {
        public ParcelResponse(ParcelResponse parcelResponse)
        {
            Id = parcelResponse.Id;
            Name = parcelResponse.Name;
            Weight = parcelResponse.Weight;
            IdDepartment = parcelResponse.IdDepartment;
            NameDepartment = parcelResponse.NameDepartment;
        }
        public int Id { get; set; } 
        public string Name { get; set; }
        public double Weight { get; set; }
        public int IdDepartment { get; set; }
        public string NameDepartment { get; set; }
    }
}
