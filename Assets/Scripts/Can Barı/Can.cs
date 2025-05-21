using UnityEngine;
using System.Collections;

public class Can : MonoBehaviour
{
    [Header ("Can")]
    [SerializeField] private float BaslangicCani;
    public float currentHealth { get; private set; }
    private Animator animasyon;
    private bool dead;

    [Header("Görünmezlik")]
    [SerializeField] private float Gorunmezliksuresi;
    [SerializeField] private int sayisi;
    private SpriteRenderer spriteRend;

    private void Awake()
    {
        currentHealth = BaslangicCani;
        animasyon = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, BaslangicCani);

        if (currentHealth > 0)
        {
            animasyon.SetTrigger("hasar");
            StartCoroutine(Invunerability());
        }
        else
        {
            if (!dead)
            {
                animasyon.SetTrigger("ölüm");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
            }
        }
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, BaslangicCani);
    }
    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < sayisi; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(Gorunmezliksuresi / (sayisi * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(Gorunmezliksuresi / (sayisi * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }
}