using UnityEngine;

public class Boşluk : MonoBehaviour
{
[SerializeField] private float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Can>().TakeDamage(damage);
        }
    }
}