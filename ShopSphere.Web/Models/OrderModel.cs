namespace ShopSphere.Web.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public List<OrderItemModel> OrderItems { get; set; } = new List<OrderItemModel>();

    }
}
