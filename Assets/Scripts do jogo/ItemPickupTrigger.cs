using UnityEngine;

public class ItemPickupTrigger : MonoBehaviour
{
    public GameObject interactionText;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {   
            Debug.Log("Player entrou no trigger");
            interactionText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            interactionText.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                CollectibleItem item =
                    GetComponent<CollectibleItem>();

                PlayerObjectives player =
                    other.GetComponent<PlayerObjectives>();

                item.Collect(player);

                interactionText.SetActive(false);
            }
        }
    }
}