using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    InputAction moveAction;

    Vector3 moveVector;
    [SerializeField] float moveSpeed = 10;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    
    void Update()
    {
        movePlayer();
    }
    void movePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>() ;
        transform.position += moveVector * moveSpeed * Time.deltaTime; //if moveVector is set to Vector2 it causes an error.
    }
}
