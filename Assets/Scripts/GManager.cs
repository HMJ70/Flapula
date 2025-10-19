using UnityEngine;

public class GManager : MonoBehaviour
{
    private int points;
    
    public void pluspoints()
    {
        points++;
    }
    public void gameover()
    {
        Debug.Log("gover");
    }
}
