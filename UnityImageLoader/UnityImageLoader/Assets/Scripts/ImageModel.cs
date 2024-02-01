using UnityEngine;

public class ImageModel : MonoBehaviour
{
    private Sprite _icon;
    public Sprite Icon => _icon;

    private string _name;
    public string Name => _name;

    private string _url;
    public string Url => _url;

    [SerializeField] private Sprite _defaultIcon;
    public Sprite DefaultIcon => _defaultIcon;

    public void SetDefaultData(string name, string url)
    {
        _icon = _defaultIcon;
        _name = name;
        _url = url;
    }

    public void SetImage(Sprite image)
    {
        _icon = image;
    }
}
