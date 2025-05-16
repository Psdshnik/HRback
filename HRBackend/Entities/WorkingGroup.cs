namespace HRBackend.Domain.Entities
{
    public class WorkingGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }   =new List<User>();   
    }
}
