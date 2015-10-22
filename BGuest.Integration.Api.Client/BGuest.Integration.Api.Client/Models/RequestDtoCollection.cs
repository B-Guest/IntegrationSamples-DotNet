﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace BGuest.Integration.Api.Client.Models
{
    public static partial class RequestDtoCollection
    {
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public static IList<RequestDto> DeserializeJson(JToken inputObject)
        {
            IList<RequestDto> deserializedObject = new List<RequestDto>();
            foreach (JToken iListValue in ((JArray)inputObject))
            {
                RequestDto requestDto = new RequestDto();
                requestDto.DeserializeJson(iListValue);
                deserializedObject.Add(requestDto);
            }
            return deserializedObject;
        }
    }
}