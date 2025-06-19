using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMover))]
public class InputController : MonoBehaviour
{
    private Actions controls;
    private PlayerMover playerMover;

    private void Start()
    {
        SetupInput();
    }

    private void SetupInput()
    {
        controls = new Actions();
        playerMover = GetComponent<PlayerMover>();
        controls.Enable();
    }

    private void OnDestroy()
    {
        if (controls != null)
            controls.Disable();
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 direction = controls.Player.Move.ReadValue<Vector2>();
        if (playerMover != null)
            playerMover.Move(direction);
    }
}