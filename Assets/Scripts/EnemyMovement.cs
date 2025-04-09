using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform[] waypoints;
    private int currentIndex = 0;
    public float speed = 2f;

    void Start()
    {
        // Procura o objeto com o nome "Waypoints"
        GameObject waypointParent = GameObject.Find("Waypoints");

        if (waypointParent != null)
        {
            // Pega os filhos e ordena por nome (Waypoint0, Waypoint1, etc)
            waypoints = new Transform[waypointParent.transform.childCount];

            for (int i = 0; i < waypoints.Length; i++)
            {
                waypoints[i] = waypointParent.transform.GetChild(i);
            }
        }
        else
        {
            Debug.LogError("Waypoints não encontrados na cena!");
        }
    }

    void Update()
    {
        if (waypoints == null || waypoints.Length == 0) return;

        if (currentIndex < waypoints.Length)
        {
            Transform target = waypoints[currentIndex];
            Vector3 direction = target.position - transform.position;
            transform.position += direction.normalized * speed * Time.deltaTime;

            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                currentIndex++;
            }
        }
        else
        {
            Destroy(gameObject); // Chegou ao final
        }
    }
}
