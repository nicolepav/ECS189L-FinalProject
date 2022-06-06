using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public void StartGame()
    {
        FindObjectOfType<SoundManager>().PlaySoundEffect("Menu Select");
        GameManager.Instance.UpdateState(GameState.PrologueState);
    }
}
