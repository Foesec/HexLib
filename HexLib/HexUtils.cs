using System;
using UnityEngine;


namespace HexLib
{
    public class HexUtils
    {
        public static Vector2 HexCorner(Vector2 center, float size, int corner)
        {
            float angleDeg = 60 * corner + 30;
            float angleRad = Mathf.PI / 180 * angleDeg;
            return new Vector2(center.x + size * Mathf.Cos(angleRad),
                               center.y + size * Mathf.Sin(angleRad));
        }

        #region conversions

        public static Vector2 CubeToAxial(Vector3 cube)
        {
            return new Vector2(cube.x, cube.z);
        }

        public static Vector3 AxialToCube(Vector2 axial)
        {
            return new Vector3(axial.x,
                              -axial.x - axial.y,
                               axial.y);
        }

        public static Vector2 CubeToOffset(Vector3 cube)
        {
            return new Vector2(cube.x + (cube.z - ((int)cube.z & 1)) / 2, // n & 1 =^= isEven
                               cube.z);
        }

        public static Vector3 OffsetToCube(Vector2 offset)
        {
            float x = offset.x - (offset.y - ((int)offset.y & 1)) / 2;
            return new Vector3(x, -x - offset.y, offset.y);
        }

        #endregion
        #region neighbours

        private static Vector3[] cubeDir = new Vector3[] {
            new Vector3(1, -1, 0), new Vector3(1, 0, -1), new Vector3(0, 1, -1),
            new Vector3(-1, 1, 0), new Vector3(-1, 0, 1), new Vector3(0, -1, 1)
        };

        private static Vector2[] axialDir = new Vector2[]{
            new Vector2( 1, 0), new Vector2( 1, -1), new Vector2(0, -1),
            new Vector2(-1, 0), new Vector2(-1,  1), new Vector2(0,  1)
        };

        #endregion


    }
}
