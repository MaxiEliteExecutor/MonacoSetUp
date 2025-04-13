string textToSave = await WEBVIEW2NAME.ExecuteScriptAsync("GetText();");
string rawText = JsonConvert.DeserializeObject<string>(textToSave);
