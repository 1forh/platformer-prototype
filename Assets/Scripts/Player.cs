using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    private UIManager _uiManager;
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _gravity = 1.3f;
    [SerializeField]
    private float _jumpHeight = 20.0f;
    private float _yVelocity;
    private bool _canDoubleJump = false;
    [SerializeField]
    private int _totalAmountOfCoins = 0;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_controller == null)
        {
            Debug.LogError("_controller is NULL");
        }

        if (_uiManager == null)
        {
            Debug.LogError("UI Manager is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0.0f, 0.0f);
        Vector3 velocity = direction * _speed;

        if (_controller.isGrounded == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (_canDoubleJump == true)
                {
                    _yVelocity += _jumpHeight;
                    _canDoubleJump = false;
                }
            }

            _yVelocity -= _gravity;
        }

        velocity.y = _yVelocity;


        _controller.Move(velocity * Time.deltaTime);
    }

    public void AddCoins(int numberOfCoins = 1)
    {
        _totalAmountOfCoins += numberOfCoins;
        _uiManager.UpdateCoinDisplay(_totalAmountOfCoins);
    }
}
