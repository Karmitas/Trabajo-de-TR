using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class RoundManager : MonoBehaviour
{

    [Header("Parameters")]
    public int currentRound;

    [Space]
    public int maxEnemiesAlive = 4;
    public int enemiesAlive;

    [Space]
    public float spawnCooldown = 5;

    [Header("Enemies spawn per round")]
    public List<int> totalEnemiesInRound;

    public List<int> enemy1Spawns;
    public List<int> enemy2Spawns;
    public List<int> enemy3Spawns;
    public List<int> enemy4Spawns;
    public List<int> enemy5Spawns;

    [Header("Spawn Points")]
    public List<GameObject> spawnPoints;

    [Header("Prefabs")]
    public List<GameObject> enemyTypes;

    public int spawnSelect = 0;
    private float sC;

    [Header("Scripts")]
    public ChestManagerSystem chests;
    public bool x;

    [Header("Win Settings")]
    public Material winSkybox;
    [Space]
    public Animator winAnimation;
    public float winAnimationDuration = 10f;
    [Space]
    public GameObject normalMusic;
    public GameObject winMusic;

    private Data data;
    private List<GameObject> chestsObj;
    private bool y;

    private int z;

    private bool a;
    private bool b;

    void Start()
    {
        sC = spawnCooldown;
        winMusic.SetActive(false);
        if (data == null)
        {
            data = GameObject.FindGameObjectWithTag("Data").GetComponent<Data>();
        }
        ArcadeMode();

        if (data == null)
        {
            b = false;
        }
        else
        {
            b = data.arcadeMode;
        }
    }

    void Update()
    {
        z = enemy1Spawns[currentRound] + enemy2Spawns[currentRound]
            + enemy3Spawns[currentRound] + enemy4Spawns[currentRound] + enemy5Spawns[currentRound];

        if (sC > 0)
        {
            sC -= Time.deltaTime;
        }

        if (enemiesAlive < maxEnemiesAlive && sC <= 0)
        {
            RoundSpawnerManager();
        }

        if (y)
        {
            GameEnded();
            return;
        }

        if (currentRound == totalEnemiesInRound.Count - 1 && enemiesAlive == 0 && !x && totalEnemiesInRound[currentRound] == 0 && z == 0 && !b)
        {
            GameEnded();
            return;
        }

        if (enemiesAlive == 0 && !x && totalEnemiesInRound[currentRound] == 0 && z == 0)
        {
            chests.EndedRound(); x = true;
        }
    }

    public void RoundSpawnerManager()
    {
        totalEnemiesInRound[currentRound] = z;

        if (enemy1Spawns[currentRound] >= 1)
        {
            SpawnEnemy(enemyTypes[0]);
            enemy1Spawns[currentRound]--;
        }
        else if (enemy2Spawns[currentRound] >= 1)
        {
            SpawnEnemy(enemyTypes[1]);
            enemy2Spawns[currentRound]--;
        }
        else if (enemy3Spawns[currentRound] >= 1)
        {
            SpawnEnemy(enemyTypes[2]);
            enemy3Spawns[currentRound]--;
        }
        else if (enemy4Spawns[currentRound] >= 1)
        {
            SpawnEnemy(enemyTypes[3]);
            enemy4Spawns[currentRound]--;
        }
        else if (enemy5Spawns[currentRound] >= 1)
        {
            SpawnEnemy(enemyTypes[4]);
            enemy5Spawns[currentRound]--;
        }

        if (spawnSelect == spawnPoints.Count) { spawnSelect = 0; }
    }

    public void SpawnEnemy(GameObject prefab)
    {
        prefab.transform.position = spawnPoints[spawnSelect].transform.position;

        Instantiate(prefab);

        enemiesAlive++;
        sC = spawnCooldown;
        spawnSelect++;
    }

    public void EnemyDied()
    {
        enemiesAlive--;
        totalEnemiesInRound[currentRound]--;
    }

    public void GameEnded()
    {
        chestsObj = new List<GameObject>(GameObject.FindGameObjectsWithTag("Chest"));
        foreach (GameObject chest in chestsObj)
        {
            chest.SetActive(false);
        }

        if (!y)
        {
            RenderSettings.skybox = winSkybox;

            normalMusic.SetActive(false);
            winMusic.SetActive(true);

            winAnimation.SetTrigger("Win");

            y = true;
        }

        if (y)
        {
            winAnimationDuration -= Time.deltaTime;
            if (winAnimationDuration <= 0)
            {
                data.nextScene = "MainMenu";
                UnityEngine.SceneManagement.SceneManager.LoadScene("LoadScene");
            }
        }
    }

    public void ArcadeMode()
    {
        if (b)
        {
            if (!a)
            {
                totalEnemiesInRound.Clear();
                enemy1Spawns.Clear();
                enemy2Spawns.Clear();
                enemy3Spawns.Clear();
                enemy4Spawns.Clear();

                totalEnemiesInRound.Add(0);
                enemy1Spawns.Add(0);
                enemy2Spawns.Add(0);
                enemy3Spawns.Add(0);
                enemy4Spawns.Add(0);

                totalEnemiesInRound.Add(0);
                enemy1Spawns.Add(4);
                enemy2Spawns.Add(0);
                enemy3Spawns.Add(Random.Range(0, 5));
                enemy4Spawns.Add(0);

                a = true;
                return;
            }
            
            if (a)
            {
                totalEnemiesInRound.Add(0);

                enemy1Spawns.Add(Random.Range(currentRound, currentRound * 2));
                enemy2Spawns.Add(Random.Range(0, currentRound * 3));
                enemy3Spawns.Add(Random.Range(0, currentRound * 2));
                enemy4Spawns.Add(Random.Range(0, currentRound));
            }
        }
    }
}
