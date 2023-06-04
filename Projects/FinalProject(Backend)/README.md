<h1> WEB CRAWLER APPLICATION </h1>



https://github.com/aycakbas/UpSchool-FullStack-Development-Bootcamp/assets/121265757/af948bef-a64e-48ce-b30d-86e2f48c3d9a




In this project, a web crawler application has been developed. The application is designed and prepared to meet customer needs. The application performs data scraping from a given website using a Selenium bot and logs the results concurrently with Signal R. The application is divided into three main parts. 


![Ekran görüntüsü 2023-06-05 012024](https://github.com/aycakbas/UpSchool-FullStack-Development-Bootcamp/assets/121265757/fdd5d4a9-3bf1-4f88-b356-9656f90dee71)


The first part is a console application that scrapes products using Selenium. The second part is a web API project responsible for transferring products to the database and frontend. The third part is a wasm project that allows tracking products and logs.
In the initial phase of the application, the console application manages user questions. The first question asks the user how many products they want. The system is designed to handle both numerical inputs and the "all" option. The second question asks the user which type of products they want to scrape, providing three options. The first option is to scrape all products, the second option is to scrape discounted products only, and the third option is to scrape products with regular or non-discounted prices.



User prefences : 


![Ekran görüntüsü 2023-06-05 000928](https://github.com/aycakbas/UpSchool-FullStack-Development-Bootcamp/assets/121265757/c55475d9-07cd-49a3-9f02-d5f868c6c666)





Logging of bot movements with Signal R


![SeleniumLogSignalR](https://github.com/aycakbas/UpSchool-FullStack-Development-Bootcamp/assets/121265757/4a27b896-ebe7-49a4-8b6d-008ac9358d54)





Web scraped products example

![ScrapedProducts](https://github.com/aycakbas/UpSchool-FullStack-Development-Bootcamp/assets/121265757/2aee234a-eea9-4567-9cac-663a397fa906)






Based on the user's choices, the Selenium bot performs the web scraping and sends the data to the database. In this application, the scraped products are defined as "products," and orders are created based on the user's preferences.


![Ekran görüntüsü 2023-06-05 011308](https://github.com/aycakbas/UpSchool-FullStack-Development-Bootcamp/assets/121265757/60c3f986-bc95-4f8e-aee9-75ea733ff06b)



The data sent to the database includes information about orders, products, and order events. Each product object is assigned a GUID ID, and the same applies to each order. The CQRS structure is used for sending products, orders, and order events to the database. The application is designed following the principles of clean architecture.


![Ekran görüntüsü 2023-06-05 011450](https://github.com/aycakbas/UpSchool-FullStack-Development-Bootcamp/assets/121265757/4ee55118-72a5-4306-b31b-e947a6a4008c)



The second part of the application is developed as a Web API project, and HTTP requests are made through the Web API. The products are sent to the database in this way. The logs generated concurrently with Signal R are transmitted to the frontend using the Data Transfer Object technique.


![Ekran görüntüsü 2023-06-05 011540](https://github.com/aycakbas/UpSchool-FullStack-Development-Bootcamp/assets/121265757/68bf45c5-5833-45b5-9fbe-bb01e3ef6d1d)



The third and final part of the application involves creating a Wasm project using Blazor. The movements of the Selenium bot and the scraped products can be tracked in real-time through the frontend.

![Wasmproj](https://github.com/aycakbas/UpSchool-FullStack-Development-Bootcamp/assets/121265757/869f8f55-419c-4196-9d6c-59e5dfa627b4)


<h2>Techniques used in the study</h2>

<h3>Clean Architecture</h3>

![1_jH0iI7-MSQYgLUrqTUm6mg](https://github.com/aycakbas/UpSchool-FullStack-Development-Bootcamp/assets/121265757/a975569b-1cbe-4dcc-9d9d-e477b60e5946)


Clean Architecture is a software architectural pattern that emphasizes separation of concerns and maintainability by enforcing a strict separation of software modules into distinct layers of responsibility. It was introduced by Robert C. Martin, also known as Uncle Bob, and has gained popularity in the software development community.

Clean Architecture is important because it provides several benefits:

Maintainability: The architecture promotes modularity and decoupling between different layers, making it easier to understand, update, and maintain the codebase over time. Changes in one layer have minimal impact on other layers, allowing for better code organization and reducing the risk of introducing bugs.

Testability: Clean Architecture encourages the use of automated tests by keeping business logic isolated from external dependencies. The separation of concerns allows for the creation of unit tests that focus on specific components without the need for complex integration testing. This improves the overall quality of the software and speeds up the development process.

Independence from Frameworks and Libraries: Clean Architecture prioritizes business logic and minimizes dependencies on external frameworks and libraries. This reduces the risk of being tied to a specific technology stack, making it easier to migrate or replace components in the future without affecting the core functionality.

Scalability and Flexibility: The architecture provides a clear structure for adding new features, modules, or extending existing ones. It allows the system to scale and evolve over time without sacrificing stability or introducing unnecessary complexity.

Understandability: Clean Architecture emphasizes clean code principles, such as separation of concerns, single responsibility, and clear boundaries between components. This makes the codebase more readable and understandable for developers, facilitating collaboration, maintenance, and onboarding of new team members.

Overall, Clean Architecture helps in building software systems that are maintainable, testable, and independent of external dependencies. It enables developers to focus on the core business logic and deliver high-quality software that is adaptable to change.


<h3> Signal R </h3>

![ASP NET-Core-SignalR](https://github.com/aycakbas/UpSchool-FullStack-Development-Bootcamp/assets/121265757/61c6188d-c8b7-443b-ac8f-c91d25d349da)


SignalR is an open-source library for real-time web functionality in .NET applications. It allows for bi-directional communication between the server and clients, enabling real-time updates, notifications, and instant messaging over HTTP.

SignalR is important for several reasons:

Real-Time Communication: SignalR enables real-time, asynchronous communication between the server and clients. It allows for pushing data from the server to connected clients instantly, eliminating the need for clients to continuously poll the server for updates. This is especially useful for applications that require live data, such as chat applications, collaborative editing tools, stock tickers, and real-time dashboards.

Scalability: SignalR is built to handle high traffic and scale to support a large number of concurrent connections. It uses various transport protocols, such as WebSockets, Server-Sent Events, and Long Polling, to ensure reliable and efficient communication. It also supports automatic load balancing across multiple servers, making it suitable for applications with high scalability requirements.

Cross-Platform Compatibility: SignalR supports a wide range of clients and platforms, including web browsers, mobile devices, and desktop applications. It provides client libraries for various programming languages, such as JavaScript, .NET, Java, and Python, making it accessible and usable across different environments.

Simplified Development: SignalR abstracts away the complexities of low-level network protocols and provides a simple programming model for real-time communication. Developers can use familiar abstractions like events, callbacks, and hub methods to handle client-server interactions. This simplifies the development process and reduces the amount of code needed to implement real-time functionality.

Bi-Directional Communication: SignalR supports both server-to-client and client-to-server communication, enabling seamless two-way data exchange. Clients can invoke server-side methods, and the server can push data or notifications to one or multiple clients simultaneously. This bidirectional communication is essential for building interactive and collaborative applications.

Overall, SignalR simplifies the implementation of real-time functionality in web applications and provides a reliable, scalable, and efficient solution for building interactive, responsive, and collaborative user experiences. It enhances the user engagement and provides a more dynamic and interactive web application experience.

<h3> Selenium Bot </h3>

![0_rRDI9EXVUCvtd2Dj-1024x534](https://github.com/aycakbas/UpSchool-FullStack-Development-Bootcamp/assets/121265757/a8159d94-015c-4566-b85a-a1106d68f8c5)

Selenium is an open-source framework for automating web browsers. It provides a set of tools and libraries that allow developers to control web browsers programmatically, simulate user interactions, and automate web testing tasks. Selenium supports multiple programming languages, including Java, C#, Python, and JavaScript.

The importance of Selenium lies in its ability to automate web browser interactions and perform tasks that would otherwise require manual intervention. Here are some key reasons why Selenium is important:

Web Testing: Selenium is widely used for web application testing. It allows developers to write automated test scripts that mimic user interactions with the web application, such as clicking buttons, filling forms, and navigating between pages. Automated testing with Selenium helps ensure the functionality, stability, and quality of web applications across different browsers and platforms.

Cross-Browser Compatibility: Web applications need to work consistently across different web browsers, such as Chrome, Firefox, Safari, and Internet Explorer. Selenium provides a unified API that abstracts away the differences between browsers, allowing developers to write browser-agnostic test scripts. This simplifies cross-browser testing and helps identify and fix browser-specific issues.

Regression Testing: With Selenium, developers can create test suites that can be executed repeatedly to validate that changes or updates to a web application have not introduced any unintended side effects or regressions. This helps catch issues early in the development cycle and ensures the stability and reliability of the application.

Scraping and Data Extraction: Selenium can be used for web scraping, which involves extracting data from websites. By automating browser interactions, developers can scrape web pages, navigate through websites, and extract desired information. This is useful for tasks such as gathering data for research, competitive analysis, or building data-driven applications.

User Experience Monitoring: Selenium can be leveraged to monitor and analyze the user experience of a web application. By simulating user interactions and capturing performance metrics, developers can identify bottlenecks, measure page load times, and analyze the responsiveness of the application. This helps optimize the user experience and improve the overall performance of the web application.

In summary, Selenium is important because it enables automated web browser interactions, facilitates web testing, ensures cross-browser compatibility, supports regression testing, enables web scraping, and helps monitor and optimize the user experience of web applications. It is a valuable tool for developers in ensuring the quality, reliability, and performance of web applications.

