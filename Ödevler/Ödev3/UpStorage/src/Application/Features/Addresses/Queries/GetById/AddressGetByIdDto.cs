using Domain.Entities;
using Domain.Enums;

namespace Application.Features.Addresses.Queries.GetById
{
    public class AddressGetByIdDto
    {
        
        public string Name { get; set; }
        public string District { get; set; }
        public string PostCode { get; set; }
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }

    }
}
