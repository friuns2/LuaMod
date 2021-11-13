using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using NLua;
using UnityEngine;
using Debug = UnityEngine.Debug;

public unsafe class Test4 : MonoBehaviour
{
    private Lua lua;
    private List<LuaFunction> lfs = new List<LuaFunction>();
    public void Start()
    {
        lua = new Lua();
        lua.LoadCLRPackage();
        lua.DoString("import ('UnityEngine') ");

        lua.DoString(@"
Test4  ={} 

    function Test4:Update ()
		    Debug.Log('update call from lua')
	    end

  function Test4:LateUpdate ()
		    Debug.Log('late update call from lua')
	    end
    
");

        Type[] typesToHookLua = {typeof(Test4)};
        
        foreach (Type type in typesToHookLua)
        {
            if (lua[type.Name] is LuaTable functions)
            {
                foreach (KeyValuePair<object,object> fc in functions)
                {
                    var mh = type.GetMethod((string)fc.Key, BindingFlags.Instance | BindingFlags.Public);
                    if (mh != null)
                    {
                        
                        var hook = new MethodHook(mh, ((Action) LuaExecute).Method, ((Action) BaseMethod).Method);
                        hook.GetFunctionAddr();
                        HookUtils.SetAddrFlagsToRWE(hook._replacementPtr, size.Length);
                        fixed (void* newPlace = size)
                        {
                            HookUtils.MemCpy(hook._replacementPtr.ToPointer(), newPlace, size.Length);
                            hook._replacementPtr = new IntPtr(newPlace);
                        }

                        HookUtils.SetAddrFlagsToRWE(hook._replacementPtr, size.Length);
                        
                        hook.Install();
                        // hook.id = (byte) lfs.Count;
                        // hook._codePatcher._pTarget
                        
                        lfs.Add((LuaFunction)fc.Value);
                        break;
                    }
                }
            }
        }
    }
    [ContextMenu("test")]
    public void test()
    {
        UnityEngine.Debug.Log((long)Unsafe.AsPointer(ref size));
        UnityEngine.Debug.Log((long)Unsafe.AsPointer(ref mestart));
        UnityEngine.Debug.Log(MethodHook.GetFunctionAddr(((Action) Update).Method));

    }
    
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public  void LuaExecute()
    {
        int a=0;
        int* b = &a;
        Debug.Log(new IntPtr(b));
    }
    
    // [MethodImpl(MethodImplOptions.NoOptimization)]
    // public void LateUpdate()
    // {
    //     Debug.Log("late update");
    // }
    //
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public void Update()
    {
        Debug.Log("update");
    }
  
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public void BaseMethod()
    {
        Debug.Log("proxy");
    }
    private long mestart,асад,сда,дсф,ас,фа,дса,ше,шя,ефа,дсад,дас,дс,дд,шч,чь,в,д,е,ш,сь,ч,г,р,с,ьчв,фдг;
    byte[] size = new byte[1024];
    
}

