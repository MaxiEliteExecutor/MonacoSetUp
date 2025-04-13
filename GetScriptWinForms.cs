string textToSave = await Editor.ExecuteScriptAsync("GetText();");
string rawText = JsonConvert.DeserializeObject<string>(textToSave);
