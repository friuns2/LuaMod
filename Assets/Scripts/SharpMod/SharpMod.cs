using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using Slowsharp;

public static class SharpMod
{

    public static Action Base;
    public static void BaseInvoke()
    {
        Base();
    }
    public static void PatchAll(string s)
    {
        foreach(var a in MethodPool.mp.hooks)
            a.Uninstall();
        s = Regex.Replace(s, @"base\.\w*\(\);", "SharpMod.BaseInvoke();");
        
        MethodPool.mp = new MethodPool();
        
        var runner = CScript.CreateRunner(s);
        

        // var type = h.GetHybType();

        var assembly = Assembly.GetExecutingAssembly();
        
        foreach (HybType  Class in runner.GetTypes())
        {
            var type = assembly.GetType(Class.parent.id);
            
            foreach (SSMethodInfo fc in Class.GetMethods())
            {
                if (Class != fc.declaringType) continue;
                
                var mh = type.GetMethod(fc.id, BindingFlags.Instance | BindingFlags.Public);
                if (mh != null)
                {
                    var t = MethodPool.mp.methods.Pop();
                    MethodPool.mp.lf[t.id] = fc;
                    

                    var hook = new MethodHook(mh, t.Call.Method, t.Base.Method);
                    hook.Install();
                    MethodPool.mp.hooks.Add(hook);
                    // break;
                }
            }
        }
            
    }
    
     
}