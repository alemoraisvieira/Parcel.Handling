using Parcel.Handling.Application.Dto;
using Parcel.Handling.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Parcel.Handling.Application.Common
{
    public interface IParcelContext
    {
        List<Package> GetParcelList();
        List<Package> GetParcelId(int id);
        Task AddParcel(ParcelDto xmlData);
    }
}
