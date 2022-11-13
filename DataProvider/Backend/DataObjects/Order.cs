using System;
using Newtonsoft.Json;

namespace DataProvider.Backend.DataObjects
{
    public enum OrderType
    {
        Default,
        Invalid,
    }

    public class Order
    {
        [JsonProperty("firstName")]
        string FirstName { get; set; }
        [JsonProperty("lastName")]
        string LastName { get; set; }
        [JsonProperty("address")]
        string Address { get; set; }
        [JsonProperty("metroStation")]
        string Station { get; set; }
        [JsonProperty("phone")]
        string Phone { get; set; }
        [JsonProperty("rentTime")]
        int RentTime { get; set; }
        [JsonProperty("deliveryDate")]
        string DeliveryDate { get; set; }
        [JsonProperty("comment")]
        string Comment { get; set; }
        [JsonProperty("color")]
        string[] Color { get; set; }

        public Order()
        {
            AutoSetupOrderByType(OrderType.Default);
        }

        private void AutoSetupOrderByType(OrderType type)
        {
            switch (type)
            {
                case OrderType.Default:
                    SetupDefaultOrder();
                    return;
                case OrderType.Invalid:
                    SetupInvalidOrder();
                    return;
            }
        }

        private Order SetupInvalidOrder()
        {
            DateTime tomorrow = new DateTime().AddDays(1);
            string[] color = new string[] { "black" };

            return ManualSetupOrder(
                "Иван",
                "Иванов",
                null,
                "Лубянка",
                "88005553535",
                1,
                tomorrow,
                "Default Order",
                color);
        }

        private Order SetupDefaultOrder()
        {
            DateTime tomorrow = new DateTime().AddDays(1);
            string[] color = new string[] { "black" };

            return ManualSetupOrder(
                "Иван",
                "Иванов",
                "ул. Ленина, д.1",
                "Лубянка",
                "88005553535",
                1,
                tomorrow,
                "Default Order",
                color);
        }

        public Order ManualSetupOrder(string firstName, string lastName, string address, string station, string phone, int rentTime, DateTime deliveryDate, string comment, string[] color)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.Station = station;
            this.Phone = phone;
            this.RentTime = rentTime;
            this.DeliveryDate = deliveryDate.ToString();

            return this;
        }
    }
}

