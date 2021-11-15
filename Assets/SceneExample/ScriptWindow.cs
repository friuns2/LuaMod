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
using UnityEngine;
public class PlayerTestMod:PlayerTest
    {
        public override void Update()
        {
            if (!cc.isGrounded)
                yVel -= 10 * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space))
                yVel = 3;
            SharpMod.BaseInvoke();
        }
    }    
";
        
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