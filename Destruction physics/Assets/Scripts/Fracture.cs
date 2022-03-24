using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fracture : MonoBehaviour
{
    float minX;
    float maxX;
    float minY;
    float maxY;

    void Start()
    {
        minX = gameObject.GetComponent<MeshFilter>().mesh.bounds.min.x;
        maxX = gameObject.GetComponent<MeshFilter>().mesh.bounds.max.x;
        minY = gameObject.GetComponent<MeshFilter>().mesh.bounds.min.z;
        maxY = gameObject.GetComponent<MeshFilter>().mesh.bounds.max.z;
    }

    Vector2 getRandomPoint()
    {
        float pointX = Random.Range(minX, maxX);
        float pointY = Random.Range(minY, maxY);

        return new Vector2(pointX, pointY);
    }

    async void BowyerWatson()
    {
        //http://paulbourke.net/papers/triangulate/
        //list of points 
        Vector2[] vertices = new Vector2[((int)maxX + 1) * ((int)maxY + 1)];//length probably not correct
        int[] triangles = new int[(int)maxX * (int)maxY * 6];//length probably not correct
        int[] edges = new int[triangles.Length * 3];//length probably not correct

        //random points
        for (int r = 0; r < 4; r++)
        {
            vertices[r] = getRandomPoint();
        }

        //add triangles from random points?

        //add a super triangle to vertex and triangle list
        vertices[vertices.Length + 1].x = maxX + 1;
        vertices[vertices.Length + 1].y = maxY + 1;
        vertices[vertices.Length + 2].x = minX + 1;
        vertices[vertices.Length + 2].y = maxY + 1;
        vertices[vertices.Length + 3].x = minX - 1;
        vertices[vertices.Length + 3].y = maxY / 2 - 1;
        triangles[0] = 0;//tofix
        triangles[1] = 1;
        triangles[2] = 2;

        //for each sample point in the vertex list...
        for (int i = 0; i < vertices.Length; i++)
        {
            /*initialize the edge buffer
               for each triangle currently in the triangle list
                  calculate the triangle circumcircle center and radius
                  if the point lies in the triangle circumcircle then
                     add the three triangle edges to the edge buffer
                     remove the triangle from the triangle list
                  endif
               endfor
               delete all doubly specified edges from the edge buffer
                  this leaves the edges of the enclosing polygon only
               add to the triangle list all triangles formed between the point 
                  and the edges of the enclosing polygon
            endfor*/
            //edge buffer?
            for (int t = 0; t < triangles.Length; t++)
            {
                //calculate triangle in circumcircle center..
                //if point...
            }
        }
    }

    async void circumCircle()
    {
        float a = 0;
        float b = 0;
        float c = 0;
        float r = 0;

        r = (a * b * c) / Mathf.Sqrt((a + b + c) * (b + c - a) * (a + b - c));
    }
}
