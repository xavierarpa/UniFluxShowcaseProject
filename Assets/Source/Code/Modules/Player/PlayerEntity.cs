using Kingdox.UniFlux;
using UnityEngine;
using Service;
public sealed class PlayerEntity : MonoFlux
{
    private bool _isGrounded;
    [Header("General fields")]
    [Space]
    [SerializeField] private int _health = default;
    [SerializeField] private float _speed = default;
    [SerializeField] private float _jumpForce = default;
    [SerializeField] private float _gravityForce = default;
    [Header("Raycast")]
    [Space]
    [SerializeField] private Vector3 _rayOffset = default;
    [SerializeField] private float _rayLength = default;
    [Header("References")]
    [Space]
    [SerializeField] private Rigidbody _rigidbody;
    [Header("Layers")]
    [Space]
    [SerializeField] private LayerMask _groundLayer;
    private bool IsGrounded
    {
        get => _isGrounded;
        set  
        {
            if(_isGrounded != value)
            {
                _isGrounded = value;
                if (value) OnGroundChange();
                else OnAirChange();
            } 
            else  
            {
                _isGrounded = value;
            }
            //
            if (value) OnGround();
            else OnAir();
        }
    }
    public int CurrentHealth
    {
        get => _health;
        set
        {
            _health = value;
            Player.Key.OnLifeChange.Dispatch(value);
        }
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + _rayOffset, -transform.up * _rayLength);
    }
#endif
    private void Update()
    {
        IsGrounded = Physics.Raycast(transform.position + _rayOffset, -transform.up, _rayLength, _groundLayer);
        Service.Camera.OnMove(transform.position);
        Service.Camera.OnRotate(transform.rotation);
    }
    [Flux(Keyboard.Key.OnInput.Space)] private void OnSpace() 
    {
        TryJump();
    }
    [Flux(Keyboard.Key.OnInput.Up)] private void OnMoveUp() 
    {
        Move(Vector3.forward);  
    }
    [Flux(Keyboard.Key.OnInput.Right)] private void OnMoveRight() 
    {
        Move(Vector3.right);  
    }
    [Flux(Keyboard.Key.OnInput.Left)] private void OnMoveLeft() 
    {
        Move(Vector3.left);  
    }
    [Flux(Keyboard.Key.OnInput.Down)] private void OnMoveDown() 
    {
        Move(Vector3.back);  
    }
    public void ApplyDamage(int damage) 
    {
        CurrentHealth -= damage;
    }
    private void Move(Vector3 inputDir) 
    {
        Vector3 vel = _rigidbody.velocity;
        vel.x += inputDir.x * _speed;
        vel.z += inputDir.z * _speed;
        _rigidbody.velocity = vel;
        Service.Lamp.UpdatePlayerPosition(transform);
    }
    private void TryJump()
    {
        if (IsGrounded) 
        {
            Jump();
        }
    }
    private void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }
    private void OnGroundChange()
    {
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0f, _rigidbody.velocity.z);
        //VFX grounded
    }
    private void OnAirChange()
    {
        //VFX jump
    }
    private void OnGround()
    {
        //...
    }
    private void OnAir()
    {
        _rigidbody.AddForce(Vector3.down * _gravityForce, ForceMode.Acceleration);
    }
}
