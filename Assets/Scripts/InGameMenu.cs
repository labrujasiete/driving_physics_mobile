using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void HotRestart()
    {
        SceneManager.LoadScene(0);
    }


}
