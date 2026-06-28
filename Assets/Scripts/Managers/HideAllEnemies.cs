using UnityEngine;

public class HideAllEnemies : MonoBehaviour
{
    public bool hideAll = true;

    void Start()
    {
        HideEnemies();
    }

    public void HideEnemies()
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
