using System.Collections;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [Header("Attack One")]
    public Transform[] attackPoints;
    public GameObject spikes;

    private enum BossState
    {   
        Idle, 
        AttackOne, 
        AttackTwo, 
        Cooldown 
    }
    private BossState currentState;

    public float cooldownTime = 2f;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(BossBehaviour());
    }

    private IEnumerator BossBehaviour()
    {
        while (true)
        {
            switch (currentState)
            {
                case BossState.Idle:
                    yield return StartCoroutine(ChooseAttack());
                    break;

                case BossState.AttackOne:
                    yield return StartCoroutine(AttackOne());
                    currentState = BossState.Cooldown;
                    break;

                case BossState.AttackTwo:
                    yield return StartCoroutine(AttackTwo());
                    currentState = BossState.Cooldown;
                    break;

                case BossState.Cooldown:
                    yield return new WaitForSeconds(cooldownTime);
                    currentState = BossState.Idle;
                    break;
            }

            yield return null;
        }
    }

    private IEnumerator ChooseAttack()
    {
        int choice = Random.Range(0, 2);
        currentState = choice == 0 ? BossState.AttackOne : BossState.AttackTwo;
        yield return null;
    }

    private IEnumerator AttackOne()
    {
        for (int i = 0; i < attackPoints.Length; i++)
        {
            GameObject bullet = Instantiate(spikes, attackPoints[i].position, attackPoints[i].rotation);
            bullet.GetComponent<Bullets>().SetSpeed(10f);
            bullet.GetComponent<Bullets>().SetDirection(attackPoints[i].transform.right);
        }

        Debug.Log("Attack One");
        yield return new WaitForSeconds(1f);
    }

    private IEnumerator AttackTwo()
    {
        Debug.Log("Attack Two");
        yield return new WaitForSeconds(1f);
    }
}