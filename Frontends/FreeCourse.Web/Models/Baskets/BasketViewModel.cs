namespace FreeCourse.Web.Models.Baskets
{
    public class BasketViewModel
    {
        public string UserId { get; set; }

        public string DiscountCode { get; set; }

        public int? DiscountRate { get; set; }

        private List<BasketItemViewModel> _basketItems { get; set; }

        public List<BasketItemViewModel> BasketItems
        {
            get
            {
                if (HasDiscount)
                {
                    _basketItems.ForEach(x =>
                    {
                        var discountPrice = x.Price * ((decimal)DiscountRate.Value / 100);
                        x.AppliedDiscount(Math.Round(x.Price-discountPrice,2)); //virgülden sonra sadece 2 basamak olsun
                    });
                }
                return _basketItems;
            }
            set
            {
                _basketItems = value; //gelen değerleri direkt _basketItems'a ata
            }
        }

        //yardımcı metod
        public decimal TotalPrice
        {
            get => _basketItems.Sum(x => x.GetCurrentPrice);
        }

        //yardımcı metod
        public bool HasDiscount
        {
            get => !string.IsNullOrEmpty(DiscountCode);
        }

    }
}
