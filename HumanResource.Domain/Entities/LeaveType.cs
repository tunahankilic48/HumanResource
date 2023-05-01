namespace HumanResource.Domain.Entities
{
    public class LeaveType : IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? StatuId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public Statu? Statu { get; set; }

        //Navigation Property
        public List<Leave> Leaves { get; set; }
    }
}
