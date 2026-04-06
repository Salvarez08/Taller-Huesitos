using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float velPersonaje = 5f;
    public float fuerzaSalto = 12f; // Prueba con 12 para un salto estándar
    public Animator anim;
    public BoxCollider2D MyCollider;

    [Header("Ajustes de Gravedad")]
    public float multiplicadorCaida = 2.5f; // Para que caiga más rápido y se sienta mejor

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        MyCollider = GetComponent<BoxCollider2D>();

        // Evita que el personaje rote al chocar con esquinas
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        heroMov();
        Jump();
        checkForGround();
        AjustarGravedad();
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

        // Mandamos la velocidad actual al animator
        anim.SetFloat("Jump_Velocity", rb2d.linearVelocity.y);

        // SOLO si presionas el botón Y estás en el suelo
        if (Input.GetButtonDown("Jump") && tocandoSuelo)
        {
            // ASIGNACIÓN DIRECTA: Esto evita que el salto se multiplique
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, fuerzaSalto);
        }
    }

    private void checkForGround()
    {
        // Si toca el suelo, Is_Grounded es TRUE
        bool estaEnSuelo = MyCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
        anim.SetBool("Is_Grounded", estaEnSuelo);
    }

    private void AjustarGravedad()
    {
        // Si el personaje está cayendo (velocidad Y negativa), aumentamos un poco la gravedad
        // para evitar que se sienta "flotado" y que la caída sea exagerada.
        if (rb2d.linearVelocity.y < 0)
        {
            rb2d.gravityScale = multiplicadorCaida;
        }
        else
        {
            rb2d.gravityScale = 1f;
        }
    }
}