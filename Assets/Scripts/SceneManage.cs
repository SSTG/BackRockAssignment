using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
   public void SceneChange(int x)
   {
    SceneManager.LoadScene(x);
   }
   public void Quit()
   {
    Application.Quit();
   }
}
