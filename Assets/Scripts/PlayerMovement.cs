using System;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float hiz;
    [SerializeField] private float ziplamahizi;

    [SerializeField] private LayerMask groundlayer;
    [SerializeField] private LayerMask duvarlayer;
    private Rigidbody2D body;
    private Animator animasyon;
    private BoxCollider2D boxCollider;
    private float wjcooldown;
    private float horizontalInput;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animasyon = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
       horizontalInput = Input.GetAxis("Horizontal");

        //Karakter sağa sola hareket ettiğinde dönmesini sağlayan kod.
        {
            if (horizontalInput > 0.01f)
            {
                transform.localScale = Vector3.one;
            }
            else if (horizontalInput < -0.01f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }


        //animasyon ayarları.
        animasyon.SetBool("run", horizontalInput != 0);
        animasyon.SetBool("zemintemas", zeminmi());


        //duvardan zıplama
        if (wjcooldown < 0.2f)
        {

            body.linearVelocity = new Vector2(horizontalInput * hiz, body.linearVelocityY);

            if (duvarmi() && !zeminmi())
            {
                body.gravityScale = 0;
                body.linearVelocity = Vector2.zero;
            }
            else
                body.gravityScale = 3.5f;
                
                if (Input.GetKey(KeyCode.Space))
                jump();
        }
        else wjcooldown += Time.deltaTime;
        
    }
    private void jump()
    {
        if (zeminmi())
        {
            body.linearVelocity = new Vector2(body.linearVelocityX, ziplamahizi);
            animasyon.SetTrigger("jump");
        }
        else if (duvarmi() && !zeminmi())
        {
            if (horizontalInput == 0)
            {
                body.linearVelocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
                body.linearVelocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 12);

            wjcooldown = 0;
            
        }
        

    }
    void OnCollisionEnter2D(Collision2D collision)
    {

    }
    private bool zeminmi()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundlayer);
        return raycastHit.collider != null;
    }
    private bool duvarmi()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size,0, new Vector2(transform.localScale.x,0),0.1f,duvarlayer);
        return raycastHit.collider != null;
    }
}
