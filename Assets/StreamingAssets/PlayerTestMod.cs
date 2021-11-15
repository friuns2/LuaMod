using System.Collections;
using UnityEngine;

public class PlayerTestMod:PlayerTest
{
    public void Init()
    {
        transform.SetPositionAndRotation(Vector3.back, Quaternion.identity);
    }
  

    public void Update()
    {
        if (!cc.isGrounded)
            yVel -= 10 * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse0))
            yVel = 3;
        base.Update();
        
    }
}