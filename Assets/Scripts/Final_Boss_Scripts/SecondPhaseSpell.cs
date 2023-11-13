using UnityEngine;
using System.Collections;

public class Enemy2 : MonoBehaviour
{
    public GameObject spellPrefab;
    public GameObject goblinPrefab;
    public GameObject skeletonPrefab;
    public float castDistance = 5f;
    private float initialCastDelay = 5f;
    public float castAnimationDuration = 2f;
    public float castDelay = 15f;

    private GameObject player;
    public bool isCasting = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(InitialSpellCast());
    }

    IEnumerator InitialSpellCast()
    {
        yield return new WaitForSeconds(initialCastDelay);
        InvokeRepeating(nameof(CastSpell), 0, castDelay);
    }

    public void CastSpell()
    {
        if (player != null && !isCasting)
        {
            isCasting = true;
            GetComponent<Animator>().SetTrigger("isClose");

            StartCoroutine(CastSpellAfterAnimation());
        }
    }

    IEnumerator CastSpellAfterAnimation()
    {
        yield return new WaitForSeconds(castAnimationDuration);

        Vector2 enemyPosition = transform.position;
        SpawnSpellAndEnemy(enemyPosition + Vector2.up * castDistance, goblinPrefab);
        SpawnSpellAndEnemy(enemyPosition - Vector2.up * castDistance, goblinPrefab);
        SpawnSpellAndEnemy(enemyPosition + Vector2.right * castDistance, skeletonPrefab);
        SpawnSpellAndEnemy(enemyPosition - Vector2.right * castDistance, skeletonPrefab);

        isCasting = false;
    }

    private void SpawnSpellAndEnemy(Vector2 position, GameObject enemyPrefab)
    {
        GameObject spell = Instantiate(spellPrefab, position, Quaternion.identity);
        Destroy(spell, 1.5f); // Assumes the spell lasts for 1.5 seconds
        StartCoroutine(SpawnEnemyAfterSpell(position, enemyPrefab));
    }

    IEnumerator SpawnEnemyAfterSpell(Vector2 position, GameObject enemyPrefab)
    {
        yield return new WaitForSeconds(1.5f);
        Instantiate(enemyPrefab, position, Quaternion.identity);
    }
}
