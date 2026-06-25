using UnityEngine;

public class HideAllEnemies : MonoBehaviour
{
    public bool hideAll = true;

    void Start()
    {
        if (hideAll)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                enemy.SetActive(false);
            }
        }
    }
}
