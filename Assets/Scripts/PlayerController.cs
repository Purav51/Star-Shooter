using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{

    Vector3 moveVector;
    Vector2 minBounds;
    Vector2 maxBounds;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float LeftBoundPadding ;
    [SerializeField] float RightBoundPadding ;
    [SerializeField] float UpBoundPadding ;
    [SerializeField] float DownBoundPadding ;

    Sooter playerShooter;
    InputAction moveAction;
    InputAction fireAction;


    void Start()
    {
        playerShooter = GetComponent<Sooter>();
        moveAction = InputSystem.actions.FindAction("Move");
        fireAction = InputSystem.actions.FindAction("Fire");
        InitBounds();
    }

    
    void Update()
    {
        movePlayer();
        FireShooter();
    }
    void InitBounds()
    {
        Camera mainCam = Camera.main;
        minBounds = mainCam.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCam.ViewportToWorldPoint(new Vector2(1,1));
    }
    void movePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        Vector3 newPos = transform.position + moveVector * moveSpeed * Time.deltaTime; //if moveVector is set to Vector2 it causes an error.
        newPos.x = Mathf.Clamp(newPos.x, minBounds.x + LeftBoundPadding, maxBounds.x - RightBoundPadding);
        newPos.y = Mathf.Clamp(newPos.y, minBounds.y + DownBoundPadding, maxBounds.y - UpBoundPadding);
        transform.position = newPos; 
    }

    void FireShooter()
    {
        playerShooter.isFiring = fireAction.IsPressed();
    }
}
