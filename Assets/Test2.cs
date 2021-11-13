using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class Test2 : MonoBehaviour
{
    public unsafe void Start()
    {
        Application.logMessageReceived+= ApplicationOnlogMessageReceived;

        // var functionAddr = MethodHook.GetFunctionAddr(((Action) TestProy).Method);


        // Debug.Log(Marshal.ReadIntPtr(new IntPtr(GetAddr(functionAddr.ToPointer()))));
        // Debug.Log(Marshal.ReadIntPtr(new IntPtr(GetAddr(functionAddr.ToPointer()))));
        
        var _hook = new MethodHook(((Action<string>)Test).Method,((Action)Testa).Method, ((Action)TestProy).Method);
        _hook.Install();
        Debug.Log(_hook.isHooked);

        // Debug.Log(Marshal.ReadIntPtr(new IntPtr(GetAddr(functionAddr.ToPointer()))));
        Test("adasd");
        // InstanceMethodTest.InstallPatch();
        // InstanceMethodTest.callOriFunc = true;
        // InstanceMethodTest InstanceTest = new InstanceMethodTest();
        // InstanceTest.Test();
    }
    private static unsafe int* GetAddr(void* pointer)
    {
        return (int*) ((byte*)pointer + 1);
    }
    private void ApplicationOnlogMessageReceived(string condition, string stacktrace, LogType type)
    {
        text.text += condition + "\n";
    }
    public void Update()
    {
       
    }
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public void TestProy()
    {
        Debug.Log("proxy");
    }
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public void Test(string s)
    {
        Debug.Log("original " + StackTraceUtility.ExtractStackTrace());
    }
    public Text text;
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public void Testa()
    {
        
        StackTrace trace = new StackTrace();    
        Type methodOwner = trace.GetFrame(0).GetMethod().DeclaringType;
        
        Debug.Log(">>>>>>" +trace+ "<<<<<");
    }
}