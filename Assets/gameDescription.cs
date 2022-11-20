using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameDescription : MonoBehaviour
{
    [SerializeField]private Image _gameDes;
    [SerializeField]private GameObject _closeBtn;
    [SerializeField] private GameObject _ball;
    [SerializeField] private BallBehaviour ballBehaviour;


    // Start is called before the first frame update
    void Update()
    {
        descriptionPresented();
       
    }

    void descriptionPresented()
    {
        if (_gameDes.GetComponent<Image>().enabled == true)
        {
            _ball.SetActive(false);
        }
        else if (_gameDes.GetComponent<Image>().enabled == false)
        {
            _ball.SetActive(true);
            Debug.Log("tes");
        }
    }

    public void closeDescription()
    {
        _gameDes.enabled = false;
        _closeBtn.SetActive(false);

    }
   
}
