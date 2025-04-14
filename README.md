```markdown
# MonacoAPI DLL README

This README provides instructions for using the `MonacoAPI.dll`, a library that integrates the Monaco Editor into a WinForms application using WebView2 for Lua scripting with tabbed editing, themes, and IntelliSense.

## Prerequisites
- **.NET Framework 4.8 or .NET 6.0+**
- **NuGet Packages**:
  - `Microsoft.Web.WebView2`
  - `Newtonsoft.Json`
- **WebView2 Runtime**: Installed on the system.
- **Internet Access**: To load the editor from `https://editorarcmainnosave.netlify.app/`.

Install NuGet packages:
```bash
Install-Package Microsoft.Web.WebView2
Install-Package Newtonsoft.Json
```

## Setup
1. **Add DLL Reference**:
   - Include `MonacoAPI.dll` in your WinForms project.
2. **Add WebView2 Control**:
   ```csharp
   using Microsoft.Web.WebView2.WinForms;
   WebView2 webView21 = new WebView2 { Dock = DockStyle.Fill };
   this.Controls.Add(webView21);
   ```
3. **Initialize Editor**:
   ```csharp
   using MonacoAPI;
   private async void Form1_Load(object sender, EventArgs e)
   {
       await webView21.EnsureCoreWebView2Async(null);
       SetUpWinForms.SetUpYourEditor(webView21.CoreWebView2);
   }
   ```

## Core Usage
- **Get Script**:
  ```csharp
  string script = await SetUpWinForms.GetScript(webView21.CoreWebView2);
  ```
- **Set Script**:
  ```csharp
  await SetUpWinForms.SetScript(webView21.CoreWebView2, "-- Lua code");
  ```
- **Set Theme**:
  ```csharp
  await SetUpWinForms.SetTheme(webView21.CoreWebView2, "Dark");
  ```
- **Configure Settings**:
  ```csharp
  await SetUpWinForms.ConfigureEditorSettings(webView21.CoreWebView2, enableMinimap: false, showLineNumbers: true);
  ```

## Advanced Features
- **Tabs**: Create, select, rename, or close tabs via UI (+ button, click, right-click, x button).
- **IntelliSense**:
  ```csharp
  await webView21.CoreWebView2.ExecuteScriptAsync("AddIntellisense('print', 'Function', 'Prints to console', 'print($0)');");
  ```
- **Custom Options**:
  ```csharp
  await webView21.CoreWebView2.ExecuteScriptAsync("editor.updateOptions({ fontSize: 18 });");
  ```
- **Scroll**:
  ```csharp
  await webView21.CoreWebView2.ExecuteScriptAsync("SetScroll(10);");
  ```

## Event Handling
- **Content Changes**:
  ```csharp
  SetUpWinForms.AddEditorEventListeners(webView21.CoreWebView2);
  webView21.CoreWebView2.WebMessageReceived += (sender, args) =>
  {
      if (args.WebMessageAsJson.Contains("content-changed"))
      {
          Console.WriteLine("Content changed!");
      }
  };
  ```

## Troubleshooting
- **WebView2 Issues**: Ensure runtime is installed and internet is available.
- **Script Errors**: Check console for JavaScript errors.
- **IntelliSense**: Verify completion items are added correctly.

## Best Practices
- Handle errors with try-catch.
- Limit frequent script updates for performance.
- Validate scripts for security.
- Extend JavaScript for custom features.

For detailed guidance, refer to the accompanying documentation or contact the developer.
```
