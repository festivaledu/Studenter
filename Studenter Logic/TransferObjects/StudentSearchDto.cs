namespace Studenter.Logic.TransferObjects
{
    public class StudentSearchDto
    {
        public string GivenName { get; set; } = "";
        public string FamilyName { get; set; } = "";
        public string Address { get; set; } = "";
        public string Email { get; set; } = "";
        public int MatrikelNumber { get; set; } = 0;
        public string Faculty { get; set; } = "";
        public string Course { get; set; } = "";
    }
}
