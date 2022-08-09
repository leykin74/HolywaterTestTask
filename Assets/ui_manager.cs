using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui_manager : MonoBehaviour
{
    public RectTransform settings;
    public RectTransform main;

    public Vector2 mainPosition = new Vector2(0, 0);
    public Vector2 settingsPosition = new Vector2(925f, 0f);
    public float movedPosition = 925f;
    public float midlePosition = 0f;

    // Time taken for the transition.
    public float duration = 50f;

    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = (Time.time - startTime) / duration;
        // setLeft(main, Mathf.SmoothStep(main.offsetMin.x, mainPosition, t));
        // Debug.Log(Mathf.SmoothStep(settings.offsetMin.x, settingsPosition, t));
        // setLeft(settings, Mathf.SmoothStep(settings.offsetMin.x, settingsPosition, t));



        settings.offsetMax = settings.offsetMin = Vector2.Lerp(settings.offsetMin, settingsPosition, t);
        main.offsetMax = main.offsetMin = Vector2.Lerp(main.offsetMin, mainPosition, t);
        // settings.offsetMax = new Vector2(Mathf.SmoothStep(settings.offsetMin.x, settingsPosition, t), settings.offsetMax.y);
    }

    public void open_settings()
    {

        mainPosition = new Vector2(-movedPosition, 0f);
        settingsPosition = new Vector2(midlePosition, 0f);

        Debug.Log("open settings " + Screen.width);
    }

    private void setLeft(RectTransform obj, float left)
    {
        obj.offsetMin = new Vector2(left, 0);
        obj.offsetMax = new Vector2(left, 0);
    }
}
