using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    [SerializeField] private List<GameObject> ball_objects;
    [SerializeField] private List<Material> color_objects;
    [SerializeField] private int selected_material;
    [SerializeField] private Vector3 min_spawn_position;
    [SerializeField] private Vector3 max_spawn_position;
    [SerializeField] private bool is_stop;

    //Top tuþlarý bu fonksiyonu çalýþtýrýr
    //fakat number deðiþkeni hangi tuþa bastýðýnýza göre 0 ile 2 arasýnda deðiþir.
    public void Spawn_Ball(int number)
    {
        //Oyun durmadý ise
        if (!is_stop)
        {
            //Alan içinde bulunacak þekilde rastgele geçici koordinatlar oluþturur.
            Vector3 temp = new Vector3(Random.Range(min_spawn_position.x, max_spawn_position.x), Random.Range(min_spawn_position.y, max_spawn_position.y), Random.Range(min_spawn_position.z, max_spawn_position.z));
            
            //ball_objects listesinde bulunan prefablardan number indexinde bulunan nesneyi çeker ve
            //temp koordinatlarý ile boþ rotasyon ile uygulamada oluþturur.
            GameObject obj = Instantiate(ball_objects[number], temp, new Quaternion());

            //Oluþan top objesi altýnda bulunan ilk çocuk objesine eriþir ve
            //renk için color_objects listesinden selected_material numarasý ile renk ekler.
            obj.transform.GetChild(0).GetComponent<MeshRenderer>().material = color_objects[selected_material];
        }
    }


    //Renk tuþlarýna bu fonksiyonu çalýþtýrýr
    public void Select_Material(int number)
    {
        selected_material = number;
    }

    public void Start_Button()
    {
        //Oyun hýzý 0 ve oyun durmamýþ ise çalýþýr
        if (Time.timeScale == 0 && !is_stop)
        {
            //oyun hýzýný 1 yapar
            Time.timeScale = 1;
        }
    }

    public void Stop_Button()
    {
        //Oyunu durdurur
        if (Time.timeScale != 0)
        {
            is_stop = true;
            Time.timeScale = 0;
        }
    }

    public void Reset_Button()
    {
        //Oyun hýzýný 0 yapar
        Time.timeScale = 0;

        //Sahneyi baþtan yükler bu sayede resetlenir
        SceneManager.LoadScene("SampleScene",LoadSceneMode.Single);
    }

    public void Speed_Up_Button()
    {
        //Oyun hýzý 0 deðilse ve oyun durmamýþsa
        //Oyun hýzýz 100 den az ise oyun hýzýný 1.5 katýna çýkartýr.
        if (Time.timeScale != 0 && !is_stop)
        {
            if (Time.timeScale < 100)
            {
                if (Time.timeScale * 1.5f < 100)
                {
                    Time.timeScale = Time.timeScale * 1.5f;
                }
                else
                {
                    Time.timeScale = 100;
                }
                Debug.Log(Time.timeScale);
            }
            else
            {
                Time.timeScale = 100;
            }
        }
    }

    void Start()
    {
        //Oyun baþladýðýnda hýzý 0 yapar
        Time.timeScale = 0;
    }
}
