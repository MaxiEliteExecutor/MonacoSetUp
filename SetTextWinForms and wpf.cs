string script = TEXT;
await WEBVIEW2NAME.CoreWebView2.ExecuteScriptAsync($"editor.setValue(`{script}`)");
