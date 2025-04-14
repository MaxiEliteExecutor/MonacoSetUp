# MonacoAPI DLL Documentation

## Overview
The `MonacoAPI.dll` integrates the Monaco Editor into WinForms applications using WebView2, enabling Lua scripting with tabbed editing, customizable themes, IntelliSense, and advanced editor features.

## Prerequisites
- **.NET Framework 4.8 or .NET 6.0+**: Ensure your project targets a compatible framework.
- **NuGet Packages**:
  - `Microsoft.Web.WebView2`
  - `Newtonsoft.Json`
- **WebView2 Runtime**: Must be installed on the system.
- **Internet Access**: Required to load the editor from `https://editorarcmainnosave.netlify.app/`.
- **Dependencies**: Monaco Editor assets (e.g., `vs/loader.js`) must be accessible via the hosted URL.

### Install NuGet Packages
Run the following in the Package Manager Console:
```bash
Install-Package Microsoft.Web.WebView2
Install-Package Newtonsoft.Json
```

## Setup
1. **Add DLL Reference**:
   - Include `MonacoAPI.dll` in your WinForms project via the Solution Explorer or project file.
2. **Add WebView2 Control**:
   - Add a WebView2 control to your form, either via the designer or programmatically:
     ```csharp
     using Microsoft.Web.WebView2.WinForms;
     WebView2 webView21 = new WebView2 { Dock = DockStyle.Fill };
     this.Controls.Add(webView21);
     ```
3. **Initialize the Editor**:
   - Initialize WebView2 and load the Monaco Editor:
     ```csharp
     using MonacoAPI;
     private async void Form1_Load(object sender, EventArgs e)
     {
         await webView21.EnsureCoreWebView2Async(null);
         SetUpWinForms.SetUpYourEditor(webView21.CoreWebView2);
     }
     ```
4. **Verify Initialization**:
   - The editor loads from `https://editorarcmainnosave.netlify.app/`. Check console output for "WebView2 initialized successfully" or navigation errors.

## Usage
### Get and Set Scripts
- **Retrieve Script**:
  - Get the current script from the active tab:
    ```csharp
    string script = await SetUpWinForms.GetScript(webView21.CoreWebView2);
    Console.WriteLine(script);
    ```
  - Returns an empty string on error.
- **Set Script**:
  - Update the active tab's content:
    ```csharp
    await SetUpWinForms.SetScript(webView21.CoreWebView2, "-- Lua script\nprint('Hello')");
    ```

### Themes
- Set the editor theme:
  ```csharp
  await SetUpWinForms.SetTheme(webView21.CoreWebView2, "Dark");
  ```
- Currently supports "Dark". Extend the JavaScript `SetTheme` function for additional themes.

### Editor Settings
- Configure editor features like minimap and line numbers:
  ```csharp
  await SetUpWinForms.ConfigureEditorSettings(webView21.CoreWebView2, enableMinimap: false, showLineNumbers: true);
  ```

### Tab Management
- **UI Controls**:
  - **Create**: Click the "+" button to add a new tab.
  - **Select**: Click a tab to switch scripts.
  - **Rename**: Right-click a tab to edit its name.
  - **Close**: Click the "x" button to remove a tab.
- **Programmatic Control**:
  - Use `SetScript` and `GetScript` to modify or retrieve the active tab's content.

### IntelliSense
- Add custom completion items for Lua:
  ```csharp
  await webView21.CoreWebView2.ExecuteScriptAsync("AddIntellisense('print', 'Function', 'Prints to console', 'print($0)');");
  ```
- Supported kinds: `Class`, `Function`, `Variable`, `Keyword`, etc.

### Custom Editor Options
- Update additional Monaco Editor settings:
  ```csharp
  await webView21.CoreWebView2.ExecuteScriptAsync("editor.updateOptions({ fontSize: 18, folding: true });");
  ```

### Scroll Control
- Scroll to a specific line:
  ```csharp
  await webView21.CoreWebView2.ExecuteScriptAsync("SetScroll(10);");
  ```

### Refresh Editor
- Refresh the editor content:
  ```csharp
  await webView21.CoreWebView2.ExecuteScriptAsync("Refresh();");
  ```

## Events
- **Content Change**:
  - Subscribe to content changes:
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
- **WebView2 Fails to Load**:
  - Ensure WebView2 Runtime is installed.
  - Verify internet connectivity.
  - Check the URL (`https://editorarcmainnosave.netlify.app/`) is accessible.
- **Script Errors**:
  - Inspect console for JavaScript errors.
  - Ensure functions like `GetText`, `SetTheme`, etc., are defined in the loaded HTML.
- **IntelliSense Not Working**:
  - Verify `AddIntellisense` calls include valid parameters.
  - Check the `Proposals` array in JavaScript via debugging.
- **Performance Issues**:
  - Disable minimap for large scripts.
  - Limit frequent `SetScript` calls.

## Best Practices
- **Error Handling**:
  - Wrap all DLL method calls in try-catch blocks:
    ```csharp
    try
    {
        await SetUpWinForms.SetScript(webView21.CoreWebView2, script);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
    ```
- **Performance**:
  - Avoid excessive script updates in loops.
  - Disable resource-heavy features (e.g., minimap) for large files.
- **Security**:
  - Validate user-provided scripts before execution.
  - Ensure the hosted URL uses HTTPS.
- **Extensibility**:
  - Add custom JavaScript functions to the HTML for new features.
  - Extend `SetTheme` to support additional themes.
  - Use `ExecuteScriptAsync` for advanced Monaco Editor interactions.
```
