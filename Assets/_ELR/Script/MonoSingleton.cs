using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T: MonoSingleton<T>
{
    //private static T m_Instance = null;
    //public static T Instance
    //{
    //    get
    //    {
    //        if(m_Instance == null)
    //        {
    //            m_Instance = GameObject.FindObjectOfType(typeof(T)) as T;

    //            if (m_Instance == null)
    //            {
    //                Debug.LogWarning("No instance of " + typeof(T).ToString() + ", a temporary one is created.");
    //            }
    //            isTemporaryInstance = true;
    //            m_Instance = new GameObject("Temp Instance of " + typeof(T).ToString(), typeof(T)).GetComponent<T>();


    //        }
    //    }
    //}
}
public abstract class ManualSingleton<T> : MonoBehaviour where T : ManualSingleton<T>
{
    private static T _instance;

    public static T Instance => _instance;

    public virtual void Awake()
    {
        if (_instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }

        _instance = (T)(MonoBehaviour)this;
        if (_instance == null)
            Debug.LogError("Check init again" + typeof(T));
    }

    protected virtual void OnDestroy()
    {
        if (_instance == this)
            _instance = null;
    }
}