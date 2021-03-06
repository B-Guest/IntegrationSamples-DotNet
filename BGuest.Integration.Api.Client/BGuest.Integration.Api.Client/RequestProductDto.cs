﻿using System.Collections.Generic;

namespace BGuest.Integration.Api.Client
{
    public class RequestProductDto
    {
        /// <summary>
        /// Optional. External key that maps a product to external systems.
        /// </summary>
        public string ExternalKey { get; set; }

        /// <summary>
        /// Optional. Comments from Guest related to this product
        /// </summary>
        public string GuestComments { get; set; }

        /// <summary>
        /// RequestProduct Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// flag that determines if the product is breakfast
        /// </summary>
        public bool IsBreakfast { get; set; }

        /// <summary>
        /// RequestProduct Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Price of item
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// ProductId of RequestProduct
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Optional. Options that compose the Product
        /// </summary>
        public IList<RequestProductOptionDto> ProductOptions { get; set; }

        /// <summary>
        /// Quantity of item
        /// </summary>
        public int Quantity { get; set; }

        ///// <summary>
        ///// Initializes a new instance of the RequestProductDto class.
        ///// </summary>
        //public RequestProductDto()
        //{
        //    this.ProductOptions = new List<RequestProductOptionDto>();
        //}
        
        ///// <summary>
        ///// Deserialize the object
        ///// </summary>
        //public virtual void DeserializeJson(JToken inputObject)
        //{
        //    if (inputObject != null && inputObject.Type != JTokenType.Null)
        //    {
        //        JToken externalKeyValue = inputObject["externalKey"];
        //        if (externalKeyValue != null && externalKeyValue.Type != JTokenType.Null)
        //        {
        //            this.ExternalKey = ((string)externalKeyValue);
        //        }
        //        JToken guestCommentsValue = inputObject["guestComments"];
        //        if (guestCommentsValue != null && guestCommentsValue.Type != JTokenType.Null)
        //        {
        //            this.GuestComments = ((string)guestCommentsValue);
        //        }
        //        JToken idValue = inputObject["id"];
        //        if (idValue != null && idValue.Type != JTokenType.Null)
        //        {
        //            this.Id = ((int)idValue);
        //        }
        //        JToken isBreakfastValue = inputObject["isBreakfast"];
        //        if (isBreakfastValue != null && isBreakfastValue.Type != JTokenType.Null)
        //        {
        //            this.IsBreakfast = ((bool)isBreakfastValue);
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
        //        JToken productIdValue = inputObject["productId"];
        //        if (productIdValue != null && productIdValue.Type != JTokenType.Null)
        //        {
        //            this.ProductId = ((int)productIdValue);
        //        }
        //        JToken productOptionsSequence = ((JToken)inputObject["productOptions"]);
        //        if (productOptionsSequence != null && productOptionsSequence.Type != JTokenType.Null)
        //        {
        //            foreach (JToken productOptionsValue in ((JArray)productOptionsSequence))
        //            {
        //                RequestProductOptionDto requestProductOptionDto = new RequestProductOptionDto();
        //                requestProductOptionDto.DeserializeJson(productOptionsValue);
        //                this.ProductOptions.Add(requestProductOptionDto);
        //            }
        //        }
        //        JToken quantityValue = inputObject["quantity"];
        //        if (quantityValue != null && quantityValue.Type != JTokenType.Null)
        //        {
        //            this.Quantity = ((int)quantityValue);
        //        }
        //    }
        //}
    }
}
