public class egrilik : MonoBehaviour

{
   


    // Start is called before the first frame update
    void Start()
    {
        
    }


    void FareSurtunmesi()
    {
        Vector3 konum = Vector3.zero;
        konum.y = Mathf.Clamp(transform.position.y, 0.0f, 6.0f);
        transform.position = Camera.main.ScreenToWorldPoint(konum);
    }
}
