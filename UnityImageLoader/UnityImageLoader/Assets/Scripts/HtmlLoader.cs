using AngleSharp;
using AngleSharp.Dom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

public class HtmlLoader : MonoBehaviour
{
    private string _url;
    public string Url => _url;

    private IEnumerable<IAttr> _urlOfImages;
    public IEnumerable<IAttr> UrlOfImages => _urlOfImages;

    public int UrlsCount => _urlOfImages.Count<IAttr>();

    private void Awake()
    {
        EventAgregator.getAllLinksOfPictures.AddListener(GetAllUrlOfPictures);
    }

    public async void GetAllUrlOfPictures(string baseUrl)
    {
        await GetAllUrlOfPicturesAsync(baseUrl);
    }

    private async Task GetAllUrlOfPicturesAsync(string baseUrl)
    {
        _url = baseUrl;

        HttpClient client = new HttpClient();

        var config = Configuration.Default.WithDefaultLoader();

        var document = await BrowsingContext.New(config).OpenAsync(baseUrl);

        if (document == null)
        {
            EventAgregator.InvalidInput.Invoke();
        }
        else
        {
            var fileExtensions = new string[] { ".jpg", ".png", ".GIF", ".JPEG", ".PDF", ".BMP", };

            _urlOfImages = from element in document.All
                           from attribute in element.Attributes
                           where fileExtensions.Any(e => attribute.Value.EndsWith(e))
                           select attribute;

            if (UrlsCount > 0)
            {
                EventAgregator.LoadAllPickures.Invoke();
            }
            else
            {
                EventAgregator.NotContent.Invoke();
            }
        }
    }
}

