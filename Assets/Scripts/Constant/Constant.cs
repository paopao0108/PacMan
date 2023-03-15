using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constant
{
    // λ����Ϣ
    public static class Position
    {
        public static Vector3 blueGhostPos = new Vector3(2f, 1.6f, 4f);
        public static Vector3 orangeGhostPos = new Vector3(1f, 1.6f, 4f);
        public static Vector3 redGhostPos = new Vector3(0f, 1.6f, 4f);
        public static Vector3 pinkGhostPos = new Vector3(-1f, 1.6f, 4f);
    }

    // ӳ���ϵ
    public class Mapping
    {
        public static Dictionary<string, Vector3> GhostPos = new Dictionary<string, Vector3>
        {
            {"blue", Position.blueGhostPos },
            {"orange", Position.orangeGhostPos },
            {"red", Position.redGhostPos },
            {"pink", Position.pinkGhostPos },
        };
    }
}
