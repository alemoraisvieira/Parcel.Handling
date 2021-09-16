using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Parcel.Handling.Application.Dto
{
    [Serializable, XmlRoot("Container")]

    public class ParcelDto
    {
        public int Id { get; set; }
        public string ShippingDate { get; set; }
        
        [XmlArray("parcels")]
        public List<Parcel> Parcels { get; set; }
    }
    public class Parcel
    {
        public Sender Sender { get; set; }
        public Receipient Receipient { get; set; }
        public double Weight { get; set; }
        public double Value { get; set; }
    }

    [XmlRoot]
    [XmlInclude(typeof(Company))]
    public class Sender
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public int CcNumber { get; set; }

    }

    [XmlRoot]
    public class Company : Sender { }

    public class Receipient
    {
        public string Name { get; set; }
        public Address Address { get; set; }

    }
    public class Address
    {
        public string Street { get; set; }
        public int HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
    }

}
