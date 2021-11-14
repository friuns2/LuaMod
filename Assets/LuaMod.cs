using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NLua;
using UnityEngine;

public static class LuaMod
{
    public static void PatchAll(string s)
    {
        PatchType(s, Assembly.GetExecutingAssembly().GetTypes().Where(a => a.IsSubclassOf(typeof(MonoBehaviour))).ToArray());
    }
    public static Lua lua;
    static LuaMod()
    {
        lua = new Lua();
        lua.LoadCLRPackage();
        lua.DoString("import ('UnityEngine') ");
    }
    public static void PatchType(string s,Type[] typesToHookLua)
    {
        foreach(var a in MethodPool.mp.hooks)
            a.Uninstall();
        MethodPool.mp = new MethodPool();
        
        
        
        lua.DoString(s);

         
        
        foreach (Type type in typesToHookLua)
        {
            if (lua[type.Name] is LuaTable luaClass)
            {
                
                foreach (KeyValuePair<object,object> fc in luaClass)
                {
                    var mh = type.GetMethod((string)fc.Key, BindingFlags.Instance | BindingFlags.Public);
                    if (mh != null)
                    {
                        var t = MethodPool.mp.methods.Pop();
                        var luaFunc =  (LuaFunction) fc.Value;
                        MethodPool.mp.lf[t.luaID] = luaFunc;
                        
                        var hook = new MethodHook(mh, t.Call.Method, t.Base.Method);
                        hook.Install();
                        MethodPool.mp.hooks.Add(hook);
                        // break;
                    }
                }
            }
        }
            
    }

}