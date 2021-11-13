using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Test3 : MonoBehaviour
{
    public unsafe void Start()
    {
        Application.logMessageReceived+= ApplicationOnlogMessageReceived;

        Hook(Test, TestPatch, TestProxy);
        Hook(Test2, TestPatch, TestProxy);
        
        Test();
        Test2();

    }
    private void Hook(Action a, Action to, Action proxy)
    {
        var _hook = new MethodHook((a).Method, (to).Method, (proxy).Method);
        _hook.Install();
    }
    private static unsafe int* GetAddr(void* pointer)
    {
        return (int*) ((byte*)pointer + 1);
    }
    private void ApplicationOnlogMessageReceived(string condition, string stacktrace, LogType type)
    {
        text.text += condition + "\n";
    }
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public void TestProxy()
    {
        Debug.Log("TestProxy");
    }
    
    
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public void Test()
    {
        Debug.Log("Test");
    }
    
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public void Test2()
    {
        Debug.Log("Test2");
    }
    
    
    public Text text;
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public void TestPatch()
    {
        Debug.Log("TestPatch");
        TestProxy();
    }   
}