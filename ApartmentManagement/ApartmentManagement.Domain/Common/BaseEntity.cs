using System.ComponentModel.DataAnnotations;


namespace ApartmentManagement.Domain.Common
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
