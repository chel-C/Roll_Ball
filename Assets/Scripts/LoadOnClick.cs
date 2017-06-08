using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOnClick : MonoBehaviour {

    public GameObject LoadingImage;

    public void LoadScene(int level)
    {
        LoadingImage.SetActive(true);
        Application.LoadLevel(level);
    }
}
