# Let's create a .txt file with the instructions
instructions_text = """
MonacoAPI Integration Tutorial

This tutorial will guide you on how to use the MonacoAPI.dll in your C# application (such as a Windows Forms application or a Discord bot).

Prerequisites:
1. .NET 8.0 or higher: Ensure your project is running on .NET 8.0 or higher.
2. MonacoAPI.dll: Make sure you have the compiled MonacoAPI.dll file.

Steps to Use MonacoAPI.dll in Your Project:

1. Create or Open Your C# Project:
   - Open Visual Studio or your preferred C# IDE.
   - Create a new project or open an existing one where you want to use the MonacoAPI.dll.

2. Add a Reference to the DLL:
   - Right-click on your project in the Solution Explorer and select "Add" -> "Reference..."
   - In the "Reference Manager" dialog, click the "Browse" button on the bottom.
   - Navigate to the location of your MonacoAPI.dll and select it.
   - After adding the reference, click "OK".

3. Import the MonacoAPI Namespace:
   - Open the C# file where you want to use the API.
   - Add the following line at the top of your file:
     ```csharp
     using MonacoAPI;
     ```

4. Using the API Methods:
   - Now, you can call the methods from the MonacoAPI like so:

   ```csharp
   using Microsoft.Web.WebView2.Core;
   using MonacoAPI;

   public class YourClass
   {
       public async Task InitializeEditor(CoreWebView2 coreWebView)
       {
           // Set up the Monaco editor with your WebView2 instance
           SetUpWinForms.SetUpYourEditor(coreWebView);
       }
       
       public async Task<string> GetScriptContent(CoreWebView2 coreWebView)
       {
           // Get the current script from the Monaco editor
           return await SetUpWinForms.GetScript(coreWebView);
       }
       
       public async Task SetScriptContent(CoreWebView2 coreWebView, string script)
       {
           // Set the given script in the Monaco editor
           await SetUpWinForms.SetScript(coreWebView, script);
       }
   }

