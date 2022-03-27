using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    public Camera cam;
    public GameObject[] blockPrefab;
    public float spawnPoint=5f;
    public float safeMargin;
    void Start()
    {
        player=GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Camera following the player
        if (player != null)
        {
            cam.transform.position = new Vector3(player.transform.position.x, cam.transform.position.y, cam.transform.position.z);
        }
        // Spawing Random blocks
        while (spawnPoint < player.transform.position.x + safeMargin && player!=null)
        {
            int k = Random.Range(0, 5);
            if (spawnPoint <= 5f)
            {
                k = 0;
            }
            GameObject currentBlock = Instantiate(blockPrefab[k]);
            PlatformController platform = currentBlock.GetComponent<PlatformController>();
            currentBlock.transform.position = new Vector3(platform.platformSize / 2 + spawnPoint, 0f, 0f);
            spawnPoint = spawnPoint + platform.platformSize;
        }
    }
}
