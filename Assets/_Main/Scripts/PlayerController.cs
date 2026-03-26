using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Declarar variables

    [SerializeField] private Rigidbody2D _rb2D;
    [SerializeField] private float _fuerzaSalto = 300f;
    [SerializeField] private bool _isGround;
    [SerializeField] private float _velocidad = 5f;
    private void Awake()
    {
        _rb2D =  GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") & _isGround)
        {
            _rb2D.AddForce(Vector2.up * _fuerzaSalto);
        }
    }
        
    private void FixedUpdate()
    {
        
        float horizontal = Input.GetAxis("Horizontal");
        _rb2D.linearVelocity = new Vector2(horizontal * _velocidad, _rb2D.linearVelocity.y);
    }

private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = false;
        }
    }
}
