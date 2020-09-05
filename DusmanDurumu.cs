using UnityEngine;

public class DusmanDurumu : MonoBehaviour
{
    public float anlikSaglikGucu=100f;
    public float enYuksekSaglikGucu = 100f;
    float hasar;
    void Start()
    {
        this.hasar = hasar;
    }
    void Update()
    {

        AlinanHasar(hasar);
    }
    public void AlinanHasar(float hasar)
    {

        anlikSaglikGucu -= hasar;
       if(anlikSaglikGucu<=0f)
        {
            Destroy(gameObject);
        }
       
    }
    public void OnCollisionEnter(Collision carpisma)
    {
        if(carpisma.gameObject.tag=="füze")
        {
            AlinanHasar(10f); //Her füze isabet ettiğinde alınan hasar 10 olacaktır.
        }
    }
   

}
