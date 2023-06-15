using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantAPI.Models
{
    public class OrderMasters
    {
        public OrderMasters()
        {
            OrderDetails = new List<OrderDetails>();
        }

        [Key]
        [Column("OrderMasterId")]
        public long OrderMasterId { get; set; }
        

        [Column(TypeName ="nvarchar(75)")]
        public string OrderNumber { get; set; }

        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        //[NotMapped]
        //public Customers Customer { get; internal set; }


        [Column(TypeName ="nvarchar(10)")]
        public string pMethod { get; set; }

        public decimal gTotal { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
        [NotMapped]
        public string deletedOrderItemIds { get; set; }
    }
}

