using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ImageLoader : MonoBehaviour
{
    [SerializeField] private ImageController _imagePrefab;
    [SerializeField] private Cache _cache;
    [SerializeField] private HtmlLoader _htmlLoader;
    [SerializeField] private GameObject _placeOfCreate;

    private List<ImageController> _imageControllers;

    private void Start()
    {
        EventAgregator.LoadAllPickures.AddListener(GetImages);
    }

    private void GetImages()
    {
        StartCoroutine(GetImagesCoroutine());
    }

    private IEnumerator GetImagesCoroutine()
    {
        if (_cache.CheckCathe(_htmlLoader.Url, _htmlLoader.UrlsCount))
        {
            CreateDefaultEmpty();

            foreach (var url in _htmlLoader.UrlOfImages)
            {

                StartCoroutine(DownloadTexture(url.Value));
                yield return null;
            }
        }
    }

    private IEnumerator DownloadTexture(string url)
    {
        var request = UnityWebRequestTexture.GetTexture(url);

        yield return request.SendWebRequest();

        while (!request.isDone)
        {
            yield return null;
        }

        if (request.isNetworkError)
        {
            Debug.Log("Error in web service::" + request.error);
        }
        else
        {
            var texture = DownloadHandlerTexture.GetContent(request);

            foreach (var controller in _imageControllers)
            {
                if (controller.ImageModel.Url == url)
                {
                    Sprite image = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);

                    controller.ImageModel.SetImage(image);
                    controller.onUpdateUI.Invoke();
                }
            }

            _cache.UpdateCathe(_htmlLoader.Url, _imageControllers);
        }
    }

    private void CreateDefaultEmpty()
    {
        _imageControllers = new List<ImageController>();

        int count = 0;
        foreach (var url in _htmlLoader.UrlOfImages)
        {
            count++;

            var go = Instantiate(_imagePrefab);

            go.transform.SetParent(_placeOfCreate.transform);
            go.transform.localScale = _placeOfCreate.transform.localScale;

            go.ImageModel.SetDefaultData(count.ToString(), url.Value);

            _imageControllers.Add(go);    
        }

        _cache.AddCathe(_htmlLoader.Url, _imageControllers);
    }
}
