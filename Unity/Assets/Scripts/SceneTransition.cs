using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    /// <summary>
    /// Loads the scene.
    /// The scene indexes are as follows:
    ///     MainMenu    = 0
    ///     LevelSelect = 1
    ///     StatShop    = 2
    ///     Settings    = 3
    ///     QuitGame    = 4
    ///     Gameplay    = 5
    ///     Results     = 6
    /// </summary>
    /// <param name="scene_index">Scene index.</param>
    public void LoadScene (int scene_index)
    {
        SceneManager.LoadScene (scene_index);
    }

    /// <summary>
    /// Quits the game.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}