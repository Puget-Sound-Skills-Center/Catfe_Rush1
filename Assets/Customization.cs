using UnityEngine;
using UnityEngine.SceneManagement;

public class Customization : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(3);
    }
}
