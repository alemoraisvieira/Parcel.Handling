using DepartmentDBContext;
using Parcel.Handling.Application.Common;
using Parcel.Handling.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcel.Handling.Infra
{
    public class ParcelContext : IParcelContext
    {
        private ApiContext _context;

        public ParcelContext(ApiContext context) =>
            (_context) = ( context);
        public async Task<IEnumerable<ParcelDto>> GetParcelList()
        {
            var result = new List<ParcelDto> { };
             var pak=   _context.Package;
            return result;
        }
        public async Task AddParcel(ParcelDto parcel)
        {

            var addParcel = new Package
            {
                Name = "",
                Weight = 0

            };
            _context.Package.Add(addParcel);
            _context.SaveChanges();
        }
    }
}
