# RequestAnalyzer
A request analyzer for a server side web application to handle millions of GET/POST HTTP requests.

# Table of contents
- General info
- In depth explanation
- Technologies
- Contact

## General info:

This project is responsible to handle high amount of HTTP requests on the server side.
The project is implemented in `C# language` and we use the `sql server` as the database. We generate `memory optimized table` to have the maximum <span style="background-color: #FFFF00">Marked text</span> performance.
We could also use other in memory databases e.g. `Redis` but I think our method is almost the same.

The most important part is in `RequestAnalyzer/RequestAnalyzer/Controllers/analyticsController.cs`.

There are two functions under `analyticsController` named `GET` and `POST`. 
In the `GET` function, it normally returns the following values:

- Number of users
- Number of clicks
- Number of impressions

In the `POST` functioon we just create a new thread in order to handle several (maybe millions of) requests. It is really helpful to make new thread and release the last one.

