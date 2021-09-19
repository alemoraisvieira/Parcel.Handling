using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Parcel.Handling.Application.Dto
{
    [XmlRoot]
    [XmlInclude(typeof(Company))]
    public class SenderDto
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public int CcNumber { get; set; }  
    }
    [XmlRoot]
    public class Company : SenderDto { }
}
