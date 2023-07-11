## Exercise:
Set up a new endpoint on this API that fetches data from the API of your choice.

BONUS: You probably used GET for your endpoint. Can you set up an endpoint that you call using POST? For simplicity you could just get it to return the data that was posted to it.

## Questions:
1. At line 24 we use _httpClientFactory to create a new client but above it (line 22) you can see it's possible to just create a new HttpClient. Why don't we do it this way? (You'll need to research Microsoft's documentation)
2. How does line 28 interact with our try-catch block?
3. Are strings the only thing we can return? How would you return an object?