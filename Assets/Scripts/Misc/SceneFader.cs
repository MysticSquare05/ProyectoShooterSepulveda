using System.Collections;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    public float fadeDuration = 1.0f;

    public bool fadeIn = false;

    private void Start()
    {
        if (fadeIn)
        {
            FadeIn();
        }
        else
        {
            FadeOut();
        }
    }

    public void FadeIn()
    {
        StartCoroutine(FadeCanvasGroup(canvasGroup, canvasGroup.alpha, 0, fadeDuration));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeCanvasGroup(canvasGroup, canvasGroup.alpha, 1, fadeDuration));
    }

    private IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float duration)
    {
        float elapsedTime = 0.0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            cg.alpha = Mathf.Lerp(start, end, elapsedTime / duration);
            yield return null;
        }
        cg.alpha = end;
    }


}
