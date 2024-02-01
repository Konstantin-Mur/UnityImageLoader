using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button _btnLoad;
    [SerializeField] private TMP_InputField _InputField;
    [SerializeField] private GameObject _invalidInputGO;
    [SerializeField] private GameObject _notContentGO;

    private void Start()
    {
        _btnLoad.interactable = false;
        _invalidInputGO.SetActive(false);
        _notContentGO.SetActive(false);

        _btnLoad.onClick.AddListener(() => EventAgregator.getAllLinksOfPictures.Invoke(_InputField.text));
        EventAgregator.InvalidInput.AddListener(InvalidInput);
        EventAgregator.NotContent.AddListener(NotContent);
    }

    private void Update()
    {
        if (!string.IsNullOrEmpty(_InputField.text))
        {
            _btnLoad.interactable = true;
        }
    }

    private void InvalidInput()
    {
        StartCoroutine(InvalidInputCoroutine());
    }

    private IEnumerator InvalidInputCoroutine()
    {
        _invalidInputGO.SetActive(true);
        yield return new WaitForSeconds(2f);
        _invalidInputGO.SetActive(false);
    }

    private void NotContent()
    {
        StartCoroutine(NotContentCoroutine());
    }

    private IEnumerator NotContentCoroutine()
    {
        _notContentGO.SetActive(true);
        yield return new WaitForSeconds(2f);
        _notContentGO.SetActive(false);
    }
}
