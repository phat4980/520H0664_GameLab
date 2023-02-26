using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float xMinMax;
    public float zMin;
    public GameObject rock;
    public int count;
    public float StartWait;
    public float cloneWait;
    public float waveWait;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Waves());
    }

    // Update is called once per frame
    IEnumerator Waves() 
    {
        while(true)
        {
            yield return new WaitForSeconds(StartWait);
            for(int i = 0; i < count; i++)
            {
                Instantiate(rock, new Vector3(Random.Range(-xMinMax, xMinMax), 0, zMin), Quaternion.identity);
                yield return new WaitForSeconds(cloneWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
