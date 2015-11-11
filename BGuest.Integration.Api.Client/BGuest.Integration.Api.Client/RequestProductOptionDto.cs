using Newtonsoft.Json.Linq;

namespace BGuest.Integration.Api.Client
{
    public class RequestProductOptionDto
    {
        /// <summary>
        /// Value of selected Alternative by Guest for this option
        /// </summary>
        public string Alternative { get; set; }

        /// <summary>
        /// Optional. AlternativeId of selected alternative
        /// </summary>
        public int? AlternativeId { get; set; }

        /// <summary>
        /// RequestProductOptionId
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// RequestProductOption Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Additional price to be added to Product for selecting
        /// this option
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// ProductOption Id of RequestProductOption
        /// </summary>
        public int ProductOptionId { get; set; }

        /// <summary>
        /// Initializes a new instance of the RequestProductOptionDto class.
        /// </summary>
        public RequestProductOptionDto()
        {
        }
        
        ///// <summary>
        ///// Deserialize the object
        ///// </summary>
        //public virtual void DeserializeJson(JToken inputObject)
        //{
        //    if (inputObject != null && inputObject.Type != JTokenType.Null)
        //    {
        //        JToken alternativeValue = inputObject["alternative"];
        //        if (alternativeValue != null && alternativeValue.Type != JTokenType.Null)
        //        {
        //            this.Alternative = ((string)alternativeValue);
        //        }
        //        JToken alternativeIdValue = inputObject["alternativeId"];
        //        if (alternativeIdValue != null && alternativeIdValue.Type != JTokenType.Null)
        //        {
        //            this.AlternativeId = ((int)alternativeIdValue);
        //        }
        //        JToken idValue = inputObject["id"];
        //        if (idValue != null && idValue.Type != JTokenType.Null)
        //        {
        //            this.Id = ((int)idValue);
        //        }
        //        JToken nameValue = inputObject["name"];
        //        if (nameValue != null && nameValue.Type != JTokenType.Null)
        //        {
        //            this.Name = ((string)nameValue);
        //        }
        //        JToken priceValue = inputObject["price"];
        //        if (priceValue != null && priceValue.Type != JTokenType.Null)
        //        {
        //            this.Price = ((double)priceValue);
        //        }
        //        JToken productOptionIdValue = inputObject["productOptionId"];
        //        if (productOptionIdValue != null && productOptionIdValue.Type != JTokenType.Null)
        //        {
        //            this.ProductOptionId = ((int)productOptionIdValue);
        //        }
        //    }
        //}
    }
}
