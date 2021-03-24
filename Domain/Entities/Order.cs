using Domain.Enum;

namespace Domain.Entities
{
	public class Order
    {
        public int Id { get; set; }
        public string OrderDetails { get; set; }
        public bool ModelElement { get; set; }
        public int QuantityOfMaterial { get; set; }
        public PaintType PaintType { get; set; }
        public MaterialType MaterialType { get; set; }
        public int PrePrice { get; set; }
        public bool Brush { get; set; }
        public bool Balloon { get; set; }
        public AppUser AppUser { get; set; }
        public Client Client { get; set; }
    }
}
