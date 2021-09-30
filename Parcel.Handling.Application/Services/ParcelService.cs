using Microsoft.Extensions.Options;
using Parcel.Handling.Application.common;
using Parcel.Handling.Application.Common;
using Parcel.Handling.Application.Dto;
using Parcel.Handling.Domain;
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
        private readonly IParcelRepository _parcelRepository;
        private readonly PathOption _options;
        public ParcelService(IParcelRepository parcelcontext, IOptions<PathOption> pathOptions)
        {
            _parcelRepository = parcelcontext;
            _options = pathOptions.Value;
        }

        public async Task<IEnumerable<Package>> GetParcels()
        {
            var result = await _parcelRepository.GetParcelList();
            return result;
        }
        public async Task <Package> GetParcelById(int id)
        {
            var result = await _parcelRepository.GetParcelId(id);
            return result;
        }
        public async Task AddParcel()
        {
            var xmlDeserialize = DeserializerXML();
            if (xmlDeserialize != null)
                await _parcelRepository.AddParcel(xmlDeserialize);
        }

        private ParcelDto DeserializerXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ParcelDto), new XmlRootAttribute("Container"));
            TextReader reader = new StreamReader(@_options.PathXml);
            object obj = serializer.Deserialize(reader);
            var XmlData = (ParcelDto)obj;
            return XmlData;
        }
    }
}
