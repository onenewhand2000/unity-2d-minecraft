using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwoDMinecraft.Core
{
    [System.Serializable]
    public class SerializableVector3Int
    {
        public int x;
        public int y;
        public int z;

        public SerializableVector3Int(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static implicit operator Vector3Int(SerializableVector3Int serializableVector3Int)
        {
            return new Vector3Int(serializableVector3Int.x, serializableVector3Int.y, serializableVector3Int.z);
        }

        public static implicit operator SerializableVector3Int(Vector3Int vector3Int)
        {
            return new SerializableVector3Int(vector3Int.x, vector3Int.y, vector3Int.z);
        }
    }
}
