using Microsoft.Identity.Client;
using Newtonsoft.Json.Linq;

namespace demo_azure
{
    public partial class MainForm : Form
    {
        /* Configure below fields with your applications details. */
        private const string _clientId = "YOUR_APPLICATIONS_CLIENTID";
        private const string _tenantId = "YOUR_APPLICATIONS_TENANTID";
        private const string _clientSecret = "CLIENT_SECRET_GENERATED_FOR_APPLICATION";
        private const string _scopes = "EXPOSED_API_SCOPES";
        private const string _redirectUrl = "REDIRECT_URL_ADDED_IN_AUTHENTICATION";

        private const string _apiUrl = "API_URL_YOU_WANT_TO_ACCESS";

        private readonly IConfidentialClientApplication _app;
        public MainForm()
        {
            InitializeComponent();

            _app = ConfidentialClientApplicationBuilder
                .Create(_clientId)
                .WithClientSecret(_clientSecret)
                .WithAuthority(AzureCloudInstance.AzurePublic, _tenantId)
                .WithRedirectUri(_redirectUrl)
                .WithLogging((level, message, containsPii) =>
                {
                    Console.WriteLine($"MSAL: {level} {message}");
                }, LogLevel.Verbose, enablePiiLogging: false, enableDefaultPlatformLogging: true)
                .Build();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                apiResult.Text = $"Fetching......";
                var result = await AcquireTokenAsync();
                apiResult.Text += $"\n\nToken acquired: {result.AccessToken.Substring(0, 10)}... ";

                var data = await FetchDataFromApiAsync(result.AccessToken);
                apiResult.Text += $"\n\nAPI Response: {data}";
            }
            catch (MsalException msalEx)
            {
                apiResult.Text = $"MSAL Error: {msalEx.ErrorCode}\n{msalEx.Message}";
            }
            catch (HttpRequestException httpEx)
            {
                apiResult.Text = $"HTTP Error: {httpEx.Message}";
            }
            catch (Exception ex)
            {
                apiResult.Text = $"Error: {ex.GetType().Name}\n{ex.Message}";
            }
        }
        private async Task<AuthenticationResult> AcquireTokenAsync()
        {
            string[] scopes = { _scopes };

            try
            {
                var accounts = await _app.GetAccountsAsync();
                return await _app.AcquireTokenSilent(scopes, accounts.FirstOrDefault()).ExecuteAsync();
            }
            catch (MsalUiRequiredException)
            {
                return await _app.AcquireTokenForClient(scopes)
                                 .ExecuteAsync();
            }
        }

        private async Task<string> FetchDataFromApiAsync(string accessToken)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                var response = await client.GetAsync(_apiUrl);

                // Check if the response is HTML
                var content = await response.Content.ReadAsStringAsync();
                if (content.Contains("<!DOCTYPE html>"))
                {
                    throw new Exception("Received HTML response instead of API data. Authentication may have failed.");
                }

                response.EnsureSuccessStatusCode();
                if (content is not null && content != "[]")
                {
                    return JObject.Parse(content).ToString();
                }
                else
                {
                    return "Request is Successful, but no data is returned.";
                }
            }
        }

        private void apiResult_TextChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void infoPara_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
