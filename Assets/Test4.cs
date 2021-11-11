using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using NLua;
using UnityEngine;

public class Test4 : MonoBehaviour
{
    private Lua lua;
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
            var functions = lua[type.Name] as LuaTable;
            if (functions != null)
            {
                foreach (KeyValuePair<object,object> fc in functions)
                {
                    var mh = type.GetMethod((string)fc.Key, BindingFlags.Instance | BindingFlags.Public);
                    if (mh != null)
                    {
                        var originalMethodName = type.Name + "." + fc.Key;
                        Action action = delegate
                        {
                            // lua.GetFunction(originalMethodName).Call(); //how to transfer originalMethodName? 
                            lua.GetFunction("Test4.Update").Call(); 
                        };
                        
                        var hook =new MethodHook(mh, action.Method, ((Action) BaseMethod).Method);
                        hook.Install();
                    }
                }
            }
        }
    }
    
    [MethodImpl(MethodImplOptions.NoOptimization)]
    public void LateUpdate()
    {
        Debug.Log("late update");
    }
    
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
}
