using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerate : MonoBehaviour
{
    // Start is called before the first frame update
    public Ground _Ground;
    public GameObject Cube;
    void Start()
    {
        _Ground.Generate(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            _Ground.GenerateNext();
        }

        if (Cube.transform.position.y < _Ground.GetPos())
        {
            UIManager.instance.UpdateSCore();
            _Ground.GenerateNext();
        }
    }

    
}
