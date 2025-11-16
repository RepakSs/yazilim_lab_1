using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraAspectFix : MonoBehaviour
{
    public float targetWidth = 1080f;
    public float targetHeight = 1920f;

    void Start()
    {
        //Camera componentine eriþir.
        Camera cam = GetComponent<Camera>();

        //Ýstenilen oran
        float targetAspect = targetWidth / targetHeight;

        //Elimizde olan oran
        float windowAspect = (float)Screen.width / Screen.height;

        //Oranlarýn birbiri ile olan oraný
        float scaleHeight = windowAspect / targetAspect;

        //Ekranýn yanlarý mý yoksa üst/alt mý kesilecek kontrolu yapýlýyor.
        //Bu kontrol sonucu ekranýn o kýsmý siyahlandýrýlýyor.
        if (scaleHeight < 1.0f)
        {
            // Kenarlarda boþluk (pillarbox)
            Rect rect = cam.rect;
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
            cam.rect = rect;
        }
        else
        {
            // Üst/alt boþluk (letterbox)
            float scaleWidth = 1.0f / scaleHeight;
            Rect rect = cam.rect;
            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;
            cam.rect = rect;
        }
    }
}
