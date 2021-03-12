using SeturAssessment.ContactService.Entities.Abstract;

namespace SeturAssessment.ContactService.Entities.Concrete
{
    public class Location : IEntity
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
    }
}
