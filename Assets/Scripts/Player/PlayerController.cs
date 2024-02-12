using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerModel _playerModel;
    float _horAxis, _verAxis;
    float _mouseX, _mouseY;

    [SerializeField] PlayerInteractions _interaction;
    [SerializeField] KeyCode[] _movementKeys;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        _horAxis = Input.GetAxis("Horizontal");
        _verAxis = Input.GetAxis("Vertical");

        if (_horAxis != 0 || _verAxis != 0)
            _playerModel.Move(_horAxis, _verAxis);

        if (_movementKeys.Any(x => Input.GetKeyDown(x) && !SoundManager.Instance.PlayerFootstepsSource.isPlaying))
            SoundManager.Instance.PlayerWalk(true);
        if (_movementKeys.All(x => !Input.GetKey(x) && SoundManager.Instance.PlayerFootstepsSource.isPlaying))
            SoundManager.Instance.PlayerWalk(false);

        _mouseX = Input.GetAxis("Mouse X");
        _mouseY = Input.GetAxis("Mouse Y");

        if (_mouseX != 0 || _verAxis != 0)
            _playerModel.SetCameraRotation(_mouseX, _mouseY);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (SubtitlesManager.Instance.Showing)
            { SubtitlesManager.Instance.ClearText(); return; }
            if (!_interaction.CanInteract) return;
            _interaction.Interact();
        }
    }
}