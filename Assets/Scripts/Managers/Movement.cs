using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _isKeyboardMovement = false;
    [SerializeField] private bool _clickMovement = false;
    [SerializeField] private Camera _camera;
    [SerializeField] private ObjectSelectionTextController _objectSelectionTextController;
    [SerializeField] private VariantsUIHandler _variantsUIHandler;
    private Vector3 _clickedPos;
    private bool _canMove = true;

    private void OnEnable()
    {
        _objectSelectionTextController.OnShowNextText += DisableMovement;
        _variantsUIHandler.OnAllCorrectAnswersSelected += EnableMovement;
    }

    private void OnDisable()
    {
        _objectSelectionTextController.OnShowNextText -= DisableMovement;
        _variantsUIHandler.OnAllCorrectAnswersSelected -= EnableMovement;
    }

    private void Update()
    {
        if (!_canMove)
        {
            return;
        }

        KeyboardMovement();
        HandleMouseInput();
        MoveToPoint();
    }

    private void KeyboardMovement()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        _isKeyboardMovement = horizontal != 0 || vertical != 0;
        if (_isKeyboardMovement)
        {
            _clickMovement = false;
        }

        transform.position += new Vector3(horizontal * _speed, vertical * _speed) * Time.deltaTime;
    }

    private void HandleMouseInput()
    {
        if (_isKeyboardMovement)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            _clickedPos = _camera.ScreenToWorldPoint(Input.mousePosition);
            _clickMovement = true;
        }
    }

    private void MoveToPoint()
    {
        if (!_clickMovement)
        {
            return;
        }

        if (_isKeyboardMovement)
        {
            return;
        }

        if (transform.position != _clickedPos)
        {
            transform.position = Vector2.MoveTowards(transform.position, _clickedPos, _speed * Time.deltaTime);
        }
        else
        {
            _clickMovement = false;
        }
    }

    private void DisableMovement()
    {
        _canMove = false;
    }

    private void EnableMovement()
    {
        _canMove = true;
    }
}