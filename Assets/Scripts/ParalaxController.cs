using UnityEngine;

public class ParalaxController : MonoBehaviour
{
    [SerializeField] private Transform[] layers;
    [SerializeField] private float[] coeff;
    private int countLayers;
    void Start()
    {
        countLayers = layers.Length;
    }

    void Update()
    {
        for (int i = 0; i < countLayers; i++)
        {
            layers[i].position = transform.position*coeff[i];
        }
    }
}
