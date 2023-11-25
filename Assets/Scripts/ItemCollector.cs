using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ItemCollector : MonoBehaviour
{
    private int banana = 0;
    [SerializeField] private TextMeshProUGUI bananaText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Banana"))
        {
            AudioManager.instance.PlaySFX("collect");
            Destroy(collision.gameObject);
            banana++;
            bananaText.text = "Banana:" + banana;
        }
    }
}
