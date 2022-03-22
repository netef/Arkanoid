using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    void Update()
    {
        GetComponent<TMPro.TMP_Text>().text = ScoreManagerScript.Instance.score.ToString();
    }
}
