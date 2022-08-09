using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui_manager : MonoBehaviour
{
    public RectTransform settings;
    public RectTransform main;
    public RectTransform _canvas;

    private Vector2 mainPosition = new Vector2(0, 0);
    private Vector2 settingsPosition;
    private float movedPosition = 925f;
    public float midlePosition = 0f;

    // Time taken for the transition.
    public float duration = 50f;

    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        settings.offsetMax = settings.offsetMin = new Vector2(_canvas.rect.width, 0f);
        settingsPosition = new Vector2(_canvas.rect.width, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        float t = (Time.time - startTime) / duration;

        settings.offsetMax = settings.offsetMin = Vector2.Lerp(settings.offsetMin, settingsPosition, t);
        main.offsetMax = main.offsetMin = Vector2.Lerp(main.offsetMin, mainPosition, t);
    }

    public void open_settings()
    {
        startTime = Time.time;
        mainPosition = new Vector2(-_canvas.rect.width, 0f);
        settingsPosition = new Vector2(midlePosition, 0f);
    }

    public void open_menu()
    {
        startTime = Time.time;
        mainPosition = new Vector2(midlePosition, 0f);
        settingsPosition = new Vector2(_canvas.rect.width, 0f);
    }
}
