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
    
    
}