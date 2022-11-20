using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class losePause : MonoBehaviour
{
    [SerializeField]Image _lose;
    [SerializeField] private GameObject _ball;

    private void Start()
    {
        _lose = GetComponent<Image>();
    }
    private void Update()
    {
        if (_lose.GetComponent<Image>().enabled == true)
        {
            _ball.SetActive(false);

        };
    }

   
}
