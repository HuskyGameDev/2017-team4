using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public SceneTransition sceneTransition;
    // image to cover screen during transition
    public Image fade;
    // value at which fade with increment
    private float fadeAmount;
    // time (seconds) between each increment
    private float fadeDelay;

    // Use this for initialization
    void Start()
    {
        fadeAmount = 0.25F / 20.0F;
        fadeDelay = 1.0F / 20.0F;
    }

    /// <summary>
    /// Transitions when the song ends.
    /// </summary>
    public void EndSong()
    {
        InvokeRepeating("FadeToResults", 2.9F, fadeDelay);
    }

    /// <summary>
    /// Increases the opacitiy of the fade image.
    /// </summary>
    private void FadeToResults()
    {
        // transition once fade is completed
        if (fade.color.a == 1.0F)
            sceneTransition.LoadScene(6);
        var fadeColor = fade.color;
        fadeColor.a = Mathf.Clamp(fadeColor.a + fadeAmount, 0.0F, 1.0F);
        fade.color = fadeColor;
    }
}