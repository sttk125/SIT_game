using UnityEngine;

public class Gate : MonoBehaviour
{
    public int addValue = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("ゲート通過！");
            // 処理
        }
    }
}
