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
        public SenderDto Sender { get; set; }
        public ReceipientDto Receipient { get; set; }
        public double Weight { get; set; }
        public double Value { get; set; }
    }
}
