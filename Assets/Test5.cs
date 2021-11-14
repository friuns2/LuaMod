using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public unsafe class Test5 : MonoBehaviour
{
    private long a = 123456789123456789;
    private IntPtr d;
    private void Start()
    {
        d = new IntPtr(Unsafe.AsPointer(ref a));

    }
    public void OnGUI()
    {
        HookUtils.SetAddrFlagsToRWE(d, 8);
        if (GUILayout.Button("Increase " + a))
            a++;
        
        HookUtils.VirtualProtect(d, 8, HookUtils.Protection.PAGE_EXECUTE_READ,out uint _);
    }
    private void OnDestroy()
    {
        HookUtils.SetAddrFlagsToRWE(d, 8);
    }
}