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
        
        cc.Move(new Vector3(Input.GetAxis("Horizontal"), yVel, Input.GetAxis("Vertical")) * (Time.deltaTime * 10));
    }
      
}

