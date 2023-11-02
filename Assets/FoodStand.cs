using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodStand : MonoBehaviour
{
    public FruitID[] fruits;
    public List<Fruit> fruitList = new List<Fruit>();
    public int foodCount = 0;
    public GameObject spawnPoint;

    public int currentSpawnDelay = SecondsToFrames(5);
    int spawnDelay = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(foodCount < 5)
        {
            if(currentSpawnDelay <= 0)
            {
                SpawnFruit();
                currentSpawnDelay = spawnDelay;
            }
            else
            {
                currentSpawnDelay--;
            }
        }
    }

    void SpawnFruit()
    {
        int fruitIndex = Random.Range(0, fruits.Length);
        Vector3 pos = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z + (foodCount * 0.5f));
        GameObject fruitObject = Instantiate(GameManager.Instance.fruits[fruitIndex].prefab, pos, Quaternion.identity);

        //GameObject fruit = Instantiate(fruits[fruitIndex].fruitPrefab, spawnPoint.transform.position, Quaternion.identity);
        fruitObject.GetComponent<Fruit>().ID = fruits[fruitIndex];
        fruitList.Add(fruitObject.GetComponent<Fruit>());
        foodCount++;
    }

    static int SecondsToFrames(int seconds)
    {
        return seconds * 60;
    }
}
