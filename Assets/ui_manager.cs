using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_manager : MonoBehaviour
{
    public GameObject settings_go;
    public GameObject main_go;
    public RectTransform _canvas;
    // public Button playBtn;
    // public Button settingsBtn;
    public RectTransform main;
    public RectTransform settings;

    public getAllButtons getAllButtons;

    private Vector2 mainPosition = new Vector2(0, 0);
    private Vector2 settingsPosition;
    public float midlePosition = 0f;

    // Time taken for the transition.
    public float duration = 50f;

    public AudioSource buttonClick;
    public AudioSource mainMusic;
    public AudioSource settingsMusic;

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
        buttonClick.Play();
        mainMusic.Stop();
        settingsMusic.Play();
        startTime = Time.time;
        mainPosition = new Vector2(-_canvas.rect.width, 0f);
        settingsPosition = new Vector2(midlePosition, 0f);
        menuButtonsOnOff(false);
    }

    public void open_menu()
    {
        buttonClick.Play();
        mainMusic.Play();
        settingsMusic.Stop();
        startTime = Time.time;
        mainPosition = new Vector2(midlePosition, 0f);
        settingsPosition = new Vector2(_canvas.rect.width, 0f);
        menuButtonsOnOff(true);
    }

    private void menuButtonsOnOff(bool onOff)
    {
        // playBtn.interactable = onOff;
        // settingsBtn.interactable = onOff;
        foreach (var item in getAllButtons.Buttons)
        {
            item.interactable = onOff;
        }
    }
}
