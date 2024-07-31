# Application Proxy Client

## Description
This Windows Forms application demonstrates how to authenticate with Microsoft Entra ID (formerly Azure AD) and make API calls to an on-premises web API exposed through Application Proxy. It uses the Microsoft Authentication Library (MSAL) for .NET to handle authentication.

## Prerequisites
- .NET SDK 8
- Visual Studio 2022
- An Azure subscription with access to Azure Active Directory
- An on-premises web API configured with Application Proxy

## Setup
1. Clone this repository or download the source code.
2. Open the solution in Visual Studio.
3. Install the required NuGet packages:
   - Microsoft.Identity.Client
   - Newtonsoft.Json

4. Register your application in Azure Active Directory:
   - Go to the Azure Portal (https://portal.azure.com)
   - Navigate to Azure Active Directory > App registrations
   - Click "New registration"
   - Enter a name for your application
   - Select "Public client/native (mobile & desktop)" as the application type
   - Set the redirect URI to "THE URI YOU WANT THE APPLICATION SHOULD REDIRECT TO"
   - Click "Register"

5. Configure your application:
   - In the Azure portal, go to your newly registered app
   - Copy the Application (client) ID and update the `ClientId` constant in the code
   - Copy your Azure AD tenant ID and update the `TenantId` constant

6. Update the `ApiUrl` constant in the code with the URL of your Application Proxy-exposed API.

7. In Azure AD, grant the necessary API permissions for your application (e.g., User.Read for Microsoft Graph API testing).

## Running the Application
1. Build the solution in Visual Studio.
2. Run the application.
3. Click the "Fetch Data" button to authenticate and make an API call.

## Troubleshooting
- If you encounter authentication errors, ensure that you've granted the necessary API permissions in Azure AD and provided admin consent if required.
- Check that the redirect URI in your code matches exactly what's registered in Azure AD.
- Clear your token cache and browser cookies related to Microsoft authentication if you've made changes to your app registration.

## Disclaimer
This application is for demonstration purposes only and should not be used in production without proper security review and testing.