using Parcel.Handling.Application.common;
using Parcel.Handling.Application.Common;
using Parcel.Handling.Application.Dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Parcel.Handling.Application.Services
{
    public class ParcelService : IParcelService
    {
        private readonly IParcelContext _parcelcontext;
        public ParcelService(IParcelContext parcelcontext) =>
                    (_parcelcontext) = (parcelcontext);

        public async Task<IEnumerable<ParcelDto>> GetParcels()
        {
            var result = await _parcelcontext.GetParcelList();

            return result;

        }
        public async Task AddParcel()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ParcelDto),new XmlRootAttribute("Container"));
            TextReader reader = new StreamReader(@"C:\ParcelDelivery\Data\Container_68465468.xml");
            //XDocument document = XDocument.Load("C:\\ParcelDelivery\\Data\\Container_68465468.xml");
            object obj = serializer.Deserialize(reader);
            ParcelDto XmlData = (ParcelDto)obj;

            await _parcelcontext.AddParcel(XmlData);

        }
    }
}
