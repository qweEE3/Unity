using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] public GameObject Template;
    [SerializeField] public float spawnInterval;
    private float timeToSpawn;
    private float minPointX;
    private float minPointZ;
    private float maxPointX;
    private float maxPointZ;
    private readonly float Y = 1;
    private GameObject mainPanel;
    private int currentPart = 1;
    private int maxEnemy = 2;
    private int currentEnemy = 0;
    private float intervalBetweenPart = 5;
    private float currentInterval = 0;
    public bool isBreakNow = false;
    public TMP_Text Timer;
    public Image TimeCount;

    // Start is called before the first frame update
    void Start()
    {
        mainPanel = GameObject.FindGameObjectWithTag("mainPanel");
        var mesh = GetComponent<BoxCollider>();
        minPointX = transform.position.x - mesh.bounds.size.x / 2;
        minPointZ = transform.position.z - mesh.bounds.size.z / 2;
        maxPointX = transform.position.x + mesh.bounds.size.x / 2;
        maxPointZ = transform.position.z + mesh.bounds.size.z / 2;
        timeToSpawn = 0;

        /*Vector3 position = new Vector3(Random.Range(minPointX, maxPointX), Y, Random.Range(minPointZ, maxPointZ));
        Collider[] intersecting = Physics.OverlapSphere(position, 2);
        foreach (var item in intersecting) Debug.Log(item);*/
    }

    // Update is called once per frame
    void Update()
    {
        if (isBreakNow)
        {
            Timer.text = "Перерыв " + intervalBetweenPart + " секунд";
            Timer.color = new Color(0, 0, 0, 1f);
            TimeCount.color = new Color(1f, 1f, 1f, 1f);
            if (currentInterval < intervalBetweenPart)
            {
                currentInterval += Time.deltaTime;
            }
            else
            {
                Timer.color = new Color(0, 0, 0, 0);
                TimeCount.color = new Color(0, 0, 0, 0);
                isBreakNow = false;
                currentInterval = 0;

                currentEnemy = 0;
                currentPart = currentPart + 1;
                maxEnemy += 10;
            }
            return;
        }

        if (timeToSpawn < spawnInterval)
        {
            timeToSpawn += Time.deltaTime;
        }
        else
        {
            timeToSpawn = 0;
            if (currentEnemy < maxEnemy)
            {
                Spawn();
                currentEnemy++;
            }
        }
    }

    public void Spawn()
    {

        Vector3 position = new Vector3(Random.Range(minPointX, maxPointX), Y, Random.Range(minPointZ, maxPointZ));
        var enemy = Instantiate(Template, position, Quaternion.identity);
        enemy.AddComponent<Follow>();
        enemy.transform.parent = mainPanel.transform;
    }

    public void checkEnemyOnMap()
    {
        var enemyes = GameObject.FindGameObjectsWithTag("Enemy").ToArray();
        if (enemyes.Length == 1)
        {
            isBreakNow = true;
        }
    }
}