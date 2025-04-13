try
{
    await Editor.EnsureCoreWebView2Async(null);
    Editor.CoreWebView2.Navigate(new Uri($"file:///{Directory.GetCurrentDirectory()}/Editor/monaco.html").ToString());
}
catch (Exception ex)
{
    System.Windows.MessageBox.Show($"Error initializing WebView2: {ex.Message}", "Initialization Error");
}
