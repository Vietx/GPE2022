using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeDestruction : MonoBehaviour
{
    public GameObject mesh;

    float cubeX;
    float cubeY;
    float cubeZ;

    public float cubeScale = 0.5f;

    void Start()
    {
        cubeX = transform.localScale.x;
        cubeY = transform.localScale.y;
        cubeZ = transform.localScale.z;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateCube();
        }
    }

    void CreateCube()
    {
        for (float x = 0; x < cubeX; x += cubeScale)
        {
            for (float y = 0; y < cubeY; y += cubeScale)
            {
                for (float z = 0; z < cubeZ; z += cubeScale)
                {
                    Vector3 vec = transform.position;

                    GameObject cubes = (GameObject)Instantiate(mesh, vec + new Vector3(x, y, z), Quaternion.identity);
                    cubes.gameObject.GetComponent<MeshRenderer>().material = gameObject.GetComponent<MeshRenderer>().material;
                }
            }
        }
    }
}
