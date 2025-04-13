try
{
    await WEBVIEW2NAME.EnsureCoreWebView2Async(null);
    WEBVIEW2NAME.CoreWebView2.Navigate(new Uri($"https://getarcexecuter.netlify.app/editor/editor").ToString());
}
catch (Exception ex)
{
    WEBVIEW2NAME.Windows.MessageBox.Show($"Error initializing WebView2: {ex.Message}", "Initialization Error");
}
