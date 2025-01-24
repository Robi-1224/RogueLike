using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawns : MonoBehaviour
{

    [SerializeField] List<Transform> spawnPoints;
    [SerializeField] List<GameObject> items;

    // Start is called before the first frame update
    void Awake()
    {
        var random= Random.Range(2,10);
        var spawnRandom = Random.Range(0,spawnPoints.Count);
        for (int i = 0; i < spawnRandom; i++)
        {
            for (int j = 0; j < random; j++)
            {
                var inst = Instantiate(items[j], spawnPoints[i].transform.position, Quaternion.identity);

                if (inst.gameObject.tag == "Enemy")
                {
                    inst.gameObject.GetComponent<PingPongMovement>().target = spawnPoints[i];
                    Debug.Log("Aids");
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
