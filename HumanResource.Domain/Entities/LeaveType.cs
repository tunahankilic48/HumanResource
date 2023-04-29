namespace HumanResource.Domain.Entities
{
    internal class LeaveType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation Property
        public List<Leave> Leaves { get; set; }
    }
}
