using UnityEngine;

public class Snake_WeakSpot : MonoBehaviour
{
    public Rigidbody2D playerRigidbody;
    public GameObject objectToDestroy;
    public GameObject player;
    public AudioClip killSound;

    private void Awake()
    {
        playerRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(killSound, transform.position);
            BumpPlayer();
            Destroy(objectToDestroy);
        }
    }

    public void BumpPlayer()
    {
        playerRigidbody.AddForce(new Vector2(0f, 900));
    }
}
