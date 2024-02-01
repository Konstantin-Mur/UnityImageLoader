using UnityEngine;
using UnityEngine.Events;

public class ImageController : MonoBehaviour
{
    private ImageModel _imageModel;
    public ImageModel ImageModel => _imageModel;

    private ImageUI _imageUI;
    public ImageUI ImageUI => _imageUI;

    public UnityEvent onUpdateUI;

    private void Awake()
    {
        _imageUI = GetComponent<ImageUI>();
        _imageModel = GetComponent<ImageModel>();

        onUpdateUI.AddListener(() => _imageUI.UpdateUI(_imageModel));
    }
}
