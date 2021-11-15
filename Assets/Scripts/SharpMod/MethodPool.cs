using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Slowsharp;
using UnityEngine;

public class MethodPool
{
    public static MethodPool mp = new MethodPool();

    public class MethodPoolItem
    {
        public int id;
        public Action Call;
        public Action Base;
        public static implicit operator MethodPoolItem((int, Action, Action) t)
        {
            return new MethodPoolItem() {id = t.Item1, Call = t.Item2, Base = t.Item3};
        }
    }
    
    public Stack<MethodPoolItem> methods = new Stack<MethodPoolItem>();
    public SSMethodInfo[] lf = new SSMethodInfo[10];
    private int id;
    public List<MethodHook> hooks = new List<MethodHook>();
    public MethodPool()
    {
        methods.Push((1, Execute1, BaseMethod1));
        // methods.Push((2, LuaExecute2, BaseMethod2));

    }
    
    
    [MethodImpl(MethodImplOptions.NoOptimization)] public void Execute1() { SharpMod.Base = (Action)BaseMethod1; mp.lf[1].Invoke(HybInstance.Object(this)); } [MethodImpl(MethodImplOptions.NoOptimization)] public void BaseMethod1() { Debug.Log("base method"); }
    
    // [MethodImpl(MethodImplOptions.NoOptimization)] public void LuaExecute2() { LuaMod.lua["this"] = this; mp.lf[2].Call(); } [MethodImpl(MethodImplOptions.NoOptimization)] public void BaseMethod2() { Debug.Log("base method"); }
    // private LuaFunction lf3; [MethodImpl(MethodImplOptions.NoOptimization)] public void LuaExecute3() { lf3.Call(); } [MethodImpl(MethodImplOptions.NoOptimization)] public void BaseMethod3() { Debug.Log("base method"); }
    // private LuaFunction lf4; [MethodImpl(MethodImplOptions.NoOptimization)] public void LuaExecute4() { lf4.Call(); } [MethodImpl(MethodImplOptions.NoOptimization)] public void BaseMethod4() { Debug.Log("base method"); }
    // private LuaFunction lf5; [MethodImpl(MethodImplOptions.NoOptimization)] public void LuaExecute5() { lf5.Call(); } [MethodImpl(MethodImplOptions.NoOptimization)] public void BaseMethod5() { Debug.Log("base method"); }
    // private LuaFunction lf6; [MethodImpl(MethodImplOptions.NoOptimization)] public void LuaExecute6() { lf6.Call(); } [MethodImpl(MethodImplOptions.NoOptimization)] public void BaseMethod6() { Debug.Log("base method"); }
    // private LuaFunction lf7; [MethodImpl(MethodImplOptions.NoOptimization)] public void LuaExecute7() { lf7.Call(); } [MethodImpl(MethodImplOptions.NoOptimization)] public void BaseMethod7() { Debug.Log("base method"); }
    
    
}