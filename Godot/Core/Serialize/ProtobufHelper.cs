using System;
using System.ComponentModel;
using System.IO;
using ProtoBuf.Meta;
using Godot;

namespace ET
{
    public static class ProtobufHelper
    {
		public static void Init()
		{
		}
        
		static ProtobufHelper()
		{
			RuntimeTypeModel.Default.Add(typeof(Vector2), false).Add("X", "Y");
			RuntimeTypeModel.Default.Add(typeof(Vector3), false).Add("X", "Y", "Z");
			RuntimeTypeModel.Default.Add(typeof(Vector4), false).Add("X", "Y", "Z", "W");
			RuntimeTypeModel.Default.Add(typeof(Quaternion), false).Add("X", "Y", "Z", "W");
		}
		
		public static object Deserialize(Type type, byte[] bytes, int index, int count)
		{
			using MemoryStream stream = new MemoryStream(bytes, index, count);
			object o = ProtoBuf.Serializer.Deserialize(type, stream);
			if (o is ISupportInitialize supportInitialize)
			{
				supportInitialize.EndInit();
			}
			return o;
		}

        public static byte[] Serialize(object message)
		{
			using MemoryStream stream = new MemoryStream();
			ProtoBuf.Serializer.Serialize(stream, message);
			return stream.ToArray();
		}

        public static void Serialize(object message, Stream stream)
        {
            ProtoBuf.Serializer.Serialize(stream, message);
        }

        public static object Deserialize(Type type, Stream stream)
        {
	        object o = ProtoBuf.Serializer.Deserialize(type, stream);
	        if (o is ISupportInitialize supportInitialize)
	        {
		        supportInitialize.EndInit();
	        }
	        return o;
        }
    }
}