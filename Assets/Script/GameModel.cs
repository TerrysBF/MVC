using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel
{
    private int coinCount;
    public int challengeTarget { get; private set; } = 5; // Desafío: recolectar 5 monedas
    public int CoinCount => coinCount; // Propiedad de solo lectura
    public bool ChallengeCompleted => coinCount >= challengeTarget; // Se calcula dinámicamente

    private float lastCoinTime = 0f;
    private int comboCount = 0;
    private const float comboWindow = 2f; // Tiempo límite para mantener el combo (2 segundos)
    public bool IsBombActive { get; private set; } = false;

    public void AddCoin()
    {
        if (IsBombActive) return; // Evita sumar monedas si hay una bomba

        int coinValue = 1; // Moneda normal = 1

        // Verifica si la recolección ocurre dentro del tiempo del combo
        if (Time.time - lastCoinTime <= comboWindow)
        {
            comboCount++;
            if (comboCount >= 3)
            {
                coinValue++; // Bonus de combo: +1 moneda extra si recolecta 3 seguidas
            }
        }
        else
        {
            comboCount = 0; // Reinicia el combo si el tiempo se agota
        }

        lastCoinTime = Time.time;

        if (!ChallengeCompleted)
        {
            coinCount += coinValue;
        }
    }

    public void ResetGame()
    {
        coinCount = 0;
        comboCount = 0;
        lastCoinTime = 0f;
    }

    public void GenerateNextObject()
    {
        IsBombActive = Random.value < 0.3f; // 30% de probabilidad de que sea una bomba
    }
}