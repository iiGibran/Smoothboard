namespace Smoothboard.Models
{
    // AddOrderViewModel represents the data needed to create a new order
    public class AddOrderViewModel
    {
        // Name of the person placing the order
        public string Name { get; set; }

        // Email address of the person placing the order
        public string Email { get; set; }

        // Address where the order will be delivered
        public string Address { get; set; }

        // Phone number for contact regarding the order
        public string Phone { get; set; }

        // Date when the order is scheduled to be dropped off
        public DateTime DropOffDate { get; set; }

        // Width of the surfboard in centimeters
        public string Width { get; set; }

        // Length of the surfboard in centimeters
        public string Length { get; set; }

        // Link to a custom design associated with the order
        public string DesignLink { get; set; }
    }
}
