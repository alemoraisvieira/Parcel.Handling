using Parcel.Handling.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Parcel.Handling.Application.Common
{
    public interface IParcelContext
    {
        Task<IEnumerable<ParcelDto>> GetParcelList();
        Task AddParcel(ParcelDto parcel);
    }
}
