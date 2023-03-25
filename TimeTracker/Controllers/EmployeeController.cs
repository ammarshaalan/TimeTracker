using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System;

namespace TimeTracker
{
    public class EmployeeController : Controller
    {
        private static HttpClient _client = new HttpClient();
        private const string _apiUrl = "https://rc-vault-fap-live-1.azurewebsites.net/api/gettimeentries?code=vO17RnE8vuzXzPJo5eaLLjXjmRW07law99QTD90zat9FfOQJKKUcgQ==";

        // GET: Employee
        public async Task<ActionResult> Index()
        {
            try
            {
                var response = await _client.GetAsync(_apiUrl);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();

                var employees = JsonConvert.DeserializeObject<List<TimeEntries>>(responseBody)
                                           .Where(te => !string.IsNullOrEmpty(te.EmployeeName))
                                           .GroupBy(te => te.EmployeeName)
                                           .Select(g => new EmployeeViewModel
                                           {
                                               Name = g.Key,
                                               TotalTimeWorked = g.Sum(te => (te.EndTimeUtc - te.StarTimeUtc).TotalHours)
                                           })
                                           .OrderByDescending(vm => vm.TotalTimeWorked)
                                           .ToList();

                return View(employees);
            }
            catch(Exception ex)
            {
                var errorMessage = "An error occurred while trying to retrieve time entry data from the API. The following error message was returned: " + ex.Message;

                ViewBag.ErrorMessage = errorMessage;

                return View("Error");
            }
        }
    }
}
