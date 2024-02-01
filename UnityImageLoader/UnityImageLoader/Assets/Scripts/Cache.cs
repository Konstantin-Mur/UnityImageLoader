using System.Collections.Generic;
using UnityEngine;

public class Cache : MonoBehaviour
{
    private Dictionary<string, List<ImageController>> _cacheOfImages = new Dictionary<string, List<ImageController>>();
    public Dictionary<string, List<ImageController>> CacheOfImages => _cacheOfImages;

    private List<string> _keysUrl = new List<string>();
    private Settings _settings;

    public bool CheckCathe(string url)
    {
        foreach (var keyUrl in CacheOfImages.Keys)
        {
            if (url == keyUrl)
            {
                return false;
            }
        }

        return true;
    }

    public void AddCathe(string url, List<ImageController> models)
    {
        _cacheOfImages.Add(url, models);
        _keysUrl.Add(url);
    }

    public void RemoveCathe(string url)
    {
        _cacheOfImages.Remove(url);
        _keysUrl.Remove(url);
    }

    public void UpdateCathe(string url, List<ImageController> models)
    {
        _cacheOfImages.Remove(url);
        _cacheOfImages.Add(url, models);
    }

    private void Start()
    {
        _settings = FindObjectOfType<Settings>();
    }
}
