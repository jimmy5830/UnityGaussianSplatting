using System.Collections;
using UnityEngine;

public class AutoCapture : MonoBehaviour
{
    public string fileName = "C.png";
    public KeyCode captureKey = KeyCode.F12;

    void Update()
    {
        if (Input.GetKeyDown(captureKey))
        {
            StartCoroutine(Capture());
        }
    }

    IEnumerator Capture()
    {
        yield return new WaitForEndOfFrame();

        int width = Screen.width;
        int height = Screen.height;

        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
        tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        tex.Apply();

        byte[] bytes = tex.EncodeToPNG();
        System.IO.File.WriteAllBytes(Application.dataPath + "/../" + fileName, bytes);

        Debug.Log("Saved capture: " + fileName);
    }
}
