using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class CorrectionSystemManager :MonoBehaviour {

    List<ELevation> Level1_CorrectionSystem = new List<ELevation>();
    List<ELevation> Level2_CorrectionSystem = new List<ELevation>();
    List<ELevation> Level3_CorrectionSystem = new List<ELevation>();
    List<ELevation> Level4_CorrectionSystem = new List<ELevation>();
    List<ELevation> Level5_CorrectionSystem = new List<ELevation>();
    List<ELevation> Level6_CorrectionSystem = new List<ELevation>();
    List<ELevation> Level7_CorrectionSystem = new List<ELevation>();
    List<ELevation> Level8_CorrectionSystem = new List<ELevation>();
    List<ELevation> Level9_CorrectionSystem = new List<ELevation>();
    List<ELevation> Level10_CorrectionSystem = new List<ELevation>();
    //初始化自己
    public static CorrectionSystemManager _instance;
    //誤差設定
    //仰角的誤差設定
    public float ElevationOffset;
    //左右角度誤差設定
    public float RLAngleOffset;
    //球初速的誤差設定
    public float SpeedOffset;

    //抓球得速度
    public float _power;
    //校正後角度
    public Quaternion recorrectforward;
    //取得攝影機
    public Camera UserCamera;
    //現在LEVEL Current_CorrectionSystem;

    List<ELevation> Current_CorrectionSystem = new List<ELevation>();

    //隨機系統
    public int Doornot;
    public int Max = 9;
    public int Min = 0;
    public int DoValve = 5;


    public GameObject ThrowPosition;

    class ELevation
    {
        public float XAngle;
        public List<RLAngle> rangelist = new List<RLAngle>();
        public RLAngle range1 = new RLAngle();
        public RLAngle range2 = new RLAngle();
        public RLAngle range3 = new RLAngle();
        public RLAngle range4 = new RLAngle();
        public RLAngle range5 = new RLAngle();
    }
    class RLAngle
    {
        public float RightAngle;
        public float LeftAngle;
        public float Speed;
    }
    public void SetLevel1CorrectionData()
    {
        //X OFFSET = 0.7 (不會剛好是X區間 / 2 ，避免重疊)
        //清空list
        //Level1_CorrectionSystem.Clear();

        //因為繪製圖表時採用無條件捨去
        //x仰角小的要+0.01
        //y左邊範圍角度+0.1
        //--資料建立順序採--
        //仰角上到下
        //角度左到右

        ELevation ELevation1 = new ELevation();
        ELevation1.XAngle = 13.62506f;
        ELevation1.range1.LeftAngle = 357.6f - RLAngleOffset; //圖表上是356.4 但是卻進不了? 所以改成356.5
        ELevation1.range1.RightAngle = 2.4f + RLAngleOffset;
        ELevation1.range1.Speed = 3.89999f;
        ELevation1.rangelist.Add(ELevation1.range1);
        Level1_CorrectionSystem.Add(ELevation1);

        ELevation ELevation2 = new ELevation();
        ELevation2.XAngle = 15.23931f;
        ELevation2.range1.LeftAngle = 357.6f - RLAngleOffset;
        ELevation2.range1.RightAngle = 2.4f + RLAngleOffset;
        ELevation2.range1.Speed = 3.9999f;
        ELevation2.rangelist.Add(ELevation2.range1);
        Level1_CorrectionSystem.Add(ELevation2);

        ELevation ELevation3 = new ELevation();
        ELevation3.XAngle = 16.85356f;
        ELevation3.range1.LeftAngle = 357.7f - RLAngleOffset; //圖表上是356.4 但是卻進不了? 所以改成356.5
        ELevation3.range1.RightAngle = 2.4f + RLAngleOffset;
        ELevation3.range1.Speed = 4.09999f;
        ELevation3.rangelist.Add(ELevation3.range1);
        Level1_CorrectionSystem.Add(ELevation3);

    }
    public void SetLevel2CorrectionData()
    {
        //X offset = 1.3
        //清空list
        //Level2_CorrectionSystem.Clear();
        //因為繪製圖表時採用無條件捨去
        //x仰角小的要+0.01
        //y左邊範圍角度+0.1
        //--資料建立順序採--
        //仰角上到下
        //角度左到右
        ELevation ELevation1 = new ELevation();
        ELevation1.XAngle = 17.78157f;
        ELevation1.range1.LeftAngle = 356.6f - RLAngleOffset;
        ELevation1.range1.RightAngle = 2.4f + RLAngleOffset;
        ELevation1.range1.Speed = 3.2999f;
        ELevation1.rangelist.Add(ELevation1.range1);
        Level2_CorrectionSystem.Add(ELevation1);

        ELevation ELevation2 = new ELevation();
        ELevation2.XAngle = 20.52847f;
        ELevation2.range1.LeftAngle = 356.7f - RLAngleOffset;
        ELevation2.range1.RightAngle = 2.5f + RLAngleOffset;
        ELevation2.range1.Speed = 3.39999f;
        ELevation2.rangelist.Add(ELevation2.range1);
        Level2_CorrectionSystem.Add(ELevation2);

        ELevation ELevation3 = new ELevation();
        ELevation3.XAngle = 23.27538f;
        ELevation3.range1.LeftAngle = 356.8f - RLAngleOffset;
        ELevation3.range1.RightAngle = 2.3f + RLAngleOffset;
        ELevation3.range1.Speed = 3.59999f;
        ELevation3.rangelist.Add(ELevation3.range1);
        Level2_CorrectionSystem.Add(ELevation3);

    }
    public void SetLevel3CorrectionData()
    {
        //清空list
        //Level3_CorrectionSystem.Clear();
        //因為繪製圖表時採用無條件捨去
        //x仰角小的要+0.01
        //y左邊範圍角度+0.1
        //--資料建立順序採--
        //仰角上到下
        //角度左到右
        ELevation ELevation1 = new ELevation();
        ELevation1.XAngle = 19.96f;
        ELevation1.range1.LeftAngle = 352.1f - RLAngleOffset;
        ELevation1.range1.RightAngle = 353.7f + RLAngleOffset;
        ELevation1.range1.Speed = 3.6f;
        ELevation1.rangelist.Add(ELevation1.range1);
        Level3_CorrectionSystem.Add(ELevation1);

        ELevation ELevation2 = new ELevation();
        ELevation2.XAngle = 22.51f;
        ELevation2.range1.LeftAngle = 352.8f - RLAngleOffset;
        ELevation2.range1.RightAngle = 354.0f + RLAngleOffset;
        ELevation2.range1.Speed = 3.5f;
        ELevation2.rangelist.Add(ELevation2.range1);
        Level3_CorrectionSystem.Add(ELevation2);

 
    }
    public void SetLevel4CorrectionData()
    {
        //X OFFSET = 0.7
        //清空list
        //Level4_CorrectionSystem.Clear();
        //因為繪製圖表時採用無條件捨去
        //x仰角小的要+0.01
        //y左邊範圍角度+0.1
        //--資料建立順序採--
        //仰角上到下
        //角度左到右


        ELevation ELevation1 = new ELevation();
        ELevation1.XAngle = 3.330669f;
        ELevation1.range1.LeftAngle = 356.9f - RLAngleOffset;
        ELevation1.range1.RightAngle = 3.1f + RLAngleOffset;
        ELevation1.range1.Speed = 4.09999f;
        ELevation1.rangelist.Add(ELevation1.range1);
        Level4_CorrectionSystem.Add(ELevation1);

        ELevation ELevation2 = new ELevation();
        ELevation2.XAngle = 5.010307f;
        ELevation2.range1.LeftAngle = 356.8f - RLAngleOffset;
        ELevation2.range1.RightAngle = 3.1f + RLAngleOffset;
        ELevation2.range1.Speed = 4.09999f;
        ELevation2.rangelist.Add(ELevation2.range1);
        Level4_CorrectionSystem.Add(ELevation2);

        ELevation ELevation3 = new ELevation();
        ELevation3.XAngle = 6.689945f;
        ELevation3.range1.LeftAngle = 357.1f - RLAngleOffset;
        ELevation3.range1.RightAngle = 3.1f + RLAngleOffset;
        ELevation3.range1.Speed = 4.19999f;
        ELevation3.rangelist.Add(ELevation3.range1);
        Level4_CorrectionSystem.Add(ELevation3);

    }
    public void SetLevel5CorrectionData()
    {

        //BOX1 BOX2 很接近 要調整 X Y OFFSET X =1.2 Y 0.5
        //清空list
        //Level4_CorrectionSystem.Clear();
        //因為繪製圖表時採用無條件捨去
        //x仰角小的要+0.01
        //y左邊範圍角度+0.1
        //--資料建立順序採--
        //仰角上到下
        //角度左到右


        ELevation ELevation1 = new ELevation();
        ELevation1.XAngle = 22.2966f;
        ELevation1.range1.LeftAngle = 18.4f - RLAngleOffset;
        ELevation1.range1.RightAngle = 23.68f + RLAngleOffset;
        ELevation1.range1.Speed = 2.6f;
        ELevation1.rangelist.Add(ELevation1.range1);
        Level5_CorrectionSystem.Add(ELevation1);

        ELevation ELevation2 = new ELevation();
        ELevation2.XAngle = 16.77389f;
        ELevation2.range1.LeftAngle = 3.46f - RLAngleOffset;
        ELevation2.range1.RightAngle = 10.04f + RLAngleOffset;
        ELevation2.range1.Speed = 3.39999f;
        ELevation2.rangelist.Add(ELevation2.range1);
        Level5_CorrectionSystem.Add(ELevation2);

        ELevation ELevation3 = new ELevation();
        ELevation3.XAngle = 12.09604f;
        ELevation3.range1.LeftAngle = 355.1f - RLAngleOffset;
        ELevation3.range1.RightAngle = 0.42f + RLAngleOffset;
        ELevation3.range1.Speed = 3.999999f;
        ELevation3.rangelist.Add(ELevation3.range1);
        Level5_CorrectionSystem.Add(ELevation3);

        ELevation ELevation4 = new ELevation();
        ELevation4.XAngle = 9.584548f;
        ELevation4.range1.LeftAngle = 349.5f - RLAngleOffset;
        ELevation4.range1.RightAngle = 353.5f + RLAngleOffset;
        ELevation4.range1.Speed = 4.69999f;
        ELevation4.rangelist.Add(ELevation4.range1);
        Level5_CorrectionSystem.Add(ELevation4);

    }
    public void SetLevel6CorrectionData()  //6使用1的
    {

        //清空list
        //Level1_CorrectionSystem.Clear();

        //因為繪製圖表時採用無條件捨去
        //x仰角小的要+0.01
        //y左邊範圍角度+0.1
        //--資料建立順序採--
        //仰角上到下
        //角度左到右

        ELevation ELevation1 = new ELevation();
        ELevation1.XAngle = 13.62506f;
        ELevation1.range1.LeftAngle = 357.6f - RLAngleOffset; //圖表上是356.4 但是卻進不了? 所以改成356.5
        ELevation1.range1.RightAngle = 2.4f + RLAngleOffset;
        ELevation1.range1.Speed = 3.89999f;
        ELevation1.rangelist.Add(ELevation1.range1);
        Level1_CorrectionSystem.Add(ELevation1);

        ELevation ELevation2 = new ELevation();
        ELevation2.XAngle = 15.23931f;
        ELevation2.range1.LeftAngle = 357.6f - RLAngleOffset;
        ELevation2.range1.RightAngle = 2.4f + RLAngleOffset;
        ELevation2.range1.Speed = 3.9999f;
        ELevation2.rangelist.Add(ELevation2.range1);
        Level1_CorrectionSystem.Add(ELevation2);

        ELevation ELevation3 = new ELevation();
        ELevation3.XAngle = 16.85356f;
        ELevation3.range1.LeftAngle = 357.7f - RLAngleOffset; //圖表上是356.4 但是卻進不了? 所以改成356.5
        ELevation3.range1.RightAngle = 2.4f + RLAngleOffset;
        ELevation3.range1.Speed = 4.09999f;
        ELevation3.rangelist.Add(ELevation3.range1);
        Level1_CorrectionSystem.Add(ELevation3);

    }
    public void SetLevel7CorrectionData()  
    {
        //X offset = 1.8
        //清空list
        //Level1_CorrectionSystem.Clear();

        //因為繪製圖表時採用無條件捨去
        //x仰角小的要+0.01
        //y左邊範圍角度+0.1
        //--資料建立順序採--
        //仰角上到下
        //角度左到右

        ELevation ELevation1 = new ELevation();
        ELevation1.XAngle = 8.392133f;
        ELevation1.range1.LeftAngle = 358.6f - RLAngleOffset; 
        ELevation1.range1.RightAngle = 1.4f + RLAngleOffset;
        ELevation1.range1.Speed = 5.5999f;
        ELevation1.rangelist.Add(ELevation1.range1);
        Level7_CorrectionSystem.Add(ELevation1);

        ELevation ELevation2 = new ELevation();
        ELevation2.XAngle = 4.689835f;
        ELevation2.range1.LeftAngle = 358.6f - RLAngleOffset;
        ELevation2.range1.RightAngle = 1.4f + RLAngleOffset;
        ELevation2.range1.Speed = 5.29999f;
        ELevation2.rangelist.Add(ELevation2.range1);
        Level7_CorrectionSystem.Add(ELevation2);


    }
    public void SetLevel8CorrectionData()
    {
        //X offset = 1.1

        //清空list
        //Level1_CorrectionSystem.Clear();

        //因為繪製圖表時採用無條件捨去
        //x仰角小的要+0.01
        //y左邊範圍角度+0.1
        //--資料建立順序採--
        //仰角上到下
        //角度左到右

        ELevation ELevation1 = new ELevation();
        ELevation1.XAngle = 18.69231f;
        ELevation1.range1.LeftAngle = 357.3f - RLAngleOffset; 
        ELevation1.range1.RightAngle = 2.7f + RLAngleOffset;
        ELevation1.range1.Speed = 3.39999f;
        ELevation1.rangelist.Add(ELevation1.range1);
        Level8_CorrectionSystem.Add(ELevation1);

        ELevation ELevation2 = new ELevation();
        ELevation2.XAngle = 16.38165f;
        ELevation2.range1.LeftAngle = 357.3f - RLAngleOffset;
        ELevation2.range1.RightAngle = 2.7f + RLAngleOffset;
        ELevation2.range1.Speed = 3.29999f;
        ELevation2.rangelist.Add(ELevation2.range1);
        Level8_CorrectionSystem.Add(ELevation2);

    }
    public void SetLevel9CorrectionData()
    {

        //清空list
        //Level1_CorrectionSystem.Clear();

        //因為繪製圖表時採用無條件捨去
        //x仰角小的要+0.01
        //y左邊範圍角度+0.1
        //--資料建立順序採--
        //仰角上到下
        //角度左到右

        ELevation ELevation1 = new ELevation();
        ELevation1.XAngle = 7.853908f;
        ELevation1.range1.LeftAngle = 360.0f - RLAngleOffset;
        ELevation1.range1.RightAngle = 0.0f + RLAngleOffset;
        ELevation1.range1.Speed = 5.100001f;
        ELevation1.rangelist.Add(ELevation1.range1);
        Level9_CorrectionSystem.Add(ELevation1);

        
    }
    public void SetLevel10CorrectionData()
    {
        //X offset = 1.3 左右太近 Y offset 0.5

        //清空list
        //Level1_CorrectionSystem.Clear();

        //因為繪製圖表時採用無條件捨去
        //x仰角小的要+0.01
        //y左邊範圍角度+0.1
        //--資料建立順序採--
        //仰角上到下
        //角度左到右

        ELevation ELevation1 = new ELevation();
        ELevation1.XAngle = 8.351427f;
        ELevation1.range1.LeftAngle = 3.3f - RLAngleOffset;
        ELevation1.range1.RightAngle = 7.9f + RLAngleOffset;
        ELevation1.range1.Speed = 5.79999f;
        ELevation1.rangelist.Add(ELevation1.range1);
        Level10_CorrectionSystem.Add(ELevation1);

        ELevation ELevation2 = new ELevation();
        ELevation2.XAngle = 8.693422f;
        ELevation2.range1.LeftAngle = 357.7f - RLAngleOffset;
        ELevation2.range1.RightAngle = 2.3f + RLAngleOffset;
        ELevation2.range1.Speed = 5.79999f;
        ELevation2.rangelist.Add(ELevation2.range1);
        Level10_CorrectionSystem.Add(ELevation2);

        ELevation ELevation3 = new ELevation();
        ELevation3.XAngle = 8.507559f;
        ELevation3.range1.LeftAngle = 351.8f - RLAngleOffset;
        ELevation3.range1.RightAngle = 356.4f + RLAngleOffset;
        ELevation3.range1.Speed = 5.699f;
        ELevation3.rangelist.Add(ELevation3.range1);
        Level10_CorrectionSystem.Add(ELevation3);

        ELevation ELevation4 = new ELevation();
        ELevation4.XAngle = 11.47323f;
        ELevation4.range1.LeftAngle = 4.4f - RLAngleOffset;
        ELevation4.range1.RightAngle = 10.5f + RLAngleOffset;
        ELevation4.range1.Speed = 4.9f;
        ELevation4.rangelist.Add(ELevation4.range1);
        Level10_CorrectionSystem.Add(ELevation4);

        ELevation ELevation5 = new ELevation();
        ELevation5.XAngle = 11.57979f;
        ELevation5.range1.LeftAngle = 356.9f - RLAngleOffset;
        ELevation5.range1.RightAngle = 3.2f + RLAngleOffset;
        ELevation5.range1.Speed = 4.8f;
        ELevation5.rangelist.Add(ELevation5.range1);
        Level10_CorrectionSystem.Add(ELevation5);

        ELevation ELevation6 = new ELevation();
        ELevation6.XAngle = 11.35953f;
        ELevation6.range1.LeftAngle = 349.3f - RLAngleOffset;
        ELevation6.range1.RightAngle = 355.2f + RLAngleOffset;
        ELevation6.range1.Speed = 4.89999f;
        ELevation6.rangelist.Add(ELevation6.range1);
        Level10_CorrectionSystem.Add(ELevation6);

        ELevation ELevation7 = new ELevation();
        ELevation7.XAngle = 17.09884f;
        ELevation7.range1.LeftAngle = 7.1f - RLAngleOffset;
        ELevation7.range1.RightAngle = 16.5f + RLAngleOffset;
        ELevation7.range1.Speed = 3.6999f;
        ELevation7.rangelist.Add(ELevation7.range1);
        Level10_CorrectionSystem.Add(ELevation7);

        ELevation ELevation8 = new ELevation();
        ELevation8.XAngle = 17.07242f;
        ELevation8.range1.LeftAngle = 343.0f - RLAngleOffset;
        ELevation8.range1.RightAngle = 352.4f + RLAngleOffset;
        ELevation8.range1.Speed = 3.6999f;
        ELevation8.rangelist.Add(ELevation8.range1);
        Level10_CorrectionSystem.Add(ELevation8);
    }
    public void ResetCurrent_CorrectionSystem()
    {
        Current_CorrectionSystem.Clear();
    }
    // Use this for initialization
    void Awake()
    {
        _instance = this;
		Level1_CorrectionSystem.Clear ();
		Level2_CorrectionSystem.Clear ();
		Level3_CorrectionSystem.Clear ();
		Level4_CorrectionSystem.Clear ();
        Level5_CorrectionSystem.Clear ();
        Level6_CorrectionSystem.Clear();
        Level7_CorrectionSystem.Clear();
        Level8_CorrectionSystem.Clear();
        Level9_CorrectionSystem.Clear();
        Level10_CorrectionSystem.Clear();
        Current_CorrectionSystem.Clear();

    }

    void Start () {
        //第一關最佳OFFSET
       ElevationOffset = 0.7f;
       RLAngleOffset = 7.0f;
       SpeedOffset = 1.0f;
}
	
	// Update is called once per frame
	void Update () {

        ChangeCorrectionSystemData();

    }
    void ChangeCorrectionSystemData()
    {
        //根據現在是第幾關 替換Current_CorrectionSystem
        if (LevelManager.instance._currentLevel == 1)
        {
            if(Level1_CorrectionSystem.Count == 0)
            {
                SetLevel1CorrectionData();
				Current_CorrectionSystem = Level1_CorrectionSystem;
                ElevationOffset = 0.7f;
                RLAngleOffset = 7.0f;
                SpeedOffset = 1.0f;
            }
            else if(LevelManager.instance.changelevel)
            {
                Current_CorrectionSystem = Level1_CorrectionSystem;
                LevelManager.instance.changelevel = false;
                ElevationOffset = 0.7f;
                RLAngleOffset = 7.0f;
                SpeedOffset = 1.0f;

            }

        }
        if (LevelManager.instance._currentLevel == 2)
        {
			if (Level2_CorrectionSystem.Count == 0)
            {
                SetLevel2CorrectionData();
				Current_CorrectionSystem = Level2_CorrectionSystem;
                ElevationOffset = 1.3f;
                RLAngleOffset = 7.0f;
                SpeedOffset = 1.0f;
            }
            else if(LevelManager.instance.changelevel)
            {
                Current_CorrectionSystem = Level2_CorrectionSystem;
                ElevationOffset = 1.3f;
                RLAngleOffset = 7.0f;
                SpeedOffset = 1.0f;
                LevelManager.instance.changelevel = false;
            }
        }
        if (LevelManager.instance._currentLevel == 3)
        {
			if (Level3_CorrectionSystem.Count == 0)
            {
                SetLevel3CorrectionData();
				Current_CorrectionSystem = Level3_CorrectionSystem;
                ElevationOffset = 0.7f;
                RLAngleOffset = 7.0f;
                SpeedOffset = 1.0f;


            }
            else if (LevelManager.instance.changelevel)
            {
                Current_CorrectionSystem = Level3_CorrectionSystem;
                ElevationOffset = 0.7f;
                RLAngleOffset = 7.0f;
                SpeedOffset = 1.0f;
                LevelManager.instance.changelevel = false;


            }

        }
        if (LevelManager.instance._currentLevel == 4)
        {
			if (Level4_CorrectionSystem.Count == 0)
            {
                SetLevel4CorrectionData();
				Current_CorrectionSystem = Level4_CorrectionSystem;
                ElevationOffset = 0.7f;
                RLAngleOffset = 7.0f;
                SpeedOffset = 1.0f;

            }
            else if (LevelManager.instance.changelevel)
            {
                Current_CorrectionSystem = Level4_CorrectionSystem;
                ElevationOffset = 0.7f;
                RLAngleOffset = 7.0f;
                SpeedOffset = 1.0f;
                LevelManager.instance.changelevel = false;


            }

        }
        if (LevelManager.instance._currentLevel == 5)
        {
            if (Level5_CorrectionSystem.Count == 0)
            {
                SetLevel5CorrectionData();
                Current_CorrectionSystem = Level5_CorrectionSystem;
                ElevationOffset = 1.2f;
                RLAngleOffset = 0.5f;
                SpeedOffset = 1.0f;

            }
            else if (LevelManager.instance.changelevel)
            {
                Current_CorrectionSystem = Level5_CorrectionSystem;
                ElevationOffset = 1.2f;
                RLAngleOffset = 0.5f;
                SpeedOffset = 1.0f;
                LevelManager.instance.changelevel = false;
            }

        }
        if (LevelManager.instance._currentLevel == 6)
        {
            if (Level6_CorrectionSystem.Count == 0)
            {
                SetLevel6CorrectionData();
                Current_CorrectionSystem = Level6_CorrectionSystem;
                ElevationOffset = 0.7f;
                RLAngleOffset = 7.0f;
                SpeedOffset = 1.0f;

            }
            else if (LevelManager.instance.changelevel)
            {
                Current_CorrectionSystem = Level6_CorrectionSystem;
                ElevationOffset = 0.7f;
                RLAngleOffset = 7.0f;
                SpeedOffset = 1.0f;
                LevelManager.instance.changelevel = false;
            }

        }
        if (LevelManager.instance._currentLevel == 7)
        {
            if (Level7_CorrectionSystem.Count == 0)
            {
                SetLevel7CorrectionData();
                Current_CorrectionSystem = Level7_CorrectionSystem;
                ElevationOffset = 1.8f;
                RLAngleOffset = 7.0f;
                SpeedOffset = 1.0f;

            }
            else if (LevelManager.instance.changelevel)
            {
                Current_CorrectionSystem = Level7_CorrectionSystem;
                ElevationOffset = 1.8f;
                RLAngleOffset = 7.0f;
                SpeedOffset = 1.0f;
                LevelManager.instance.changelevel = false;
            }

        }
        if (LevelManager.instance._currentLevel == 8)
        {
            if (Level8_CorrectionSystem.Count == 0)
            {
                SetLevel8CorrectionData();
                Current_CorrectionSystem = Level8_CorrectionSystem;
                ElevationOffset = 1.1f;
                RLAngleOffset = 7.0f;
                SpeedOffset = 1.0f;

            }
            else if (LevelManager.instance.changelevel)
            {
                Current_CorrectionSystem = Level8_CorrectionSystem;
                ElevationOffset = 1.1f;
                RLAngleOffset = 7.0f;
                SpeedOffset = 1.0f;
                LevelManager.instance.changelevel = false;
            }

        }
        if (LevelManager.instance._currentLevel == 9)
        {
            if (Level9_CorrectionSystem.Count == 0)
            {
                SetLevel9CorrectionData();
                Current_CorrectionSystem = Level9_CorrectionSystem;
                ElevationOffset = 0.7f;
                RLAngleOffset = 7.0f;
                SpeedOffset = 1.0f;

            }
            else if (LevelManager.instance.changelevel)
            {
                Current_CorrectionSystem = Level9_CorrectionSystem;
                ElevationOffset = 0.7f;
                RLAngleOffset = 7.0f;
                SpeedOffset = 1.0f;
                LevelManager.instance.changelevel = false;
            }

        }
        if (LevelManager.instance._currentLevel == 10)
        {
            if (Level10_CorrectionSystem.Count == 0)
            {
                SetLevel10CorrectionData();
                Current_CorrectionSystem = Level10_CorrectionSystem;
                ElevationOffset = 1.3f;
                RLAngleOffset = 0.5f;
                SpeedOffset = 1.0f;

            }
            else if (LevelManager.instance.changelevel)
            {
                Current_CorrectionSystem = Level10_CorrectionSystem;
                ElevationOffset = 1.3f;
                RLAngleOffset = 0.5f;
                SpeedOffset = 1.0f;
                LevelManager.instance.changelevel = false;
            }

        }
    }

    public void DoCorrectionTestVersion()
    {
        //誤差設定越小，難度越難
        //丟球
        //抓球得速度
        //抓攝影機rotation X 無條件捨去取到小數點.兩位
        //抓攝影機rotation y
        //用rotation X 找 CorrectionSystem 最接近的 ELevation （誤差以內），if 找不到return
        //if 找到 再把攝影機rotation y 無條件捨去取到小數點.一位 再用找到ELevation 最接近rotation y的左右角度range （誤差以內），if 找不到return
        //if 找到 再把球得速度，無條件捨去取到小數點.一位 再用找到range 裡 的Speed（誤差以內），if 找不到return
        //if 找到 把出球點的rotation x rotation y = 攝影機rotation x , rotation y , 球的初速度 ＝ Speed
        //抓球得速度
        //Debug.Log("進入矯正 ? 有");
		_power = Mark._instiate._Speed;

        float rotationx = Mark._instiate.rotationx;
        Debug.Log("抓到攝影機仰角 X : " + rotationx);
		//抓攝影機rotation y
		float rotationy = Mark._instiate.rotationy;
		Debug.Log("抓到攝影機仰角 Y : " + rotationy);

        //rotationx = (float)Math.Round((rotationx), 3);
        ////Debug.Log("取攝影機仰角 X 到.三位: " + rotationx);
        //rotationx = (float)Math.Floor(rotationx * 100.0f);
        ////Debug.Log("取攝影機仰角 X 乘以 10 濾掉小數點: " + rotationx);
        //rotationx = rotationx * 0.01f;
        ////Debug.Log("取攝影機仰角 X 乘以 0.01 濾掉回到.兩位(可能有雜質): " + rotationx);
        //rotationx = (float)Math.Round((rotationx), 2);
        ////Debug.Log("取攝影機仰角 X 取到.兩位(乾淨): " + rotatelaonx);

        //用rotation X 找 CorrectionSystem 最接近的 ELevation （誤差以內），if 找不到return
        for (int i = 0; i < Current_CorrectionSystem.Count; i++)
        {
            //Debug.Log("找到資料庫有仰角資料嗎 幾筆 : " + Current_CorrectionSystem.Count);
            if (Current_CorrectionSystem[i].XAngle - ElevationOffset < rotationx && rotationx < Current_CorrectionSystem[i].XAngle + ElevationOffset)
            {
                Debug.Log("xxxxxxxxxxxxxxxxxxxxxxxxxxx" + Current_CorrectionSystem[i].XAngle);
                rotationx = Current_CorrectionSystem[i].XAngle;

                for (int j = 0; j < Current_CorrectionSystem[i].rangelist.Count; j++)
                {
					float rightangle = Current_CorrectionSystem[i].rangelist[j].RightAngle;
                    float leftangle = Current_CorrectionSystem[i].rangelist[j].LeftAngle;

                    if (rightangle - leftangle > 0)
                    {
                        if ((leftangle <= rotationy) && (rotationy <= rightangle))
                        {
                            //Debug.Log("抓到data資料 Y 左邊極值(有-OFFSET) : " + leftangle + "抓到資料 Y 右邊 : " + rightangle);
							if((leftangle <= rotationy) && (rotationy <= (leftangle + RLAngleOffset)) && j == 0)
                            {
                                //Debug.Log(" Y 左邊極值(有-OFFSET) : " + leftangle + " Y 能進的左邊極值邊 : " + (leftangle + RLAngleOffset));
                                Debug.Log("J=0: " + rotationy);
                                rotationy = leftangle + RLAngleOffset;
                                //Debug.Log("修正後y 成功" + rotationy);
                            }
							if (((rightangle - RLAngleOffset) <= rotationy) && (rotationy <= rightangle) && (j + 1) == Current_CorrectionSystem[i].rangelist.Count)
                            {
                                //Debug.Log("  Y 能進右邊極值(+OFFSET) : " + rightangle + " Y 能進的右邊極值邊 : " + (rightangle - RLAngleOffset));
                                Debug.Log("J=LAST: " + rotationy);
                                rotationy = rightangle - RLAngleOffset;
                                //Debug.Log("修正後y 成功" + rotationy);
                            }
                            Debug.Log("222抓到資料 Y 左邊 : " + leftangle + "抓到資料 Y 右邊 : " + rightangle);
                            float speed = Current_CorrectionSystem[i].rangelist[j].Speed;
                            Debug.Log("222抓到的DATA速度 : " + speed);

                            if ((speed - SpeedOffset <= _power) && (_power <= speed + SpeedOffset))
                            {
								_power = speed;

								Debug.Log("222修正角度 rotationx : " + rotationx + " rotationy : " + rotationy + "速度 : " + _power);
								Mark._instiate.ThrowPosition.transform.rotation = new Quaternion();
								Mark._instiate.ThrowPosition.transform.Rotate(0.0f,rotationy,0.0f,Space.World);
								Mark._instiate.ThrowPosition.transform.Rotate(rotationx,0.0f,0.0f,Space.Self);

								Mark._instiate._Speed = _power;
								return;
                            }
                            else { return; }
                        }
                        else { continue; }
                    }
                    else if (rightangle - leftangle < 0)
                    {
                        if (((leftangle <= rotationy) && (rotationy <= 360.0f)) || ((0 <= rotationy) && (rotationy <= rightangle)))
                        {
                            if ((leftangle <= rotationy) && (rotationy <= (leftangle + RLAngleOffset)) && j == 0)
                            {
                                //Debug.Log(" Y 左邊極值(有-OFFSET) : " + leftangle + " Y 能進的左邊極值邊 : " + (leftangle + RLAngleOffset));
                                rotationy = leftangle + RLAngleOffset;
                                //Debug.Log("修正後y 成功" + rotationy);
                            }
                            if (((rightangle - RLAngleOffset) <= rotationy) && (rotationy <= rightangle) && (j + 1) == Current_CorrectionSystem[i].rangelist.Count)
                            {
                                //Debug.Log("  Y 能進右邊極值(+OFFSET) : " + rightangle + " Y 能進的右邊極值邊 : " + (leftangle - RLAngleOffset));
                                rotationy = rightangle - RLAngleOffset;
                                //Debug.Log("修正後y 成功" + rotationy);
                            }
                            Debug.Log("333抓到資料 Y 左邊 : " + leftangle + "抓到資料 Y 右邊 : " + rightangle);
                            float speed = Current_CorrectionSystem[i].rangelist[j].Speed;
							Debug.Log("333抓到的DATA速度 : " + speed);
 
                            if ((speed - SpeedOffset <= _power) && (_power <= speed + SpeedOffset))
                            {
								_power = speed;
                                Debug.Log("333修正角度 rotationx : " + rotationx + " rotationy : " + rotationy + "速度 : " + _power);
								Mark._instiate.ThrowPosition.transform.rotation = new Quaternion();
								Mark._instiate.ThrowPosition.transform.Rotate(0.0f,rotationy,0.0f,Space.World);
								Mark._instiate.ThrowPosition.transform.Rotate(rotationx,0.0f,0.0f,Space.Self);
								Mark._instiate._Speed = _power;
								return;
							}
                            else { return; }
                        }
                        else { continue; }
                    }
                    else
                    {

                        //攝影機角度小於0
                        if (360.0f - RLAngleOffset < rotationy && rotationy < 360.0f)
                        {
                            rotationy = leftangle + RLAngleOffset;
                        }
                        //攝影機角度大等於0
                        if (0.0f <= rotationy && rotationy < RLAngleOffset)
                        {
                            rotationy = rightangle - RLAngleOffset;
                        }

                        Debug.Log("111抓到資料 Y 左邊 : " + leftangle + "抓到資料 Y 右邊 : " + rightangle);
                        float speed = Current_CorrectionSystem[i].rangelist[j].Speed;
                        Debug.Log("111抓到的DATA速度 : " + speed);

                        if ((speed - SpeedOffset <= _power) && (_power <= speed + SpeedOffset))
                        {
                            _power = speed;
                            Debug.Log("111修正角度 rotationx : " + rotationx + " rotationy : " + rotationy + "速度 : " + _power);
                            Mark._instiate.ThrowPosition.transform.rotation = new Quaternion();
                            Mark._instiate.ThrowPosition.transform.Rotate(0.0f, rotationy, 0.0f, Space.World);
                            Mark._instiate.ThrowPosition.transform.Rotate(rotationx, 0.0f, 0.0f, Space.Self);
                            Mark._instiate._Speed = _power;
                            return;
                        }
                    }
                }
            }
            else
            {
                continue;
            }
            return;
        }
    }
}
