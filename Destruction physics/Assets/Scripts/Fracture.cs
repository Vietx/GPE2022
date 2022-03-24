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

    void BowyerWatson()
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
        vertices[vertices.Length + 1].x = maxX + 100;
        vertices[vertices.Length + 1].y = maxY + 100;
        vertices[vertices.Length + 2].x = minX + 100;
        vertices[vertices.Length + 2].y = maxY + 100;
        vertices[vertices.Length + 3].x = minX - 100;
        vertices[vertices.Length + 3].y = maxY / 2 - 100;
        triangles[0] = 0;//tofix
        triangles[1] = 1;
        triangles[2] = 2;

        //for each sample point in the vertex list...
        for (int i = 0; i < vertices.Length; i++)
        {
            List<Edge> edgeBuffer;
            for (int t = 0; t < triangles.Length; t++)
            {
                //if point in circle
                //add to edge buffer
                //remove from triangles
            }
        }
    }

    circumCircle calculateCircle(float ax, float ay, float bx, float by, float cx, float cy)
    {
        //https://stackoverflow.com/questions/56224824/how-do-i-find-the-circumcenter-of-the-triangle-using-python-without-external-lib
        //https://www.mathopenref.com/trianglecircumcircle.html
        //circumcenter
        float d = 2 * (ax * (by - cy) + bx * (cy - ay) + cx * (ay - by));
        float ux = ((ax * ax + ay * ay) * (by - cy) + (bx * bx + by * by) * (cy - ay) + (cx * cx + cy * cy) * (ay - by)) / d;
        float uy = ((ax * ax + ay * ay) * (cx - bx) + (bx * bx + by * by) * (ax - cx) + (cx * cx + cy * cy) * (bx - ax)) / d;
        //radius
        float r = (a * b * c) / Mathf.Sqrt((a + b + c) * (b + c - a) * (a + b - c));

        return new circumCircle(r,ux,uy);
    }

    private bool inCircle(float ax, float ay,float bx,float by,float cx,float cy,float dx,float dy)
    {
        //https://stackoverflow.com/questions/39984709/how-can-i-check-wether-a-point-is-inside-the-circumcircle-of-3-points
        //iets met counterclockwise probably
        float ax_ = ax-dx;
        float ay_ = ay-dy;
        float bx_ = bx-dx;
        float by_ = by-dy;
        float cx_ = cx-dx;
        float cy_ = cy-dy;
        return (
            (ax_*ax_ + ay_*ay_) * (bx_*cy_-cx_*by_) -
            (bx_*bx_ + by_*by_) * (ax_*cy_-cx_*ay_) +
            (cx_*cx_ + cy_*cy_) * (ax_*by_-bx_*ay_)
        ) > 0;
    }
}

struct Edge
{
    public Edge(float a, float b)
    {
        A=a;
        B=b;
    }

    public float A {get;}
    public float B {get;}
}

struct circumCircle
{
    public circumCircle(float r, float ux, float uy)
    {
        R=r;
        UX=ux;
        UY=uy;
    }
    //radius
    public float R {get;}
    //circumcenter
    public float UX {get;}
    public float UY {get;}
}