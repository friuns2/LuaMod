using System.Runtime.InteropServices;
using UnityEngine;



public class Test5 : MonoBehaviour
{
    
    [DllImport("__Internal")]
    private static extern int _asmAdd(int x, int y);
 
    void OnGUI()
    {
        GUI.Label(new Rect(100, 50, 100, 100), _asmAdd(10, 20).ToString());
    }

}