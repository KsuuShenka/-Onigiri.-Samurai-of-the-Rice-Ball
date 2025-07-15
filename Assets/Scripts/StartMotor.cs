using UnityEngine;

public class StartMotor : MonoBehaviour
{
    private SliderJoint2D platform;
    
    private void Start()
    {
        platform = GetComponent<SliderJoint2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            platform.useMotor = true;
        } 
    }  
}
