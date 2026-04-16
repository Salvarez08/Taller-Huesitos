using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float velPersonaje = 7f;
    public float fuerzaSalto = 7f;
    public Animator anim;
    public CapsuleCollider2D MyCollider;
    public SpriteRenderer spriteRenderer;

    public bool Damage;
    public bool isInvincible;

    [Header("Ajustes de Daño")]
    public float tiempoStun = 0.4f;
    public float tiempoInvencibilidad = 1.5f;

    [Header("Ajustes de Gravedad")]
    public float multiplicadorCaida = 3f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        MyCollider = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
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
        bool estaEnSuelo = MyCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
        anim.SetBool("Is_Grounded", estaEnSuelo);
    }

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
        if (!isInvincible)
        {
            Damage = true;
            isInvincible = true;

            Vector2 rebote = new Vector2(transform.position.x - direccion.x, 1).normalized * 5f;
            rb2d.linearVelocity = Vector2.zero;
            rb2d.AddForce(rebote, ForceMode2D.Impulse);

            Invoke("End_Damage", tiempoStun);
            StartCoroutine(InvincibilityRoutine());
        }
    }

    public void End_Damage()
    {
        Damage = false;
    }

    private IEnumerator InvincibilityRoutine()
    {
        float tiempoPasado = 0;
        while (tiempoPasado < tiempoInvencibilidad)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(0.1f);
            tiempoPasado += 0.1f;
        }

        spriteRenderer.enabled = true;
        isInvincible = false;
    }
}

