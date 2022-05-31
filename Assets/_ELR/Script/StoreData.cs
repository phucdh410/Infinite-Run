using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Newtonsoft.Json;
using System.IO;

public class StoreData : MonoBehaviour
{
        private string _tempString = string.Empty;
        public TextMeshProUGUI TextMesh;
        public string CustomString;
        private const string PREF_KEY = "PrefString";
        public string cachedString;
    public TempScriptObject ObjectData;
    
    public void SaveString()
    {
        //PlayerPrefs.SetString(PREF_KEY, CustomString);
        var objectJson = new MyJson();
        cachedString = JsonConvert.SerializeObject(objectJson);
        TextMesh.text = cachedString;
    }

    public void LoadString()
    {
        var objectJson = new MyJson();
        cachedString = cachedString.Replace("Player", "Players");
        objectJson = JsonConvert.DeserializeObject<MyJson>(cachedString);
        Debug.Log(objectJson.name + " " + objectJson.level);
        //var temp = PlayerPrefs.GetString(PREF_KEY);
        //TextMesh.text = temp;
        //// Delete key
        //PlayerPrefs.DeleteKey(PREF_KEY);
        //PlayerPrefs.DeleteAll()
    }
    public void SaveFile()
    {
        //Save File
        var path = Application.persistentDataPath + "/saveFile.txt";
        //Debug.Log(path);
        //Load File
        var loadString = File.ReadAllText(path);
        var temp = loadString.Split(';');
        //Debug.Log(loadString);

    }
    public void LoadNode()
    {
        TextMesh.text = ObjectData.Name + " " + ObjectData.Level;
    }
}


public class MyJson
{
    public int level = 100;
    public string name = "Tui";
    public int Hp = 100;
    public string[] Slot = { "a", "b", "c", "d" };
}