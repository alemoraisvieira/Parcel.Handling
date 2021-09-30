using Parcel.Handling.Application.Dto;
using Parcel.Handling.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Parcel.Handling.Application.Common
{
    public interface IParcelRepository
    {
        Task <List<Package>> GetParcelList();
        Task <Package> GetParcelId(int id);
        Task AddParcel(ParcelDto xmlData);
    }
}
