using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private PlayerHealth PlayerHealth;
    public int damageTaken = 5;
    private Transform playerSpawn;


    private void Awake()
    {
        PlayerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth.takeDamage(damageTaken);
            collision.transform.position = playerSpawn.position;
        }
    }
}
