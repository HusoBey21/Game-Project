using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Animation))]
public class Dusman : MonoBehaviour
{
   public Transform oyuncu;
    Animator anim;
    Rigidbody myRigidBody;
    Vector3 hareketYonu;
    void Start()
    {
        if(oyuncu==null)
        {
            Debug.LogError("Oyuncuya henüz bir şey atanmadı", this);
        }
        anim = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody>();
        oyuncu = GetComponent<Transform>();
    }
    void Update()
    {
        hareketYonu = Vector3.zero;
        if(Vector3.Distance(oyuncu.position,this.transform.position)<5)
        {
            Vector3 yon = oyuncu.position - this.transform.position;
            yon.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(yon), 0.1f);
            anim.SetBool("IsIdle", false);
            if(yon.magnitude > .8)
            {
                hareketYonu = yon.normalized;
                anim.SetBool("IsWalking", true);
                anim.SetBool("IsStriking", false);


            }
            else
            {
                anim.SetBool("IsStriking", true);
                anim.SetBool("IsWalking", false);
            }
            

        }
        else
        {
            anim.SetBool("IsIdle", true);
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsStriking", false);
        }

        void SabitlenmisGuncelleme()
        {
            myRigidBody.AddForce(hareketYonu * 50f);
        }
    }
}
