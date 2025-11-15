using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Camera))]
public class FlipCamera : MonoBehaviour
{
    new Camera camera;
    public bool flipHorizontal = true;

    void OnEnable()
    {
        camera = GetComponent<Camera>();
        RenderPipelineManager.beginCameraRendering += OnBeginCameraRendering;
        RenderPipelineManager.endCameraRendering += OnEndCameraRendering;
    }

    void OnDisable()
    {
        RenderPipelineManager.beginCameraRendering -= OnBeginCameraRendering;
        RenderPipelineManager.endCameraRendering -= OnEndCameraRendering;
        GL.invertCulling = false;
    }

    void OnBeginCameraRendering(ScriptableRenderContext context, Camera cam)
    {
        if (cam != camera) return;          // only our camera
        camera.ResetWorldToCameraMatrix();
        camera.ResetProjectionMatrix();

        if (flipHorizontal)
        {
            var scale = Matrix4x4.Scale(new Vector3(-1, 1, 1));
            camera.projectionMatrix = camera.projectionMatrix * scale;
            GL.invertCulling = true;
        }
        else
        {
            GL.invertCulling = false;
        }
    }

    void OnEndCameraRendering(ScriptableRenderContext context, Camera cam)
    {
        if (cam != camera) return;
        GL.invertCulling = false;
    }
}
