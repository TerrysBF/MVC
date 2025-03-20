using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    public TMP_Text coinText;
    public TMP_Text rewardText;
    public TMP_Text messageText;
    public GameObject coinImage;
    public GameObject bombImage;

    // Actualiza el texto con la cantidad de monedas recolectadas y el objetivo
    public void UpdateCoinCount(int count, int target)
    {
        coinText.text = "Monedas: " + count + " / " + target;
    }

    // Muestra la recompensa cuando se completa el desaf�o
    public void ShowReward()
    {
        rewardText.text = "�Desaf�o completado! Recompensa desbloqueada: �Premio Especial!";
    }

    // Muestra mensaje de Game Over
    public void ShowGameOver()
    {
        messageText.text = "�Perdiste! Presionaste espacio en una bomba.";
    }

    // Actualiza la visualizaci�n de la moneda o bomba en pantalla
    public void UpdateObjectDisplay(bool isBomb)
    {
        coinImage.SetActive(!isBomb);
        bombImage.SetActive(isBomb);
        messageText.text = isBomb ? "�Cuidado! �Presionar�s espacio?" : "�Presiona espacio para recoger!";
    }
}