using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getAllButtons : MonoBehaviour
{
    public Button[] Buttons;
    // Start is called before the first frame update
    void Start()
    {
        Buttons = GetComponentsInChildren<Button>();
    }
}
