using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float velPersonaje = 7f;
    public float fuerzaSalto = 7f;
    public Animator anim;
    public CapsuleCollider2D MyCollider;
    public bool Damage;

    [Header("Ajustes de Gravedad")]
    public float multiplicadorCaida = 3f; 

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        MyCollider = GetComponent<CapsuleCollider2D>();

        //pa q no ruede, esto me lo sque de twitter XDD
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        //se supone que esto haga un stun, lo dudo XD
        if (!Damage)
        {
            heroMov();
            Jump();
        }

        checkForGround();
        AjustarGravedad();

        anim.SetBool("Damage", Damage);
    }

    void heroMov()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rb2d.linearVelocity = new Vector2(h * velPersonaje, rb2d.linearVelocity.y);

        if (h != 0)
        {
            transform.eulerAngles = new Vector3(0, h > 0 ? 0 : 180, 0);
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    private void Jump()
    {
        bool tocandoSuelo = MyCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));

        
        anim.SetFloat("Jump_Velocity", rb2d.linearVelocity.y);

     
        if (Input.GetButtonDown("Jump") && tocandoSuelo)
        {
            
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, fuerzaSalto);
        }
    }

    private void checkForGround()
    {
        // suelo toca=true, no toca=false
        bool estaEnSuelo = MyCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
        anim.SetBool("Is_Grounded", estaEnSuelo);
    }


    //esta parte me la ayudo a hacer un amigo, q perra webada fue esto.

    private void AjustarGravedad()
    {
       
        if (rb2d.linearVelocity.y < 0)
        {
            rb2d.gravityScale = multiplicadorCaida;
        }
        else
        {
            rb2d.gravityScale = 1f;
        }
    }

    public void Take_Damage(Vector2 direccion, int cntDmg)
    {

        if (!Damage)
        {
            Damage = true;
            Vector2 rebote = new Vector2(transform.position.x - direccion.x, 1).normalized *5f;
            rb2d.AddForce(rebote, ForceMode2D.Impulse);

            Invoke("End_Damage", 0.8f);
        }
    }

    public void End_Damage()
    {
        Damage = false;
    }
}

