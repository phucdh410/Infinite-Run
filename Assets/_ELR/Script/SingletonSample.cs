using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonSample : ManualSingleton<SingletonSample>
{
    private int _tempInt;

    public int TempInt
    {
        get { return _tempInt; }
        set { _tempInt = value; }
    }

    public int GetTempInt()
    {
        return _tempInt;
    }

    public void SetTempInt(int i)
    {
        _tempInt = i;
    }

    private void Start() {
        _tempInt = 100;
    }
}
