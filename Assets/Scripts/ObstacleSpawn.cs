using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    public GameObject prefab;
    public float spawninterval = 1f;
    public float minheight = -1f;
    public float maxheight = 1f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(spawn), spawninterval, spawninterval);
    }
    private void OnDisable()
    {
        CancelInvoke(nameof(spawn));
    }
    private void spawn()
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minheight, maxheight);
    }
}
