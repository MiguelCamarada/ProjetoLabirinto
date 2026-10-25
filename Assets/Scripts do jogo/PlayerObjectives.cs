using TMPro;
using UnityEngine;

public class PlayerObjectives : MonoBehaviour
{
    public int collectedItems = 0;
    public int totalItems = 3;
    public bool fuseCollected;
    public bool wrenchCollected;
    public bool cableCollected;

    public TextMeshProUGUI objectiveText;
    public TextMeshProUGUI pickupText;

    public bool HasAllItems()
    {
        return collectedItems >= totalItems;
    }

    public void CollectItem(CollectibleItem.ItemType itemType)
{
    collectedItems++;

    switch(itemType)
    {
        case CollectibleItem.ItemType.Fuse:
            fuseCollected = true;
            pickupText.text = "Fusível coletado!";
            break;

        case CollectibleItem.ItemType.Wrench:
            wrenchCollected = true;
            pickupText.text = "Ferramenta coletada!";
            break;

        case CollectibleItem.ItemType.Cable:
            cableCollected = true;
            pickupText.text = "Cabos coletados!";
            break;
    }

    Invoke(nameof(ClearPickupMessage), 2f);

    UpdateObjectives();
}

    void ClearPickupMessage()
    {
        pickupText.text = "";
    }

    void Start()
    {
        UpdateObjectives();
    }

    void UpdateObjectives()
{
    objectiveText.text =
        "Objetivos\n\n" +

        (fuseCollected ?
        "[X] Fusível\n" :
        "[ ] Fusível\n") +

        (wrenchCollected ?
        "[X] Ferramenta\n" :
        "[ ] Ferramenta\n") +

        (cableCollected ?
        "[X] Cabos" :
        "[ ] Cabos");
}
}