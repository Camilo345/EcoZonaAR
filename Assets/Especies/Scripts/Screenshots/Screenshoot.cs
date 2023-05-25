using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Screenshoot : MonoBehaviour
{
    public RawImage PhotoImage;
    public GameObject panel;
    public List<GameObject> UI;
    public GameObject marco;

    private Texture2D texturaScreen;
    // Start is called before the first frame update
    void Start()
    {
        marco.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeScreenShoot()
    {
        // ScreenCapture.CaptureScreenshot("My_Screen.jpg");
        
        StartCoroutine(ScreenShoot());
    }

    IEnumerator ScreenShoot()
    {
        marco.SetActive(true);
        DesactivateUI(false);
        yield return new WaitForEndOfFrame();
       
        //Texture2D textureMarco = tomarCaptura();
      
        Texture2D texture = tomarCaptura();
        marco.SetActive(false);
        RenderTexture rt = new RenderTexture(texture.width / 2, texture.height / 2, 0);
        RenderTexture.active = rt;
        Graphics.Blit(texture, rt);

        // PhotoImage.uvRect = new Rect(0,152, rt.width, rt.height);
        PhotoImage.rectTransform.sizeDelta = new Vector2(rt.width*1.25f, rt.height*1.25f);
        PhotoImage.texture = rt;
        panel.SetActive(true);
       
        string name = "ScreenShoot_AR" + System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")+".png";
        // string filePath = Path.Combine(GetAndroidExternalStoragePath(), name);
        //  File.WriteAllBytes(filePath, texture.EncodeToPNG());
      //  texturaScreen = texture;
        NativeGallery.SaveImageToGallery(texture, "Fotos Animales Ecopetrol", name);
        Debug.Log(name);
        Destroy(texture);
    }

    private Texture2D tomarCaptura()
    {
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        texture.Apply();
        return texture;
    }

    private void DesactivateUI(bool state)
    {
        for (int i = 0; i < UI.Count; i++)
        {
            UI[i].SetActive(state);
        }
    }
    private string GetAndroidExternalStoragePath()
    {
        var path="";
        if (Application.platform == RuntimePlatform.Android)
        {
            var jc = new AndroidJavaClass("android.os.Environment");
            path = jc.CallStatic<AndroidJavaObject>("getExternalStoragePublicDirectory",
                jc.GetStatic<string>("DIRECTORY_DCIM"))
                .Call<string>("getAbsolutePath");
        }
        else
        {
           path= Application.dataPath + "/Resources/save_screen/" + name + ".jpg";
        }
           

       
        return path;
    }

    public void closePanel()
    {
        panel.SetActive(false);
        DesactivateUI(true);
    }

}
