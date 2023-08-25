namespace Smoothboard.Models
{
    // UpdateOrderViewModel represents the data needed to update an order's details
    public class UpdateOrderViewModel
    {
        // Unique identifier of the order
        public Guid Id { get; set; }

        // Updated name of the person placing the order
        public string Name { get; set; }

        // Updated email address of the person placing the order
        public string Email { get; set; }

        // Updated address where the order will be delivered
        public string Address { get; set; }

        // Updated phone number for contact regarding the order
        public string Phone { get; set; }

        // Updated date when the order is scheduled to be dropped off
        public DateTime DropOffDate { get; set; }

        // Updated width of the surfboard in centimeters
        public string Width { get; set; }

        // Updated length of the surfboard in centimeters
        public string Length { get; set; }

        // Updated link to a custom design associated with the order
        public string DesignLink { get; set; }
    }
}
