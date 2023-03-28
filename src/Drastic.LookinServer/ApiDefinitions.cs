using Foundation;

namespace LookinServer
{
	[Static]
	partial interface Constants
	{
		// extern double LookinServerVersionNumber;
		[Field ("LookinServerVersionNumber", "__Internal")]
		double LookinServerVersionNumber { get; }

		// // extern const unsigned char[] LookinServerVersionString;
		// [Field ("LookinServerVersionString", "__Internal")]
		// byte[] LookinServerVersionString { get; }
	}
}
