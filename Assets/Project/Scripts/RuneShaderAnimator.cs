using UnityEngine;

public class RuneShaderAnimator : MonoBehaviour
{
    public float speed = 10f;

    private MeshRenderer meshRenderer;
    private Material runeMaterial;
    private Vector2 textureOffset;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        runeMaterial = meshRenderer.materials[0];
        textureOffset = runeMaterial.GetTextureOffset("_MainTex");
    }

    private void Update()
    {
        textureOffset -= Vector2.up * Time.deltaTime;
        runeMaterial.SetTextureOffset("_MainTex", textureOffset);
    }
}
