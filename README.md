# Interview Test App

This application is designed to be a simple test of C# ability using Asp.Net core with .Net 6. This readme contains the instructions for completing the test below. If you have any questions, please contact the person administering this test.

Given that this test is completely un-monitored, you are allowed full access to any resources you see fit. The idea is to simulate a real development scenario. This means access to the internet, other code samples, or anything else you may find helpful is 100% permitted.

## Instructions

1. Ensure you have a local development environment setup that can run .Net 6 applications. If you need a free to use IDE, you can download and use [Visual Studio Community 2022](https://visualstudio.microsoft.com/vs/community/).
2. The first task is to refactor the existing code. We are not looking for anything in particular, just general improvements and adherence to good code design principles and practices.
3. The second task is to implement a new endpoint on the API.
   1. The access url for the endpoint should be a GET request made to '/health'.
   2. The endpoint should return an HTTP status code of 200 with a message from the database.
      1. The message to be returned from the database is found in the table "healthCheck". Return the value in the column named "message" from the SECOND row of that table. The message will read "Everything is OK!".
4. The final task is to implement unit tests for the API. You may use any unit testing framework of your choice.

When you are done making your changes, please create a pull request from your branch back into the main branch. We will be in touch shortly after to do a code review through your changes and allow you a chance to explain your implementation.
