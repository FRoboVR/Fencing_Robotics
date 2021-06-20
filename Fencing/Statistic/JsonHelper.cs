using UnityEngine;
using UnityEngine.UI;

public class JsonHelper
{

    public static T[] getJsonArray<T>(string json)
    {
        string newJson = "{ \"array\": " + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson <Wrapper<T>>(newJson);
        return wrapper.array;
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] array = null;
    }
}

[System.Serializable]
public class TopItem
{
    public string name;
    public string discipline;
    public string score;
    public string time;
}