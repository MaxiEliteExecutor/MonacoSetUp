string script = TEXT;
await Editor.CoreWebView2.ExecuteScriptAsync($"editor.setValue(`{script}`)");
