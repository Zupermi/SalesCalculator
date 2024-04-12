using System.ComponentModel;
using System.Text.Json.Serialization;
using WebTest.Converters;

namespace WebTest.Models
{
    public class Discounts
    {
        public string Key { get; set; }
        public decimal Value { get; set; }

        [JsonConverter(typeof(StringToBooleanConverter))]
        public bool? Stacks { get; set; }
    }
}
