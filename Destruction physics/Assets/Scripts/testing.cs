using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing : MonoBehaviour
{
    public Material material;
    // Start is called before the first frame update
    void Start()
    {
        //var rigidbody = GameObject.AddComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000.0f))
            {
                deleteTri(hit.triangleIndex);
            }
        }
    }

    void deleteTri(int index)
    {
        Destroy(this.gameObject.GetComponent<MeshCollider>());
        Mesh mesh = transform.GetComponent<MeshFilter>().mesh;
        int[] oldTriangles = mesh.triangles;
        int[] newTriangles = new int[mesh.triangles.Length - 3];

        int i = 0;
        int j = 0;
        while (j < mesh.triangles.Length)
        {
            if (j != index * 3)
            {
                for (int x = 0; x < 3; x++)
                {
                    newTriangles[i++] = oldTriangles[j++];
                }
            }
            else
            {
                j += 3;
                Vector3[] vertices = new Vector3[3];
                Vector2[] uv = new Vector2[3];
                int[] tr = new int[3];

                vertices[0] = new Vector3(0, 0);
                vertices[1] = new Vector3(1, 1);
                vertices[2] = new Vector3(0, 1);

                uv[0] = new Vector2(0, 0);
                uv[1] = new Vector2(1, 1);
                uv[2] = new Vector2(0, 1);

                tr[0] = 0;
                tr[1] = 1;
                tr[2] = 2;

                Mesh newMesh = new Mesh();
                newMesh.vertices = vertices;
                newMesh.uv = uv;
                newMesh.triangles = tr;

                GameObject poof = new GameObject("tri_part", typeof(MeshFilter), typeof(MeshRenderer), typeof(Rigidbody), typeof(BoxCollider));
                Debug.Log(mesh.vertices.Length);
                poof.transform.position = transform.position;

                poof.GetComponent<MeshFilter>().mesh = newMesh;
                poof.GetComponent<MeshRenderer>().material = material;
                poof.layer = 2;
            }
        }

        transform.GetComponent<MeshFilter>().mesh.triangles = newTriangles;
        this.gameObject.AddComponent<MeshCollider>();
    }
}
