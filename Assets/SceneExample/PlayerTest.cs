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
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        var move = new Vector3(x, yVel, y);
        cc.Move(move * (Time.deltaTime * 10));
        
    }
      
}

