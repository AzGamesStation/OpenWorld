using FullSerializer;

namespace Game.GlobalComponent
{
	public class MiamiSerializier
	{
		public static string JSONSerialize(object obj)
		{
			fsSerializer fsSerializer = new fsSerializer();
			fsSerializer.TrySerialize(obj, out fsData data);
			return data.ToString();
		}

		public static object JSONDeserialize(string str)
		{
			return JSONDeserialize<object>(str);
		}

		public static T JSONDeserialize<T>(string str)
		{
			fsData data = fsJsonParser.Parse(str);
			fsSerializer fsSerializer = new fsSerializer();
			T instance = default(T);
			fsSerializer.TryDeserialize(data, ref instance);
			return instance;
		}
	}
}
