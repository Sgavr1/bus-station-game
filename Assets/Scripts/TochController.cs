using UnityEngine;

public class TochController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if(hit.collider != null)
            {
                Auto auto = hit.collider.GetComponent<Auto>();
                if (auto != null)
                {
                    Debug.Log(auto.gameObject.name);
                    auto.Run();
                }
            }
        }
    }
}
