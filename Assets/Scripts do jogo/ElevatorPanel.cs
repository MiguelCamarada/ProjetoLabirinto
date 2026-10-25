using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ElevatorPanel : MonoBehaviour
{
    public TextMeshProUGUI panelText;
    public TextMeshProUGUI objectiveText;
    public SpriteRenderer panelSpriteRenderer;

    public Sprite painelFechado;
    public Sprite painelPiscando1;
    public Sprite painelPiscando2;
    public Sprite painelAberto;

    public string nextSceneName = "Fase2";

    bool playerNear = false;

    PlayerObjectives playerObjectives;

private void OnTriggerEnter(Collider other)
{
    if(other.CompareTag("Player"))
    {
        playerNear = true;

        panelText.gameObject.SetActive(true);
      

        playerObjectives =
            other.GetComponent<PlayerObjectives>();

        if(playerObjectives.HasAllItems())
        {
            panelText.text =
                "Pressione E para reparar o elevador.";
        }
        else
        {
            panelText.text =
                "Elevador sem energia.\nPreciso encontrar os componentes.";
        }
    }
}

    private void OnTriggerExit(Collider other)
{
    if(other.CompareTag("Player"))
    {
        playerNear = false;

       
    }
}


void Update()
{
    if(playerNear && Input.GetKeyDown(KeyCode.E))
    {
        if(playerObjectives.HasAllItems())
        {
            StartCoroutine(RepairElevator());
        }
        else
      {
  panelText.text =
    "Ainda faltam componentes.";

    Invoke(nameof(RestoreObjectives), 2f);
    }
    }
}
void RestoreObjectives()
{
    panelText.text = objectiveText.text;

    Invoke(nameof(HidePanelText), 5f);
}

void HidePanelText()
{
    panelText.gameObject.SetActive(false);
}

IEnumerator RepairElevator()
{
    playerNear = false;

    panelText.text = "Consertando elevador...";

    // Pisca algumas vezes

    for(int i = 0; i < 4; i++)
    {
        panelSpriteRenderer.sprite = painelPiscando1;
        yield return new WaitForSeconds(0.2f);

        panelSpriteRenderer.sprite = painelPiscando2;
        yield return new WaitForSeconds(0.2f);
    }

    // Painel aberto

    panelSpriteRenderer.sprite = painelAberto;

   
    yield return new WaitForSeconds(2f);

    SceneManager.LoadScene(nextSceneName);
}

}