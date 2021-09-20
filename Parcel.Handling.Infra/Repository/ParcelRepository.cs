using DepartmentDBContext;
using Parcel.Handling.Application.Common;
using Parcel.Handling.Application.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcel.Handling.Infra
{
    public class ParcelRepository : IParcelContext
    {
        private ApiContext _context;

        public ParcelRepository(ApiContext context) =>
            (_context) = (context);
        public List<Package> GetParcelList()
        {
            var result = _context.Package.OrderBy(x => x.Id).ToList();
            return result;
        }

        public List<Package> GetParcelId(int id)
        {
            var result = _context.Package.Where(x=> x.Id == id);
            return result.ToList();
        }
        public Task AddParcel(ParcelDto xmlData)
        {

            string departmentName = "";
            foreach (var file in xmlData.Parcels)
            {
                if (file.Weight <= 1.0 && file.Value <= 1000)
                {
                    departmentName = "Mail";
                }
                else if (file.Weight <= 10.0 && file.Value <= 1000)
                {
                    departmentName = "Regular";
                }
                else if (file.Weight > 10.0 && file.Value <= 1000)
                {
                    departmentName = "Heavy";
                }
                else if (file.Value >= 1000)
                {
                    departmentName = "Insurance";
                }
                
                
                var addParcel = new Package
                {
                    NameSender = file.Sender.Name,
                    NameReceipient = file.Receipient.Name,
                    Weight = file.Weight,
                    Value = file.Value,
                    NameDepartment = departmentName,
                };
                _context.Package.Add(addParcel);
            }

            _context.SaveChanges();
            return Task.CompletedTask;  
        } 
    }
}
