using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] Transform _cameraTransform;
    [SerializeField] LayerMask _interactablesLayer;
    [SerializeField] float _rayDistance;
    Action _interact;
    public Action Interact { get { return _interact; } }
    bool _canInteract;
    public bool CanInteract { get { return _canInteract; } }
    RaycastHit _hit;

    private void Update()
    {
        if (Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out _hit, _rayDistance, _interactablesLayer))
        {
            _interact = _hit.transform.GetComponent<Interactable>().Interact;
            _canInteract = true;
            return;
        }
        if (_canInteract) _canInteract = false;
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(_cameraTransform.position, _cameraTransform.position + _cameraTransform.forward * _rayDistance);
    }
}