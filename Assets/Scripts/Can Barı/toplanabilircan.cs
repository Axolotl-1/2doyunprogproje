using UnityEngine;

public class toplanabilircan : MonoBehaviour
{
    [SerializeField] private float healthValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Can>().AddHealth(healthValue);
            gameObject.SetActive(false);
        }
    }
}