using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class screen : MonoBehaviour
{
    Texture2D screenCap;
    Texture2D border;
    bool shot = false;

    // Use this for initialization
    void Start()
    {
        screenCap = new Texture2D(300, 200, TextureFormat.RGB24, false); // 1
        border = new Texture2D(2, 2, TextureFormat.ARGB32, false); // 2
        border.Apply();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        { // 3
            StartCoroutine("Capture");
            //Capture();
        }
    }

    IEnumerator Capture()
    {
        yield return new WaitForEndOfFrame();
        screenCap.ReadPixels(new Rect(198, 98, 298, 198), 0, 0);
        screenCap.Apply();

        // Encode texture into PNG
        byte[] bytes = screenCap.EncodeToPNG();
        //Object.Destroy(screenCap);

        // For testing purposes, also write to a file in the project folder
        File.WriteAllBytes(Application.dataPath + "/SavedScreen.png", bytes);

        shot = true;
    }
}