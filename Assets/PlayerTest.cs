using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class PlayerTest : MonoBehaviour
{
    public class Test2
    {
        public int a;
    }
    public CharacterController cc;
    public float gravity;
    // [MethodImpl(MethodImplOptions.NoOptimization)]
    public void Update()
    {
        cc.Move(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * (Time.deltaTime * 10));
    }
      
}

