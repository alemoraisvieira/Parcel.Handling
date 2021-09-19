using Parcel.Handling.Application.Dto;
using Parcel.Handling.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Parcel.Handling.Application.common
{
    public interface IParcelService
    {
        Task<List<Package>> GetParcels();
        Task<List<Package>> GetParcelById(int id);
        Task AddParcel();
    }
}
