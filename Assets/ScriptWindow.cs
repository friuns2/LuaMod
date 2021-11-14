using UnityEngine;
using UnityEngine.UI;

public class ScriptWindow:MonoBehaviour
{
    public Text console;
    public InputField text;
    public Button compile;
    private void Start()
    {
        Application.logMessageReceived+= ApplicationOnlogMessageReceived;
        compile.onClick.AddListener(Patch);
        text.text = @"
-- USE WASD Keys to move, press Compile to add Jump mod

PlayerTest  ={} 

function PlayerTest:Update ()
    if Input.GetKeyDown(KeyCode.Space) then
        this.yVel = 3;    
    end
    base:Invoke()
end
";
        
    }
    private void ApplicationOnlogMessageReceived(string condition, string stacktrace, LogType type)
    {
        console.text = condition;
        
    }
    public void Patch()
    {
        LuaMod.PatchAll(text.text);
    }
}