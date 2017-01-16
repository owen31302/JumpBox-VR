using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PassLevel : MonoBehaviour
{
    public static PassLevel _instance;
    public Text _levelMessage;

    public int _counter;
    public int _currentBoxLv1;
    public int _currentBoxLv2;
    public int _currentBoxLv3;
    public int _currentBoxLv4;
    public int _currentBoxLv6;
    public int _currentBoxLv7;
    public int _currentBoxLv8;
    public int levelTenBoxIndex;


    void Awake()
    {
        _instance = this;
    }

    // Use this for initialization
    void Start()
    {
        levelTenBoxIndex = 0;
        _levelMessage = LevelManager.instance._success;
        _currentBoxLv1 = 0;
        _currentBoxLv2 = 0;
        _currentBoxLv3 = 0;
        _currentBoxLv4 = 0;
        _currentBoxLv6 = 0;
        _currentBoxLv7 = 0;
        _currentBoxLv8 = 0;
        _counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelManager.instance._currentLevel == 10)
        {
            if (L10Fadeinoutanimation._instance.L10Boxs[0].constantly && L10Fadeinoutanimation._instance.L10Boxs[2].constantly && L10Fadeinoutanimation._instance.L10Boxs[5].constantly) {
                _levelMessage.text = "SUCCESS";
            }
            if (L10Fadeinoutanimation._instance.L10Boxs[5].constantly && L10Fadeinoutanimation._instance.L10Boxs[6].constantly && L10Fadeinoutanimation._instance.L10Boxs[7].constantly) {
                _levelMessage.text = "SUCCESS";
            }
            if (L10Fadeinoutanimation._instance.L10Boxs[2].constantly && L10Fadeinoutanimation._instance.L10Boxs[3].constantly && L10Fadeinoutanimation._instance.L10Boxs[4].constantly) {
                _levelMessage.text = "SUCCESS";
            }
            if (L10Fadeinoutanimation._instance.L10Boxs[0].constantly && L10Fadeinoutanimation._instance.L10Boxs[3].constantly && L10Fadeinoutanimation._instance.L10Boxs[7].constantly) {
                _levelMessage.text = "SUCCESS";
            }
            if (L10Fadeinoutanimation._instance.L10Boxs[1].constantly && L10Fadeinoutanimation._instance.L10Boxs[3].constantly && L10Fadeinoutanimation._instance.L10Boxs[5].constantly) {
                _levelMessage.text = "SUCCESS";
            }
            if (L10Fadeinoutanimation._instance.L10Boxs[1].constantly && L10Fadeinoutanimation._instance.L10Boxs[4].constantly && L10Fadeinoutanimation._instance.L10Boxs[7].constantly) {
                _levelMessage.text = "SUCCESS";
            }
        }
    }

    void OnCollisionEnter(Collision c)
    {
        _counter = 0;


        /****LV1****/
        if (LevelManager.instance._currentLevel == 1)
        {
            if (_currentBoxLv1 == 0)
            {
                if (c.gameObject.name.Equals("BoxNo1Up"))
                {
                    _currentBoxLv1 = 1;
                }
            }
            if (c.gameObject.name.Equals("bakedTable"))
            {
                _currentBoxLv1 = 0;
            }
            if (c.gameObject.name.Equals("Ground"))
            {
                _currentBoxLv1 = 0;
            }
        }
        /****LV1****/

        /****LV2****/
        if (LevelManager.instance._currentLevel == 2)
        {
            if (_currentBoxLv2 == 0)
            {
                if (c.gameObject.name.Equals("BoxNo1Up"))
                {
                    _currentBoxLv2 = 1;
                }
            }
            else if (_currentBoxLv2 == 1)
            {
                if (c.gameObject.name.Equals("BoxNo2Up"))
                {
                    _currentBoxLv2 = 2;
                }
            }
            if (c.gameObject.name.Equals("bakedTable"))
            {
                _currentBoxLv2 = 0;
            }
            if (c.gameObject.name.Equals("Ground"))
            {
                _currentBoxLv2 = 0;
            }
        }
        /****LV2****/

        /****LV3****/
        if (LevelManager.instance._currentLevel == 3)
        {
            if (_currentBoxLv3 == 0)
            {
                if (c.gameObject.name.Equals("BoxNo1Up"))
                {
                    _currentBoxLv3 = 1;
                }
            }
            else if (_currentBoxLv3 == 1)
            {
                if (c.gameObject.name.Equals("BoxNo2Up"))
                {
                    _currentBoxLv3 = 2;
                }
            }
            if (c.gameObject.name.Equals("bakedTable"))
            {
                _currentBoxLv3 = 0;
            }
            if (c.gameObject.name.Equals("Ground"))
            {
                _currentBoxLv3 = 0;
            }
        }
        /****LV3****/

        /****LV4****/
        if (LevelManager.instance._currentLevel == 4)
        {
            if (_currentBoxLv4 == 0)
            {
                if (c.gameObject.name.Equals("BoxNo1Up"))
                {
                    _currentBoxLv4 = 1;
                }
            }
            if (c.gameObject.name.Equals("bakedTable"))
            {
                _currentBoxLv4 = 0;
            }
            if (c.gameObject.name.Equals("Ground"))
            {
                _currentBoxLv4 = 0;
            }
        }
        /****LV4****/


        /****LV6****/
        if (LevelManager.instance._currentLevel == 6)
        {
            if (_currentBoxLv6 == 0)
            {
                if (c.gameObject.name.Equals("BoxNo1Up"))
                {
                    _currentBoxLv6 = 1;
                }
            }
            if (c.gameObject.name.Equals("bakedTable"))
            {
                _currentBoxLv6 = 0;
            }
            if (c.gameObject.name.Equals("Ground"))
            {
                _currentBoxLv6 = 0;
            }
        }
        /****LV6****/



        /****LV7****/
        if (LevelManager.instance._currentLevel == 7)
        {
            if (_currentBoxLv7 == 0)
            {
                if (c.gameObject.name.Equals("BoxNo1Up"))
                {
                    _currentBoxLv7 = 1;
                }
            }
            if (_currentBoxLv7 == 1)
            {
                if (c.gameObject.name.Equals("BoxNo2Up"))
                {
                    _currentBoxLv7 = 2;
                }
            }
            
            if (c.gameObject.name.Equals("bakedTable"))
            {
                _currentBoxLv7 = 0;
            }
            if (c.gameObject.name.Equals("Ground"))
            {
                _currentBoxLv7 = 0;
            }
        }
        /****LV7****/


        /****LV8****/
        if (LevelManager.instance._currentLevel == 8)
        {
            if (_currentBoxLv8 == 0)
            {
                if (c.gameObject.name.Equals("BoxNo1Up"))
                {
                    _currentBoxLv8 = 1;
                }
            }
            else if (_currentBoxLv8 == 1)
            {
                if (c.gameObject.name.Equals("BoxNo2Up"))
                {
                    _currentBoxLv8 = 2;
                }
            }
            if (c.gameObject.name.Equals("bakedTable"))
            {
                _currentBoxLv8 = 0;
            }
            if (c.gameObject.name.Equals("Ground"))
            {
                _currentBoxLv8 = 0;
            }
        }
        /****LV8****/
    }

    void OnCollisionStay(Collision c)
    {
        /****LV1****/
        if (LevelManager.instance._currentLevel == 1)
        {
            if (_currentBoxLv1 == 1)
            {
                if (c.gameObject.name.Equals("BoxTarget"))
                {
                    _currentBoxLv1 = 0;
                    _levelMessage.text = "SUCCESS";
                }
            }
        }
        /****LV1****/

        /****LV2****/
        if (LevelManager.instance._currentLevel == 2)
        {
            if (_currentBoxLv2 == 2)
            {
                if (c.gameObject.name.Equals("BoxTarget"))
                {
                    _currentBoxLv2 = 0;
                    _levelMessage.text = "SUCCESS";
                }
            }
        }
        /****LV2****/

        /****LV3****/
        if (LevelManager.instance._currentLevel == 3)
        {
            if (_currentBoxLv3 == 2)
            {
                if (c.gameObject.name.Equals("BoxTarget"))
                {
                    _currentBoxLv3 = 0;
                    _levelMessage.text = "SUCCESS";
                }
            }
        }
        /****LV3****/

        /****LV4****/
        if (LevelManager.instance._currentLevel == 4)
        {
            if (_currentBoxLv4 == 1)
            {
                if (c.gameObject.name.Equals("BoxTarget"))
                {
                    _currentBoxLv4 = 0;
                    _levelMessage.text = "SUCCESS";
                }
            }
        }
        /****LV4****/

        /****LV5****/
        if (LevelManager.instance._currentLevel == 5)
        {
            if (LevelManager.instance._currentBoxLv5 == 0)
            {
                if (c.gameObject.name.Equals("BoxNo1"))
                {
                    _counter++;
                    if (_counter >= 10)
                    {
                        LevelManager.instance._currentBoxLv5 = 1;
                        _levelMessage.text = "Box One Check";
                        _counter = 0;
                    }
                }
            }
            else if (LevelManager.instance._currentBoxLv5 == 1)
            {
                if (c.gameObject.name.Equals("BoxNo2"))
                {
                    _counter++;
                    if (_counter >= 10)
                    {
                        LevelManager.instance._currentBoxLv5 = 2;
                        _levelMessage.text = "Box Two Check";
                        _counter = 0;
                    }
                }
            }
            else if (LevelManager.instance._currentBoxLv5 == 2)
            {
                if (c.gameObject.name.Equals("BoxNo3"))
                {
                    _counter++;
                    if (_counter >= 10)
                    {
                        LevelManager.instance._currentBoxLv5 = 3;
                        _levelMessage.text = "Box Three Check";
                        _counter = 0;
                    }
                }
            }
            else if (LevelManager.instance._currentBoxLv5 == 3)
            {
                if (c.gameObject.name.Equals("BoxTarget"))
                {
                    _counter++;
                    if (_counter >= 10)
                    {
                        LevelManager.instance._currentBoxLv5 = 0;
                        _levelMessage.text = "SUCCESS";
                        _counter = 0;
                    }
                }
            }
        }
        /****LV5****/



        /****LV6****/
        if (LevelManager.instance._currentLevel == 6)
        {
            if (_currentBoxLv6 == 1)
            {
                if (c.gameObject.name.Equals("BoxTarget"))
                {
                    _currentBoxLv6 = 0;
                    _levelMessage.text = "SUCCESS";
                }
            }
        }
        /****LV6****/



        /****LV7****/
        if (LevelManager.instance._currentLevel == 7)
        {
            if (_currentBoxLv7 == 2)
            {
                if (c.gameObject.name.Equals("BoxTarget"))
                {
                    _currentBoxLv7 = 0;
                    _levelMessage.text = "SUCCESS";
                }
            }
        }
        /****LV7****/


        /****LV8****/
        if (LevelManager.instance._currentLevel == 8)
        {
            if (_currentBoxLv8 == 2)
            {
                if (c.gameObject.name.Equals("BoxTarget"))
                {
                    _currentBoxLv8 = 0;
                    _levelMessage.text = "SUCCESS";
                }
            }
        }
        /****LV8****/



        /****LV10****/
        if (LevelManager.instance._currentLevel == 10)
        {
            for(levelTenBoxIndex = 0; levelTenBoxIndex < L10Fadeinoutanimation._instance.L10Boxs.Length; levelTenBoxIndex++)
            {
                if (c.gameObject.name.Equals("BoxNo" + levelTenBoxIndex))
                {
                    L10Fadeinoutanimation._instance.L10Boxs[levelTenBoxIndex].constantly = true;
                }
            }
        }
        /****LV10****/
    }
}
