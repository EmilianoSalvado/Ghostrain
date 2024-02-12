using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SubtitlesManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] float _timeBetweenLetters;
    bool _showing = false;
    public bool Showing { get { return _showing; } }

    public static SubtitlesManager Instance;

    private void Start()
    {
        if (Instance != null) Destroy(this);
        Instance = this;
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            DisplayText("Pablito clavó un clavito qué clavito clavó pablito");
    }
#endif

    public void DisplayText(string s)
    {
        StopAllCoroutines();
        StartCoroutine(DisplayTextRoutine(s));
    }

    public void ClearText()
    {
        StopAllCoroutines();
        _text.text = "";
        _showing = false;
    }

    IEnumerator DisplayTextRoutine(string s)
    {
        _showing = true;

        _text.text = "";

        var wait = new WaitForSeconds(_timeBetweenLetters);

        var charArray = s.ToCharArray();

        foreach (var c in charArray)
        {
            _text.text += c;
            yield return wait;
        }
    }
}