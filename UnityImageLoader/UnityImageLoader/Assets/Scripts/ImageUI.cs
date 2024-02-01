using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ImageUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private Image _image;

    public void UpdateUI(ImageModel model)
    {
        _name.text = model.Name;

        if (model.Icon == null)
        {
            _image.sprite = model.DefaultIcon;
        }
        else
        {
            _image.sprite = model.Icon;
        }
    }
}
