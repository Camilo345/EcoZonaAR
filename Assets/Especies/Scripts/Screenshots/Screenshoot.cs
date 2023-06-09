using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class Screenshoot : MonoBehaviour
{
    public Image PhotoImage;
    public RawImage PhotoRawImage;
    public Image mascara;
    public GameObject panel;
    public List<GameObject> UI;
    public GameObject marco;
    public enviarEmail email;
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
        //texture = CalculateTexture(rt.height, rt.width, rt.height / 2, rt.height / 2, rt.width / 2, texture);

        Graphics.Blit(texture, rt);
        //mascara.rectTransform.sizeDelta = new Vector2(rt.width * 1.25f, rt.height * 1.25f);
        // PhotoImage.uvRect = new Rect(0,152, rt.width, rt.height);
        PhotoImage.rectTransform.sizeDelta = new Vector2(rt.width*1.5f, rt.height*1.5f);
        PhotoRawImage.rectTransform.sizeDelta = new Vector2(rt.width * 1.25f, rt.height * 1.25f);
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(texture.width / 2, texture.height / 2));
        PhotoImage.GetComponent<Image>().overrideSprite = sprite;
        PhotoRawImage.texture = rt;

        string filePath = Path.Combine(Application.temporaryCachePath, "shared.png");
        File.WriteAllBytes(filePath, texture.EncodeToPNG());


        email.enviarCorreo(filePath);
        panel.SetActive(true);
       
        string name = "ScreenShoot_AR" + System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")+".png";
        // string filePath = Path.Combine(GetAndroidExternalStoragePath(), name);
        //  File.WriteAllBytes(filePath, texture.EncodeToPNG());
        NativeGallery.SaveImageToGallery(texture, "Fotos Animales Ecopetrol", name);
      //  Destroy(texture);
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

    public void compartirRedes()
    {
        StartCoroutine(TakeScreenshotAndShare());
    }

    private IEnumerator TakeScreenshotAndShare()
    {
        yield return new WaitForEndOfFrame();
          Texture2D texture =TextureToTexture2D(PhotoRawImage.texture);
        //Texture2D texture = textureFromSprite(PhotoImage.sprite);

        string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        File.WriteAllBytes(filePath, texture.EncodeToPNG());
        Debug.Log(texture);
        // To avoid memory leaks
        Destroy(texture);

        new NativeShare().AddFile(filePath)
            .SetSubject("Subject goes here").SetText("Recuerdo de la visita a ZonaEco").Share();

        // Share on WhatsApp only, if installed (Android only)
        //if( NativeShare.TargetExists( "com.whatsapp" ) )
        //	new NativeShare().AddFile( filePath ).AddTarget( "com.whatsapp" ).Share();
    }
    private Texture2D TextureToTexture2D(Texture texture)
    {
        Texture2D texture2D = new Texture2D(texture.width, texture.height, TextureFormat.RGBA32, false);
        RenderTexture currentRT = RenderTexture.active;
        RenderTexture renderTexture = RenderTexture.GetTemporary(texture.width, texture.height, 32);
        Graphics.Blit(texture, renderTexture);

        RenderTexture.active = renderTexture;
        texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture2D.Apply();

        RenderTexture.active = currentRT;
        RenderTexture.ReleaseTemporary(renderTexture);
        return texture2D;
    }

    public static Texture2D textureFromSprite(Sprite sprite)
    {
        if (sprite.rect.width != sprite.texture.width)
        {
            Texture2D newText = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
            Color[] newColors = sprite.texture.GetPixels((int)sprite.textureRect.x,
                                                         (int)sprite.textureRect.y,
                                                         (int)sprite.textureRect.width,
                                                         (int)sprite.textureRect.height);
            newText.SetPixels(newColors);
            newText.Apply();
            return newText;
        }
        else
            return sprite.texture;
    }

    Texture2D CalculateTexture(int h, int w, float r, float cx, float cy, Texture2D sourceTex)
    {
        Color[] c = sourceTex.GetPixels(0, 0, sourceTex.width, sourceTex.height);
        Texture2D b = new Texture2D(h, w);
        for (int i = 0; i < (h * w); i++)
        {
            int y = Mathf.FloorToInt(((float)i) / ((float)w));
            int x = Mathf.FloorToInt(((float)i - ((float)(y * w))));
            if (r * r >= (x - cx) * (x - cx) + (y - cy) * (y - cy))
            {
                b.SetPixel(x, y, c[i]);
            }
            else
            {
                b.SetPixel(x, y, Color.clear);
            }
        }
        b.Apply();
        return b;
    }

    public void closePanel()
    {
        Debug.Log("d");
        panel.SetActive(false);
        DesactivateUI(true);
    }
}
