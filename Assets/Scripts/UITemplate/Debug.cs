using UnityEngine.UI;

namespace UITemplate
{
	public class Debug
	{
		private static Text logText;

		private static void LogMessage(string message)
		{
			if (logText != null)
			{
				logText.text = logText.text + "\n" + message;
			}
		}

		private static void InitLog()
		{
		}
	}
}
