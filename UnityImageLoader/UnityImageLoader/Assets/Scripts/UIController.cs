using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button _btnLoad;
    [SerializeField] private TMP_InputField _InputField;
    [SerializeField] private GameObject _invalidInputGO;

    private void Start()
    {
        _btnLoad.interactable = false;
        _invalidInputGO.SetActive(false);

        _btnLoad.onClick.AddListener(() => EventAgregator.getAllLinksOfPictures.Invoke(_InputField.text));
        EventAgregator.InvalidInput.AddListener(InvalidInput);
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
}
