using System.Collections.Generic;

namespace BGuest.Integration.Api.Client
{
    public class RequestCategoryDto
    {
        /// <summary>
        /// CategoryId of RequestCategory
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// RequestCategory Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// RequestCateogry Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List of Products contained in RequestCategory
        /// </summary>
        public IList<RequestProductDto> Products { get; set; }

        ///// <summary>
        ///// Initializes a new instance of the RequestCategoryDto class.
        ///// </summary>
        //public RequestCategoryDto()
        //{
        //    this.Products = new List<RequestProductDto>();
        //}
        
        ///// <summary>
        ///// Deserialize the object
        ///// </summary>
        //public virtual void DeserializeJson(JToken inputObject)
        //{
        //    if (inputObject != null && inputObject.Type != JTokenType.Null)
        //    {
        //        JToken categoryIdValue = inputObject["categoryId"];
        //        if (categoryIdValue != null && categoryIdValue.Type != JTokenType.Null)
        //        {
        //            this.CategoryId = ((int)categoryIdValue);
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
        //        JToken productsSequence = ((JToken)inputObject["products"]);
        //        if (productsSequence != null && productsSequence.Type != JTokenType.Null)
        //        {
        //            foreach (JToken productsValue in ((JArray)productsSequence))
        //            {
        //                RequestProductDto requestProductDto = new RequestProductDto();
        //                requestProductDto.DeserializeJson(productsValue);
        //                this.Products.Add(requestProductDto);
        //            }
        //        }
        //    }
        //}
    }
}
