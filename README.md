### ✅ **Step-by-Step: How to Use the API**

---

### **1. Setup WebView2**
Make sure your project references:

- `Microsoft.Web.WebView2`
- `Newtonsoft.Json`

Install via NuGet:
```bash
Install-Package Microsoft.Web.WebView2
Install-Package Newtonsoft.Json
```

---

### **2. Initialize WebView2**

In your form (WinForms or WPF), you’ll need to ensure `WebView2` is initialized before using the API.

#### Example (WinForms):
```csharp
public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        InitEditor();
    }

    private async void InitEditor()
    {
        await webView21.EnsureCoreWebView2Async();
        MonacoAPI.SetUpEditor.SetUpEditor(webView21.CoreWebView2);
    }
}
```

---

### **3. Get & Set Script**

```csharp
private void SetScriptButton_Click(object sender, EventArgs e)
{
    MonacoAPI.SetUpEditor.SetScript(webView21.CoreWebView2, "print('Hello World');");
}

private void GetScriptButton_Click(object sender, EventArgs e)
{
    string code = MonacoAPI.SetUpEditor.GetScript(webView21.CoreWebView2);
    MessageBox.Show(code);
}
```

---

### **4. Apply Theme**

```csharp
private void SetThemeButton_Click(object sender, EventArgs e)
{
    MonacoAPI.SetUpEditor.SetTheme(webView21.CoreWebView2, "vs-dark");
}
```

---

### **5. Editor Options**

```csharp
private void ConfigureEditorButton_Click(object sender, EventArgs e)
{
    MonacoAPI.SetUpEditor.ConfigureEditorSettings(webView21.CoreWebView2, enableMinimap: true, showLineNumbers: true);
}
```

---

### **6. Listen for Changes**

You can add event listeners to capture editor content changes.

```csharp
private void AddListenerButton_Click(object sender, EventArgs e)
{
    MonacoAPI.SetUpEditor.AddEditorEventListeners(webView21.CoreWebView2);

    webView21.WebMessageReceived += (s, args) =>
    {
        string message = args.WebMessageAsString;
        if (message == "content-changed")
        {
            Console.WriteLine("Editor content changed!");
        }
    };
}
```
