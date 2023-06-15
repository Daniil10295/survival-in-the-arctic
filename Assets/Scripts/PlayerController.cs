using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float speed;

    private void Start()
    {
        StartCoroutine(Warm());
    }

    void Update()
    {
        playerTransform.Translate(new Vector3((speed * Time.deltaTime) * Input.GetAxis("Horizontal"), (speed * Time.deltaTime) * Input.GetAxis("Vertical"), 0));
    }

    IEnumerator Warm()
    {
        var playerInfo = playerTransform.gameObject.GetComponent<PlayerInfo>();
        while (true)
        {
            var colliders = Physics2D.OverlapCircleAll(new Vector2(playerTransform.position.x, playerTransform.position.y), 2);
            
            playerInfo.inWarm = false;
            foreach (var collider in colliders)
            {
                if (collider.gameObject.CompareTag("bonfire"))
                {
                    playerInfo.inWarm = true;
                    break;
                }
            }
            
            yield return new WaitForSeconds(1);
        }
    }
}
