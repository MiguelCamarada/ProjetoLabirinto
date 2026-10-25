using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public enum ItemType
    {
        Fuse,
        Wrench,
        Cable
    }

    public ItemType itemType;

    public void Collect(PlayerObjectives player)
{
    player.CollectItem(itemType);

    Destroy(gameObject);
  }
}