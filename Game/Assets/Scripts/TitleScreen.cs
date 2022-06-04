using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.UpdateState(GameState.PlayState);
    }
}
