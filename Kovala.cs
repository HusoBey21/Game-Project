using UnityEngine;
using UnityEngine.UI;
public class Kovala : MonoBehaviour
{
    public Transform oyuncu;
    int hareketSurati = 4;
    int enBuyukMesafe = 6;
    int enKucukMesafe = 2;
    public bool canli;
    public GameObject robotPrefab;
    private GameObject MachineGunRobot;
    void Start()
    {
        oyuncu = GameObject.FindGameObjectWithTag("Player").transform; //Etiketi player olan her oyun nesnesini kovalamakta kararlıyız.
        canli = true;
        robotPrefab = new GameObject("yenisi", typeof(Rigidbody), typeof(BoxCollider)); //Bu da yeni ipsiz sapsız bir nesne oluşturuyor.
    }
    void Update()
    {
        if(oyuncu==null)
        {                            //Burada oyuncuya herhangi bir değer atanmadığında onun boş olup olmadığını denetleme durumudur.
            return;
        }
        if (oyuncu != null)
        {
            transform.LookAt(oyuncu);
            if (Vector3.Distance(transform.position, oyuncu.position) >= enKucukMesafe)
            {
                transform.position += transform.forward * hareketSurati * Time.deltaTime;
            }
            if (Vector3.Distance(transform.position, oyuncu.position) <= enBuyukMesafe)
            {
                Ray isin = new Ray(transform.position, transform.forward);
                RaycastHit vurus;
                if (Physics.SphereCast(isin, 0.75f, out vurus))
                {
                    GameObject nesneyeVurus = vurus.transform.gameObject;
                    if (nesneyeVurus.GetComponent<OyuncuBilgisi>())
                    {
                        
                            MachineGunRobot = Instantiate(robotPrefab) as GameObject;
                            MachineGunRobot.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                            MachineGunRobot.transform.rotation = transform.rotation;
                        
                    }
                }
            }
        }
    }
    void SetCanli(bool canli)
    {
        this.canli = canli;
    }

    
}
