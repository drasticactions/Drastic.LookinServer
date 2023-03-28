using System;
using ObjCRuntime;

namespace LookinServer
{
	[Verify (InferredFromMemberPrefix)]
	public enum Lookin : uint
	{
		RequestTypePing = 200,
		RequestTypeApp = 201,
		RequestTypeHierarchy = 202,
		RequestTypeHierarchyDetails = 203,
		RequestTypeModification = 204,
		RequestTypeAttrModificationPatch = 205,
		RequestTypeInvokeMethod = 206,
		RequestTypeFetchObject = 207,
		RequestTypeFetchImageViewImage = 208,
		RequestTypeModifyRecognizerEnable = 209,
		RequestTypeAllAttrGroups = 210,
		RequestTypeClassesAndMethodTraceLit = 212,
		RequestTypeAllSelectorNames = 213,
		RequestTypeAddMethodTrace = 214,
		RequestTypeDeleteMethodTrace = 215,
		Push_BringForwardScreenshotTask = 303,
		Push_CanceHierarchyDetails = 304,
		Push_MethodTraceRecord = 403
	}

	[Verify (InferredFromMemberPrefix)]
	public enum LookinErrCode_
	{
		Default = -400,
		Inner = -401,
		PeerTalk = -402,
		NoConnect = -403,
		PingFailForTimeout = -404,
		Timeout = -405,
		Discard = -406,
		PingFailForBackgroundState = -407,
		ObjectNotFound = -500,
		ModifyValueTypeInvalid = -501,
		Exception = -502,
		ServerVersionTooHigh = -600,
		ServerVersionTooLow = -601,
		ServerIsPrivate = -602,
		ClientIsPrivate = -603,
		UnsupportedFileType = -700
	}

	[Flags]
	[Native]
	public enum LookinPreviewBitMask : ulong
	{
		None = 0x0,
		Selectable = 1uL << 1,
		Unselectable = 1uL << 2,
		HasLight = 1uL << 3,
		NoLight = 1uL << 4
	}

	[Native]
	public enum LookinDisplayItemImageEncodeType : ulong
	{
		None,
		NSData,
		Image
	}

	[Native]
	public enum LookinDoNotFetchScreenshotReason : ulong
	{
		FetchScreenshotPermitted,
		DoNotFetchScreenshotForTooLarge,
		DoNotFetchScreenshotForUserConfig
	}

	[Native]
	public enum LookinDisplayItemProperty : ulong
	{
		None,
		FrameToRoot,
		DisplayingInHierarchy,
		InHiddenHierarchy,
		IsExpandable,
		IsExpanded,
		SoloScreenshot,
		GroupScreenshot,
		IsSelected,
		IsHovered,
		AvoidSyncScreenshot,
		InNoPreviewHierarchy,
		IsInSearch,
		HighlightedSearchString
	}

	[Native]
	public enum LKS_PerspectiveDimension : ulong
	{
		LKS_PerspectiveDimension2D,
		LKS_PerspectiveDimension3D
	}

	[Native]
	public enum LookinAppInfoDevice : long
	{
		Simulator,
		IPad,
		Others
	}

	[Native]
	public enum LookinAttrType : long
	{
		None,
		Void,
		Char,
		Int,
		Short,
		Long,
		LongLong,
		UnsignedChar,
		UnsignedInt,
		UnsignedShort,
		UnsignedLong,
		UnsignedLongLong,
		Float,
		Double,
		Bool,
		Sel,
		Class,
		CGPoint,
		CGVector,
		CGSize,
		CGRect,
		CGAffineTransform,
		UIEdgeInsets,
		UIOffset,
		NSString,
		EnumInt,
		EnumLong,
		UIColor,
		CustomObj
	}

	[Native]
	public enum LookinCodingValueType : long
	{
		Unknown,
		Char,
		Double,
		Float,
		LongLong,
		Bool,
		Color,
		Enum,
		Image
	}

	[Native]
	public enum LookinAttributesSectionStyle : long
	{
		Default,
		LookinAttributesSectionStyle0,
		LookinAttributesSectionStyle1,
		LookinAttributesSectionStyle2
	}

	[Native]
	public enum LookinConstraintItemType : long
	{
		Unknown,
		Nil,
		View,
		Self,
		Super,
		LayoutGuide
	}

	[Native]
	public enum LookinEventHandlerType : long
	{
		TargetAction,
		Gesture
	}

	[Native]
	public enum LookinStaticAsyncUpdateTaskType : long
	{
		NoScreenshot,
		SoloScreenshot,
		GroupScreenshot
	}

	public enum PTUSBHubError : uint
	{
		BadDevice = 2,
		ConnectionRefused = 3
	}
}
