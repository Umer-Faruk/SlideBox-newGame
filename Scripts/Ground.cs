using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject groundCube;

    private GameObject GROUND;
    private List<GameObject> cubes = new List<GameObject>();
    void Awake()
    {
        GROUND = new GameObject("GROUND");
    }

    public float GetPos()
    {
        return GROUND.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Generate(int m)
    {
        GROUND.transform.position = new Vector3(0, 0, 0);
        
        int skipcount = Random.Range(1, 9);
        for (int i = 0; i < 11; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                GameObject GroundCube =  Instantiate(groundCube, new Vector3(i, 0, j), Quaternion.identity, GROUND.transform);
                if (i == 0  || j == 0 || i ==10 ||j ==10)
                {
                    GroundCube.transform.localScale = new Vector3(1,2f,1);
                    var r =  GroundCube.GetComponent<Renderer>();
                    r.material.color = Color.red;
                }
                else
                {
                    cubes.Add(GroundCube);
                }
                
                
                if (i == skipcount && j == skipcount) GroundCube.SetActive(false);

            }
        }
    }

    public void GenerateNext()
    {
        GROUND.transform.position = new Vector3(0, GROUND.transform.position.y -10 , 0);
        Color newColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        foreach (var cube in cubes)
        {
            var r =  cube.GetComponent<Renderer>();
            r.material.color = newColor;
            if(!cube.activeSelf) cube.SetActive(true);
        }
        cubes[Random.Range(0,cubes.Count)].SetActive(false);
    }
}