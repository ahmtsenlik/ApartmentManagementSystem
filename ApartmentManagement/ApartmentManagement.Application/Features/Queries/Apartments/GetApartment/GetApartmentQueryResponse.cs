using ApartmentManagement.Application.Models;


namespace ApartmentManagement.Application.Features.Queries.Apartments.GetApartment
{
    public class GetApartmentQueryResponse
    {
        public int Id { get; set; }
        public bool IsEmpty { get; set; }
        public string Block { get; set; }
        public int No { get; set; }
        public string NumberOfRooms { get; set; }
        public int Floor { get; set; }
        public UserModel User { get; set; }

    
    }
    
}
