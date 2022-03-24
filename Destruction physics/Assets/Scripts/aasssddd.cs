using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aasssddd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var test = inCircle(1,2,4,5,6,3,4,5);
        Debug.log(test);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool inCircle (int ax, int ay, int bx, int by, int cx, int cy, int dx, int dy) {
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
