using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enum;

namespace Application.Order
{
    public class OrderViewModel
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
    }
}
