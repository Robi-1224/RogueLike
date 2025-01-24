using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RandomSpawns : MonoBehaviour
{

    [SerializeField] List<Transform> spawnPoints;
    [SerializeField] List<GameObject> items;

    // Start is called before the first frame update
    void Awake()
    {
        Randomize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Randomize()
    {
        var random = Random.Range(0, 7);
        var spawnRandom = Random.Range(0, spawnPoints.Count);
        var player = GameObject.FindGameObjectWithTag("Player");

        for (int i = 0; i < spawnRandom; i++)
        {
            for (int j = 0; j < random; j++)
            {
                var inst = Instantiate(items[j], new Vector3(spawnPoints[i].position.x + 3, spawnPoints[i].position.y, spawnPoints[i].position.z), Quaternion.identity);
                player.transform.position =  new Vector3(spawnPoints[i].position.x - 1, spawnPoints[i].position.y, spawnPoints[i].position.z);

                if (inst.gameObject.tag == "Enemy")
                {
                    inst.gameObject.GetComponent<PingPongMovement>().target = spawnPoints[i];
                 
                }
                else if (inst.gameObject.tag == "Coin")
                {
                    inst.transform.position = new Vector3(inst.transform.position.x, inst.transform.position.y + 1.3f, inst.transform.position.z);
                }


            }
        }
    }
}
