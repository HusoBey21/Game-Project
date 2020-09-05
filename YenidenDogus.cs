using UnityEngine;

public class YenidenDogus : MonoBehaviour
{
    [SerializeField]
    private Transform oyuncu;
    [SerializeField] private Transform yenidenDogusNoktasi;
    void OnTriggerEnter(Collider diger)
    {
        oyuncu.transform.position = yenidenDogusNoktasi.transform.position;
    }
}
