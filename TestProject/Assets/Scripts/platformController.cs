using Unity.VisualScripting;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private float speed;

    [SerializeField] private Transform tf;
    private bool touched = false;
    void Start()
    {
        speed = 3.0f;
    }

    void Update()
    {
        // Move the object straight down
        Vector3 movement = Vector3.down * speed * Time.deltaTime;
        transform.Translate(movement);

        if(tf.position.y < -5)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.tag == "Player") {
            if (touched == false)
            {
                //player.GetComponent<playerController>().score += 5;
                //print(player.GetComponent<playerController>().score);
            }

        }
        touched = true;
    }
}