using UnityEngine;

public class Background : MonoBehaviour
{
    private MeshRenderer m_MeshRenderer;
    public float animspeed = 1.0f;
    private void Awake()
    {
        m_MeshRenderer = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        m_MeshRenderer.material.mainTextureOffset += new Vector2(animspeed * Time.deltaTime, 0);
    }
}
