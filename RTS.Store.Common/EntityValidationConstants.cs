namespace RTS.Store.Common
{
    public static class EntityValidationConstants
    {
        public static class Product
        {
            public const int ProductNameMaxLength = 50;
            public const int ProductNameMinLength = 3;

            public const int ProductDescriptionMaxLength = 500;
            public const int ProductDescriptionMinLength = 10;

            public const int ImageurlMaxLength = 2048;

            public const string PriceMinValue = "0";
            public const string priceMaxValue = "1000000";
        
        }
    }
}
