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
        public List<ParcelsDto> Parcels { get; set; }
    }

   
}
