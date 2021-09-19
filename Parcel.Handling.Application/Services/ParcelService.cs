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
        private readonly IParcelContext _parcelcontext;
        private readonly PathOption _options;
        public ParcelService(IParcelContext parcelcontext, IOptions<PathOption> pathOptions)
        {
            _parcelcontext = parcelcontext;
            _options = pathOptions.Value;
        }

        public async Task<List<Package>> GetParcels()
        {
            var result =  _parcelcontext.GetParcelList();
            return result;
        }
        public async Task<List<Package>> GetParcelById(int id)
        {
            var result = _parcelcontext.GetParcelId(id);
            return result;
        }
        public Task AddParcel()
        {
            var xmlDeserialize = DeserializerXML();
            if (xmlDeserialize != null)
                _parcelcontext.AddParcel(xmlDeserialize);
            return Task.CompletedTask;
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
