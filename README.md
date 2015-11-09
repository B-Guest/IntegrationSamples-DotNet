# IntegrationSamples-DotNet
<h3>B-Guest Integration API usage samples for PMS developers</h3>
<h4>Webhooks</h4>
Here's a simple implementation example of an integration webhook. <br/>
Everytime there's a change in BGuest data, our backend will automatically send an HTTP POST request to the url you defined 
for your integration client with a JSON payload containing the information about these changes and a query string containing the secret code value that you defined.

```
POST <your-endpoint>?secret=<your-webhook-secret>
```

<br/>
Your endpoint should be prepared to receive a JSON payload with the following format: <br/>

```javascript
  {
    "documentType": string, 
    "request": {
      "requestId": int, 
      "subServiceName": string, 
      "subServiceTypeName": string,
      "pointOfInterestName": string,
      "operation": string, 
      "changedBy": string,
      "isIntegratedOnPms": bool,
      "room": string,
      "externalKey": string,
      "additionalInfo": string
      "expectedForLocalTime": date
      "products": [
        {
          "externalKey": string
        }
      ]
    }
  }
```

| Object        | Field           | Definition  |
| ------------- |:-------------:| -----:|
| root      | documentType |  Type of notification. So far, the only possible value is "Request"|
| request      | requestId      |   Id of the request |
| request | subServiceName      |    SubServive of the request |
| request | subServiceTypeName      |     SubService type of the request |
| request | pointOfInterestName      |    Point of Interest of the request |
| request | operation      |    Operation made. Ultimately, it reflects the state the request is on. Possible values are "Created", "Started", "Ready", "Completed" and "Canceled" |
| request | changedBy      |    Who was responsible for these changes. Possible values are "Guest", "HotelBackOffice" and "IntegrationApi" |
| request | isIntegratedOnPms      |    Indicates if this request is already integrated in the PMS |
| request | room      |    Hotel room number |
| request | externalKey      |    PMS identification key for this request if already integrated |
| request | additionalInfo      |    Any aditional information the guest has provided |
| request | expectedForLocalTime      |    Date and time the guest expects the request to be delivered |
| request | products      |    List of products the guest added to the request |
| request.product | externalKey      |    PMS identification key for each request's product |


NOTE:
A Request can only be associated to either a SubService or a Point of Interest, which means that if SubServiceName and SubServiceTypeName are not null, PointOfInterestName will always be null, and vice-versa.

<br/>
<b>Supported webhook calls:</b>
<ul>
  <li>Creation and Update of Request</li>
</ul>

<b>Future implementations:</b>
<ul>
  <li>Creation and Update of Stays</li>
  <li>Creation of Conversations and Messages</li>
</ul>

