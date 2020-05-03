using System;

namespace Ostore.API.Models.InputModels

{
    public class OrderInputModel
    {
        public int? Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Store Store { get; set; }
        public string OrderAddress { get; set; }
        public DateTime Date { get; set; }

    }
}
