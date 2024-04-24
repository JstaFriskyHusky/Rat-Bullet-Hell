using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        int currentEnemy = 0;
        while (currentEnemy < enemyCount)
        {
            xPos = Random.Range(1, 5);
            zPos = Random.Range(1, 5);
            Instantiate(theEnemy, new Vector3(xPos, 3, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
            currentEnemy += 1;
        }
    }
}
