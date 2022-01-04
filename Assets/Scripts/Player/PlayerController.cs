using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Camera _mainCamera;

    private Vector2 _currentMovement;
    //   private CharacterController _characterController;

    private Rigidbody2D _rigidbody2D;

    
    void Start()
    {
        _mainCamera = Camera.main;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!GameManager.Instance.IsGameOver)
        {
            BorderCheck();
            MovementController();
        }
    }
    
    
    private void BorderCheck()
    {
        Vector3 fillingArea = Camera.main.ViewportToWorldPoint(Camera.main.transform.position);

        Vector3 pos = transform.position;
        if (pos.x > Mathf.Abs(fillingArea.x)) pos.x = -Mathf.Abs(fillingArea.x);
        if (pos.x < -Mathf.Abs(fillingArea.x)) pos.x = Mathf.Abs(fillingArea.x);
        if (pos.y > Mathf.Abs(fillingArea.y)) pos.y = -Mathf.Abs(fillingArea.y);
        if (pos.y < -Mathf.Abs(fillingArea.y)) pos.y = Mathf.Abs(fillingArea.y);

        transform.position = pos;
    }

    
    private void MovementController()
    {
        _currentMovement.x = Input.GetAxis("Horizontal");
        _currentMovement.y = Input.GetAxis("Vertical");

        Vector3 difference = Input.mousePosition - _mainCamera.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        if (_currentMovement.magnitude >= 0.05f)
        {
            Vector3 force = (transform.right * _currentMovement.x) +
                            (transform.up * (_currentMovement.y > 0 ? _currentMovement.y : 0));
            _rigidbody2D.AddForce(force * Time.deltaTime * 1000);
        }
    }
}
