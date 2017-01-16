using UnityEngine;
using System.Collections;

public class flipcamera : MonoBehaviour {
    public Camera maincamera;

    void OnPreCull()
    {
        maincamera.ResetWorldToCameraMatrix();
        maincamera.ResetProjectionMatrix();
        maincamera.projectionMatrix = maincamera.projectionMatrix * Matrix4x4.Scale(new Vector3(1, -1, 1));
    }

    void OnPreRender()
    {
        GL.SetRevertBackfacing(true);
    }

    void OnPostRender()
    {
        GL.SetRevertBackfacing(false);
    }
}
