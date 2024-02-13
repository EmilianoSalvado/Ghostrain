using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowAnimation : MonoBehaviour
{
    public static Dictionary<ShadowAnimations, string> animParameters;

    [SerializeField] ShadowAnimations _animToTrigger;
    [SerializeField] Animator _animator;

    private void Start()
    {
        if (animParameters == null)
        {
            animParameters = new Dictionary<ShadowAnimations, string>();

            animParameters.Add(ShadowAnimations.Talking, "Talking");
            animParameters.Add(ShadowAnimations.Angry, "Angry");
            animParameters.Add(ShadowAnimations.Kind, "Kind");
        }
    }

    public void TriggerAnimation(bool b)
    {
        _animator.SetBool(animParameters[_animToTrigger], b);
    }
}
