using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FareBakisi : MonoBehaviour
{
    Transform hedef;
   
    void Start()
    {
        hedef = GameObject.FindGameObjectWithTag("enemy").transform;
    }

    
    void Update()
    {

        Vector3 fare = Input.mousePosition; //Farenin oyun içerisindeki konumunu alır.
        Vector3 fareDunyasi = Camera.main.ScreenToWorldPoint(new Vector3(fare.x,fare.y, hedef.position.y));//Bu farenin kamerayı yönetebilmesi anlamına gelir.
        Vector3 ileri = (fareDunyasi - hedef.position);
        hedef.transform.rotation = Quaternion.LookRotation(ileri, Vector3.forward);//Bu dönüş değerini belirler.
    }
    

}
