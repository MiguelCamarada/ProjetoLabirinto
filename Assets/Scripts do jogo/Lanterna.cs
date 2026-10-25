using UnityEngine;

public class Lanterna : MonoBehaviour
{
    public GameObject luzLanterna;
    public KeyCode botaoAlternar = KeyCode.F;

    void Update()
    {
        if (Input.GetKeyDown(botaoAlternar))
        {
            luzLanterna.SetActive(!luzLanterna.activeSelf);
        }
    }
}