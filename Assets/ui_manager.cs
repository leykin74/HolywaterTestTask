using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_manager : MonoBehaviour
{
    public GameObject settings_go;
    public GameObject main_go;
    public RectTransform _canvas;
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

    public bool musicOn = true;
    public bool soundOn = true;

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
        buttonClickPlaySound();
        switchMusic(false);
        startTime = Time.time;
        mainPosition = new Vector2(-_canvas.rect.width, 0f);
        settingsPosition = new Vector2(midlePosition, 0f);
        menuButtonsOnOff(false);
    }

    public void open_menu()
    {
        buttonClickPlaySound();
        switchMusic(true);
        startTime = Time.time;
        mainPosition = new Vector2(midlePosition, 0f);
        settingsPosition = new Vector2(_canvas.rect.width, 0f);
        menuButtonsOnOff(true);
    }

    private void menuButtonsOnOff(bool onOff)
    {
        foreach (var item in getAllButtons.Buttons)
        {
            item.interactable = onOff;
        }
    }

    private void switchMusic(bool onOff)
    {
        if (musicOn) {
            if (onOff)
            {
                mainMusic.Play();
                settingsMusic.Stop();
            }
            else
            {
                mainMusic.Stop();
                settingsMusic.Play();
            }
        } else {
            stopMusic();
        }
    }

    private void buttonClickPlaySound()
    {
        if (soundOn) buttonClick.Play();
    }

    public void onSFXChange(bool onOff)
    {
        soundOn = !soundOn;
    }

    public void onMusicChange(bool onOff)
    {
        musicOn = !musicOn;
        switchMusic(false);
    }

    private void stopMusic() {
        mainMusic.Stop();
        settingsMusic.Stop();
    }

    public void playBtnClicked() {
        buttonClickPlaySound();
        menuButtonsOnOff(false);
        stopMusic();

        foreach (var _animator in getAllButtons.Animators)
        {
            _animator.SetBool("fadeOut", true);
        }
    }
}
