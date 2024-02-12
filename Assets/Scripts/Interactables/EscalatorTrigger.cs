using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscalatorTrigger : MonoBehaviour
{
    [SerializeField] Transform _directionPoint;
    [SerializeField] float _force;
    private void OnTriggerEnter(Collider other)
    {
        StopAllCoroutines();
        StartCoroutine(Escalate(other.GetComponent<Rigidbody>()));
    }

    private void OnTriggerExit(Collider other)
    {
        other.attachedRigidbody.velocity = Vector3.zero;
        StopAllCoroutines();
    }

    IEnumerator Escalate(Rigidbody rb)
    {
        while (true)
        {
            rb.velocity = _directionPoint.localPosition.normalized * _force;
            yield return null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, _directionPoint.position);
    }
}