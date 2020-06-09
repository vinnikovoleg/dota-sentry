using Newtonsoft.Json;

namespace DotaSentry.Models
{
    public class InventoryItemModel
    {
        [JsonProperty("id")] 
        public long Id { get; set; }

        [JsonProperty("name")] 
        public string Name { get; set; }

        [JsonProperty("cost")] 
        public long Cost { get; set; }

        [JsonProperty("secret_shop")] 
        public long SecretShop { get; set; }

        [JsonProperty("side_shop")] 
        public long SideShop { get; set; }

        [JsonProperty("recipe")] 
        public long Recipe { get; set; }

        [JsonProperty("localized_name")] 
        public string LocalizedName { get; set; }
        
        [JsonProperty("Logo")] 
        public string Logo { get; set; }
    }
}