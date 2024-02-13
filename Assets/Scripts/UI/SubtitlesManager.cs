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

    public static SubtitlesManager instance;

    private void Start()
    {
        if (instance != null) Destroy(this);
        instance = this;
    }

    public void DisplayText(string s, AudioSource AS, ShadowAnimation shadowAnim)
    {
        StopAllCoroutines();
        StartCoroutine(DisplayTextRoutine(s, AS, shadowAnim));
    }

    public void ClearText()
    {
        StopAllCoroutines();
        _text.text = "";
        _showing = false;
    }

    IEnumerator DisplayTextRoutine(string s, AudioSource AS, ShadowAnimation shadowAnim)
    {
        _showing = true;

        _text.text = "";

        shadowAnim.TriggerAnimation(true);

        var wait = new WaitForSeconds(_timeBetweenLetters);

        var charArray = s.ToCharArray();

        foreach (var c in charArray)
        {
            SoundManager.instance.TalkingCharacter(AS);
            _text.text += c;
            yield return wait;
        }

        shadowAnim.TriggerAnimation(false);
    }
}