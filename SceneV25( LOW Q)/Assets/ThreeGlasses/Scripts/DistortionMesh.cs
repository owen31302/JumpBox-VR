﻿/************************************************************************************

Filename    :   DistortionMesh.cs
Content     :   Interface for the Three Glasses Device
Created     :   March 31, 2015
Authors     :   Xiong Fei

Copyright   :   Copyright 2015 ThreeGlasses VR, Inc. All Rights reserved.

************************************************************************************/
using UnityEngine;
using System.Runtime.InteropServices;

namespace SZVR_SDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DistMeshVert
    {
        public float screenPosNDC_x;
        public float screenPosNDC_y;
        public float timewarpLerp;
        public float shade;
        public float uv_u;
        public float uv_v;
        public float uvR_u;
        public float uvR_v;
        public float uvG_u;
        public float uvG_v;
        public float uvB_u;
        public float uvB_v;
    };

	public class DistortionMesh
	{
		public const string vrLib = "SZVRPlugin";

        //[DllImport(vrLib)]
        //private static extern void SZVR_GetDistortionMeshInfo(ref int resH, ref int resV, ref float fovH, ref float fovV );

        [DllImport(vrLib)]
        private static extern void SZVR_GetFov(ref float fov);

		[DllImport(vrLib)]
        private static extern void SZVR_DistortionMeshParameter(ref int numVerts, ref int numIndicies, bool rightEye);

		[DllImport(vrLib)]
        private static extern void SZVR_DistortionMesh(int vertexNum, DistMeshVert[] eyeVertex, int indiciesNum, int[] eyeIndicies, bool rightEye, bool flipY);

        /// <summary>
        /// GenerateMesh.
        /// </summary>
        /// <param name="lc"></param>
        /// <param name="rightEye"></param>
        /// <param name="flipY"></param>
        /// <returns></returns>
		public static Mesh GenerateMesh(bool rightEye, bool flipY)
		{
			Mesh mesh = new Mesh();

			int numVerts = 0;
			int numIndicies = 0;

            SZVR_DistortionMeshParameter(ref numVerts, ref numIndicies, rightEye);

			DistMeshVert[] meshVerts = new DistMeshVert[numVerts];
			int[] triIndices = new int[numIndicies];

            SZVR_DistortionMesh(numVerts, meshVerts, numIndicies, triIndices, rightEye, flipY);

			Vector3[] positions = new Vector3[numVerts];
            //Vector2[] uv = new Vector2[numVerts];
            //Vector2[] uv1 = new Vector2[numVerts];
            Vector2[] uv   = new Vector2[numVerts];
            Vector2[] uvR  = new Vector2[numVerts];
            Vector4[] uvGB = new Vector4[numVerts];

			for(int i = 0; i < numVerts; i++)
			{
				positions[i].x = meshVerts[i].screenPosNDC_x;
				positions[i].y = meshVerts[i].screenPosNDC_y;
				positions[i].z = meshVerts[i].shade;
// 				uv[i].x        = meshVerts[i].uv_u;
// 				uv[i].y        = meshVerts[i].uv_v;
// 				uv1[i].x       = meshVerts[i].uv1_u;
// 				uv1[i].y       = meshVerts[i].uv1_v;
                uv[i].x        = meshVerts[i].uv_u;
                uv[i].y        = meshVerts[i].uv_v;
                uvR[i].x       = meshVerts[i].uvR_u;
                uvR[i].y       = meshVerts[i].uvR_v;
                uvGB[i].x      = meshVerts[i].uvG_u;
                uvGB[i].y      = meshVerts[i].uvG_v;
                uvGB[i].z      = meshVerts[i].uvB_u;
                uvGB[i].w      = meshVerts[i].uvB_v;
			}

			mesh.vertices  = positions;
// 			mesh.uv        = uv;
// #if UNITY_5
// 			mesh.uv2       = uv1;
// #elif UNITY_5_0_0
// 			mesh.uv1       = uv1;
// #else
// 			mesh.uv1       = uv1;
// #endif
            mesh.uv        = uv;
#if UNITY_5
            mesh.uv2       = uvR;
#elif UNITY_4
            mesh.uv1       = uvR;
#endif
            mesh.tangents   = uvGB;
			mesh.triangles = triIndices;

            //Debug.Log("Mesh:" + mesh.triangles[10].ToString() +"Data:"+ triIndices[10].ToString());
			
			return mesh;
		}

        /*
		/// <summary>
		/// Gets the field of view.
		/// </summary>
		/// <returns>Float type value.</returns>
        public static float GetFOV()
        {
            float fov = 0;
            SZVR_GetFov(ref fov);
            return fov;
        }
         */
	}
}
