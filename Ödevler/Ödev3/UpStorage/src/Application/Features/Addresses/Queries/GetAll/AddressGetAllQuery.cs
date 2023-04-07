using MediatR;

namespace Application.Features.Addresses.Queries.GetAll
{
    public class AddressGetAllQuery : IRequest<List<AddressGetAllDto>>
    {
        public string UserId { get; set; }
        public bool? IsDeleted { get; set; }

        public AddressGetAllQuery(int userId, bool? isDeleted)
        {
            UserId = UserId;

            IsDeleted = isDeleted;
        }
    }
}
