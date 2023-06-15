using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantAPI.Models
{
    public class OrderDetails
    {
        [Key]
        public long OrderDetailId { get; set; }
       
        [ForeignKey("OrderMasterId")]
        public long OrderMasterId { get; set; }
        //public OrderMasters OrderMasters { get; set; }

        [ForeignKey("FoodItemId")]
        public int FoodItemId { get; set; }
        //public FoodItems FoodItems { get; set; }

         public decimal FoodItemPrice { get; set; }
        public int Quantity { get; set; }
    }
}
