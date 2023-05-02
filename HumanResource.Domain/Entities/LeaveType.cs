namespace HumanResource.Domain.Entities
{
    public class LeaveType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LeaveTypeEnumId { get; set; }


        //Navigation Property
        public List<Leave> Leaves { get; set; }
    }
}
