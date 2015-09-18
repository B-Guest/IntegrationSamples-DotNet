# IntegrationSamples-DotNet
<h3>B-Guest Integration API usage samples for PMS developers</h3>
<h4>Webhooks</h4>
Here's a simple implementation example of an integration webhook. <br/>
Everytime there's a change in BGuest data, our backend will automatically send an HTTP POST request to the url you defined 
for your integration client with a JSON payload containing the information about these changes and a query string containing the secret code value that you defined.

```
POST <your-end-point>?secret=<your-webhook-secret>
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
      "changedBy": string 
    }
  }
```

<b>documentType:</b> type of notification. So far, the only possible value is "Request"<br/>
<b>request.requestId:</b> id of the request<br/>
<b>request.subServiceName:</b> SubServive of the request<br/>
<b>request.subServiceTypeName:</b> SubService type of the request<br/>
<b>request.pointOfInterestName:</b> Point of Interest of the request<br/>
<b>request.operation:</b> operation made. Ultimately, it reflects the state the request is on. Possible values are "Created", "Started", "Ready", "Completed" and "Canceled"<br/>
<b>request.changedBy:</b> who was responsible for these changes. Possible values are "Guest", "HotelBackOffice" and "IntegrationApi"<br/>

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

