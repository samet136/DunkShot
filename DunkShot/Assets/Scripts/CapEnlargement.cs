using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CapEnlargement : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI time;
    [SerializeField] private int StartTime;
    [SerializeField] private GameManager manager;
    IEnumerator Start()
    {
        time.text = StartTime.ToString();
        while (true)
        {
            yield return new WaitForSeconds(1f);
            StartTime--;
            time.text = StartTime.ToString();
            if (StartTime == 0)
            {
                gameObject.SetActive(false);
                break;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        manager.CapEnlargement(transform.position);
        gameObject.SetActive(false);     
    }

}
