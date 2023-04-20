using UnityEngine.SceneManagement;
using UnityEngine;

public class Button_PlayAgain : MonoBehaviour
{
    public void ChangeToScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
