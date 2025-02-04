## HNG SecondTask

## Task Description
Create an API that takes a number and returns interesting mathematical properties about it, along with a fun fact. (the insteresting fact should be retrieved from http://numbersapi.com")

## API Guideline
Bing API
Method : GET
url : baseUrl
Response : "Api is Active!!!"
Status Code: 200

Get interesting fact
Method : GET
url : baseUrl/api/classify-number?number=number
response{
    "number": number,

    "is_prime": bool,

    "is_perfect": bool,

    "properties": [],

    "digit_sum": number,  // sum of its digits

    "fun_fact": "An interesing fact" //gotten from the numbers API
}
Status Code : 200

Bad Response
Response{
    "number": "alphabet",

    "error": true
}
Status Code : 400


