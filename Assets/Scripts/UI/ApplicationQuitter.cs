using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class ApplicationQuitter : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }
}
