/************************************************************************************

Filename    :   DeviceInterface.cs
Content     :   Interface for the Three Glasses Device
Created     :   March 31, 2015
Authors     :   Xiong Fei

Copyright   :   Copyright 2015 ThreeGlasses VR, Inc. All Rights reserved.

************************************************************************************/
using UnityEngine;
using System.Runtime.InteropServices;
using System;

namespace SZVR_SDK
{
	public class DeviceInterface
	{
		public const string vrLib = "SZVRPlugin";
		
		[DllImport (vrLib)]
        private static extern bool SZVR_GetCameraOrientation(ref float ox, ref float oy, ref float oz, ref float ow);

        [DllImport(vrLib)]
        private static extern bool SZVR_GetHmdTouchPad(ref float tx, ref float ty);

        [DllImport(vrLib)]
        private static extern bool SZVR_PayApp(string appKey);

        [DllImport("user32.dll")]
        static extern IntPtr SetWindowLong(IntPtr hwnd, int _nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        static extern IntPtr GetActiveWindow();

		public static float ipd = 0.064f;

        //private const uint SWP_NOMOVE = 0x2;
        //private const uint SWP_NOSIZE = 1;
        //private const uint SWP_NOZORDER = 0x4;
        //private const uint SWP_HIDEWINDOW = 0x0080;
        private const uint SWP_SHOWWINDOW = 0x0040;
        private const int GWL_STYLE = -16;
        private const int WS_BORDER = 1;

        public static void SetPositionAndReslution()
        {
            string[] args = Environment.GetCommandLineArgs();

            // VRUIPopPage.PopPromptPage(args[0] + "" + args[1] + "" + args[2] + "" + args[3] + "" + args[4] + "" + args[5]);

            int x = 0;
            int y = 0;
            int w = 0;
            int h = 0;

            if (args.Length == 6)
            {
                if (int.TryParse(args[2], out x) &&
                    int.TryParse(args[3], out y) &&
                    int.TryParse(args[4], out w) &&
                    int.TryParse(args[5], out h))
                {
                    Screen.SetResolution(w, h, false);
                    SetWindowLong(GetActiveWindow(), GWL_STYLE, WS_BORDER);
                    SetWindowPos(GetActiveWindow(), 0, x, y, w, h, SWP_SHOWWINDOW);
                }
                else
                {
                    Application.Quit();
                }
            }
        }

		/// <summary>
		/// Orients the sensor.
		/// </summary>
		/// <param name="q">Q.</param>
		private static void OrientSensor(ref Quaternion q)
		{
			q.x = -q.x;
			q.y = -q.y;
		}

		/// <summary>
		/// Sensor data into the direction of the data.
		/// </summary>
		/// <returns>The camera orientation.</returns>
		public static bool GetCameraOrientation(ref Quaternion rotation)
		{
			Quaternion o = Quaternion.identity;

			float ow = 0, ox = 0, oy = 0, oz = 0;
			
			bool IsSensorAttach = SZVR_GetCameraOrientation(ref  ox, ref  oy, ref  oz, ref  ow);
			
			o.w = ow; o.x = ox; o.y = oy; o.z = oz;
			
			OrientSensor(ref o);
            rotation = o;

            return IsSensorAttach;
		}

        public static void ResetInitOrientation()
        {
            Quaternion o = Quaternion.identity;

			float ow = 0, ox = 0, oy = 0, oz = 0;

            bool IsSensorAttach = SZVR_GetCameraOrientation(ref  ox, ref  oy, ref  oz, ref  ow);
            o.w = ow; o.x = ox; o.y = oy; o.z = oz;
            OrientSensor(ref o);

            Vector3 v = o.eulerAngles;
            v = new Vector3(0, v.y, 0);
            o = Quaternion.Euler(v);
            if (IsSensorAttach)
                SZVRDevice.sensorOffset = Quaternion.Inverse(o);
        }

        public static bool GetTouch(ref Vector2 pos)
        {
            //Vector2 p = Vector2.zero;

            float tx = 0, ty = 0;

            bool IsTouchAttach = SZVR_GetHmdTouchPad(ref  tx, ref  ty);

            pos.x = tx; 
            pos.y = ty;

            return IsTouchAttach;
        }
	}
}
