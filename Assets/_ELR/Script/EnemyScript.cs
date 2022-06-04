using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public EnemyGenerator enemyGenerator;
    //public GameManager gm;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(enemyGenerator.currentSpeed * Time.deltaTime * Vector2.left);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("nextLine"))
        {
            enemyGenerator.GenerateNextEnemyWithGap();
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
            //gm.setScore();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemyGenerator.setIsOver();
        }
    }
}
