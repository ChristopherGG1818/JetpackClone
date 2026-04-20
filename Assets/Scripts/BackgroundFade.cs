using UnityEngine;
using System.Collections;

public class BackgroundFade : MonoBehaviour
{
    public Sprite[] backgrounds;

    public float changeTime = 10f;
    public float fadeDuration = 2f;

    private SpriteRenderer sr;
    private int currentIndex = 0;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        // Start at sky (index 0)
        sr.sprite = backgrounds[0];

        StartCoroutine(ChangeRoutine());
    }

    IEnumerator ChangeRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(changeTime);
            yield return StartCoroutine(FadeToNext());
        }
    }

    IEnumerator FadeToNext()
    {
        float t = 0f;
        Color color = sr.color;

        // FADE OUT
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, t / fadeDuration);
            sr.color = color;
            yield return null;
        }

        // INDEX LOGIC (skip 0 after intro)
        if (currentIndex == 0)
        {
            currentIndex = 1;
        }
        else
        {
            currentIndex++;

            if (currentIndex >= backgrounds.Length)
            {
                currentIndex = 1; // loop 1+
            }
        }

        // CHANGE BACKGROUND
        sr.sprite = backgrounds[currentIndex];

        // FADE IN
        t = 0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, t / fadeDuration);
            sr.color = color;
            yield return null;
        }
    }
}