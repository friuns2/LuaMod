using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ScriptWindow:MonoBehaviour
{
    public Text console;
    public Text_Editor text;
    public Button compile;
    
    
    private void Start()
    {
        Application.logMessageReceived+= ApplicationOnlogMessageReceived;
        compile.onClick.AddListener(Patch);
        text.text = File.ReadAllText(Application.streamingAssetsPath + "/PlayerTestMod.cs").Replace("\r", "");
    }
    private void ApplicationOnlogMessageReceived(string condition, string stacktrace, LogType type)
    {
        console.text = condition;
        
    }
    public void Patch()
    {
        SharpMod.PatchAll(text.text);
    }
}