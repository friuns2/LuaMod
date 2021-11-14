using UnityEngine;
using UnityEngine.UI;

public class ScriptWindow:MonoBehaviour
{
    public Text console;
    public Text text;
    public Button compile;
    private void Start()
    {
        Application.logMessageReceived+= ApplicationOnlogMessageReceived;
        compile.onClick.AddListener(Patch);

        text.text = @"

PlayerTest  ={} 

    function PlayerTest:Update ()
            if Input.GetKeyDown(KeyCode.Space) then
                Debug.Log(Jump)
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