using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Top : MonoBehaviour
{

    //Deðiþkenler
    public float hiz = 5f;
    private Rigidbody rb;
    private Vector3 yon;

    void Start()
    {
        //Nesne içinde bulunan rigidbody componentine eriþip referans olarak ekliyor.
        rb = GetComponent<Rigidbody>();

        // Yerçekimi iptal:
        rb.useGravity = false;

        // Ýlk yönü rastgele belirleme
        yon = new Vector3(
            Random.value < 0.5f ? -1 : 1,
            Random.value < 0.5f ? -1 : 1,
            0
        ).normalized;

        rb.linearVelocity = yon * hiz;
    }

    void FixedUpdate()
    {
        // Hýz sabit kalsýn (zamanla yavaþlamasýn)
        rb.linearVelocity = rb.linearVelocity.normalized * hiz;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Normal vektöre göre sekme yönünü hesapla
        Vector3 normal = collision.contacts[0].normal;
        yon = Vector3.Reflect(yon, normal);

        // Yeni yönü uygula
        rb.linearVelocity = yon.normalized * hiz;
    }
}
