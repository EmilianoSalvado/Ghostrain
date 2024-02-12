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

    public void DisplayText(string s, AudioSource AS)
    {
        StopAllCoroutines();
        StartCoroutine(DisplayTextRoutine(s, AS));
    }

    public void ClearText()
    {
        StopAllCoroutines();
        _text.text = "";
        _showing = false;
    }

    IEnumerator DisplayTextRoutine(string s, AudioSource AS)
    {
        _showing = true;

        _text.text = "";

        var wait = new WaitForSeconds(_timeBetweenLetters);

        var charArray = s.ToCharArray();

        foreach (var c in charArray)
        {
            SoundManager.Instance.TalkingCharacter(AS);
            _text.text += c;
            yield return wait;
        }
    }
}