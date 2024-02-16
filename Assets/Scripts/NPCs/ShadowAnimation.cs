using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowAnimation : MonoBehaviour
{
    public static Dictionary<ShadowAnimations, string> animParameters;

    [SerializeField] ShadowAnimations _animToTrigger;
    [SerializeField] Animator _animator;
    [SerializeField] Transform _meshTransform;
    bool _isSpeaking;
    public bool IsSpeaking {  get { return _isSpeaking; } }

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
        _isSpeaking = b;
        _animator.SetBool(animParameters[_animToTrigger], b);
        StartCoroutine(LookAtPlayer());
    }

    IEnumerator LookAtPlayer()
    {
        while (_isSpeaking)
        {
            _meshTransform.forward = new Vector3(PlayerModel.playerPosition.x - transform.position.x,
                transform.forward.y,
                PlayerModel.playerPosition.z - transform.position.z);
            yield return null;
        }
        _meshTransform.forward = transform.forward;
    }
}
