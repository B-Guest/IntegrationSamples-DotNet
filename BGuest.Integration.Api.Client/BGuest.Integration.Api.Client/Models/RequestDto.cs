﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace BGuest.Integration.Api.Client.Models
{
    public partial class RequestDto
    {
        private string _additionalInfo;
        
        /// <summary>
        /// Optional. Additional information from Request
        /// </summary>
        public string AdditionalInfo
        {
            get { return this._additionalInfo; }
            set { this._additionalInfo = value; }
        }
        
        private DateTimeOffset? _canceledOn;
        
        /// <summary>
        /// Optional. Date when Request state was changed to "Canceled"
        /// </summary>
        public DateTimeOffset? CanceledOn
        {
            get { return this._canceledOn; }
            set { this._canceledOn = value; }
        }
        
        private IList<RequestCategoryDto> _categories;
        
        /// <summary>
        /// Optional. List of Categories if Request has SubService
        /// </summary>
        public IList<RequestCategoryDto> Categories
        {
            get { return this._categories; }
            set { this._categories = value; }
        }
        
        private DateTimeOffset? _completedOn;
        
        /// <summary>
        /// Optional. Date when Request state was changed to "Completed"
        /// </summary>
        public DateTimeOffset? CompletedOn
        {
            get { return this._completedOn; }
            set { this._completedOn = value; }
        }
        
        private string _currency;
        
        /// <summary>
        /// Optional. The request currency
        /// </summary>
        public string Currency
        {
            get { return this._currency; }
            set { this._currency = value; }
        }
        
        private DateTimeOffset? _expectedFor;
        
        /// <summary>
        /// Optional. Date to when the Request is expected (DEPRECATED - use
        /// ExpectdForLocalTime)
        /// </summary>
        public DateTimeOffset? ExpectedFor
        {
            get { return this._expectedFor; }
            set { this._expectedFor = value; }
        }
        
        private DateTimeOffset? _expectedForLocalTime;
        
        /// <summary>
        /// Optional. Date to when the Request is expected in hotel local time
        /// </summary>
        public DateTimeOffset? ExpectedForLocalTime
        {
            get { return this._expectedForLocalTime; }
            set { this._expectedForLocalTime = value; }
        }
        
        private bool? _expressDelivery;
        
        /// <summary>
        /// Optional. flag to determine if the Request is for express delivery
        /// </summary>
        public bool? ExpressDelivery
        {
            get { return this._expressDelivery; }
            set { this._expressDelivery = value; }
        }
        
        private string _externalKey;
        
        /// <summary>
        /// Optional. The request's external system key
        /// </summary>
        public string ExternalKey
        {
            get { return this._externalKey; }
            set { this._externalKey = value; }
        }
        
        private GuestDto _guest;
        
        /// <summary>
        /// Optional. The guest
        /// </summary>
        public GuestDto Guest
        {
            get { return this._guest; }
            set { this._guest = value; }
        }
        
        private string _guestComments;
        
        /// <summary>
        /// Optional. Comments from Guest
        /// </summary>
        public string GuestComments
        {
            get { return this._guestComments; }
            set { this._guestComments = value; }
        }
        
        private string _hotelComments;
        
        /// <summary>
        /// Optional. Notes from Hotel
        /// </summary>
        public string HotelComments
        {
            get { return this._hotelComments; }
            set { this._hotelComments = value; }
        }
        
        private int? _id;
        
        /// <summary>
        /// Optional. Request Id
        /// </summary>
        public int? ID
        {
            get { return this._id; }
            set { this._id = value; }
        }
        
        private DateTimeOffset? _integratedOn;
        
        /// <summary>
        /// Optional. Date when Request was Integrated on PMS
        /// </summary>
        public DateTimeOffset? IntegratedOn
        {
            get { return this._integratedOn; }
            set { this._integratedOn = value; }
        }
        
        private bool? _isIntegratedOnPms;
        
        /// <summary>
        /// Optional. flag that determines if the Request is integrated on PMS
        /// </summary>
        public bool? IsIntegratedOnPms
        {
            get { return this._isIntegratedOnPms; }
            set { this._isIntegratedOnPms = value; }
        }
        
        private bool? _isReadByGuest;
        
        /// <summary>
        /// Optional. flag that determines if any Request change was checked by
        /// Guest
        /// </summary>
        public bool? IsReadByGuest
        {
            get { return this._isReadByGuest; }
            set { this._isReadByGuest = value; }
        }
        
        private PointOfInterestDto _pointOfInterest;
        
        /// <summary>
        /// Optional. Model of Request's Point of Interest if applicable
        /// </summary>
        public PointOfInterestDto PointOfInterest
        {
            get { return this._pointOfInterest; }
            set { this._pointOfInterest = value; }
        }
        
        private DateTimeOffset? _readyOn;
        
        /// <summary>
        /// Optional. Date when Request state was changed to "Ready"
        /// </summary>
        public DateTimeOffset? ReadyOn
        {
            get { return this._readyOn; }
            set { this._readyOn = value; }
        }
        
        private DateTimeOffset? _requestedOn;
        
        /// <summary>
        /// Optional. Date of creation
        /// </summary>
        public DateTimeOffset? RequestedOn
        {
            get { return this._requestedOn; }
            set { this._requestedOn = value; }
        }
        
        private string _room;
        
        /// <summary>
        /// Optional. Room number of the request
        /// </summary>
        public string Room
        {
            get { return this._room; }
            set { this._room = value; }
        }
        
        private DateTimeOffset? _startedOn;
        
        /// <summary>
        /// Optional. Date when Request state was changed to "Started"
        /// </summary>
        public DateTimeOffset? StartedOn
        {
            get { return this._startedOn; }
            set { this._startedOn = value; }
        }
        
        private int? _state;
        
        /// <summary>
        /// Optional. Current state of Request (Canceled = -2;
        /// PendingStayValidation = -1; New = 0; Started = 1; Ready = 2;
        /// Completed = 3)
        /// </summary>
        public int? State
        {
            get { return this._state; }
            set { this._state = value; }
        }
        
        private SubServiceDto _subService;
        
        /// <summary>
        /// Optional. Model of Request's SubService if applicable
        /// </summary>
        public SubServiceDto SubService
        {
            get { return this._subService; }
            set { this._subService = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the RequestDto class.
        /// </summary>
        public RequestDto()
        {
            this.Categories = new List<RequestCategoryDto>();
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken additionalInfoValue = inputObject["additionalInfo"];
                if (additionalInfoValue != null && additionalInfoValue.Type != JTokenType.Null)
                {
                    this.AdditionalInfo = ((string)additionalInfoValue);
                }
                JToken canceledOnValue = inputObject["canceledOn"];
                if (canceledOnValue != null && canceledOnValue.Type != JTokenType.Null)
                {
                    this.CanceledOn = ((DateTimeOffset)canceledOnValue);
                }
                JToken categoriesSequence = ((JToken)inputObject["categories"]);
                if (categoriesSequence != null && categoriesSequence.Type != JTokenType.Null)
                {
                    foreach (JToken categoriesValue in ((JArray)categoriesSequence))
                    {
                        RequestCategoryDto requestCategoryDto = new RequestCategoryDto();
                        requestCategoryDto.DeserializeJson(categoriesValue);
                        this.Categories.Add(requestCategoryDto);
                    }
                }
                JToken completedOnValue = inputObject["completedOn"];
                if (completedOnValue != null && completedOnValue.Type != JTokenType.Null)
                {
                    this.CompletedOn = ((DateTimeOffset)completedOnValue);
                }
                JToken currencyValue = inputObject["currency"];
                if (currencyValue != null && currencyValue.Type != JTokenType.Null)
                {
                    this.Currency = ((string)currencyValue);
                }
                JToken expectedForValue = inputObject["expectedFor"];
                if (expectedForValue != null && expectedForValue.Type != JTokenType.Null)
                {
                    this.ExpectedFor = ((DateTimeOffset)expectedForValue);
                }
                JToken expectedForLocalTimeValue = inputObject["expectedForLocalTime"];
                if (expectedForLocalTimeValue != null && expectedForLocalTimeValue.Type != JTokenType.Null)
                {
                    this.ExpectedForLocalTime = ((DateTimeOffset)expectedForLocalTimeValue);
                }
                JToken expressDeliveryValue = inputObject["expressDelivery"];
                if (expressDeliveryValue != null && expressDeliveryValue.Type != JTokenType.Null)
                {
                    this.ExpressDelivery = ((bool)expressDeliveryValue);
                }
                JToken externalKeyValue = inputObject["externalKey"];
                if (externalKeyValue != null && externalKeyValue.Type != JTokenType.Null)
                {
                    this.ExternalKey = ((string)externalKeyValue);
                }
                JToken guestValue = inputObject["guest"];
                if (guestValue != null && guestValue.Type != JTokenType.Null)
                {
                    GuestDto guestDto = new GuestDto();
                    guestDto.DeserializeJson(guestValue);
                    this.Guest = guestDto;
                }
                JToken guestCommentsValue = inputObject["guestComments"];
                if (guestCommentsValue != null && guestCommentsValue.Type != JTokenType.Null)
                {
                    this.GuestComments = ((string)guestCommentsValue);
                }
                JToken hotelCommentsValue = inputObject["hotelComments"];
                if (hotelCommentsValue != null && hotelCommentsValue.Type != JTokenType.Null)
                {
                    this.HotelComments = ((string)hotelCommentsValue);
                }
                JToken idValue = inputObject["id"];
                if (idValue != null && idValue.Type != JTokenType.Null)
                {
                    this.ID = ((int)idValue);
                }
                JToken integratedOnValue = inputObject["integratedOn"];
                if (integratedOnValue != null && integratedOnValue.Type != JTokenType.Null)
                {
                    this.IntegratedOn = ((DateTimeOffset)integratedOnValue);
                }
                JToken isIntegratedOnPmsValue = inputObject["isIntegratedOnPms"];
                if (isIntegratedOnPmsValue != null && isIntegratedOnPmsValue.Type != JTokenType.Null)
                {
                    this.IsIntegratedOnPms = ((bool)isIntegratedOnPmsValue);
                }
                JToken isReadByGuestValue = inputObject["isReadByGuest"];
                if (isReadByGuestValue != null && isReadByGuestValue.Type != JTokenType.Null)
                {
                    this.IsReadByGuest = ((bool)isReadByGuestValue);
                }
                JToken pointOfInterestValue = inputObject["pointOfInterest"];
                if (pointOfInterestValue != null && pointOfInterestValue.Type != JTokenType.Null)
                {
                    PointOfInterestDto pointOfInterestDto = new PointOfInterestDto();
                    pointOfInterestDto.DeserializeJson(pointOfInterestValue);
                    this.PointOfInterest = pointOfInterestDto;
                }
                JToken readyOnValue = inputObject["readyOn"];
                if (readyOnValue != null && readyOnValue.Type != JTokenType.Null)
                {
                    this.ReadyOn = ((DateTimeOffset)readyOnValue);
                }
                JToken requestedOnValue = inputObject["requestedOn"];
                if (requestedOnValue != null && requestedOnValue.Type != JTokenType.Null)
                {
                    this.RequestedOn = ((DateTimeOffset)requestedOnValue);
                }
                JToken roomValue = inputObject["room"];
                if (roomValue != null && roomValue.Type != JTokenType.Null)
                {
                    this.Room = ((string)roomValue);
                }
                JToken startedOnValue = inputObject["startedOn"];
                if (startedOnValue != null && startedOnValue.Type != JTokenType.Null)
                {
                    this.StartedOn = ((DateTimeOffset)startedOnValue);
                }
                JToken stateValue = inputObject["state"];
                if (stateValue != null && stateValue.Type != JTokenType.Null)
                {
                    this.State = ((int)stateValue);
                }
                JToken subServiceValue = inputObject["subService"];
                if (subServiceValue != null && subServiceValue.Type != JTokenType.Null)
                {
                    SubServiceDto subServiceDto = new SubServiceDto();
                    subServiceDto.DeserializeJson(subServiceValue);
                    this.SubService = subServiceDto;
                }
            }
        }
    }
}