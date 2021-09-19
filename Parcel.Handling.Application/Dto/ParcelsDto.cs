using System;
using System.Collections.Generic;
using System.Text;

namespace Parcel.Handling.Application.Dto
{
    public class ParcelsDto
    {
        public SenderDto Sender { get; set; }
        public ReceipientDto Receipient { get; set; }
        public double Weight { get; set; }
        public double Value { get; set; }
    }
}
