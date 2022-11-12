using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Canvas))]
public class RestartButton : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
