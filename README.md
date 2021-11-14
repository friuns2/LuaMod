### Mod existing unity3d game with lua at runtime on android and PC

Game logic we going to extend

```c#
public class PlayerTest : MonoBehaviour
{

    public CharacterController cc;
    public float yVel;
    public void Update()
    {
        if (!cc.isGrounded)
            yVel -= 10 * Time.deltaTime;

        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        var move = new Vector3(x, yVel, y);
        cc.Move(move * (Time.deltaTime * 10));
    }

}
```

Extending it by adding jump at runtime

```c#
 LuaMod.PatchAll(@"

PlayerTest  ={} 

function PlayerTest:Update ()
    if Input.GetKeyDown(KeyCode.Space) then
        this.yVel = 3;    
    end
    base:Invoke()
end
");
```

https://user-images.githubusercontent.com/16543239/141689971-dee3e61f-c287-47ae-8d18-4a103996248e.mp4

Discord: https://discord.gg/bxVky7seqa
