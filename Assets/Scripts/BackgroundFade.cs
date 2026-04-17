using UnityEngine;
using System.Collections;

public class BackgroundFade : MonoBehaviour
{
    public Sprite[] backgrounds;

    public Sprite[] foregrounds;
    public SpriteRenderer fg1;
    public SpriteRenderer fg2;

    public float changeTime = 15f;
    public float fadeDuration = 2f;

    private SpriteRenderer sr;
    private int currentIndex = 0;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        // Start with whatever sprite you assigned in Unity (Sky)
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

        // INDEX LOGIC (IMPORTANT PART)
        if (currentIndex == 0)
        {
            currentIndex = 1; // Sky → first zone
        }
        else
        {
            currentIndex++;

            if (currentIndex >= backgrounds.Length)
            {
                currentIndex = 1; // loop zones, skip sky
            }
        }

        // APPLY NEW SPRITES
        sr.sprite = backgrounds[currentIndex];

        fg1.sprite = foregrounds[currentIndex];
        fg2.sprite = foregrounds[currentIndex];

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