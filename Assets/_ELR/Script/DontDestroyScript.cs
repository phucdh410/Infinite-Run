using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyScript : MonoBehaviour
{
    private static readonly Dictionary<string, GameObject> _cachedObj = new Dictionary<string, GameObject>();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (_cachedObj.ContainsKey(name))
        {
            DestroyImmediate(gameObject);
            return;
        }
        _cachedObj[name] = gameObject;
    }
}
