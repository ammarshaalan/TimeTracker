# TimeTracker
This is a web application that tracks time entries for employees. It retrieves the time entries data from an external API and displays it in a table.

## Installation
1. Clone the repository to your local machine.
2. Open the solution file (TimeTracker.sln) in Visual Studio.
3. Build the solution to restore packages and dependencies.
4. Run the application.

## Usage
1. When the application is launched, it will retrieve the time entries data from the external API.
2. The data will be displayed in a table, showing the employee name and the total time worked.
3. The table is sorted in descending order based on the total time worked.
4. If there is an error retrieving the data from the API, an error message will be displayed.
5. To view a pie chart of the time entries data, click on the "View Pie Chart" button on the home page. This will display a pie chart that shows the percentage of time worked for each employee. Each segment of the pie chart represents one employee and is labeled with their name and the percentage of time they worked. The chart uses a color scheme to distinguish between different employees.
6. To download a PNG image of the pie chart, click on the "Download Image" button located below the chart. This will save a copy of the chart as a PNG file on your computer.

## Technology Stack
* C#
* ASP.NET MVC
* Newtonsoft.Json
* HttpClient

