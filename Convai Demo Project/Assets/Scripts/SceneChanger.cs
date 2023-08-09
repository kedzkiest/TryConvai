using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string mainSceneName;

    // Update is called once per frame
    private void Update()
    {
        // Scene reload function in case we need to reload the system due to unexpeted bugs, etc..
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("Opening");
        }
    }

    /// <summary>
    /// Scene transition Opening -> Main
    /// </summary>
    public void GoToMain()
    {
        SceneManager.LoadScene(mainSceneName);
    }
}
