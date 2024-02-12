using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextReader : MonoBehaviour
{
    [SerializeField] GameObject _textReaderScreen;
    [SerializeField] TextMeshProUGUI _text;

    public static TextReader instance;

    private void Start()
    {
        instance = this;
    }

    public void OpenTextReaderScreen(string text)
    {
        _text.text = text;

        _textReaderScreen.SetActive(true);

        Cursor.lockState = CursorLockMode.Confined;
        PlayerController.instance.BehaviourEnable(false);
    }

    public void Close()
    {
        _textReaderScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        PlayerController.instance.BehaviourEnable(true);
    }
}