# Promised C# HTTP Requests

This class pretend to be a helpful tool when you try to make asynchronous request in C#, its focused to use on Unity3D and has been tested on Mac OSX El Capitan and unity3D 5.2.1.

The core of the promises is the great library [C-Sharp-Promise](https://github.com/Real-Serious-Games/C-Sharp-Promise#interfaces) and must be included in the project or assets folder.

> If the compiler has troubles when you clone this repo, delete: Examples, Tests, packages and xunit folders.

This class provides methods to handle request to a REST service and return strings in his methods, for handle the JSON this class is a very nice tool [SimpleJSON](http://wiki.unity3d.com/index.php/SimpleJSON)

## Usage

Add the reference of the Namespace

```C#
using PromisedRequest;
````

Specifing Headers to the request.

```C#
Dictionary<string, string> headers = new Dictionary<string, string>();
headers.Add ("X-USER-ROLE", "1");
headers.Add ("X-XSRF-TOKEN", "8374YUED-JDJDOWUR83-LDKDJFLL");

string url = "http://api-rest.com/resource/";

HTTPRequest request = new HTTPRequest (url, headers);
````

## Request with no headers

```C#
string url = "http://api-rest.com/resource/";

HTTPRequest request = new HTTPRequest (url, null);
```

## GetJsonString() Method

This method do a GET request to the Uri and return a string with the JSON

```C#
request.GetJsonString ()
	.Then (response => Debug.Log(response))
	.Catch (err => Debug.Log (err));
```

## GET(Dictionary<string, string>) Method

This method is for do a GET request with params to a REST Service, if no dictionary are passed as argument the method will throw a ArgumentNullException ()

```C#
string url = "http://api-rest.com/resource/";

HTTPRequest request = new HTTPRequest (url, null);

Dictionary<string, string> parameters = new Dictionary<string, string>();
parameters.Add ("foo", "bar");

request.GET (parameters)
	.Then (response => Debug.Log(response))
	.Catch (err => Debug.Log (err));
```

... More Methods are in the way.
