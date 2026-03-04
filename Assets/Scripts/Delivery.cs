using UnityEngine;

public class Delivery : MonoBehaviour //make new scripts for different functionalities
{
    bool hasPackage; //bool has a default value of false
    [SerializeField] float destroyDelay = 1f;
    //If tag is package
    //then write to console
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Package") && !hasPackage)
        {
            Debug.Log("Package collected");
            hasPackage = true;
            GetComponent<ParticleSystem>().Play();

            //removes the game object once its collected
            Destroy(collision.gameObject, destroyDelay);
        }
        
        if(collision.CompareTag("Customer") && hasPackage) //automatically asks if 'true'
        {
            Debug.Log("Package delivered");
            hasPackage = false;
            GetComponent<ParticleSystem>().Stop();

            Destroy(collision.gameObject);
        }
    }
}
//can use void Start(){} to check for values immediatly after run is pressed - debugging mechanism