using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Scripting;
using Debug = UnityEngine.Debug;
[assembly: Preserve]
public class PlayerTest : MonoBehaviour
{
    
    public CharacterController cc;
    public float yVel;
    // public void Init()
    // {
    //     Debug.Log("asddas");
    // }
    public void Update()
    {
        
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        var move = new Vector3(x, yVel, y);
        cc.Move(move * (Time.deltaTime * 10));
        
        
    }
      
}

