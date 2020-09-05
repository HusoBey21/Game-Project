using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanAtesi : MonoBehaviour
{
     Transform hedef;
    public float surat = 70f;
    public int hasar = 10;
    public float patlamaYaricapi = 0f; //Patlama yarıçapı belirlendi
    public GameObject patlamaEtkisi; //Burada patlama etkisi oluşturacağız.
    public float yakinlik;
    public float fuzeZamani = 10f;
    DusmanDurumu dusman;
    void Start()
    {
        patlamaEtkisi = new GameObject("patlama", typeof(Rigidbody), typeof(BoxCollider), typeof(MeshRenderer));
        hedef=GameObject.FindGameObjectWithTag("enemy").transform;
        dusman = hedef.gameObject.GetComponent<DusmanDurumu>();

    }
    void Update()
    {
        if(hedef==null)
        {
            Destroy(gameObject); //Hedefi bulamaması durumunda füze kendini yok edecek.
            return; //void döndürür.

        }
        Vector3 yon = hedef.position - transform.position; //Bu hedef ile füze arasında vektörel bir fark oluşmasını sağlar.
        float buCercevedekiUzaklik = surat * Time.deltaTime; //Uzaklık zamana göre değişim içinde olacak.
        if(yon.magnitude<=buCercevedekiUzaklik+yakinlik)
        {
            HedefVur();
            return;
        }
        if(fuzeZamani<=0)
        {
            HedefVur();

        }
        fuzeZamani -= Time.deltaTime; //Geri sayım gibi düşünülebilir.

    }
    void HedefVur()
    {
        GameObject etkiOlusumu = Instantiate(patlamaEtkisi, patlamaEtkisi.transform.position, patlamaEtkisi.transform.rotation) as GameObject;
        Destroy(etkiOlusumu, 5); //5 saniye içinde yok edilecek.
        if(patlamaYaricapi>0f)
        {
            Patlat();
        }
        Destroy(gameObject); //Oyun nesnesini de yok etmiş oluyoruz.

    }
    private void OnCollisionEnter(Collision carpisma)
    {
        HedefVur();
    }
    public void Patlat()
    {
        Collider[] carpisanlar = Physics.OverlapSphere(transform.position, patlamaYaricapi);//Küresel hareketten ötürü
        foreach(Collider carpisan in carpisanlar)
        {
            if(carpisan.tag=="enemy")
            {
                dusman.AlinanHasar(hasar);
            }
        }

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, patlamaYaricapi);
    }

  
}
