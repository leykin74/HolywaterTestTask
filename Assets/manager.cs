using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour
{
    public GameObject loading;

    public void openMenu()
    {
        loading.SetActive(true);
        SceneManager.LoadScene("Scene1");
    }
}
