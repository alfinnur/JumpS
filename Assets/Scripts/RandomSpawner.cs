using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour {

    public float speed;
    [SerializeField]
    float maxEnemys;
    float totalEnemyAvailable;
    [SerializeField]
    GameObject targetSpawn, MainCharacter;
    Camera m_camera;

    public float colThickness = 4f;
    public float zPosition = 0f;
    private Vector2 screenSize;
    // Use this for initialization
    void Start () {
        m_camera = Camera.main;

        System.Collections.Generic.Dictionary<string, Transform> colliders = new System.Collections.Generic.Dictionary<string, Transform>();
        //colliders.Add("Top", new GameObject().transform);
        colliders.Add("Bottom", new GameObject().transform);
        colliders.Add("Right", new GameObject().transform);
        colliders.Add("Left", new GameObject().transform);

        Vector3 cameraPos = Camera.main.transform.position;
        screenSize.x = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f;
        screenSize.y = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height))) * 0.5f;

        foreach (KeyValuePair<string, Transform> valPair in colliders)
        {
            valPair.Value.gameObject.AddComponent<BoxCollider2D>();
            valPair.Value.name = valPair.Key + "Collider";
            valPair.Value.parent = transform;
            valPair.Value.tag = "edge";
            if (valPair.Key == "Left" || valPair.Key == "Right")
                valPair.Value.localScale = new Vector3(colThickness, screenSize.y * 2, colThickness);
            else
            {
                valPair.Value.localScale = new Vector3(screenSize.x * 2, colThickness, colThickness);
                valPair.Value.tag = "bottom";
            }

        }
        colliders["Right"].position = new Vector3(cameraPos.x + screenSize.x + (colliders["Right"].localScale.x * 0.5f), cameraPos.y, zPosition);
        colliders["Left"].position = new Vector3(cameraPos.x - screenSize.x - (colliders["Left"].localScale.x * 0.5f), cameraPos.y, zPosition);
        //colliders["Top"].position = new Vector3(cameraPos.x, cameraPos.y + screenSize.y + (colliders["Top"].localScale.y * 0.5f), zPosition);
        colliders["Bottom"].position = new Vector3(cameraPos.x, cameraPos.y - screenSize.y - (colliders["Bottom"].localScale.y * 0.5f), zPosition);

    }

    // Update is called once per frame
    void Update () {
        if (totalEnemyAvailable < maxEnemys)
        {
            Vector3 spawnPosition = m_camera.ScreenToWorldPoint(new Vector3(Random.Range(10, Screen.width - 10), Screen.height, 10));
            GameObject newObj = Instantiate(targetSpawn, spawnPosition, Quaternion.identity) as GameObject;
            //newObj.transform.SetParent(transform);
            totalEnemyAvailable++;
        }
        transform.position = new Vector3(MainCharacter.transform.position.x, MainCharacter.transform.position.y, -10);
	}

    public void Regenerate()
    {
        totalEnemyAvailable--;
    }
}
