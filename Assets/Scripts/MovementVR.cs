using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class MovementVR : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 1f;
    private Vector2 inputMovement = Vector2.zero;
    public void OnMove(InputAction.CallbackContext ctx)
    {
        if(ctx.performed) inputMovement = ctx.ReadValue<Vector2>();
    }

    private void Update() 
    {
        Vector2 translation = inputMovement * moveSpeed * Time.deltaTime;
        transform.position += new Vector3(translation.x, transform.position.y, translation.y);
    }
}
