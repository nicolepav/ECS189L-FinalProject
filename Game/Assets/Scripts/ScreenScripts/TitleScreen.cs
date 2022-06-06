using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public void StartGame()
    {
        SoundManager.Instance.PlaySoundEffect("Menu Select");
        GameManager.Instance.UpdateState(GameState.PrologueState);
    }
}
