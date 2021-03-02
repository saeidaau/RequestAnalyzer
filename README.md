# RequestAnalyzer
A request analyzer for a server side web application to handle millions of GET/POST HTTP requests.

# Table of contents
- General info
- In depth explanation
- Technologies
- Contact

![GitHub all releases](https://img.shields.io/github/downloads/saeidaau/RequestAnalyzer/total?logo=GitHub)

## General info:

This project is responsible to handle high amount of HTTP requests on the server side.
The project is implemented in `C#` and `ASP.Net` and we use the `sql server` as the database. We generate `memory optimized table` to have the maximum performance.
We could also use other in memory databases e.g. `Redis` but I think our method is almost the same.

## In depth explanation:

The most important part is in `RequestAnalyzer/RequestAnalyzer/Controllers/analyticsController.cs`.

There are two functions under `analyticsController` named `GET` and `POST`. 
In the `GET` function, it normally returns the following values:

- Number of users
- Number of clicks
- Number of impressions

In the `POST` functioon we just create a new thread in order to handle several (maybe millions of) requests. It is really helpful to make new thread and release the last one.

The other important thing as mentioned before is the database. The reason why we use `sql server` is that it is compatible with `ASP.Net`.
The DB file is available in `RequestAnalyzer/RequestAnalyzer_DB.sql`.

Finally, we can talk about the scalability of the project.
The web server can be distributed (run over several machines) and since the database will be the same, there is no problem with that.

## Technologies:

The main technologies used in this project are:

- ASP.Net
- C#
- sql server
- memory optimized table

## Contact:

Do not hesitate to reach me out via my email: `saeid.samizade@gmail.com`
