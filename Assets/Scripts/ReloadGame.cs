using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadGame : MonoBehaviour
{
   // public float gameRestartDelay = 2f;
    public void DelayedRestart(float delay)
    {
        Invoke(nameof(Restart), delay);
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
