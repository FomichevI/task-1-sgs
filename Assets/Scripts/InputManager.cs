using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Vector2 _startPosition;
    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))            
                SceneController.Instance.BackToPreviousScene();            
        }

        else if (Application.platform == RuntimePlatform.IPhonePlayer) //Свайп вправо на IOS
        {
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if(touch.phase == TouchPhase.Began)                
                    _startPosition = touch.position;
                else if (touch.phase == TouchPhase.Moved && touch.position.x > _startPosition.x)
                {
                    if (Mathf.Abs(touch.position.x - _startPosition.x) > Screen.width/2)
                        SceneController.Instance.BackToPreviousScene();                }
                
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Escape))
                SceneController.Instance.BackToPreviousScene();
        }
    }
}
