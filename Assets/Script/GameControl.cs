using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour
{
    private GameModel model;
    public GameView view;

    void Start()
    {
        model = new GameModel();
        view.UpdateCoinCount(model.CoinCount, model.challengeTarget);
        GenerateNextObject();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (model.IsBombActive)
            {
                view.ShowGameOver();
                model.ResetGame();
                view.UpdateCoinCount(model.CoinCount, model.challengeTarget);
            }
            else
            {
                model.AddCoin();
                view.UpdateCoinCount(model.CoinCount, model.challengeTarget);

                if (model.ChallengeCompleted)
                {
                    view.ShowReward();
                }
            }

            GenerateNextObject();
        }
    }

    void GenerateNextObject()
    {
        model.GenerateNextObject();
        view.UpdateObjectDisplay(model.IsBombActive);
    }
}
