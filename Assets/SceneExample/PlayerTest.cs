using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using Debug = UnityEngine.Debug;

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

