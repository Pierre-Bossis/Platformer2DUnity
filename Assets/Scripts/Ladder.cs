using TMPro;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private bool isInRange;
    private PlayerMovement playerMovement;
    private GameObject player;
    public BoxCollider2D topCollider;
    private TextMeshProUGUI interactUI;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if(isInRange && playerMovement.isClimbing && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.isClimbing = false;
            topCollider.isTrigger = false;
            interactUI.color = Color.white;
            return;
        }

        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            interactUI.color = Color.green;
            playerMovement.isClimbing = true;
            topCollider.isTrigger = true;
            player.transform.position = new Vector3(transform.position.x, player.transform.position.y, player.transform.position.z);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            playerMovement.isClimbing = false;
            topCollider.isTrigger = false;
            interactUI.enabled = false;
            interactUI.color = Color.white;
        }
    }
}
