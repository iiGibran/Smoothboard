namespace Smoothboard.Models.Domain
{

    // Defining all needed properties
    public class Order
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime DropOffDate { get; set; }
        public string Width { get; set; }
        public string Length { get; set; }
        public string DesignLink { get; set; }


    }
}
