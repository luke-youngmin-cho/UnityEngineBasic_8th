using System;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    public bool isMovable;
    public bool isDirectionChangeable;

    public const int DIRECTION_RIGHT = 1;
    public const int DIRECTION_LEFT = -1;
    public int direction
    {
        get => _direction;
        set
        {
            if (value < 0)
            {
                transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
                _direction = DIRECTION_LEFT;
            }
            else
            {
                transform.eulerAngles = Vector3.zero;
                _direction = DIRECTION_RIGHT;
            }
        }
    }

    private int _direction;
    public float horizontal
    {
        get => _horizontal;
        set
        {
            if (isMovable == false)
                return;

            if (_horizontal == value)
                return;

            _horizontal = value;
            //onHorizontalChanged(value); // 직접호출 - 등록된 함수를 호출할때마다 인자를 직접참조
            //onHorizontalChanged.Invoke(value); // 간접호출 - Invoke의 매개변수에 인자 전달 후.. 등록된함수들은 Invoke 의 매개변수를 참조함
            onHorizontalChanged?.Invoke(value); // null 체크 연산자 - null 이면 (등록된함수 없으면) 호출 x 
        }
    }
    private float _horizontal;
    public event Action<float> onHorizontalChanged;
    private Rigidbody2D _rigidbody;
    private Vector2 _move;
    [SerializeField] private float _speed = 1.0f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        if (isMovable)
        {
            _move = new Vector2(horizontal, 0.0f);
        }
        else
        {
            _move = Vector2.zero;
        }

        if (isDirectionChangeable)
        {
            if (_horizontal > 0)
                direction = DIRECTION_RIGHT;
            else if (_horizontal < 0)
                direction = DIRECTION_LEFT;
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.position += _move * _speed * Time.fixedDeltaTime;
    }
}
