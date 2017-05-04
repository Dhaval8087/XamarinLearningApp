using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LearningApp.Model;

namespace LearningApp.Services
{
    public class CallWebService
    {
        public async Task CallLoginService(string emailaddress,string password,
            Action<string> Callback)
        {
            try
            {
                
                var loginRequest = new LoginRequest { emailAddress = emailaddress, password = password };

                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("x-api-key", "D18F5B97-9FC2-4355-B293-0000044B8088");
                var jsonRequest = JsonConvert.SerializeObject(loginRequest);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "text/json");

                HttpResponseMessage response = await client.PostAsync("http://10.37.21.73/ZeroChaos.Service.Host/json/reply/loginrequest", content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                   
                    var returnedToken = response.Content.ReadAsStringAsync();
                    Callback(returnedToken.Result);
                }
            }
            catch (Exception ex)
            {
               
            }
        }
        public async Task CallFilterSearchTimesheetService(Action<string> Callback)
        {
            try
            {
               
                var client = new HttpClient();
                var UserDetails = new TimesheetRequest { loggedonUser = App.LoggedonUser,contactID=App.LoggedonUser.userID,resourceID=App.LoggedonUser.userID,offset=0,pageSize=10 };
                var jsonRequest = JsonConvert.SerializeObject(UserDetails);

                var content = new StringContent(jsonRequest, Encoding.UTF8, "text/json");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("x-api-key", "D18F5B97-9FC2-4355-B293-0000044B8088");
                client.DefaultRequestHeaders.Add("x-user-id", App.LoginResponse != null ? App.LoginResponse.AuthToken.ToString() : string.Empty);
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                HttpResponseMessage response = await client.PostAsync("http://10.37.21.73/ZeroChaos.Service.Host/json/reply/FilterTimesheetsForSearchRequest",content);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                   
                    var returnedToken = response.Content.ReadAsStringAsync();
                    Callback(returnedToken.Result);
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        public async Task GetTimesheetDetailsRequest(int TimesheetID,Action<string> Callback)
        {
            try
            {

                var client = new HttpClient();
                var timesheetDetails = new TimesheetDetailsRequest { timesheetID = TimesheetID,loggedonUser= App.LoggedonUser };
                var jsonRequest = JsonConvert.SerializeObject(timesheetDetails);

                var content = new StringContent(jsonRequest, Encoding.UTF8, "text/json");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("x-api-key", "D18F5B97-9FC2-4355-B293-0000044B8088");
                client.DefaultRequestHeaders.Add("x-user-id", App.LoginResponse != null ? App.LoginResponse.AuthToken.ToString() : string.Empty);
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                HttpResponseMessage response = await client.PostAsync("http://10.37.21.73/ZeroChaos.Service.Host/json/reply/GetTimesheetDetailsRequest", content);

                if (response.StatusCode == HttpStatusCode.OK)
                {

                    var returnedToken = response.Content.ReadAsStringAsync();
                    Callback(returnedToken.Result);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public async Task GetApprovalManagersRequest(int ProjectID, Action<string> Callback)
        {
            try
            {

                var client = new HttpClient();
                var timesheetDetails = new ApprovalManagersRequest { projectID = ProjectID, loggedonUser = App.LoggedonUser };
                var jsonRequest = JsonConvert.SerializeObject(timesheetDetails);

                var content = new StringContent(jsonRequest, Encoding.UTF8, "text/json");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("x-api-key", "D18F5B97-9FC2-4355-B293-0000044B8088");
                client.DefaultRequestHeaders.Add("x-user-id", App.LoginResponse != null ? App.LoginResponse.AuthToken.ToString() : string.Empty);
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                HttpResponseMessage response = await client.PostAsync("http://10.37.21.73/ZeroChaos.Service.Host/json/reply/GetApprovalManagersRequest", content);

                if (response.StatusCode == HttpStatusCode.OK)
                {

                    var returnedToken = response.Content.ReadAsStringAsync();
                    Callback(returnedToken.Result);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public async Task GetTimesheetPayCodesRequest(TimesheetPayCodesRequest request,Action<string> Callback)
        {
            try
            {

                var client = new HttpClient();
                request.loggedonUser = App.LoggedonUser;
                var jsonRequest = JsonConvert.SerializeObject(request);

                var content = new StringContent(jsonRequest, Encoding.UTF8, "text/json");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("x-api-key", "D18F5B97-9FC2-4355-B293-0000044B8088");
                client.DefaultRequestHeaders.Add("x-user-id", App.LoginResponse != null ? App.LoginResponse.AuthToken.ToString() : string.Empty);
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                HttpResponseMessage response = await client.PostAsync("http://10.37.21.73/ZeroChaos.Service.Host/json/reply/GetPayCodesRequest", content);

                if (response.StatusCode == HttpStatusCode.OK)
                {

                    var returnedToken = response.Content.ReadAsStringAsync();
                    Callback(returnedToken.Result);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public async Task GetTimesheetEntryDatesRequest(TimesheetEntryDatesRequest request,Action<string> Callback)
        {
            try
            {

                var client = new HttpClient();
                request.loggedonUser = App.LoggedonUser;
                var jsonRequest = JsonConvert.SerializeObject(request);

                var content = new StringContent(jsonRequest, Encoding.UTF8, "text/json");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("x-api-key", "D18F5B97-9FC2-4355-B293-0000044B8088");
                client.DefaultRequestHeaders.Add("x-user-id", App.LoginResponse != null ? App.LoginResponse.AuthToken.ToString() : string.Empty);
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                HttpResponseMessage response = await client.PostAsync("http://10.37.21.73/ZeroChaos.Service.Host/json/reply/GetTimesheetEntryDatesRequest", content);

                if (response.StatusCode == HttpStatusCode.OK)
                {

                    var returnedToken = response.Content.ReadAsStringAsync();
                    Callback(returnedToken.Result);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public async Task GetProjectTrackCodesRequest(ProjectTrackCodesRequest request,Action<string> Callback)
        {
            try
            {

                var client = new HttpClient();
                request.loggedonUser = App.LoggedonUser;
                var jsonRequest = JsonConvert.SerializeObject(request);

                var content = new StringContent(jsonRequest, Encoding.UTF8, "text/json");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("x-api-key", "D18F5B97-9FC2-4355-B293-0000044B8088");
                client.DefaultRequestHeaders.Add("x-user-id", App.LoginResponse != null ? App.LoginResponse.AuthToken.ToString() : string.Empty);
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                HttpResponseMessage response = await client.PostAsync("http://10.37.21.73/ZeroChaos.Service.Host/json/reply/GetProjectTrackCodesRequest", content);

                if (response.StatusCode == HttpStatusCode.OK)
                {

                    var returnedToken = response.Content.ReadAsStringAsync();
                    Callback(returnedToken.Result);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public async Task SaveorSubmitTimesheet(SaveOrSubmitTimesheetRequest request, Action<string> Callback)
        {
            try
            {

                var client = new HttpClient();
                request.loggedonUser = App.LoggedonUser;
                var jsonRequest = JsonConvert.SerializeObject(request);

                var content = new StringContent(jsonRequest, Encoding.UTF8, "text/json");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("x-api-key", "D18F5B97-9FC2-4355-B293-0000044B8088");
                client.DefaultRequestHeaders.Add("x-user-id", App.LoginResponse != null ? App.LoginResponse.AuthToken.ToString() : string.Empty);
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                HttpResponseMessage response = await client.PostAsync("http://10.37.21.73/ZeroChaos.Service.Host/json/reply/SaveOrSubmitTimesheetRequest", content);

                if (response.StatusCode == HttpStatusCode.OK)
                {

                    var returnedToken = response.Content.ReadAsStringAsync();
                    Callback(returnedToken.Result);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
    
}
