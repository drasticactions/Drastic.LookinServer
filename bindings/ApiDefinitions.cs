using System;
using CoreAnimation;
using CoreFoundation;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace LookinServer
{
	// @interface Lookin (CALayer)
	[Category]
	[BaseType (typeof(CALayer))]
	interface CALayer_Lookin
	{
		// -(void)lookin_removeImplicitAnimations;
		[Export ("lookin_removeImplicitAnimations")]
		void Lookin_removeImplicitAnimations ();
	}

	// @interface LookinServer (CALayer)
	[Category]
	[BaseType (typeof(CALayer))]
	interface CALayer_LookinServer
	{
		// @property (nonatomic, weak) UIView * lks_hostView;
		[Export ("lks_hostView", ArgumentSemantic.Weak)]
		UIView Lks_hostView { get; set; }

		// -(UIWindow *)lks_window;
		[Export ("lks_window")]
		[Verify (MethodToProperty)]
		UIWindow Lks_window { get; }

		// -(CGRect)lks_frameInWindow:(UIWindow *)window;
		[Export ("lks_frameInWindow:")]
		CGRect Lks_frameInWindow (UIWindow window);

		// @property (assign, nonatomic) BOOL lks_isLookinPrivateLayer;
		[Export ("lks_isLookinPrivateLayer")]
		bool Lks_isLookinPrivateLayer { get; set; }

		// @property (assign, nonatomic) BOOL lks_avoidCapturing;
		[Export ("lks_avoidCapturing")]
		bool Lks_avoidCapturing { get; set; }

		// -(UIImage *)lks_groupScreenshotWithLowQuality:(BOOL)lowQuality;
		[Export ("lks_groupScreenshotWithLowQuality:")]
		UIImage Lks_groupScreenshotWithLowQuality (bool lowQuality);

		// -(UIImage *)lks_soloScreenshotWithLowQuality:(BOOL)lowQuality;
		[Export ("lks_soloScreenshotWithLowQuality:")]
		UIImage Lks_soloScreenshotWithLowQuality (bool lowQuality);

		// -(NSArray<NSArray<NSString *> *> *)lks_relatedClassChainList;
		[Export ("lks_relatedClassChainList")]
		[Verify (MethodToProperty)]
		NSArray<NSString>[] Lks_relatedClassChainList { get; }

		// -(NSArray<NSString *> *)lks_selfRelation;
		[Export ("lks_selfRelation")]
		[Verify (MethodToProperty)]
		string[] Lks_selfRelation { get; }

		// @property (nonatomic, strong) UIColor * lks_backgroundColor;
		[Export ("lks_backgroundColor", ArgumentSemantic.Strong)]
		UIColor Lks_backgroundColor { get; set; }

		// @property (nonatomic, strong) UIColor * lks_borderColor;
		[Export ("lks_borderColor", ArgumentSemantic.Strong)]
		UIColor Lks_borderColor { get; set; }

		// @property (nonatomic, strong) UIColor * lks_shadowColor;
		[Export ("lks_shadowColor", ArgumentSemantic.Strong)]
		UIColor Lks_shadowColor { get; set; }

		// @property (assign, nonatomic) CGFloat lks_shadowOffsetWidth;
		[Export ("lks_shadowOffsetWidth")]
		nfloat Lks_shadowOffsetWidth { get; set; }

		// @property (assign, nonatomic) CGFloat lks_shadowOffsetHeight;
		[Export ("lks_shadowOffsetHeight")]
		nfloat Lks_shadowOffsetHeight { get; set; }
	}

	// @interface LKS_AttrGroupsMaker : NSObject
	[BaseType (typeof(NSObject))]
	interface LKS_AttrGroupsMaker
	{
		// +(NSArray<LookinAttributesGroup *> *)attrGroupsForLayer:(CALayer *)layer;
		[Static]
		[Export ("attrGroupsForLayer:")]
		LookinAttributesGroup[] AttrGroupsForLayer (CALayer layer);
	}

	// @interface LKS_AttrModificationHandler : NSObject
	[BaseType (typeof(NSObject))]
	interface LKS_AttrModificationHandler
	{
		// +(void)handleModification:(LookinAttributeModification *)modification completion:(void (^)(LookinDisplayItemDetail *, NSError *))completion;
		[Static]
		[Export ("handleModification:completion:")]
		void HandleModification (LookinAttributeModification modification, Action<LookinDisplayItemDetail, NSError> completion);

		// +(void)handlePatchWithTasks:(NSArray<LookinStaticAsyncUpdateTask *> *)tasks block:(void (^)(LookinDisplayItemDetail *))block;
		[Static]
		[Export ("handlePatchWithTasks:block:")]
		void HandlePatchWithTasks (LookinStaticAsyncUpdateTask[] tasks, Action<LookinDisplayItemDetail> block);
	}

	// @interface LKS_AttrModificationPatchHandler : NSObject
	[BaseType (typeof(NSObject))]
	interface LKS_AttrModificationPatchHandler
	{
		// +(void)handleLayerOids:(NSArray<NSNumber *> *)oids lowImageQuality:(BOOL)lowImageQuality block:(void (^)(LookinDisplayItemDetail *, NSUInteger, NSError *))block;
		[Static]
		[Export ("handleLayerOids:lowImageQuality:block:")]
		void HandleLayerOids (NSNumber[] oids, bool lowImageQuality, Action<LookinDisplayItemDetail, nuint, NSError> block);
	}

	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const LKS_ConnectionDidEndNotificationName;
		[Field ("LKS_ConnectionDidEndNotificationName", "__Internal")]
		NSString LKS_ConnectionDidEndNotificationName { get; }
	}

	// @interface LKS_ConnectionManager : NSObject
	[BaseType (typeof(NSObject))]
	interface LKS_ConnectionManager
	{
		// +(instancetype)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		LKS_ConnectionManager SharedInstance ();

		// @property (assign, nonatomic) BOOL applicationIsActive;
		[Export ("applicationIsActive")]
		bool ApplicationIsActive { get; set; }

		// -(BOOL)isConnected;
		[Export ("isConnected")]
		[Verify (MethodToProperty)]
		bool IsConnected { get; }

		// -(void)respond:(LookinConnectionResponseAttachment *)data requestType:(uint32_t)requestType tag:(uint32_t)tag;
		[Export ("respond:requestType:tag:")]
		void Respond (LookinConnectionResponseAttachment data, uint requestType, uint tag);

		// -(void)pushData:(NSObject *)data type:(uint32_t)type;
		[Export ("pushData:type:")]
		void PushData (NSObject data, uint type);
	}

	// @interface LKS_EventHandlerMaker : NSObject
	[BaseType (typeof(NSObject))]
	interface LKS_EventHandlerMaker
	{
		// +(NSArray<LookinEventHandler *> *)makeForView:(UIView *)view;
		[Static]
		[Export ("makeForView:")]
		LookinEventHandler[] MakeForView (UIView view);
	}

	// @interface LKS_ExportManager : NSObject
	[BaseType (typeof(NSObject))]
	interface LKS_ExportManager
	{
		// +(instancetype)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		LKS_ExportManager SharedInstance ();

		// -(void)exportAndShare;
		[Export ("exportAndShare")]
		void ExportAndShare ();
	}

	// @interface LKS_Helper : NSObject
	[BaseType (typeof(NSObject))]
	interface LKS_Helper
	{
		// +(NSString *)descriptionOfObject:(id)object;
		[Static]
		[Export ("descriptionOfObject:")]
		string DescriptionOfObject (NSObject @object);

		// +(NSBundle *)bundle;
		[Static]
		[Export ("bundle")]
		[Verify (MethodToProperty)]
		NSBundle Bundle { get; }
	}

	// typedef void (^LKS_HierarchyDetailsHandler_Block)(NSArray<LookinDisplayItemDetail *> *, NSError *);
	delegate void LKS_HierarchyDetailsHandler_Block (LookinDisplayItemDetail[] arg0, NSError arg1);

	// @interface LKS_HierarchyDetailsHandler : NSObject
	[BaseType (typeof(NSObject))]
	interface LKS_HierarchyDetailsHandler
	{
		// +(instancetype)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		LKS_HierarchyDetailsHandler SharedInstance ();

		// -(void)startWithPackages:(NSArray<LookinStaticAsyncUpdateTasksPackage *> *)packages block:(LKS_HierarchyDetailsHandler_Block)block;
		[Export ("startWithPackages:block:")]
		void StartWithPackages (LookinStaticAsyncUpdateTasksPackage[] packages, LKS_HierarchyDetailsHandler_Block block);

		// -(void)bringForwardWithPackages:(NSArray<LookinStaticAsyncUpdateTasksPackage *> *)packages;
		[Export ("bringForwardWithPackages:")]
		void BringForwardWithPackages (LookinStaticAsyncUpdateTasksPackage[] packages);

		// -(void)cancel;
		[Export ("cancel")]
		void Cancel ();
	}

	// @interface LKS_HierarchyDisplayItemsMaker : NSObject
	[BaseType (typeof(NSObject))]
	interface LKS_HierarchyDisplayItemsMaker
	{
		// +(NSArray<LookinDisplayItem *> *)itemsWithScreenshots:(BOOL)hasScreenshots attrList:(BOOL)hasAttrList lowImageQuality:(BOOL)lowQuality includedWindows:(NSArray<UIWindow *> *)includedWindows excludedWindows:(NSArray<UIWindow *> *)excludedWindows;
		[Static]
		[Export ("itemsWithScreenshots:attrList:lowImageQuality:includedWindows:excludedWindows:")]
		LookinDisplayItem[] ItemsWithScreenshots (bool hasScreenshots, bool hasAttrList, bool lowQuality, UIWindow[] includedWindows, UIWindow[] excludedWindows);
	}

	// @interface LKS_LocalInspectContainerWindow : UIWindow
	[BaseType (typeof(UIWindow))]
	interface LKS_LocalInspectContainerWindow
	{
	}

	// @interface LKS_LocalInspectManager : NSObject
	[BaseType (typeof(NSObject))]
	interface LKS_LocalInspectManager
	{
		// +(instancetype)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		LKS_LocalInspectManager SharedInstance ();

		// -(void)startLocalInspectWithIncludedWindows:(NSArray<UIWindow *> *)includedWindows excludedWindows:(NSArray<UIWindow *> *)excludedWindows;
		[Export ("startLocalInspectWithIncludedWindows:excludedWindows:")]
		void StartLocalInspectWithIncludedWindows (UIWindow[] includedWindows, UIWindow[] excludedWindows);
	}

	// @interface LKS_LocalInspectPanelLabelView : UIView
	[BaseType (typeof(UIView))]
	interface LKS_LocalInspectPanelLabelView
	{
		// @property (nonatomic, strong) UILabel * leftLabel;
		[Export ("leftLabel", ArgumentSemantic.Strong)]
		UILabel LeftLabel { get; set; }

		// @property (nonatomic, strong) UILabel * rightLabel;
		[Export ("rightLabel", ArgumentSemantic.Strong)]
		UILabel RightLabel { get; set; }

		// @property (assign, nonatomic) CGFloat verInset;
		[Export ("verInset")]
		nfloat VerInset { get; set; }

		// @property (assign, nonatomic) CGFloat interspace;
		[Export ("interspace")]
		nfloat Interspace { get; set; }

		// @property (nonatomic, strong) CALayer * bottomBorderLayer;
		[Export ("bottomBorderLayer", ArgumentSemantic.Strong)]
		CALayer BottomBorderLayer { get; set; }

		// -(void)addBottomBorderLayer;
		[Export ("addBottomBorderLayer")]
		void AddBottomBorderLayer ();
	}

	// @interface LKS_LocalInspectViewController : UIViewController
	[BaseType (typeof(UIViewController))]
	interface LKS_LocalInspectViewController
	{
		// @property (copy, nonatomic) void (^didSelectExit)();
		[Export ("didSelectExit", ArgumentSemantic.Copy)]
		Action DidSelectExit { get; set; }

		// -(void)highlightLayer:(CALayer *)layer;
		[Export ("highlightLayer:")]
		void HighlightLayer (CALayer layer);

		// @property (assign, nonatomic) BOOL showTitleButton;
		[Export ("showTitleButton")]
		bool ShowTitleButton { get; set; }

		// -(void)clearContents;
		[Export ("clearContents")]
		void ClearContents ();

		// -(void)startTitleButtonAnimIfNeeded;
		[Export ("startTitleButtonAnimIfNeeded")]
		void StartTitleButtonAnimIfNeeded ();

		// @property (copy, nonatomic) NSArray<UIWindow *> * includedWindows;
		[Export ("includedWindows", ArgumentSemantic.Copy)]
		UIWindow[] IncludedWindows { get; set; }

		// @property (copy, nonatomic) NSArray<UIWindow *> * excludedWindows;
		[Export ("excludedWindows", ArgumentSemantic.Copy)]
		UIWindow[] ExcludedWindows { get; set; }

		// @property (nonatomic, weak) UIWindow * prevKeyWindow;
		[Export ("prevKeyWindow", ArgumentSemantic.Weak)]
		UIWindow PrevKeyWindow { get; set; }
	}

	// @interface LKS_MethodTraceManager : NSObject
	[BaseType (typeof(NSObject))]
	interface LKS_MethodTraceManager
	{
		// +(instancetype)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		LKS_MethodTraceManager SharedInstance ();

		// -(void)addWithClassName:(NSString *)className selName:(NSString *)selName;
		[Export ("addWithClassName:selName:")]
		void AddWithClassName (string className, string selName);

		// -(void)removeWithClassName:(NSString *)className selName:(NSString *)selName;
		[Export ("removeWithClassName:selName:")]
		void RemoveWithClassName (string className, string selName);

		// -(NSArray<NSDictionary<NSString *,id> *> *)currentActiveTraceList;
		[Export ("currentActiveTraceList")]
		[Verify (MethodToProperty)]
		NSDictionary<NSString, NSObject>[] CurrentActiveTraceList { get; }

		// -(NSArray<NSString *> *)allClassesListInApp;
		[Export ("allClassesListInApp")]
		[Verify (MethodToProperty)]
		string[] AllClassesListInApp { get; }
	}

	// @interface LKS_ObjectRegistry : NSObject
	[BaseType (typeof(NSObject))]
	interface LKS_ObjectRegistry
	{
		// +(instancetype)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		LKS_ObjectRegistry SharedInstance ();

		// -(unsigned long)addObject:(NSObject *)object;
		[Export ("addObject:")]
		nuint AddObject (NSObject @object);

		// -(NSObject *)objectWithOid:(unsigned long)oid;
		[Export ("objectWithOid:")]
		NSObject ObjectWithOid (nuint oid);
	}

	// @protocol LKS_PerspectiveDataSourceDelegate <NSObject>
	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof(NSObject))]
	interface LKS_PerspectiveDataSourceDelegate
	{
		// @optional -(void)dataSourceDidChangeSelectedItem:(LKS_PerspectiveDataSource *)dataSource;
		[Export ("dataSourceDidChangeSelectedItem:")]
		void DataSourceDidChangeSelectedItem (LKS_PerspectiveDataSource dataSource);

		// @optional -(void)dataSourceDidChangeDisplayItems:(LKS_PerspectiveDataSource *)dataSource;
		[Export ("dataSourceDidChangeDisplayItems:")]
		void DataSourceDidChangeDisplayItems (LKS_PerspectiveDataSource dataSource);

		// @optional -(void)dataSourceDidChangeNoPreview:(LKS_PerspectiveDataSource *)dataSource;
		[Export ("dataSourceDidChangeNoPreview:")]
		void DataSourceDidChangeNoPreview (LKS_PerspectiveDataSource dataSource);
	}

	// @interface LKS_PerspectiveDataSource : NSObject
	[BaseType (typeof(NSObject))]
	interface LKS_PerspectiveDataSource
	{
		// @property (nonatomic, weak) id<LKS_PerspectiveDataSourceDelegate> perspectiveLayer;
		[Export ("perspectiveLayer", ArgumentSemantic.Weak)]
		LKS_PerspectiveDataSourceDelegate PerspectiveLayer { get; set; }

		// @property (nonatomic, weak) id<LKS_PerspectiveDataSourceDelegate> hierarchyView;
		[Export ("hierarchyView", ArgumentSemantic.Weak)]
		LKS_PerspectiveDataSourceDelegate HierarchyView { get; set; }

		// -(instancetype)initWithHierarchyInfo:(LookinHierarchyInfo *)info;
		[Export ("initWithHierarchyInfo:")]
		NativeHandle Constructor (LookinHierarchyInfo info);

		// @property (readonly, copy, nonatomic) NSArray<LookinDisplayItem *> * flatItems;
		[Export ("flatItems", ArgumentSemantic.Copy)]
		LookinDisplayItem[] FlatItems { get; }

		// @property (readonly, copy, nonatomic) NSArray<LookinDisplayItem *> * displayingFlatItems;
		[Export ("displayingFlatItems", ArgumentSemantic.Copy)]
		LookinDisplayItem[] DisplayingFlatItems { get; }

		// -(NSInteger)numberOfRows;
		[Export ("numberOfRows")]
		[Verify (MethodToProperty)]
		nint NumberOfRows { get; }

		// -(LookinDisplayItem *)itemAtRow:(NSInteger)index;
		[Export ("itemAtRow:")]
		LookinDisplayItem ItemAtRow (nint index);

		// -(NSInteger)rowForItem:(LookinDisplayItem *)item;
		[Export ("rowForItem:")]
		nint RowForItem (LookinDisplayItem item);

		// @property (nonatomic, weak) LookinDisplayItem * selectedItem;
		[Export ("selectedItem", ArgumentSemantic.Weak)]
		LookinDisplayItem SelectedItem { get; set; }

		// -(void)collapseItem:(LookinDisplayItem *)item;
		[Export ("collapseItem:")]
		void CollapseItem (LookinDisplayItem item);

		// -(void)expandItem:(LookinDisplayItem *)item;
		[Export ("expandItem:")]
		void ExpandItem (LookinDisplayItem item);

		// -(NSArray<NSString *> *)aliasForColor:(UIColor *)color;
		[Export ("aliasForColor:")]
		string[] AliasForColor (UIColor color);

		// @property (readonly, nonatomic, strong) LookinHierarchyInfo * rawHierarchyInfo;
		[Export ("rawHierarchyInfo", ArgumentSemantic.Strong)]
		LookinHierarchyInfo RawHierarchyInfo { get; }
	}

	// @interface LKS_PerspectiveHierarchyCell : UITableViewCell
	[BaseType (typeof(UITableViewCell))]
	interface LKS_PerspectiveHierarchyCell
	{
		// @property (nonatomic, strong) LookinDisplayItem * displayItem;
		[Export ("displayItem", ArgumentSemantic.Strong)]
		LookinDisplayItem DisplayItem { get; set; }

		// -(void)reRender;
		[Export ("reRender")]
		void ReRender ();

		// @property (readonly, nonatomic, strong) UIButton * indicatorButton;
		[Export ("indicatorButton", ArgumentSemantic.Strong)]
		UIButton IndicatorButton { get; }
	}

	// @interface LKS_PerspectiveHierarchyView : UIView <LKS_PerspectiveDataSourceDelegate>
	[BaseType (typeof(UIView))]
	interface LKS_PerspectiveHierarchyView : ILKS_PerspectiveDataSourceDelegate
	{
		// -(instancetype)initWithDataSource:(LKS_PerspectiveDataSource *)dataSource;
		[Export ("initWithDataSource:")]
		NativeHandle Constructor (LKS_PerspectiveDataSource dataSource);

		// @property (assign, nonatomic) BOOL isHorizontalLayout;
		[Export ("isHorizontalLayout")]
		bool IsHorizontalLayout { get; set; }
	}

	// @interface LookinObject : NSObject <NSSecureCoding, NSCopying>
	[BaseType (typeof(NSObject))]
	interface LookinObject : INSSecureCoding, INSCopying
	{
		// +(instancetype)instanceWithObject:(NSObject *)object;
		[Static]
		[Export ("instanceWithObject:")]
		LookinObject InstanceWithObject (NSObject @object);

		// @property (assign, nonatomic) unsigned long oid;
		[Export ("oid")]
		nuint Oid { get; set; }

		// @property (copy, nonatomic) NSString * memoryAddress;
		[Export ("memoryAddress")]
		string MemoryAddress { get; set; }

		// @property (copy, nonatomic) NSArray<NSString *> * classChainList;
		[Export ("classChainList", ArgumentSemantic.Copy)]
		string[] ClassChainList { get; set; }

		// @property (copy, nonatomic) NSString * specialTrace;
		[Export ("specialTrace")]
		string SpecialTrace { get; set; }

		// @property (copy, nonatomic) NSArray<LookinIvarTrace *> * ivarTraces;
		[Export ("ivarTraces", ArgumentSemantic.Copy)]
		LookinIvarTrace[] IvarTraces { get; set; }

		// @property (readonly, copy, nonatomic) NSString * completedSelfClassName;
		[Export ("completedSelfClassName")]
		string CompletedSelfClassName { get; }

		// @property (readonly, copy, nonatomic) NSString * shortSelfClassName;
		[Export ("shortSelfClassName")]
		string ShortSelfClassName { get; }
	}

	// @protocol LookinDisplayItemDelegate <NSObject>
	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof(NSObject))]
	interface LookinDisplayItemDelegate
	{
		// @required -(void)displayItem:(LookinDisplayItem *)displayItem propertyDidChange:(LookinDisplayItemProperty)property;
		[Abstract]
		[Export ("displayItem:propertyDidChange:")]
		void PropertyDidChange (LookinDisplayItem displayItem, LookinDisplayItemProperty property);
	}

	// @interface LookinDisplayItem : NSObject <NSSecureCoding, NSCopying>
	[BaseType (typeof(NSObject))]
	interface LookinDisplayItem : INSSecureCoding, INSCopying
	{
		// @property (copy, nonatomic) NSArray<LookinDisplayItem *> * subitems;
		[Export ("subitems", ArgumentSemantic.Copy)]
		LookinDisplayItem[] Subitems { get; set; }

		// @property (assign, nonatomic) BOOL isHidden;
		[Export ("isHidden")]
		bool IsHidden { get; set; }

		// @property (assign, nonatomic) float alpha;
		[Export ("alpha")]
		float Alpha { get; set; }

		// @property (assign, nonatomic) CGRect frame;
		[Export ("frame", ArgumentSemantic.Assign)]
		CGRect Frame { get; set; }

		// @property (assign, nonatomic) CGRect bounds;
		[Export ("bounds", ArgumentSemantic.Assign)]
		CGRect Bounds { get; set; }

		// @property (nonatomic, strong) UIImage * soloScreenshot;
		[Export ("soloScreenshot", ArgumentSemantic.Strong)]
		UIImage SoloScreenshot { get; set; }

		// @property (nonatomic, strong) UIImage * groupScreenshot;
		[Export ("groupScreenshot", ArgumentSemantic.Strong)]
		UIImage GroupScreenshot { get; set; }

		// @property (nonatomic, strong) LookinObject * viewObject;
		[Export ("viewObject", ArgumentSemantic.Strong)]
		LookinObject ViewObject { get; set; }

		// @property (nonatomic, strong) LookinObject * layerObject;
		[Export ("layerObject", ArgumentSemantic.Strong)]
		LookinObject LayerObject { get; set; }

		// @property (nonatomic, strong) LookinObject * hostViewControllerObject;
		[Export ("hostViewControllerObject", ArgumentSemantic.Strong)]
		LookinObject HostViewControllerObject { get; set; }

		// @property (copy, nonatomic) NSArray<LookinAttributesGroup *> * attributesGroupList;
		[Export ("attributesGroupList", ArgumentSemantic.Copy)]
		LookinAttributesGroup[] AttributesGroupList { get; set; }

		// @property (copy, nonatomic) NSArray<LookinEventHandler *> * eventHandlers;
		[Export ("eventHandlers", ArgumentSemantic.Copy)]
		LookinEventHandler[] EventHandlers { get; set; }

		// @property (assign, nonatomic) BOOL representedAsKeyWindow;
		[Export ("representedAsKeyWindow")]
		bool RepresentedAsKeyWindow { get; set; }

		[Wrap ("WeakPreviewItemDelegate")]
		LookinDisplayItemDelegate PreviewItemDelegate { get; set; }

		// @property (nonatomic, weak) id<LookinDisplayItemDelegate> previewItemDelegate;
		[NullAllowed, Export ("previewItemDelegate", ArgumentSemantic.Weak)]
		NSObject WeakPreviewItemDelegate { get; set; }

		[Wrap ("WeakRowViewDelegate")]
		LookinDisplayItemDelegate RowViewDelegate { get; set; }

		// @property (nonatomic, weak) id<LookinDisplayItemDelegate> rowViewDelegate;
		[NullAllowed, Export ("rowViewDelegate", ArgumentSemantic.Weak)]
		NSObject WeakRowViewDelegate { get; set; }

		// @property (nonatomic, strong) UIColor * backgroundColor;
		[Export ("backgroundColor", ArgumentSemantic.Strong)]
		UIColor BackgroundColor { get; set; }

		// @property (assign, nonatomic) BOOL shouldCaptureImage;
		[Export ("shouldCaptureImage")]
		bool ShouldCaptureImage { get; set; }

		// @property (nonatomic, weak) LookinDisplayItem * superItem;
		[Export ("superItem", ArgumentSemantic.Weak)]
		LookinDisplayItem SuperItem { get; set; }

		// -(LookinObject *)displayingObject;
		[Export ("displayingObject")]
		[Verify (MethodToProperty)]
		LookinObject DisplayingObject { get; }

		// @property (readonly, copy, nonatomic) NSString * title;
		[Export ("title")]
		string Title { get; }

		// @property (readonly, copy, nonatomic) NSString * subtitle;
		[Export ("subtitle")]
		string Subtitle { get; }

		// -(NSInteger)indentLevel;
		[Export ("indentLevel")]
		[Verify (MethodToProperty)]
		nint IndentLevel { get; }

		// @property (readonly, assign, nonatomic) BOOL representedForSystemClass;
		[Export ("representedForSystemClass")]
		bool RepresentedForSystemClass { get; }

		// @property (assign, nonatomic) BOOL isExpanded;
		[Export ("isExpanded")]
		bool IsExpanded { get; set; }

		// @property (readonly, assign, nonatomic) BOOL isExpandable;
		[Export ("isExpandable")]
		bool IsExpandable { get; }

		// @property (readonly, assign, nonatomic) BOOL displayingInHierarchy;
		[Export ("displayingInHierarchy")]
		bool DisplayingInHierarchy { get; }

		// @property (readonly, assign, nonatomic) BOOL inHiddenHierarchy;
		[Export ("inHiddenHierarchy")]
		bool InHiddenHierarchy { get; }

		// -(UIImage *)appropriateScreenshot;
		[Export ("appropriateScreenshot")]
		[Verify (MethodToProperty)]
		UIImage AppropriateScreenshot { get; }

		// @property (assign, nonatomic) LookinDisplayItemImageEncodeType screenshotEncodeType;
		[Export ("screenshotEncodeType", ArgumentSemantic.Assign)]
		LookinDisplayItemImageEncodeType ScreenshotEncodeType { get; set; }

		// @property (assign, nonatomic) LookinDoNotFetchScreenshotReason doNotFetchScreenshotReason;
		[Export ("doNotFetchScreenshotReason", ArgumentSemantic.Assign)]
		LookinDoNotFetchScreenshotReason DoNotFetchScreenshotReason { get; set; }

		// @property (nonatomic, weak) LookinPreviewItemLayer * previewLayer;
		[Export ("previewLayer", ArgumentSemantic.Weak)]
		LookinPreviewItemLayer PreviewLayer { get; set; }

		// @property (nonatomic, weak) LookinDisplayItemNode * previewNode;
		[Export ("previewNode", ArgumentSemantic.Weak)]
		LookinDisplayItemNode PreviewNode { get; set; }

		// @property (assign, nonatomic) BOOL noPreview;
		[Export ("noPreview")]
		bool NoPreview { get; set; }

		// @property (readonly, assign, nonatomic) BOOL inNoPreviewHierarchy;
		[Export ("inNoPreviewHierarchy")]
		bool InNoPreviewHierarchy { get; }

		// @property (assign, nonatomic) NSInteger previewZIndex;
		[Export ("previewZIndex")]
		nint PreviewZIndex { get; set; }

		// @property (readonly, assign, nonatomic) CGRect frameToRoot;
		[Export ("frameToRoot", ArgumentSemantic.Assign)]
		CGRect FrameToRoot { get; }

		// -(void)enumerateSelfAndAncestors:(void (^)(LookinDisplayItem *, BOOL *))block;
		[Export ("enumerateSelfAndAncestors:")]
		unsafe void EnumerateSelfAndAncestors (Action<LookinDisplayItem, bool*> block);

		// -(void)enumerateAncestors:(void (^)(LookinDisplayItem *, BOOL *))block;
		[Export ("enumerateAncestors:")]
		unsafe void EnumerateAncestors (Action<LookinDisplayItem, bool*> block);

		// -(void)enumerateSelfAndChildren:(void (^)(LookinDisplayItem *))block;
		[Export ("enumerateSelfAndChildren:")]
		void EnumerateSelfAndChildren (Action<LookinDisplayItem> block);

		// @property (assign, nonatomic) BOOL preferToBeCollapsed;
		[Export ("preferToBeCollapsed")]
		bool PreferToBeCollapsed { get; set; }

		// @property (assign, nonatomic) BOOL isSelected;
		[Export ("isSelected")]
		bool IsSelected { get; set; }

		// @property (assign, nonatomic) BOOL isHovered;
		[Export ("isHovered")]
		bool IsHovered { get; set; }

		// -(BOOL)itemIsKindOfClassWithName:(NSString *)className;
		[Export ("itemIsKindOfClassWithName:")]
		bool ItemIsKindOfClassWithName (string className);

		// -(BOOL)itemIsKindOfClassesWithNames:(NSSet<NSString *> *)classNames;
		[Export ("itemIsKindOfClassesWithNames:")]
		bool ItemIsKindOfClassesWithNames (NSSet<NSString> classNames);

		// +(NSArray<LookinDisplayItem *> *)flatItemsFromHierarchicalItems:(NSArray<LookinDisplayItem *> *)items;
		[Static]
		[Export ("flatItemsFromHierarchicalItems:")]
		LookinDisplayItem[] FlatItemsFromHierarchicalItems (LookinDisplayItem[] items);

		// @property (assign, nonatomic) BOOL hasDeterminedExpansion;
		[Export ("hasDeterminedExpansion")]
		bool HasDeterminedExpansion { get; set; }

		// -(BOOL)isMatchedWithSearchString:(NSString *)string;
		[Export ("isMatchedWithSearchString:")]
		bool IsMatchedWithSearchString (string @string);

		// @property (assign, nonatomic) BOOL isInSearch;
		[Export ("isInSearch")]
		bool IsInSearch { get; set; }

		// @property (copy, nonatomic) NSString * highlightedSearchString;
		[Export ("highlightedSearchString")]
		string HighlightedSearchString { get; set; }
	}

	// @interface LKS_PerspectiveItemLayer : CALayer
	[BaseType (typeof(CALayer))]
	interface LKS_PerspectiveItemLayer
	{
		// @property (nonatomic, strong) LookinDisplayItem * displayItem;
		[Export ("displayItem", ArgumentSemantic.Strong)]
		LookinDisplayItem DisplayItem { get; set; }

		// -(void)reRender;
		[Export ("reRender")]
		void ReRender ();
	}

	// @interface LKS_PerspectiveLayer : CALayer <LKS_PerspectiveDataSourceDelegate>
	[BaseType (typeof(CALayer))]
	interface LKS_PerspectiveLayer : ILKS_PerspectiveDataSourceDelegate
	{
		// -(instancetype)initWithDataSource:(LKS_PerspectiveDataSource *)dataSource;
		[Export ("initWithDataSource:")]
		NativeHandle Constructor (LKS_PerspectiveDataSource dataSource);

		// @property (assign, nonatomic) LKS_PerspectiveDimension dimension;
		[Export ("dimension", ArgumentSemantic.Assign)]
		LKS_PerspectiveDimension Dimension { get; set; }

		// @property (readonly, assign, nonatomic) CGFloat rotation;
		[Export ("rotation")]
		nfloat Rotation { get; }

		// -(void)setRotation:(CGFloat)rotation animated:(BOOL)animated completion:(void (^)(void))completionBlock;
		[Export ("setRotation:animated:completion:")]
		void SetRotation (nfloat rotation, bool animated, Action completionBlock);
	}

	// @interface LKS_PerspectiveContainerWindow : UIWindow
	[BaseType (typeof(UIWindow))]
	interface LKS_PerspectiveContainerWindow
	{
	}

	// @interface LKS_PerspectiveManager : NSObject
	[BaseType (typeof(NSObject))]
	interface LKS_PerspectiveManager
	{
		// +(instancetype)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		LKS_PerspectiveManager SharedInstance ();

		// -(void)showWithIncludedWindows:(NSArray<UIWindow *> *)includedWindows excludedWindows:(NSArray<UIWindow *> *)excludedWindows;
		[Export ("showWithIncludedWindows:excludedWindows:")]
		void ShowWithIncludedWindows (UIWindow[] includedWindows, UIWindow[] excludedWindows);
	}

	// @interface LKS_PerspectiveToolbarCloseButton : UIButton
	[BaseType (typeof(UIButton))]
	interface LKS_PerspectiveToolbarCloseButton
	{
	}

	// @interface LKS_PerspectiveToolbarDimensionButtonsView : UIView
	[BaseType (typeof(UIView))]
	interface LKS_PerspectiveToolbarDimensionButtonsView
	{
		// @property (readonly, nonatomic, strong) UIButton * button2D;
		[Export ("button2D", ArgumentSemantic.Strong)]
		UIButton Button2D { get; }

		// @property (readonly, nonatomic, strong) UIButton * button3D;
		[Export ("button3D", ArgumentSemantic.Strong)]
		UIButton Button3D { get; }
	}

	// @interface LKS_PerspectiveToolbarLayoutButtonsView : UIView
	[BaseType (typeof(UIView))]
	interface LKS_PerspectiveToolbarLayoutButtonsView
	{
		// @property (readonly, nonatomic, strong) UIButton * verticalLayoutButton;
		[Export ("verticalLayoutButton", ArgumentSemantic.Strong)]
		UIButton VerticalLayoutButton { get; }

		// @property (readonly, nonatomic, strong) UIButton * horizontalLayoutButton;
		[Export ("horizontalLayoutButton", ArgumentSemantic.Strong)]
		UIButton HorizontalLayoutButton { get; }
	}

	// @interface LKS_PerspectiveToolbarPropertyButton : UIButton
	[BaseType (typeof(UIButton))]
	interface LKS_PerspectiveToolbarPropertyButton
	{
	}

	// @interface LKS_PerspectiveViewController : UIViewController
	[BaseType (typeof(UIViewController))]
	interface LKS_PerspectiveViewController
	{
		// -(instancetype)initWithHierarchyInfo:(LookinHierarchyInfo *)info;
		[Export ("initWithHierarchyInfo:")]
		NativeHandle Constructor (LookinHierarchyInfo info);

		// @property (readonly, nonatomic, strong) LKS_PerspectiveToolbarCloseButton * closeButton;
		[Export ("closeButton", ArgumentSemantic.Strong)]
		LKS_PerspectiveToolbarCloseButton CloseButton { get; }
	}

	// @interface LKS_RequestHandler : NSObject
	[BaseType (typeof(NSObject))]
	interface LKS_RequestHandler
	{
		// -(BOOL)canHandleRequestType:(uint32_t)requestType;
		[Export ("canHandleRequestType:")]
		bool CanHandleRequestType (uint requestType);

		// -(void)handleRequestType:(uint32_t)requestType tag:(uint32_t)tag object:(id)object;
		[Export ("handleRequestType:tag:object:")]
		void HandleRequestType (uint requestType, uint tag, NSObject @object);
	}

	// @interface LKS_TraceManager : NSObject
	[BaseType (typeof(NSObject))]
	interface LKS_TraceManager
	{
		// +(instancetype)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		LKS_TraceManager SharedInstance ();

		// -(void)reload;
		[Export ("reload")]
		void Reload ();
	}

	// @interface LookinAppInfo : NSObject <NSSecureCoding, NSCopying>
	[BaseType (typeof(NSObject))]
	interface LookinAppInfo : INSSecureCoding, INSCopying
	{
		// @property (assign, nonatomic) NSUInteger appInfoIdentifier;
		[Export ("appInfoIdentifier")]
		nuint AppInfoIdentifier { get; set; }

		// @property (assign, nonatomic) BOOL shouldUseCache;
		[Export ("shouldUseCache")]
		bool ShouldUseCache { get; set; }

		// @property (assign, nonatomic) int serverVersion;
		[Export ("serverVersion")]
		int ServerVersion { get; set; }

		// @property (nonatomic, strong) UIImage * screenshot;
		[Export ("screenshot", ArgumentSemantic.Strong)]
		UIImage Screenshot { get; set; }

		// @property (nonatomic, strong) UIImage * appIcon;
		[Export ("appIcon", ArgumentSemantic.Strong)]
		UIImage AppIcon { get; set; }

		// @property (copy, nonatomic) NSString * appName;
		[Export ("appName")]
		string AppName { get; set; }

		// @property (copy, nonatomic) NSString * appBundleIdentifier;
		[Export ("appBundleIdentifier")]
		string AppBundleIdentifier { get; set; }

		// @property (copy, nonatomic) NSString * deviceDescription;
		[Export ("deviceDescription")]
		string DeviceDescription { get; set; }

		// @property (copy, nonatomic) NSString * osDescription;
		[Export ("osDescription")]
		string OsDescription { get; set; }

		// @property (assign, nonatomic) NSUInteger osMainVersion;
		[Export ("osMainVersion")]
		nuint OsMainVersion { get; set; }

		// @property (assign, nonatomic) LookinAppInfoDevice deviceType;
		[Export ("deviceType", ArgumentSemantic.Assign)]
		LookinAppInfoDevice DeviceType { get; set; }

		// @property (assign, nonatomic) double screenWidth;
		[Export ("screenWidth")]
		double ScreenWidth { get; set; }

		// @property (assign, nonatomic) double screenHeight;
		[Export ("screenHeight")]
		double ScreenHeight { get; set; }

		// @property (assign, nonatomic) double screenScale;
		[Export ("screenScale")]
		double ScreenScale { get; set; }

		// -(BOOL)isEqualToAppInfo:(LookinAppInfo *)info;
		[Export ("isEqualToAppInfo:")]
		bool IsEqualToAppInfo (LookinAppInfo info);

		// +(LookinAppInfo *)currentInfoWithScreenshot:(BOOL)hasScreenshot icon:(BOOL)hasIcon localIdentifiers:(NSArray<NSNumber *> *)localIdentifiers;
		[Static]
		[Export ("currentInfoWithScreenshot:icon:localIdentifiers:")]
		LookinAppInfo CurrentInfoWithScreenshot (bool hasScreenshot, bool hasIcon, NSNumber[] localIdentifiers);
	}

	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern const LookinAttrGroupIdentifier LookinAttrGroup_None;
		[Field ("LookinAttrGroup_None", "__Internal")]
		NSString LookinAttrGroup_None { get; }

		// extern const LookinAttrGroupIdentifier LookinAttrGroup_Class;
		[Field ("LookinAttrGroup_Class", "__Internal")]
		NSString LookinAttrGroup_Class { get; }

		// extern const LookinAttrGroupIdentifier LookinAttrGroup_Relation;
		[Field ("LookinAttrGroup_Relation", "__Internal")]
		NSString LookinAttrGroup_Relation { get; }

		// extern const LookinAttrGroupIdentifier LookinAttrGroup_Layout;
		[Field ("LookinAttrGroup_Layout", "__Internal")]
		NSString LookinAttrGroup_Layout { get; }

		// extern const LookinAttrGroupIdentifier LookinAttrGroup_AutoLayout;
		[Field ("LookinAttrGroup_AutoLayout", "__Internal")]
		NSString LookinAttrGroup_AutoLayout { get; }

		// extern const LookinAttrGroupIdentifier LookinAttrGroup_ViewLayer;
		[Field ("LookinAttrGroup_ViewLayer", "__Internal")]
		NSString LookinAttrGroup_ViewLayer { get; }

		// extern const LookinAttrGroupIdentifier LookinAttrGroup_UIImageView;
		[Field ("LookinAttrGroup_UIImageView", "__Internal")]
		NSString LookinAttrGroup_UIImageView { get; }

		// extern const LookinAttrGroupIdentifier LookinAttrGroup_UILabel;
		[Field ("LookinAttrGroup_UILabel", "__Internal")]
		NSString LookinAttrGroup_UILabel { get; }

		// extern const LookinAttrGroupIdentifier LookinAttrGroup_UIControl;
		[Field ("LookinAttrGroup_UIControl", "__Internal")]
		NSString LookinAttrGroup_UIControl { get; }

		// extern const LookinAttrGroupIdentifier LookinAttrGroup_UIButton;
		[Field ("LookinAttrGroup_UIButton", "__Internal")]
		NSString LookinAttrGroup_UIButton { get; }

		// extern const LookinAttrGroupIdentifier LookinAttrGroup_UIScrollView;
		[Field ("LookinAttrGroup_UIScrollView", "__Internal")]
		NSString LookinAttrGroup_UIScrollView { get; }

		// extern const LookinAttrGroupIdentifier LookinAttrGroup_UITableView;
		[Field ("LookinAttrGroup_UITableView", "__Internal")]
		NSString LookinAttrGroup_UITableView { get; }

		// extern const LookinAttrGroupIdentifier LookinAttrGroup_UITextView;
		[Field ("LookinAttrGroup_UITextView", "__Internal")]
		NSString LookinAttrGroup_UITextView { get; }

		// extern const LookinAttrGroupIdentifier LookinAttrGroup_UITextField;
		[Field ("LookinAttrGroup_UITextField", "__Internal")]
		NSString LookinAttrGroup_UITextField { get; }

		// extern const LookinAttrGroupIdentifier LookinAttrGroup_UIVisualEffectView;
		[Field ("LookinAttrGroup_UIVisualEffectView", "__Internal")]
		NSString LookinAttrGroup_UIVisualEffectView { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_None;
		[Field ("LookinAttrSec_None", "__Internal")]
		NSString LookinAttrSec_None { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_Class_Class;
		[Field ("LookinAttrSec_Class_Class", "__Internal")]
		NSString LookinAttrSec_Class_Class { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_Relation_Relation;
		[Field ("LookinAttrSec_Relation_Relation", "__Internal")]
		NSString LookinAttrSec_Relation_Relation { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_Layout_Frame;
		[Field ("LookinAttrSec_Layout_Frame", "__Internal")]
		NSString LookinAttrSec_Layout_Frame { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_Layout_Bounds;
		[Field ("LookinAttrSec_Layout_Bounds", "__Internal")]
		NSString LookinAttrSec_Layout_Bounds { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_Layout_SafeArea;
		[Field ("LookinAttrSec_Layout_SafeArea", "__Internal")]
		NSString LookinAttrSec_Layout_SafeArea { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_Layout_Position;
		[Field ("LookinAttrSec_Layout_Position", "__Internal")]
		NSString LookinAttrSec_Layout_Position { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_Layout_AnchorPoint;
		[Field ("LookinAttrSec_Layout_AnchorPoint", "__Internal")]
		NSString LookinAttrSec_Layout_AnchorPoint { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_AutoLayout_Hugging;
		[Field ("LookinAttrSec_AutoLayout_Hugging", "__Internal")]
		NSString LookinAttrSec_AutoLayout_Hugging { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_AutoLayout_Resistance;
		[Field ("LookinAttrSec_AutoLayout_Resistance", "__Internal")]
		NSString LookinAttrSec_AutoLayout_Resistance { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_AutoLayout_Constraints;
		[Field ("LookinAttrSec_AutoLayout_Constraints", "__Internal")]
		NSString LookinAttrSec_AutoLayout_Constraints { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_AutoLayout_IntrinsicSize;
		[Field ("LookinAttrSec_AutoLayout_IntrinsicSize", "__Internal")]
		NSString LookinAttrSec_AutoLayout_IntrinsicSize { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_ViewLayer_Visibility;
		[Field ("LookinAttrSec_ViewLayer_Visibility", "__Internal")]
		NSString LookinAttrSec_ViewLayer_Visibility { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_ViewLayer_InterationAndMasks;
		[Field ("LookinAttrSec_ViewLayer_InterationAndMasks", "__Internal")]
		NSString LookinAttrSec_ViewLayer_InterationAndMasks { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_ViewLayer_Corner;
		[Field ("LookinAttrSec_ViewLayer_Corner", "__Internal")]
		NSString LookinAttrSec_ViewLayer_Corner { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_ViewLayer_BgColor;
		[Field ("LookinAttrSec_ViewLayer_BgColor", "__Internal")]
		NSString LookinAttrSec_ViewLayer_BgColor { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_ViewLayer_Border;
		[Field ("LookinAttrSec_ViewLayer_Border", "__Internal")]
		NSString LookinAttrSec_ViewLayer_Border { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_ViewLayer_Shadow;
		[Field ("LookinAttrSec_ViewLayer_Shadow", "__Internal")]
		NSString LookinAttrSec_ViewLayer_Shadow { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_ViewLayer_ContentMode;
		[Field ("LookinAttrSec_ViewLayer_ContentMode", "__Internal")]
		NSString LookinAttrSec_ViewLayer_ContentMode { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_ViewLayer_TintColor;
		[Field ("LookinAttrSec_ViewLayer_TintColor", "__Internal")]
		NSString LookinAttrSec_ViewLayer_TintColor { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_ViewLayer_Tag;
		[Field ("LookinAttrSec_ViewLayer_Tag", "__Internal")]
		NSString LookinAttrSec_ViewLayer_Tag { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UIImageView_Name;
		[Field ("LookinAttrSec_UIImageView_Name", "__Internal")]
		NSString LookinAttrSec_UIImageView_Name { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UIImageView_Open;
		[Field ("LookinAttrSec_UIImageView_Open", "__Internal")]
		NSString LookinAttrSec_UIImageView_Open { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UILabel_Text;
		[Field ("LookinAttrSec_UILabel_Text", "__Internal")]
		NSString LookinAttrSec_UILabel_Text { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UILabel_Font;
		[Field ("LookinAttrSec_UILabel_Font", "__Internal")]
		NSString LookinAttrSec_UILabel_Font { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UILabel_NumberOfLines;
		[Field ("LookinAttrSec_UILabel_NumberOfLines", "__Internal")]
		NSString LookinAttrSec_UILabel_NumberOfLines { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UILabel_TextColor;
		[Field ("LookinAttrSec_UILabel_TextColor", "__Internal")]
		NSString LookinAttrSec_UILabel_TextColor { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UILabel_BreakMode;
		[Field ("LookinAttrSec_UILabel_BreakMode", "__Internal")]
		NSString LookinAttrSec_UILabel_BreakMode { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UILabel_Alignment;
		[Field ("LookinAttrSec_UILabel_Alignment", "__Internal")]
		NSString LookinAttrSec_UILabel_Alignment { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UILabel_CanAdjustFont;
		[Field ("LookinAttrSec_UILabel_CanAdjustFont", "__Internal")]
		NSString LookinAttrSec_UILabel_CanAdjustFont { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UIControl_EnabledSelected;
		[Field ("LookinAttrSec_UIControl_EnabledSelected", "__Internal")]
		NSString LookinAttrSec_UIControl_EnabledSelected { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UIControl_VerAlignment;
		[Field ("LookinAttrSec_UIControl_VerAlignment", "__Internal")]
		NSString LookinAttrSec_UIControl_VerAlignment { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UIControl_HorAlignment;
		[Field ("LookinAttrSec_UIControl_HorAlignment", "__Internal")]
		NSString LookinAttrSec_UIControl_HorAlignment { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UIControl_QMUIOutsideEdge;
		[Field ("LookinAttrSec_UIControl_QMUIOutsideEdge", "__Internal")]
		NSString LookinAttrSec_UIControl_QMUIOutsideEdge { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UIButton_ContentInsets;
		[Field ("LookinAttrSec_UIButton_ContentInsets", "__Internal")]
		NSString LookinAttrSec_UIButton_ContentInsets { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UIButton_TitleInsets;
		[Field ("LookinAttrSec_UIButton_TitleInsets", "__Internal")]
		NSString LookinAttrSec_UIButton_TitleInsets { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UIButton_ImageInsets;
		[Field ("LookinAttrSec_UIButton_ImageInsets", "__Internal")]
		NSString LookinAttrSec_UIButton_ImageInsets { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UIScrollView_ContentInset;
		[Field ("LookinAttrSec_UIScrollView_ContentInset", "__Internal")]
		NSString LookinAttrSec_UIScrollView_ContentInset { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UIScrollView_AdjustedInset;
		[Field ("LookinAttrSec_UIScrollView_AdjustedInset", "__Internal")]
		NSString LookinAttrSec_UIScrollView_AdjustedInset { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UIScrollView_IndicatorInset;
		[Field ("LookinAttrSec_UIScrollView_IndicatorInset", "__Internal")]
		NSString LookinAttrSec_UIScrollView_IndicatorInset { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UIScrollView_Offset;
		[Field ("LookinAttrSec_UIScrollView_Offset", "__Internal")]
		NSString LookinAttrSec_UIScrollView_Offset { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UIScrollView_ContentSize;
		[Field ("LookinAttrSec_UIScrollView_ContentSize", "__Internal")]
		NSString LookinAttrSec_UIScrollView_ContentSize { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UIScrollView_Behavior;
		[Field ("LookinAttrSec_UIScrollView_Behavior", "__Internal")]
		NSString LookinAttrSec_UIScrollView_Behavior { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UIScrollView_ShowsIndicator;
		[Field ("LookinAttrSec_UIScrollView_ShowsIndicator", "__Internal")]
		NSString LookinAttrSec_UIScrollView_ShowsIndicator { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UIScrollView_Bounce;
		[Field ("LookinAttrSec_UIScrollView_Bounce", "__Internal")]
		NSString LookinAttrSec_UIScrollView_Bounce { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UIScrollView_ScrollPaging;
		[Field ("LookinAttrSec_UIScrollView_ScrollPaging", "__Internal")]
		NSString LookinAttrSec_UIScrollView_ScrollPaging { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UIScrollView_ContentTouches;
		[Field ("LookinAttrSec_UIScrollView_ContentTouches", "__Internal")]
		NSString LookinAttrSec_UIScrollView_ContentTouches { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UIScrollView_Zoom;
		[Field ("LookinAttrSec_UIScrollView_Zoom", "__Internal")]
		NSString LookinAttrSec_UIScrollView_Zoom { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UIScrollView_QMUIInitialInset;
		[Field ("LookinAttrSec_UIScrollView_QMUIInitialInset", "__Internal")]
		NSString LookinAttrSec_UIScrollView_QMUIInitialInset { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UITableView_Style;
		[Field ("LookinAttrSec_UITableView_Style", "__Internal")]
		NSString LookinAttrSec_UITableView_Style { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UITableView_SectionsNumber;
		[Field ("LookinAttrSec_UITableView_SectionsNumber", "__Internal")]
		NSString LookinAttrSec_UITableView_SectionsNumber { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UITableView_RowsNumber;
		[Field ("LookinAttrSec_UITableView_RowsNumber", "__Internal")]
		NSString LookinAttrSec_UITableView_RowsNumber { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UITableView_SeparatorStyle;
		[Field ("LookinAttrSec_UITableView_SeparatorStyle", "__Internal")]
		NSString LookinAttrSec_UITableView_SeparatorStyle { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UITableView_SeparatorColor;
		[Field ("LookinAttrSec_UITableView_SeparatorColor", "__Internal")]
		NSString LookinAttrSec_UITableView_SeparatorColor { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UITableView_SeparatorInset;
		[Field ("LookinAttrSec_UITableView_SeparatorInset", "__Internal")]
		NSString LookinAttrSec_UITableView_SeparatorInset { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UITextView_Basic;
		[Field ("LookinAttrSec_UITextView_Basic", "__Internal")]
		NSString LookinAttrSec_UITextView_Basic { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UITextView_Text;
		[Field ("LookinAttrSec_UITextView_Text", "__Internal")]
		NSString LookinAttrSec_UITextView_Text { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UITextView_Font;
		[Field ("LookinAttrSec_UITextView_Font", "__Internal")]
		NSString LookinAttrSec_UITextView_Font { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UITextView_TextColor;
		[Field ("LookinAttrSec_UITextView_TextColor", "__Internal")]
		NSString LookinAttrSec_UITextView_TextColor { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UITextView_Alignment;
		[Field ("LookinAttrSec_UITextView_Alignment", "__Internal")]
		NSString LookinAttrSec_UITextView_Alignment { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UITextView_ContainerInset;
		[Field ("LookinAttrSec_UITextView_ContainerInset", "__Internal")]
		NSString LookinAttrSec_UITextView_ContainerInset { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UITextField_Text;
		[Field ("LookinAttrSec_UITextField_Text", "__Internal")]
		NSString LookinAttrSec_UITextField_Text { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UITextField_Placeholder;
		[Field ("LookinAttrSec_UITextField_Placeholder", "__Internal")]
		NSString LookinAttrSec_UITextField_Placeholder { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UITextField_Font;
		[Field ("LookinAttrSec_UITextField_Font", "__Internal")]
		NSString LookinAttrSec_UITextField_Font { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UITextField_TextColor;
		[Field ("LookinAttrSec_UITextField_TextColor", "__Internal")]
		NSString LookinAttrSec_UITextField_TextColor { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UITextField_Alignment;
		[Field ("LookinAttrSec_UITextField_Alignment", "__Internal")]
		NSString LookinAttrSec_UITextField_Alignment { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UITextField_Clears;
		[Field ("LookinAttrSec_UITextField_Clears", "__Internal")]
		NSString LookinAttrSec_UITextField_Clears { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UITextField_CanAdjustFont;
		[Field ("LookinAttrSec_UITextField_CanAdjustFont", "__Internal")]
		NSString LookinAttrSec_UITextField_CanAdjustFont { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UITextField_ClearButtonMode;
		[Field ("LookinAttrSec_UITextField_ClearButtonMode", "__Internal")]
		NSString LookinAttrSec_UITextField_ClearButtonMode { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UIVisualEffectView_Style;
		[Field ("LookinAttrSec_UIVisualEffectView_Style", "__Internal")]
		NSString LookinAttrSec_UIVisualEffectView_Style { get; }

		// extern const LookinAttrSectionIdentifier LookinAttrSec_UIVisualEffectView_QMUIForegroundColor;
		[Field ("LookinAttrSec_UIVisualEffectView_QMUIForegroundColor", "__Internal")]
		NSString LookinAttrSec_UIVisualEffectView_QMUIForegroundColor { get; }

		// extern const LookinAttrIdentifier LookinAttr_None;
		[Field ("LookinAttr_None", "__Internal")]
		NSString LookinAttr_None { get; }

		// extern const LookinAttrIdentifier LookinAttr_Class_Class_Class;
		[Field ("LookinAttr_Class_Class_Class", "__Internal")]
		NSString LookinAttr_Class_Class_Class { get; }

		// extern const LookinAttrIdentifier LookinAttr_Relation_Relation_Relation;
		[Field ("LookinAttr_Relation_Relation_Relation", "__Internal")]
		NSString LookinAttr_Relation_Relation_Relation { get; }

		// extern const LookinAttrIdentifier LookinAttr_Layout_Frame_Frame;
		[Field ("LookinAttr_Layout_Frame_Frame", "__Internal")]
		NSString LookinAttr_Layout_Frame_Frame { get; }

		// extern const LookinAttrIdentifier LookinAttr_Layout_Bounds_Bounds;
		[Field ("LookinAttr_Layout_Bounds_Bounds", "__Internal")]
		NSString LookinAttr_Layout_Bounds_Bounds { get; }

		// extern const LookinAttrIdentifier LookinAttr_Layout_SafeArea_SafeArea;
		[Field ("LookinAttr_Layout_SafeArea_SafeArea", "__Internal")]
		NSString LookinAttr_Layout_SafeArea_SafeArea { get; }

		// extern const LookinAttrIdentifier LookinAttr_Layout_Position_Position;
		[Field ("LookinAttr_Layout_Position_Position", "__Internal")]
		NSString LookinAttr_Layout_Position_Position { get; }

		// extern const LookinAttrIdentifier LookinAttr_Layout_AnchorPoint_AnchorPoint;
		[Field ("LookinAttr_Layout_AnchorPoint_AnchorPoint", "__Internal")]
		NSString LookinAttr_Layout_AnchorPoint_AnchorPoint { get; }

		// extern const LookinAttrIdentifier LookinAttr_AutoLayout_Hugging_Hor;
		[Field ("LookinAttr_AutoLayout_Hugging_Hor", "__Internal")]
		NSString LookinAttr_AutoLayout_Hugging_Hor { get; }

		// extern const LookinAttrIdentifier LookinAttr_AutoLayout_Hugging_Ver;
		[Field ("LookinAttr_AutoLayout_Hugging_Ver", "__Internal")]
		NSString LookinAttr_AutoLayout_Hugging_Ver { get; }

		// extern const LookinAttrIdentifier LookinAttr_AutoLayout_Resistance_Hor;
		[Field ("LookinAttr_AutoLayout_Resistance_Hor", "__Internal")]
		NSString LookinAttr_AutoLayout_Resistance_Hor { get; }

		// extern const LookinAttrIdentifier LookinAttr_AutoLayout_Resistance_Ver;
		[Field ("LookinAttr_AutoLayout_Resistance_Ver", "__Internal")]
		NSString LookinAttr_AutoLayout_Resistance_Ver { get; }

		// extern const LookinAttrIdentifier LookinAttr_AutoLayout_Constraints_Constraints;
		[Field ("LookinAttr_AutoLayout_Constraints_Constraints", "__Internal")]
		NSString LookinAttr_AutoLayout_Constraints_Constraints { get; }

		// extern const LookinAttrIdentifier LookinAttr_AutoLayout_IntrinsicSize_Size;
		[Field ("LookinAttr_AutoLayout_IntrinsicSize_Size", "__Internal")]
		NSString LookinAttr_AutoLayout_IntrinsicSize_Size { get; }

		// extern const LookinAttrIdentifier LookinAttr_ViewLayer_Visibility_Hidden;
		[Field ("LookinAttr_ViewLayer_Visibility_Hidden", "__Internal")]
		NSString LookinAttr_ViewLayer_Visibility_Hidden { get; }

		// extern const LookinAttrIdentifier LookinAttr_ViewLayer_Visibility_Opacity;
		[Field ("LookinAttr_ViewLayer_Visibility_Opacity", "__Internal")]
		NSString LookinAttr_ViewLayer_Visibility_Opacity { get; }

		// extern const LookinAttrIdentifier LookinAttr_ViewLayer_InterationAndMasks_Interaction;
		[Field ("LookinAttr_ViewLayer_InterationAndMasks_Interaction", "__Internal")]
		NSString LookinAttr_ViewLayer_InterationAndMasks_Interaction { get; }

		// extern const LookinAttrIdentifier LookinAttr_ViewLayer_InterationAndMasks_MasksToBounds;
		[Field ("LookinAttr_ViewLayer_InterationAndMasks_MasksToBounds", "__Internal")]
		NSString LookinAttr_ViewLayer_InterationAndMasks_MasksToBounds { get; }

		// extern const LookinAttrIdentifier LookinAttr_ViewLayer_Corner_Radius;
		[Field ("LookinAttr_ViewLayer_Corner_Radius", "__Internal")]
		NSString LookinAttr_ViewLayer_Corner_Radius { get; }

		// extern const LookinAttrIdentifier LookinAttr_ViewLayer_BgColor_BgColor;
		[Field ("LookinAttr_ViewLayer_BgColor_BgColor", "__Internal")]
		NSString LookinAttr_ViewLayer_BgColor_BgColor { get; }

		// extern const LookinAttrIdentifier LookinAttr_ViewLayer_Border_Color;
		[Field ("LookinAttr_ViewLayer_Border_Color", "__Internal")]
		NSString LookinAttr_ViewLayer_Border_Color { get; }

		// extern const LookinAttrIdentifier LookinAttr_ViewLayer_Border_Width;
		[Field ("LookinAttr_ViewLayer_Border_Width", "__Internal")]
		NSString LookinAttr_ViewLayer_Border_Width { get; }

		// extern const LookinAttrIdentifier LookinAttr_ViewLayer_Shadow_Color;
		[Field ("LookinAttr_ViewLayer_Shadow_Color", "__Internal")]
		NSString LookinAttr_ViewLayer_Shadow_Color { get; }

		// extern const LookinAttrIdentifier LookinAttr_ViewLayer_Shadow_Opacity;
		[Field ("LookinAttr_ViewLayer_Shadow_Opacity", "__Internal")]
		NSString LookinAttr_ViewLayer_Shadow_Opacity { get; }

		// extern const LookinAttrIdentifier LookinAttr_ViewLayer_Shadow_Radius;
		[Field ("LookinAttr_ViewLayer_Shadow_Radius", "__Internal")]
		NSString LookinAttr_ViewLayer_Shadow_Radius { get; }

		// extern const LookinAttrIdentifier LookinAttr_ViewLayer_Shadow_OffsetW;
		[Field ("LookinAttr_ViewLayer_Shadow_OffsetW", "__Internal")]
		NSString LookinAttr_ViewLayer_Shadow_OffsetW { get; }

		// extern const LookinAttrIdentifier LookinAttr_ViewLayer_Shadow_OffsetH;
		[Field ("LookinAttr_ViewLayer_Shadow_OffsetH", "__Internal")]
		NSString LookinAttr_ViewLayer_Shadow_OffsetH { get; }

		// extern const LookinAttrIdentifier LookinAttr_ViewLayer_ContentMode_Mode;
		[Field ("LookinAttr_ViewLayer_ContentMode_Mode", "__Internal")]
		NSString LookinAttr_ViewLayer_ContentMode_Mode { get; }

		// extern const LookinAttrIdentifier LookinAttr_ViewLayer_TintColor_Color;
		[Field ("LookinAttr_ViewLayer_TintColor_Color", "__Internal")]
		NSString LookinAttr_ViewLayer_TintColor_Color { get; }

		// extern const LookinAttrIdentifier LookinAttr_ViewLayer_TintColor_Mode;
		[Field ("LookinAttr_ViewLayer_TintColor_Mode", "__Internal")]
		NSString LookinAttr_ViewLayer_TintColor_Mode { get; }

		// extern const LookinAttrIdentifier LookinAttr_ViewLayer_Tag_Tag;
		[Field ("LookinAttr_ViewLayer_Tag_Tag", "__Internal")]
		NSString LookinAttr_ViewLayer_Tag_Tag { get; }

		// extern const LookinAttrIdentifier LookinAttr_UIImageView_Name_Name;
		[Field ("LookinAttr_UIImageView_Name_Name", "__Internal")]
		NSString LookinAttr_UIImageView_Name_Name { get; }

		// extern const LookinAttrIdentifier LookinAttr_UIImageView_Open_Open;
		[Field ("LookinAttr_UIImageView_Open_Open", "__Internal")]
		NSString LookinAttr_UIImageView_Open_Open { get; }

		// extern const LookinAttrIdentifier LookinAttr_UILabel_Text_Text;
		[Field ("LookinAttr_UILabel_Text_Text", "__Internal")]
		NSString LookinAttr_UILabel_Text_Text { get; }

		// extern const LookinAttrIdentifier LookinAttr_UILabel_Font_Name;
		[Field ("LookinAttr_UILabel_Font_Name", "__Internal")]
		NSString LookinAttr_UILabel_Font_Name { get; }

		// extern const LookinAttrIdentifier LookinAttr_UILabel_Font_Size;
		[Field ("LookinAttr_UILabel_Font_Size", "__Internal")]
		NSString LookinAttr_UILabel_Font_Size { get; }

		// extern const LookinAttrIdentifier LookinAttr_UILabel_NumberOfLines_NumberOfLines;
		[Field ("LookinAttr_UILabel_NumberOfLines_NumberOfLines", "__Internal")]
		NSString LookinAttr_UILabel_NumberOfLines_NumberOfLines { get; }

		// extern const LookinAttrIdentifier LookinAttr_UILabel_TextColor_Color;
		[Field ("LookinAttr_UILabel_TextColor_Color", "__Internal")]
		NSString LookinAttr_UILabel_TextColor_Color { get; }

		// extern const LookinAttrIdentifier LookinAttr_UILabel_Alignment_Alignment;
		[Field ("LookinAttr_UILabel_Alignment_Alignment", "__Internal")]
		NSString LookinAttr_UILabel_Alignment_Alignment { get; }

		// extern const LookinAttrIdentifier LookinAttr_UILabel_BreakMode_Mode;
		[Field ("LookinAttr_UILabel_BreakMode_Mode", "__Internal")]
		NSString LookinAttr_UILabel_BreakMode_Mode { get; }

		// extern const LookinAttrIdentifier LookinAttr_UILabel_CanAdjustFont_CanAdjustFont;
		[Field ("LookinAttr_UILabel_CanAdjustFont_CanAdjustFont", "__Internal")]
		NSString LookinAttr_UILabel_CanAdjustFont_CanAdjustFont { get; }

		// extern const LookinAttrIdentifier LookinAttr_UIControl_EnabledSelected_Enabled;
		[Field ("LookinAttr_UIControl_EnabledSelected_Enabled", "__Internal")]
		NSString LookinAttr_UIControl_EnabledSelected_Enabled { get; }

		// extern const LookinAttrIdentifier LookinAttr_UIControl_EnabledSelected_Selected;
		[Field ("LookinAttr_UIControl_EnabledSelected_Selected", "__Internal")]
		NSString LookinAttr_UIControl_EnabledSelected_Selected { get; }

		// extern const LookinAttrIdentifier LookinAttr_UIControl_VerAlignment_Alignment;
		[Field ("LookinAttr_UIControl_VerAlignment_Alignment", "__Internal")]
		NSString LookinAttr_UIControl_VerAlignment_Alignment { get; }

		// extern const LookinAttrIdentifier LookinAttr_UIControl_HorAlignment_Alignment;
		[Field ("LookinAttr_UIControl_HorAlignment_Alignment", "__Internal")]
		NSString LookinAttr_UIControl_HorAlignment_Alignment { get; }

		// extern const LookinAttrIdentifier LookinAttr_UIControl_QMUIOutsideEdge_Edge;
		[Field ("LookinAttr_UIControl_QMUIOutsideEdge_Edge", "__Internal")]
		NSString LookinAttr_UIControl_QMUIOutsideEdge_Edge { get; }

		// extern const LookinAttrIdentifier LookinAttr_UIButton_ContentInsets_Insets;
		[Field ("LookinAttr_UIButton_ContentInsets_Insets", "__Internal")]
		NSString LookinAttr_UIButton_ContentInsets_Insets { get; }

		// extern const LookinAttrIdentifier LookinAttr_UIButton_TitleInsets_Insets;
		[Field ("LookinAttr_UIButton_TitleInsets_Insets", "__Internal")]
		NSString LookinAttr_UIButton_TitleInsets_Insets { get; }

		// extern const LookinAttrIdentifier LookinAttr_UIButton_ImageInsets_Insets;
		[Field ("LookinAttr_UIButton_ImageInsets_Insets", "__Internal")]
		NSString LookinAttr_UIButton_ImageInsets_Insets { get; }

		// extern const LookinAttrIdentifier LookinAttr_UIScrollView_Offset_Offset;
		[Field ("LookinAttr_UIScrollView_Offset_Offset", "__Internal")]
		NSString LookinAttr_UIScrollView_Offset_Offset { get; }

		// extern const LookinAttrIdentifier LookinAttr_UIScrollView_ContentSize_Size;
		[Field ("LookinAttr_UIScrollView_ContentSize_Size", "__Internal")]
		NSString LookinAttr_UIScrollView_ContentSize_Size { get; }

		// extern const LookinAttrIdentifier LookinAttr_UIScrollView_ContentInset_Inset;
		[Field ("LookinAttr_UIScrollView_ContentInset_Inset", "__Internal")]
		NSString LookinAttr_UIScrollView_ContentInset_Inset { get; }

		// extern const LookinAttrIdentifier LookinAttr_UIScrollView_AdjustedInset_Inset;
		[Field ("LookinAttr_UIScrollView_AdjustedInset_Inset", "__Internal")]
		NSString LookinAttr_UIScrollView_AdjustedInset_Inset { get; }

		// extern const LookinAttrIdentifier LookinAttr_UIScrollView_Behavior_Behavior;
		[Field ("LookinAttr_UIScrollView_Behavior_Behavior", "__Internal")]
		NSString LookinAttr_UIScrollView_Behavior_Behavior { get; }

		// extern const LookinAttrIdentifier LookinAttr_UIScrollView_IndicatorInset_Inset;
		[Field ("LookinAttr_UIScrollView_IndicatorInset_Inset", "__Internal")]
		NSString LookinAttr_UIScrollView_IndicatorInset_Inset { get; }

		// extern const LookinAttrIdentifier LookinAttr_UIScrollView_ScrollPaging_ScrollEnabled;
		[Field ("LookinAttr_UIScrollView_ScrollPaging_ScrollEnabled", "__Internal")]
		NSString LookinAttr_UIScrollView_ScrollPaging_ScrollEnabled { get; }

		// extern const LookinAttrIdentifier LookinAttr_UIScrollView_ScrollPaging_PagingEnabled;
		[Field ("LookinAttr_UIScrollView_ScrollPaging_PagingEnabled", "__Internal")]
		NSString LookinAttr_UIScrollView_ScrollPaging_PagingEnabled { get; }

		// extern const LookinAttrIdentifier LookinAttr_UIScrollView_Bounce_Ver;
		[Field ("LookinAttr_UIScrollView_Bounce_Ver", "__Internal")]
		NSString LookinAttr_UIScrollView_Bounce_Ver { get; }

		// extern const LookinAttrIdentifier LookinAttr_UIScrollView_Bounce_Hor;
		[Field ("LookinAttr_UIScrollView_Bounce_Hor", "__Internal")]
		NSString LookinAttr_UIScrollView_Bounce_Hor { get; }

		// extern const LookinAttrIdentifier LookinAttr_UIScrollView_ShowsIndicator_Hor;
		[Field ("LookinAttr_UIScrollView_ShowsIndicator_Hor", "__Internal")]
		NSString LookinAttr_UIScrollView_ShowsIndicator_Hor { get; }

		// extern const LookinAttrIdentifier LookinAttr_UIScrollView_ShowsIndicator_Ver;
		[Field ("LookinAttr_UIScrollView_ShowsIndicator_Ver", "__Internal")]
		NSString LookinAttr_UIScrollView_ShowsIndicator_Ver { get; }

		// extern const LookinAttrIdentifier LookinAttr_UIScrollView_ContentTouches_Delay;
		[Field ("LookinAttr_UIScrollView_ContentTouches_Delay", "__Internal")]
		NSString LookinAttr_UIScrollView_ContentTouches_Delay { get; }

		// extern const LookinAttrIdentifier LookinAttr_UIScrollView_ContentTouches_CanCancel;
		[Field ("LookinAttr_UIScrollView_ContentTouches_CanCancel", "__Internal")]
		NSString LookinAttr_UIScrollView_ContentTouches_CanCancel { get; }

		// extern const LookinAttrIdentifier LookinAttr_UIScrollView_Zoom_MinScale;
		[Field ("LookinAttr_UIScrollView_Zoom_MinScale", "__Internal")]
		NSString LookinAttr_UIScrollView_Zoom_MinScale { get; }

		// extern const LookinAttrIdentifier LookinAttr_UIScrollView_Zoom_MaxScale;
		[Field ("LookinAttr_UIScrollView_Zoom_MaxScale", "__Internal")]
		NSString LookinAttr_UIScrollView_Zoom_MaxScale { get; }

		// extern const LookinAttrIdentifier LookinAttr_UIScrollView_Zoom_Scale;
		[Field ("LookinAttr_UIScrollView_Zoom_Scale", "__Internal")]
		NSString LookinAttr_UIScrollView_Zoom_Scale { get; }

		// extern const LookinAttrIdentifier LookinAttr_UIScrollView_Zoom_Bounce;
		[Field ("LookinAttr_UIScrollView_Zoom_Bounce", "__Internal")]
		NSString LookinAttr_UIScrollView_Zoom_Bounce { get; }

		// extern const LookinAttrIdentifier LookinAttr_UIScrollView_QMUIInitialInset_Inset;
		[Field ("LookinAttr_UIScrollView_QMUIInitialInset_Inset", "__Internal")]
		NSString LookinAttr_UIScrollView_QMUIInitialInset_Inset { get; }

		// extern const LookinAttrIdentifier LookinAttr_UITableView_Style_Style;
		[Field ("LookinAttr_UITableView_Style_Style", "__Internal")]
		NSString LookinAttr_UITableView_Style_Style { get; }

		// extern const LookinAttrIdentifier LookinAttr_UITableView_SectionsNumber_Number;
		[Field ("LookinAttr_UITableView_SectionsNumber_Number", "__Internal")]
		NSString LookinAttr_UITableView_SectionsNumber_Number { get; }

		// extern const LookinAttrIdentifier LookinAttr_UITableView_RowsNumber_Number;
		[Field ("LookinAttr_UITableView_RowsNumber_Number", "__Internal")]
		NSString LookinAttr_UITableView_RowsNumber_Number { get; }

		// extern const LookinAttrIdentifier LookinAttr_UITableView_SeparatorInset_Inset;
		[Field ("LookinAttr_UITableView_SeparatorInset_Inset", "__Internal")]
		NSString LookinAttr_UITableView_SeparatorInset_Inset { get; }

		// extern const LookinAttrIdentifier LookinAttr_UITableView_SeparatorColor_Color;
		[Field ("LookinAttr_UITableView_SeparatorColor_Color", "__Internal")]
		NSString LookinAttr_UITableView_SeparatorColor_Color { get; }

		// extern const LookinAttrIdentifier LookinAttr_UITableView_SeparatorStyle_Style;
		[Field ("LookinAttr_UITableView_SeparatorStyle_Style", "__Internal")]
		NSString LookinAttr_UITableView_SeparatorStyle_Style { get; }

		// extern const LookinAttrIdentifier LookinAttr_UITextView_Font_Name;
		[Field ("LookinAttr_UITextView_Font_Name", "__Internal")]
		NSString LookinAttr_UITextView_Font_Name { get; }

		// extern const LookinAttrIdentifier LookinAttr_UITextView_Font_Size;
		[Field ("LookinAttr_UITextView_Font_Size", "__Internal")]
		NSString LookinAttr_UITextView_Font_Size { get; }

		// extern const LookinAttrIdentifier LookinAttr_UITextView_Basic_Editable;
		[Field ("LookinAttr_UITextView_Basic_Editable", "__Internal")]
		NSString LookinAttr_UITextView_Basic_Editable { get; }

		// extern const LookinAttrIdentifier LookinAttr_UITextView_Basic_Selectable;
		[Field ("LookinAttr_UITextView_Basic_Selectable", "__Internal")]
		NSString LookinAttr_UITextView_Basic_Selectable { get; }

		// extern const LookinAttrIdentifier LookinAttr_UITextView_Text_Text;
		[Field ("LookinAttr_UITextView_Text_Text", "__Internal")]
		NSString LookinAttr_UITextView_Text_Text { get; }

		// extern const LookinAttrIdentifier LookinAttr_UITextView_TextColor_Color;
		[Field ("LookinAttr_UITextView_TextColor_Color", "__Internal")]
		NSString LookinAttr_UITextView_TextColor_Color { get; }

		// extern const LookinAttrIdentifier LookinAttr_UITextView_Alignment_Alignment;
		[Field ("LookinAttr_UITextView_Alignment_Alignment", "__Internal")]
		NSString LookinAttr_UITextView_Alignment_Alignment { get; }

		// extern const LookinAttrIdentifier LookinAttr_UITextView_ContainerInset_Inset;
		[Field ("LookinAttr_UITextView_ContainerInset_Inset", "__Internal")]
		NSString LookinAttr_UITextView_ContainerInset_Inset { get; }

		// extern const LookinAttrIdentifier LookinAttr_UITextField_Text_Text;
		[Field ("LookinAttr_UITextField_Text_Text", "__Internal")]
		NSString LookinAttr_UITextField_Text_Text { get; }

		// extern const LookinAttrIdentifier LookinAttr_UITextField_Placeholder_Placeholder;
		[Field ("LookinAttr_UITextField_Placeholder_Placeholder", "__Internal")]
		NSString LookinAttr_UITextField_Placeholder_Placeholder { get; }

		// extern const LookinAttrIdentifier LookinAttr_UITextField_Font_Name;
		[Field ("LookinAttr_UITextField_Font_Name", "__Internal")]
		NSString LookinAttr_UITextField_Font_Name { get; }

		// extern const LookinAttrIdentifier LookinAttr_UITextField_Font_Size;
		[Field ("LookinAttr_UITextField_Font_Size", "__Internal")]
		NSString LookinAttr_UITextField_Font_Size { get; }

		// extern const LookinAttrIdentifier LookinAttr_UITextField_TextColor_Color;
		[Field ("LookinAttr_UITextField_TextColor_Color", "__Internal")]
		NSString LookinAttr_UITextField_TextColor_Color { get; }

		// extern const LookinAttrIdentifier LookinAttr_UITextField_Alignment_Alignment;
		[Field ("LookinAttr_UITextField_Alignment_Alignment", "__Internal")]
		NSString LookinAttr_UITextField_Alignment_Alignment { get; }

		// extern const LookinAttrIdentifier LookinAttr_UITextField_Clears_ClearsOnBeginEditing;
		[Field ("LookinAttr_UITextField_Clears_ClearsOnBeginEditing", "__Internal")]
		NSString LookinAttr_UITextField_Clears_ClearsOnBeginEditing { get; }

		// extern const LookinAttrIdentifier LookinAttr_UITextField_Clears_ClearsOnInsertion;
		[Field ("LookinAttr_UITextField_Clears_ClearsOnInsertion", "__Internal")]
		NSString LookinAttr_UITextField_Clears_ClearsOnInsertion { get; }

		// extern const LookinAttrIdentifier LookinAttr_UITextField_CanAdjustFont_CanAdjustFont;
		[Field ("LookinAttr_UITextField_CanAdjustFont_CanAdjustFont", "__Internal")]
		NSString LookinAttr_UITextField_CanAdjustFont_CanAdjustFont { get; }

		// extern const LookinAttrIdentifier LookinAttr_UITextField_CanAdjustFont_MinSize;
		[Field ("LookinAttr_UITextField_CanAdjustFont_MinSize", "__Internal")]
		NSString LookinAttr_UITextField_CanAdjustFont_MinSize { get; }

		// extern const LookinAttrIdentifier LookinAttr_UITextField_ClearButtonMode_Mode;
		[Field ("LookinAttr_UITextField_ClearButtonMode_Mode", "__Internal")]
		NSString LookinAttr_UITextField_ClearButtonMode_Mode { get; }

		// extern const LookinAttrIdentifier LookinAttr_UIVisualEffectView_Style_Style;
		[Field ("LookinAttr_UIVisualEffectView_Style_Style", "__Internal")]
		NSString LookinAttr_UIVisualEffectView_Style_Style { get; }

		// extern const LookinAttrIdentifier LookinAttr_UIVisualEffectView_QMUIForegroundColor_Color;
		[Field ("LookinAttr_UIVisualEffectView_QMUIForegroundColor_Color", "__Internal")]
		NSString LookinAttr_UIVisualEffectView_QMUIForegroundColor_Color { get; }
	}

	// @interface LookinAttribute : NSObject <NSSecureCoding, NSCopying>
	[BaseType (typeof(NSObject))]
	interface LookinAttribute : INSSecureCoding, INSCopying
	{
		// @property (copy, nonatomic) LookinAttrIdentifier identifier;
		[Export ("identifier")]
		string Identifier { get; set; }

		// @property (nonatomic, strong) id value;
		[Export ("value", ArgumentSemantic.Strong)]
		NSObject Value { get; set; }

		// @property (assign, nonatomic) LookinAttrType attrType;
		[Export ("attrType", ArgumentSemantic.Assign)]
		LookinAttrType AttrType { get; set; }

		// @property (nonatomic, weak) LookinDisplayItem * targetDisplayItem;
		[Export ("targetDisplayItem", ArgumentSemantic.Weak)]
		LookinDisplayItem TargetDisplayItem { get; set; }
	}

	// @interface LookinAttributeModification : NSObject <NSSecureCoding>
	[BaseType (typeof(NSObject))]
	interface LookinAttributeModification : INSSecureCoding
	{
		// @property (assign, nonatomic) unsigned long targetOid;
		[Export ("targetOid")]
		nuint TargetOid { get; set; }

		// @property (assign, nonatomic) SEL setterSelector;
		[Export ("setterSelector", ArgumentSemantic.Assign)]
		Selector SetterSelector { get; set; }

		// @property (assign, nonatomic) SEL getterSelector;
		[Export ("getterSelector", ArgumentSemantic.Assign)]
		Selector GetterSelector { get; set; }

		// @property (assign, nonatomic) LookinAttrType attrType;
		[Export ("attrType", ArgumentSemantic.Assign)]
		LookinAttrType AttrType { get; set; }

		// @property (nonatomic, strong) id value;
		[Export ("value", ArgumentSemantic.Strong)]
		NSObject Value { get; set; }
	}

	// @interface LookinAttributesGroup : NSObject <NSSecureCoding, NSCopying>
	[BaseType (typeof(NSObject))]
	interface LookinAttributesGroup : INSSecureCoding, INSCopying
	{
		// @property (copy, nonatomic) LookinAttrGroupIdentifier identifier;
		[Export ("identifier")]
		string Identifier { get; set; }

		// @property (copy, nonatomic) NSArray<LookinAttributesSection *> * attrSections;
		[Export ("attrSections", ArgumentSemantic.Copy)]
		LookinAttributesSection[] AttrSections { get; set; }
	}

	// @interface LookinAttributesSection : NSObject <NSSecureCoding, NSCopying>
	[BaseType (typeof(NSObject))]
	interface LookinAttributesSection : INSSecureCoding, INSCopying
	{
		// @property (copy, nonatomic) LookinAttrSectionIdentifier identifier;
		[Export ("identifier")]
		string Identifier { get; set; }

		// @property (copy, nonatomic) NSArray<LookinAttribute *> * attributes;
		[Export ("attributes", ArgumentSemantic.Copy)]
		LookinAttribute[] Attributes { get; set; }
	}

	// @interface LookinAutoLayoutConstraint : NSObject <NSSecureCoding>
	[BaseType (typeof(NSObject))]
	interface LookinAutoLayoutConstraint : INSSecureCoding
	{
		// +(instancetype)instanceFromNSConstraint:(NSLayoutConstraint *)constraint isEffective:(BOOL)isEffective firstItemType:(LookinConstraintItemType)firstItemType secondItemType:(LookinConstraintItemType)secondItemType;
		[Static]
		[Export ("instanceFromNSConstraint:isEffective:firstItemType:secondItemType:")]
		LookinAutoLayoutConstraint InstanceFromNSConstraint (NSLayoutConstraint constraint, bool isEffective, LookinConstraintItemType firstItemType, LookinConstraintItemType secondItemType);

		// @property (assign, nonatomic) BOOL effective;
		[Export ("effective")]
		bool Effective { get; set; }

		// @property (assign, nonatomic) BOOL active;
		[Export ("active")]
		bool Active { get; set; }

		// @property (assign, nonatomic) BOOL shouldBeArchived;
		[Export ("shouldBeArchived")]
		bool ShouldBeArchived { get; set; }

		// @property (nonatomic, strong) LookinObject * firstItem;
		[Export ("firstItem", ArgumentSemantic.Strong)]
		LookinObject FirstItem { get; set; }

		// @property (assign, nonatomic) LookinConstraintItemType firstItemType;
		[Export ("firstItemType", ArgumentSemantic.Assign)]
		LookinConstraintItemType FirstItemType { get; set; }

		// @property (assign, nonatomic) NSLayoutAttribute firstAttribute;
		[Export ("firstAttribute", ArgumentSemantic.Assign)]
		NSLayoutAttribute FirstAttribute { get; set; }

		// @property (assign, nonatomic) NSLayoutRelation relation;
		[Export ("relation", ArgumentSemantic.Assign)]
		NSLayoutRelation Relation { get; set; }

		// @property (nonatomic, strong) LookinObject * secondItem;
		[Export ("secondItem", ArgumentSemantic.Strong)]
		LookinObject SecondItem { get; set; }

		// @property (assign, nonatomic) LookinConstraintItemType secondItemType;
		[Export ("secondItemType", ArgumentSemantic.Assign)]
		LookinConstraintItemType SecondItemType { get; set; }

		// @property (assign, nonatomic) NSLayoutAttribute secondAttribute;
		[Export ("secondAttribute", ArgumentSemantic.Assign)]
		NSLayoutAttribute SecondAttribute { get; set; }

		// @property (assign, nonatomic) CGFloat multiplier;
		[Export ("multiplier")]
		nfloat Multiplier { get; set; }

		// @property (assign, nonatomic) CGFloat constant;
		[Export ("constant")]
		nfloat Constant { get; set; }

		// @property (assign, nonatomic) CGFloat priority;
		[Export ("priority")]
		nfloat Priority { get; set; }

		// @property (copy, nonatomic) NSString * identifier;
		[Export ("identifier")]
		string Identifier { get; set; }

		// +(NSString *)descriptionWithItemObject:(LookinObject *)object type:(LookinConstraintItemType)type detailed:(BOOL)detailed;
		[Static]
		[Export ("descriptionWithItemObject:type:detailed:")]
		string DescriptionWithItemObject (LookinObject @object, LookinConstraintItemType type, bool detailed);

		// +(NSString *)descriptionWithAttribute:(NSLayoutAttribute)attribute;
		[Static]
		[Export ("descriptionWithAttribute:")]
		string DescriptionWithAttribute (NSLayoutAttribute attribute);

		// +(NSString *)symbolWithRelation:(NSLayoutRelation)relation;
		[Static]
		[Export ("symbolWithRelation:")]
		string SymbolWithRelation (NSLayoutRelation relation);

		// +(NSString *)descriptionWithRelation:(NSLayoutRelation)relation;
		[Static]
		[Export ("descriptionWithRelation:")]
		string DescriptionWithRelation (NSLayoutRelation relation);
	}

	// @interface LookinConnectionAttachment : NSObject <NSSecureCoding>
	[BaseType (typeof(NSObject))]
	interface LookinConnectionAttachment : INSSecureCoding
	{
		// @property (assign, nonatomic) LookinCodingValueType dataType;
		[Export ("dataType", ArgumentSemantic.Assign)]
		LookinCodingValueType DataType { get; set; }

		// @property (nonatomic, strong) id data;
		[Export ("data", ArgumentSemantic.Strong)]
		NSObject Data { get; set; }
	}

	// @interface LookinConnectionResponseAttachment : LookinConnectionAttachment
	[BaseType (typeof(LookinConnectionAttachment))]
	interface LookinConnectionResponseAttachment
	{
		// +(instancetype)attachmentWithError:(NSError *)error;
		[Static]
		[Export ("attachmentWithError:")]
		LookinConnectionResponseAttachment AttachmentWithError (NSError error);

		// @property (assign, nonatomic) int lookinServerVersion;
		[Export ("lookinServerVersion")]
		int LookinServerVersion { get; set; }

		// @property (assign, nonatomic) BOOL lookinServerIsExprimental;
		[Export ("lookinServerIsExprimental")]
		bool LookinServerIsExprimental { get; set; }

		// @property (nonatomic, strong) NSError * error;
		[Export ("error", ArgumentSemantic.Strong)]
		NSError Error { get; set; }

		// @property (assign, nonatomic) BOOL appIsInBackground;
		[Export ("appIsInBackground")]
		bool AppIsInBackground { get; set; }

		// @property (assign, nonatomic) NSUInteger dataTotalCount;
		[Export ("dataTotalCount")]
		nuint DataTotalCount { get; set; }

		// @property (assign, nonatomic) NSUInteger currentDataCount;
		[Export ("currentDataCount")]
		nuint CurrentDataCount { get; set; }
	}

	// @interface LookinDashboardBlueprint : NSObject
	[BaseType (typeof(NSObject))]
	interface LookinDashboardBlueprint
	{
		// +(NSArray<LookinAttrGroupIdentifier> *)groupIDs;
		[Static]
		[Export ("groupIDs")]
		[Verify (MethodToProperty)]
		string[] GroupIDs { get; }

		// +(NSArray<LookinAttrSectionIdentifier> *)sectionIDsForGroupID:(LookinAttrGroupIdentifier)groupID;
		[Static]
		[Export ("sectionIDsForGroupID:")]
		string[] SectionIDsForGroupID (string groupID);

		// +(NSArray<LookinAttrIdentifier> *)attrIDsForSectionID:(LookinAttrSectionIdentifier)sectionID;
		[Static]
		[Export ("attrIDsForSectionID:")]
		string[] AttrIDsForSectionID (string sectionID);

		// +(void)getHostGroupID:(LookinAttrGroupIdentifier *)groupID sectionID:(LookinAttrSectionIdentifier *)sectionID fromAttrID:(LookinAttrIdentifier)attrID;
		[Static]
		[Export ("getHostGroupID:sectionID:fromAttrID:")]
		void GetHostGroupID (out string groupID, out string sectionID, string attrID);

		// +(NSString *)groupTitleWithGroupID:(LookinAttrGroupIdentifier)groupID;
		[Static]
		[Export ("groupTitleWithGroupID:")]
		string GroupTitleWithGroupID (string groupID);

		// +(NSString *)sectionTitleWithSectionID:(LookinAttrSectionIdentifier)secID;
		[Static]
		[Export ("sectionTitleWithSectionID:")]
		string SectionTitleWithSectionID (string secID);

		// +(LookinAttrType)objectAttrTypeWithAttrID:(LookinAttrIdentifier)attrID;
		[Static]
		[Export ("objectAttrTypeWithAttrID:")]
		LookinAttrType ObjectAttrTypeWithAttrID (string attrID);

		// +(NSString *)classNameWithAttrID:(LookinAttrIdentifier)attrID;
		[Static]
		[Export ("classNameWithAttrID:")]
		string ClassNameWithAttrID (string attrID);

		// +(BOOL)isUIViewPropertyWithAttrID:(LookinAttrIdentifier)attrID;
		[Static]
		[Export ("isUIViewPropertyWithAttrID:")]
		bool IsUIViewPropertyWithAttrID (string attrID);

		// +(NSString *)enumListNameWithAttrID:(LookinAttrIdentifier)attrID;
		[Static]
		[Export ("enumListNameWithAttrID:")]
		string EnumListNameWithAttrID (string attrID);

		// +(BOOL)needPatchAfterModificationWithAttrID:(LookinAttrIdentifier)attrID;
		[Static]
		[Export ("needPatchAfterModificationWithAttrID:")]
		bool NeedPatchAfterModificationWithAttrID (string attrID);

		// +(NSString *)fullTitleWithAttrID:(LookinAttrIdentifier)attrID;
		[Static]
		[Export ("fullTitleWithAttrID:")]
		string FullTitleWithAttrID (string attrID);

		// +(NSString *)briefTitleWithAttrID:(LookinAttrIdentifier)attrID;
		[Static]
		[Export ("briefTitleWithAttrID:")]
		string BriefTitleWithAttrID (string attrID);

		// +(SEL)getterWithAttrID:(LookinAttrIdentifier)attrID;
		[Static]
		[Export ("getterWithAttrID:")]
		Selector GetterWithAttrID (string attrID);

		// +(SEL)setterWithAttrID:(LookinAttrIdentifier)attrID;
		[Static]
		[Export ("setterWithAttrID:")]
		Selector SetterWithAttrID (string attrID);

		// +(BOOL)hideIfNilWithAttrID:(LookinAttrIdentifier)attrID;
		[Static]
		[Export ("hideIfNilWithAttrID:")]
		bool HideIfNilWithAttrID (string attrID);

		// +(NSInteger)minAvailableOSVersionWithAttrID:(LookinAttrIdentifier)attrID;
		[Static]
		[Export ("minAvailableOSVersionWithAttrID:")]
		nint MinAvailableOSVersionWithAttrID (string attrID);
	}

	// @interface LookinDisplayItemDetail : NSObject <NSSecureCoding>
	[BaseType (typeof(NSObject))]
	interface LookinDisplayItemDetail : INSSecureCoding
	{
		// @property (assign, nonatomic) unsigned long displayItemOid;
		[Export ("displayItemOid")]
		nuint DisplayItemOid { get; set; }

		// @property (nonatomic, strong) UIImage * groupScreenshot;
		[Export ("groupScreenshot", ArgumentSemantic.Strong)]
		UIImage GroupScreenshot { get; set; }

		// @property (nonatomic, strong) UIImage * soloScreenshot;
		[Export ("soloScreenshot", ArgumentSemantic.Strong)]
		UIImage SoloScreenshot { get; set; }

		// @property (nonatomic, strong) NSValue * frameValue;
		[Export ("frameValue", ArgumentSemantic.Strong)]
		NSValue FrameValue { get; set; }

		// @property (nonatomic, strong) NSValue * boundsValue;
		[Export ("boundsValue", ArgumentSemantic.Strong)]
		NSValue BoundsValue { get; set; }

		// @property (nonatomic, strong) NSNumber * hiddenValue;
		[Export ("hiddenValue", ArgumentSemantic.Strong)]
		NSNumber HiddenValue { get; set; }

		// @property (nonatomic, strong) NSNumber * alphaValue;
		[Export ("alphaValue", ArgumentSemantic.Strong)]
		NSNumber AlphaValue { get; set; }

		// @property (copy, nonatomic) NSArray<LookinAttributesGroup *> * attributesGroupList;
		[Export ("attributesGroupList", ArgumentSemantic.Copy)]
		LookinAttributesGroup[] AttributesGroupList { get; set; }
	}

	// @interface LookinEventHandler : NSObject <NSSecureCoding>
	[BaseType (typeof(NSObject))]
	interface LookinEventHandler : INSSecureCoding
	{
		// @property (assign, nonatomic) LookinEventHandlerType handlerType;
		[Export ("handlerType", ArgumentSemantic.Assign)]
		LookinEventHandlerType HandlerType { get; set; }

		// @property (copy, nonatomic) NSString * eventName;
		[Export ("eventName")]
		string EventName { get; set; }

		// @property (copy, nonatomic) NSArray<LookinStringTwoTuple *> * targetActions;
		[Export ("targetActions", ArgumentSemantic.Copy)]
		LookinStringTwoTuple[] TargetActions { get; set; }

		// @property (copy, nonatomic) NSString * inheritedRecognizerName;
		[Export ("inheritedRecognizerName")]
		string InheritedRecognizerName { get; set; }

		// @property (assign, nonatomic) BOOL gestureRecognizerIsEnabled;
		[Export ("gestureRecognizerIsEnabled")]
		bool GestureRecognizerIsEnabled { get; set; }

		// @property (copy, nonatomic) NSString * gestureRecognizerDelegator;
		[Export ("gestureRecognizerDelegator")]
		string GestureRecognizerDelegator { get; set; }

		// @property (copy, nonatomic) NSArray<NSString *> * recognizerIvarTraces;
		[Export ("recognizerIvarTraces", ArgumentSemantic.Copy)]
		string[] RecognizerIvarTraces { get; set; }

		// @property (assign, nonatomic) unsigned long long recognizerOid;
		[Export ("recognizerOid")]
		ulong RecognizerOid { get; set; }
	}

	// @interface LookinHierarchyFile : NSObject <NSSecureCoding>
	[BaseType (typeof(NSObject))]
	interface LookinHierarchyFile : INSSecureCoding
	{
		// @property (assign, nonatomic) int serverVersion;
		[Export ("serverVersion")]
		int ServerVersion { get; set; }

		// @property (nonatomic, strong) LookinHierarchyInfo * hierarchyInfo;
		[Export ("hierarchyInfo", ArgumentSemantic.Strong)]
		LookinHierarchyInfo HierarchyInfo { get; set; }

		// @property (copy, nonatomic) NSDictionary<NSNumber *,NSData *> * soloScreenshots;
		[Export ("soloScreenshots", ArgumentSemantic.Copy)]
		NSDictionary<NSNumber, NSData> SoloScreenshots { get; set; }

		// @property (copy, nonatomic) NSDictionary<NSNumber *,NSData *> * groupScreenshots;
		[Export ("groupScreenshots", ArgumentSemantic.Copy)]
		NSDictionary<NSNumber, NSData> GroupScreenshots { get; set; }

		// +(NSError *)verifyHierarchyFile:(LookinHierarchyFile *)file;
		[Static]
		[Export ("verifyHierarchyFile:")]
		NSError VerifyHierarchyFile (LookinHierarchyFile file);
	}

	// @interface LookinHierarchyInfo : NSObject <NSSecureCoding, NSCopying>
	[BaseType (typeof(NSObject))]
	interface LookinHierarchyInfo : INSSecureCoding, INSCopying
	{
		// +(instancetype)staticInfo;
		[Static]
		[Export ("staticInfo")]
		LookinHierarchyInfo StaticInfo ();

		// +(instancetype)exportedInfo;
		[Static]
		[Export ("exportedInfo")]
		LookinHierarchyInfo ExportedInfo ();

		// +(instancetype)perspectiveInfoWithIncludedWindows:(NSArray<UIWindow *> *)includedWindows excludedWindows:(NSArray<UIWindow *> *)excludedWindows;
		[Static]
		[Export ("perspectiveInfoWithIncludedWindows:excludedWindows:")]
		LookinHierarchyInfo PerspectiveInfoWithIncludedWindows (UIWindow[] includedWindows, UIWindow[] excludedWindows);

		// @property (copy, nonatomic) NSArray<LookinDisplayItem *> * displayItems;
		[Export ("displayItems", ArgumentSemantic.Copy)]
		LookinDisplayItem[] DisplayItems { get; set; }

		// @property (copy, nonatomic) NSDictionary<NSString *,id> * colorAlias;
		[Export ("colorAlias", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> ColorAlias { get; set; }

		// @property (copy, nonatomic) NSArray<NSString *> * collapsedClassList;
		[Export ("collapsedClassList", ArgumentSemantic.Copy)]
		string[] CollapsedClassList { get; set; }

		// @property (nonatomic, strong) LookinAppInfo * appInfo;
		[Export ("appInfo", ArgumentSemantic.Strong)]
		LookinAppInfo AppInfo { get; set; }

		// @property (assign, nonatomic) int serverVersion;
		[Export ("serverVersion")]
		int ServerVersion { get; set; }

		// @property (assign, nonatomic) int serverSetupType;
		[Export ("serverSetupType")]
		int ServerSetupType { get; set; }
	}

	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const LookinIvarTraceRelationValue_Self;
		[Field ("LookinIvarTraceRelationValue_Self", "__Internal")]
		NSString LookinIvarTraceRelationValue_Self { get; }
	}

	// @interface LookinIvarTrace : NSObject <NSSecureCoding, NSCopying>
	[BaseType (typeof(NSObject))]
	interface LookinIvarTrace : INSSecureCoding, INSCopying
	{
		// @property (copy, nonatomic) NSString * relation;
		[Export ("relation")]
		string Relation { get; set; }

		// @property (copy, nonatomic) NSString * hostClassName;
		[Export ("hostClassName")]
		string HostClassName { get; set; }

		// @property (copy, nonatomic) NSString * ivarName;
		[Export ("ivarName")]
		string IvarName { get; set; }

		// @property (nonatomic, weak) id hostObject;
		[Export ("hostObject", ArgumentSemantic.Weak)]
		NSObject HostObject { get; set; }
	}

	// @interface LookinServer (NSObject)
	[Category]
	[BaseType (typeof(NSObject))]
	interface NSObject_LookinServer
	{
		// @property (copy, nonatomic) NSArray<LookinIvarTrace *> * lks_ivarTraces;
		[Export ("lks_ivarTraces", ArgumentSemantic.Copy)]
		LookinIvarTrace[] Lks_ivarTraces { get; set; }
	}

	// @interface LookinMethodTraceRecordStackItem : NSObject
	[BaseType (typeof(NSObject))]
	interface LookinMethodTraceRecordStackItem
	{
		// @property (assign, nonatomic) NSUInteger idx;
		[Export ("idx")]
		nuint Idx { get; set; }

		// @property (copy, nonatomic) NSString * category;
		[Export ("category")]
		string Category { get; set; }

		// @property (copy, nonatomic) NSString * detail;
		[Export ("detail")]
		string Detail { get; set; }

		// @property (assign, nonatomic) BOOL isSystemSeriesEnding;
		[Export ("isSystemSeriesEnding")]
		bool IsSystemSeriesEnding { get; set; }

		// @property (assign, nonatomic) BOOL isSystemItem;
		[Export ("isSystemItem")]
		bool IsSystemItem { get; set; }
	}

	// @interface LookinMethodTraceRecord : NSObject <NSSecureCoding>
	[BaseType (typeof(NSObject))]
	interface LookinMethodTraceRecord : INSSecureCoding
	{
		// @property (copy, nonatomic) NSString * targetAddress;
		[Export ("targetAddress")]
		string TargetAddress { get; set; }

		// @property (copy, nonatomic) NSString * selClassName;
		[Export ("selClassName")]
		string SelClassName { get; set; }

		// @property (copy, nonatomic) NSString * selName;
		[Export ("selName")]
		string SelName { get; set; }

		// @property (copy, nonatomic) NSArray<NSString *> * args;
		[Export ("args", ArgumentSemantic.Copy)]
		string[] Args { get; set; }

		// @property (copy, nonatomic) NSArray<NSString *> * callStacks;
		[Export ("callStacks", ArgumentSemantic.Copy)]
		string[] CallStacks { get; set; }

		// @property (nonatomic, strong) NSDate * date;
		[Export ("date", ArgumentSemantic.Strong)]
		NSDate Date { get; set; }

		// @property (readonly, copy, nonatomic) NSString * combinedTitle;
		[Export ("combinedTitle")]
		string CombinedTitle { get; }

		// -(NSArray<LookinMethodTraceRecordStackItem *> *)briefFormattedCallStacks;
		[Export ("briefFormattedCallStacks")]
		[Verify (MethodToProperty)]
		LookinMethodTraceRecordStackItem[] BriefFormattedCallStacks { get; }

		// -(NSArray<LookinMethodTraceRecordStackItem *> *)completeFormattedCallStacks;
		[Export ("completeFormattedCallStacks")]
		[Verify (MethodToProperty)]
		LookinMethodTraceRecordStackItem[] CompleteFormattedCallStacks { get; }
	}

	// @interface LookinMsgActionParams : NSObject
	[BaseType (typeof(NSObject))]
	interface LookinMsgActionParams
	{
		// @property (nonatomic, strong) id value;
		[Export ("value", ArgumentSemantic.Strong)]
		NSObject Value { get; set; }

		// @property (assign, nonatomic) double doubleValue;
		[Export ("doubleValue")]
		double DoubleValue { get; set; }

		// @property (assign, nonatomic) NSInteger integerValue;
		[Export ("integerValue")]
		nint IntegerValue { get; set; }

		// @property (assign, nonatomic) BOOL boolValue;
		[Export ("boolValue")]
		bool BoolValue { get; set; }

		// @property (nonatomic, weak) id relatedObject;
		[Export ("relatedObject", ArgumentSemantic.Weak)]
		NSObject RelatedObject { get; set; }

		// @property (nonatomic, strong) id userInfo;
		[Export ("userInfo", ArgumentSemantic.Strong)]
		NSObject UserInfo { get; set; }
	}

	// @interface LookinMsgAttribute : NSObject
	[BaseType (typeof(NSObject))]
	interface LookinMsgAttribute
	{
		// +(instancetype)attributeWithValue:(id)value;
		[Static]
		[Export ("attributeWithValue:")]
		LookinMsgAttribute AttributeWithValue (NSObject value);

		// @property (readonly, nonatomic, strong) id currentValue;
		[Export ("currentValue", ArgumentSemantic.Strong)]
		NSObject CurrentValue { get; }

		// -(void)setValue:(id)value ignoreSubscriber:(id)ignoreSubscriber userInfo:(id)userInfo;
		[Export ("setValue:ignoreSubscriber:userInfo:")]
		void SetValue (NSObject value, NSObject ignoreSubscriber, NSObject userInfo);

		// -(void)subscribe:(id)target action:(SEL)action relatedObject:(id)relatedObject;
		[Export ("subscribe:action:relatedObject:")]
		void Subscribe (NSObject target, Selector action, NSObject relatedObject);

		// -(void)subscribe:(id)target action:(SEL)action relatedObject:(id)relatedObject sendAtOnce:(BOOL)sendAtOnce;
		[Export ("subscribe:action:relatedObject:sendAtOnce:")]
		void Subscribe (NSObject target, Selector action, NSObject relatedObject, bool sendAtOnce);
	}

	// @interface LookinDoubleMsgAttribute : LookinMsgAttribute
	[BaseType (typeof(LookinMsgAttribute))]
	interface LookinDoubleMsgAttribute
	{
		// @property (readonly, assign, nonatomic) double currentDoubleValue;
		[Export ("currentDoubleValue")]
		double CurrentDoubleValue { get; }

		// +(instancetype)attributeWithDouble:(double)value;
		[Static]
		[Export ("attributeWithDouble:")]
		LookinDoubleMsgAttribute AttributeWithDouble (double value);

		// -(void)setDoubleValue:(double)doubleValue ignoreSubscriber:(id)ignoreSubscriber;
		[Export ("setDoubleValue:ignoreSubscriber:")]
		void SetDoubleValue (double doubleValue, NSObject ignoreSubscriber);
	}

	// @interface LookinIntegerMsgAttribute : LookinMsgAttribute
	[BaseType (typeof(LookinMsgAttribute))]
	interface LookinIntegerMsgAttribute
	{
		// @property (readonly, assign, nonatomic) NSInteger currentIntegerValue;
		[Export ("currentIntegerValue")]
		nint CurrentIntegerValue { get; }

		// +(instancetype)attributeWithInteger:(NSInteger)value;
		[Static]
		[Export ("attributeWithInteger:")]
		LookinIntegerMsgAttribute AttributeWithInteger (nint value);

		// -(void)setIntegerValue:(NSInteger)integerValue ignoreSubscriber:(id)ignoreSubscriber;
		[Export ("setIntegerValue:ignoreSubscriber:")]
		void SetIntegerValue (nint integerValue, NSObject ignoreSubscriber);
	}

	// @interface LookinBOOLMsgAttribute : LookinMsgAttribute
	[BaseType (typeof(LookinMsgAttribute))]
	interface LookinBOOLMsgAttribute
	{
		// @property (readonly, assign, nonatomic) BOOL currentBOOLValue;
		[Export ("currentBOOLValue")]
		bool CurrentBOOLValue { get; }

		// +(instancetype)attributeWithBOOL:(BOOL)value;
		[Static]
		[Export ("attributeWithBOOL:")]
		LookinBOOLMsgAttribute AttributeWithBOOL (bool value);

		// -(void)setBOOLValue:(BOOL)BOOLValue ignoreSubscriber:(id)ignoreSubscriber;
		[Export ("setBOOLValue:ignoreSubscriber:")]
		void SetBOOLValue (bool BOOLValue, NSObject ignoreSubscriber);
	}

	// @interface LookinMsgTargetAction : NSObject
	[BaseType (typeof(NSObject))]
	interface LookinMsgTargetAction
	{
		// @property (nonatomic, weak) id target;
		[Export ("target", ArgumentSemantic.Weak)]
		NSObject Target { get; set; }

		// @property (assign, nonatomic) SEL action;
		[Export ("action", ArgumentSemantic.Assign)]
		Selector Action { get; set; }

		// @property (nonatomic, weak) id relatedObject;
		[Export ("relatedObject", ArgumentSemantic.Weak)]
		NSObject RelatedObject { get; set; }
	}

	// @interface LkScreenshotFetchManager : NSObject
	[BaseType (typeof(NSObject))]
	interface LkScreenshotFetchManager
	{
		// +(instancetype)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		LkScreenshotFetchManager SharedInstance ();

		// -(void)prepare;
		[Export ("prepare")]
		void Prepare ();

		// -(void)fetchGroupScreenshotForAncestorsOfItem:(LookinDisplayItem *)item;
		[Export ("fetchGroupScreenshotForAncestorsOfItem:")]
		void FetchGroupScreenshotForAncestorsOfItem (LookinDisplayItem item);

		// -(void)fetchSoloScreenshotForItem:(LookinDisplayItem *)item;
		[Export ("fetchSoloScreenshotForItem:")]
		void FetchSoloScreenshotForItem (LookinDisplayItem item);

		// -(void)fetchGroupScreenshotForItem:(LookinDisplayItem *)item;
		[Export ("fetchGroupScreenshotForItem:")]
		void FetchGroupScreenshotForItem (LookinDisplayItem item);

		// -(void)submitTasks;
		[Export ("submitTasks")]
		void SubmitTasks ();

		// -(void)fetchAndUpdateScreenshotsForItems:(NSArray<LookinDisplayItem *> *)items;
		[Export ("fetchAndUpdateScreenshotsForItems:")]
		void FetchAndUpdateScreenshotsForItems (LookinDisplayItem[] items);
	}

	// @interface LookinServer (NSObject)
	[Category]
	[BaseType (typeof(NSObject))]
	interface NSObject_LookinServer
	{
		// -(unsigned long)lks_registerOid;
		[Export ("lks_registerOid")]
		[Verify (MethodToProperty)]
		nuint Lks_registerOid { get; }

		// @property (assign, nonatomic) unsigned long lks_oid;
		[Export ("lks_oid")]
		nuint Lks_oid { get; set; }

		// +(NSObject *)lks_objectWithOid:(unsigned long)oid;
		[Static]
		[Export ("lks_objectWithOid:")]
		NSObject Lks_objectWithOid (nuint oid);

		// @property (copy, nonatomic) NSString * lks_specialTrace;
		[Export ("lks_specialTrace")]
		string Lks_specialTrace { get; set; }

		// +(void)lks_clearAllObjectsTraces;
		[Static]
		[Export ("lks_clearAllObjectsTraces")]
		void Lks_clearAllObjectsTraces ();

		// -(NSArray<NSString *> *)lks_classChainListWithSwiftPrefix:(BOOL)hasSwiftPrefix;
		[Export ("lks_classChainListWithSwiftPrefix:")]
		string[] Lks_classChainListWithSwiftPrefix (bool hasSwiftPrefix);

		// -(NSString *)lks_shortClassName;
		[Export ("lks_shortClassName")]
		[Verify (MethodToProperty)]
		string Lks_shortClassName { get; }
	}

	// @interface LookinServer (UIBlurEffect)
	[Category]
	[BaseType (typeof(UIBlurEffect))]
	interface UIBlurEffect_LookinServer
	{
		// @property (nonatomic, strong) NSNumber * lks_effectStyleNumber;
		[Export ("lks_effectStyleNumber", ArgumentSemantic.Strong)]
		NSNumber Lks_effectStyleNumber { get; set; }
	}

	// @interface LookinServer (UIColor)
	[Category]
	[BaseType (typeof(UIColor))]
	interface UIColor_LookinServer
	{
		// -(NSArray<NSNumber *> *)lks_rgbaComponents;
		[Export ("lks_rgbaComponents")]
		[Verify (MethodToProperty)]
		NSNumber[] Lks_rgbaComponents { get; }

		// +(instancetype)lks_colorFromRGBAComponents:(NSArray<NSNumber *> *)components;
		[Static]
		[Export ("lks_colorFromRGBAComponents:")]
		UIColor Lks_colorFromRGBAComponents (NSNumber[] components);

		// -(NSString *)lks_rgbaString;
		[Export ("lks_rgbaString")]
		[Verify (MethodToProperty)]
		string Lks_rgbaString { get; }

		// -(NSString *)lks_hexString;
		[Export ("lks_hexString")]
		[Verify (MethodToProperty)]
		string Lks_hexString { get; }

		// +(UIColor *)lks_colorWithCGColor:(CGColorRef)cgColor;
		[Static]
		[Export ("lks_colorWithCGColor:")]
		UIColor Lks_colorWithCGColor (CGColor cgColor);
	}

	// @interface LookinServer (UIGestureRecognizer)
	[Category]
	[BaseType (typeof(UIGestureRecognizer))]
	interface UIGestureRecognizer_LookinServer
	{
		// @property (nonatomic, strong) NSMutableArray<LookinTwoTuple *> * lks_targetActions;
		[Export ("lks_targetActions", ArgumentSemantic.Strong)]
		NSMutableArray<LookinTwoTuple> Lks_targetActions { get; set; }
	}

	// @interface LookinServer (UIImage)
	[Category]
	[BaseType (typeof(UIImage))]
	interface UIImage_LookinServer
	{
		// @property (copy, nonatomic) NSString * lks_imageSourceName;
		[Export ("lks_imageSourceName")]
		string Lks_imageSourceName { get; set; }

		// -(NSData *)lookin_data;
		[Export ("lookin_data")]
		[Verify (MethodToProperty)]
		NSData Lookin_data { get; }
	}

	// @interface LookinServer (UIImageView)
	[Category]
	[BaseType (typeof(UIImageView))]
	interface UIImageView_LookinServer
	{
		// -(NSString *)lks_imageSourceName;
		[Export ("lks_imageSourceName")]
		[Verify (MethodToProperty)]
		string Lks_imageSourceName { get; }

		// -(NSNumber *)lks_imageViewOidIfHasImage;
		[Export ("lks_imageViewOidIfHasImage")]
		[Verify (MethodToProperty)]
		NSNumber Lks_imageViewOidIfHasImage { get; }
	}

	// @interface LookinServer (UILabel)
	[Category]
	[BaseType (typeof(UILabel))]
	interface UILabel_LookinServer
	{
		// @property (assign, nonatomic) CGFloat lks_fontSize;
		[Export ("lks_fontSize")]
		nfloat Lks_fontSize { get; set; }

		// -(NSString *)lks_fontName;
		[Export ("lks_fontName")]
		[Verify (MethodToProperty)]
		string Lks_fontName { get; }
	}

	// @interface LookinServer (UITableView)
	[Category]
	[BaseType (typeof(UITableView))]
	interface UITableView_LookinServer
	{
		// -(NSArray<NSNumber *> *)lks_numberOfRows;
		[Export ("lks_numberOfRows")]
		[Verify (MethodToProperty)]
		NSNumber[] Lks_numberOfRows { get; }
	}

	// @interface LookinServer (UITextField)
	[Category]
	[BaseType (typeof(UITextField))]
	interface UITextField_LookinServer
	{
		// @property (assign, nonatomic) CGFloat lks_fontSize;
		[Export ("lks_fontSize")]
		nfloat Lks_fontSize { get; set; }

		// -(NSString *)lks_fontName;
		[Export ("lks_fontName")]
		[Verify (MethodToProperty)]
		string Lks_fontName { get; }
	}

	// @interface LookinServer (UITextView)
	[Category]
	[BaseType (typeof(UITextView))]
	interface UITextView_LookinServer
	{
		// @property (assign, nonatomic) CGFloat lks_fontSize;
		[Export ("lks_fontSize")]
		nfloat Lks_fontSize { get; set; }

		// -(NSString *)lks_fontName;
		[Export ("lks_fontName")]
		[Verify (MethodToProperty)]
		string Lks_fontName { get; }
	}

	// @interface LookinServer (UIView)
	[Category]
	[BaseType (typeof(UIView))]
	interface UIView_LookinServer
	{
		// @property (nonatomic, weak) UIViewController * lks_hostViewController;
		[Export ("lks_hostViewController", ArgumentSemantic.Weak)]
		UIViewController Lks_hostViewController { get; set; }

		// @property (assign, nonatomic) BOOL lks_isChildrenViewOfTabBar;
		[Export ("lks_isChildrenViewOfTabBar")]
		bool Lks_isChildrenViewOfTabBar { get; set; }

		// -(UIView *)lks_subviewAtPoint:(CGPoint)point preferredClasses:(NSArray<Class> *)preferredClasses;
		[Export ("lks_subviewAtPoint:preferredClasses:")]
		UIView Lks_subviewAtPoint (CGPoint point, Class[] preferredClasses);

		// -(CGFloat)lks_bestWidth;
		[Export ("lks_bestWidth")]
		[Verify (MethodToProperty)]
		nfloat Lks_bestWidth { get; }

		// -(CGFloat)lks_bestHeight;
		[Export ("lks_bestHeight")]
		[Verify (MethodToProperty)]
		nfloat Lks_bestHeight { get; }

		// -(CGSize)lks_bestSize;
		[Export ("lks_bestSize")]
		[Verify (MethodToProperty)]
		CGSize Lks_bestSize { get; }

		// @property (assign, nonatomic) float lks_horizontalContentHuggingPriority;
		[Export ("lks_horizontalContentHuggingPriority")]
		float Lks_horizontalContentHuggingPriority { get; set; }

		// @property (assign, nonatomic) float lks_verticalContentHuggingPriority;
		[Export ("lks_verticalContentHuggingPriority")]
		float Lks_verticalContentHuggingPriority { get; set; }

		// @property (assign, nonatomic) float lks_horizontalContentCompressionResistancePriority;
		[Export ("lks_horizontalContentCompressionResistancePriority")]
		float Lks_horizontalContentCompressionResistancePriority { get; set; }

		// @property (assign, nonatomic) float lks_verticalContentCompressionResistancePriority;
		[Export ("lks_verticalContentCompressionResistancePriority")]
		float Lks_verticalContentCompressionResistancePriority { get; set; }

		// +(void)lks_rebuildGlobalInvolvedRawConstraints;
		[Static]
		[Export ("lks_rebuildGlobalInvolvedRawConstraints")]
		void Lks_rebuildGlobalInvolvedRawConstraints ();

		// @property (nonatomic, strong) NSMutableArray<NSLayoutConstraint *> * lks_involvedRawConstraints;
		[Export ("lks_involvedRawConstraints", ArgumentSemantic.Strong)]
		NSMutableArray<NSLayoutConstraint> Lks_involvedRawConstraints { get; set; }

		// -(NSArray<NSDictionary<NSString *,id> *> *)lks_constraints;
		[Export ("lks_constraints")]
		[Verify (MethodToProperty)]
		NSDictionary<NSString, NSObject>[] Lks_constraints { get; }
	}

	// @interface LookinServer (UIViewController)
	[Category]
	[BaseType (typeof(UIViewController))]
	interface UIViewController_LookinServer
	{
		// +(UIViewController *)lks_visibleViewController;
		[Static]
		[Export ("lks_visibleViewController")]
		[Verify (MethodToProperty)]
		UIViewController Lks_visibleViewController { get; }
	}

	// @interface LookinServer (UIVisualEffectView)
	[Category]
	[BaseType (typeof(UIVisualEffectView))]
	interface UIVisualEffectView_LookinServer
	{
		// -(NSNumber *)lks_blurEffectStyleNumber;
		// -(void)setLks_blurEffectStyleNumber:(NSNumber *)lks_blurEffectStyleNumber;
		[Export ("lks_blurEffectStyleNumber")]
		[Verify (MethodToProperty)]
		NSNumber Lks_blurEffectStyleNumber { get; set; }
	}

	// @interface Lookin (NSArray)
	[Category]
	[BaseType (typeof(NSArray))]
	interface NSArray_Lookin
	{
		// -(NSArray<ValueType> *)lookin_resizeWithCount:(NSUInteger)count add:(ValueType (^)(NSUInteger))addBlock remove:(void (^)(NSUInteger, ValueType))removeBlock doNext:(void (^)(NSUInteger, ValueType))doBlock __attribute__((warn_unused_result("")));
		[Export ("lookin_resizeWithCount:add:remove:doNext:")]
		NSObject[] Lookin_resizeWithCount (nuint count, Func<nuint, NSObject> addBlock, Action<nuint, NSObject> removeBlock, Action<nuint, NSObject> doBlock);

		// +(NSArray *)lookin_arrayWithCount:(NSUInteger)count block:(id (^)(NSUInteger))block;
		[Static]
		[Export ("lookin_arrayWithCount:block:")]
		[Verify (StronglyTypedNSArray)]
		NSObject[] Lookin_arrayWithCount (nuint count, Func<nuint, NSObject> block);

		// -(BOOL)lookin_hasIndex:(NSInteger)index;
		[Export ("lookin_hasIndex:")]
		bool Lookin_hasIndex (nint index);

		// -(NSArray *)lookin_map:(id (^)(NSUInteger, ValueType))block;
		[Export ("lookin_map:")]
		[Verify (StronglyTypedNSArray)]
		NSObject[] Lookin_map (Func<nuint, NSObject, NSObject> block);

		// -(NSArray<ValueType> *)lookin_filter:(BOOL (^)(ValueType))block;
		[Export ("lookin_filter:")]
		NSObject[] Lookin_filter (Func<NSObject, bool> block);

		// -(ValueType)lookin_firstFiltered:(BOOL (^)(ValueType))block;
		[Export ("lookin_firstFiltered:")]
		NSObject Lookin_firstFiltered (Func<NSObject, bool> block);

		// -(ValueType)lookin_lastFiltered:(BOOL (^)(ValueType))block;
		[Export ("lookin_lastFiltered:")]
		NSObject Lookin_lastFiltered (Func<NSObject, bool> block);

		// -(id)lookin_reduce:(id (^)(id, NSUInteger, ValueType))block;
		[Export ("lookin_reduce:")]
		NSObject Lookin_reduce (Func<NSObject, nuint, NSObject, NSObject> block);

		// -(CGFloat)lookin_reduceCGFloat:(CGFloat (^)(CGFloat, NSUInteger, ValueType))block initialAccumlator:(CGFloat)initialAccumlator;
		[Export ("lookin_reduceCGFloat:initialAccumlator:")]
		nfloat Lookin_reduceCGFloat (Func<nfloat, nuint, NSObject, nfloat> block, nfloat initialAccumlator);

		// -(NSInteger)lookin_reduceInteger:(NSInteger (^)(NSInteger, NSUInteger, ValueType))block initialAccumlator:(NSInteger)initialAccumlator;
		[Export ("lookin_reduceInteger:initialAccumlator:")]
		nint Lookin_reduceInteger (Func<nint, nuint, NSObject, nint> block, nint initialAccumlator);

		// -(BOOL)lookin_all:(BOOL (^)(ValueType))block;
		[Export ("lookin_all:")]
		bool Lookin_all (Func<NSObject, bool> block);

		// -(BOOL)lookin_any:(BOOL (^)(ValueType))block;
		[Export ("lookin_any:")]
		bool Lookin_any (Func<NSObject, bool> block);

		// -(NSArray<ValueType> *)lookin_arrayByRemovingObject:(ValueType)obj;
		[Export ("lookin_arrayByRemovingObject:")]
		NSObject[] Lookin_arrayByRemovingObject (NSObject obj);

		// -(NSArray<ValueType> *)lookin_nonredundantArray;
		[Export ("lookin_nonredundantArray")]
		[Verify (MethodToProperty)]
		NSObject[] Lookin_nonredundantArray { get; }

		// -(ValueType)lookin_safeObjectAtIndex:(NSInteger)idx;
		[Export ("lookin_safeObjectAtIndex:")]
		NSObject Lookin_safeObjectAtIndex (nint idx);

		// -(NSArray<ValueType> *)lookin_sortedArrayByStringLength;
		[Export ("lookin_sortedArrayByStringLength")]
		[Verify (MethodToProperty)]
		NSObject[] Lookin_sortedArrayByStringLength { get; }
	}

	// @interface Lookin (NSMutableArray)
	[Category]
	[BaseType (typeof(NSMutableArray))]
	interface NSMutableArray_Lookin
	{
		// -(void)lookin_dequeueWithCount:(NSUInteger)count add:(ValueType (^)(NSUInteger))addBlock notDequeued:(void (^)(NSUInteger, ValueType))notDequeuedBlock doNext:(void (^)(NSUInteger, ValueType))doBlock;
		[Export ("lookin_dequeueWithCount:add:notDequeued:doNext:")]
		void Lookin_dequeueWithCount (nuint count, Func<nuint, NSObject> addBlock, Action<nuint, NSObject> notDequeuedBlock, Action<nuint, NSObject> doBlock);

		// -(void)lookin_removeObjectsPassingTest:(BOOL (^)(NSUInteger, ValueType))block;
		[Export ("lookin_removeObjectsPassingTest:")]
		void Lookin_removeObjectsPassingTest (Func<nuint, NSObject, bool> block);
	}

	// @interface Lookin (NSSet)
	[Category]
	[BaseType (typeof(NSSet))]
	interface NSSet_Lookin
	{
		// -(NSSet *)lookin_map:(id (^)(ValueType))block;
		[Export ("lookin_map:")]
		NSSet Lookin_map (Func<NSObject, NSObject> block);

		// -(ValueType)lookin_firstFiltered:(BOOL (^)(ValueType))block;
		[Export ("lookin_firstFiltered:")]
		NSObject Lookin_firstFiltered (Func<NSObject, bool> block);

		// -(NSSet<ValueType> *)lookin_filter:(BOOL (^)(ValueType))block;
		[Export ("lookin_filter:")]
		NSSet<NSObject> Lookin_filter (Func<NSObject, bool> block);

		// -(BOOL)lookin_any:(BOOL (^)(ValueType))block;
		[Export ("lookin_any:")]
		bool Lookin_any (Func<NSObject, bool> block);
	}

	// @interface Lookin (NSObject)
	[Category]
	[BaseType (typeof(NSObject))]
	interface NSObject_Lookin
	{
		// -(void)lookin_bindObject:(id)object forKey:(NSString *)key;
		[Export ("lookin_bindObject:forKey:")]
		void Lookin_bindObject (NSObject @object, string key);

		// -(void)lookin_bindObjectWeakly:(id)object forKey:(NSString *)key;
		[Export ("lookin_bindObjectWeakly:forKey:")]
		void Lookin_bindObjectWeakly (NSObject @object, string key);

		// -(id)lookin_getBindObjectForKey:(NSString *)key;
		[Export ("lookin_getBindObjectForKey:")]
		NSObject Lookin_getBindObjectForKey (string key);

		// -(void)lookin_bindDouble:(double)doubleValue forKey:(NSString *)key;
		[Export ("lookin_bindDouble:forKey:")]
		void Lookin_bindDouble (double doubleValue, string key);

		// -(double)lookin_getBindDoubleForKey:(NSString *)key;
		[Export ("lookin_getBindDoubleForKey:")]
		double Lookin_getBindDoubleForKey (string key);

		// -(void)lookin_bindBOOL:(BOOL)boolValue forKey:(NSString *)key;
		[Export ("lookin_bindBOOL:forKey:")]
		void Lookin_bindBOOL (bool boolValue, string key);

		// -(BOOL)lookin_getBindBOOLForKey:(NSString *)key;
		[Export ("lookin_getBindBOOLForKey:")]
		bool Lookin_getBindBOOLForKey (string key);

		// -(void)lookin_bindLong:(long)longValue forKey:(NSString *)key;
		[Export ("lookin_bindLong:forKey:")]
		void Lookin_bindLong (nint longValue, string key);

		// -(long)lookin_getBindLongForKey:(NSString *)key;
		[Export ("lookin_getBindLongForKey:")]
		nint Lookin_getBindLongForKey (string key);

		// -(void)lookin_bindPoint:(CGPoint)pointValue forKey:(NSString *)key;
		[Export ("lookin_bindPoint:forKey:")]
		void Lookin_bindPoint (CGPoint pointValue, string key);

		// -(CGPoint)lookin_getBindPointForKey:(NSString *)key;
		[Export ("lookin_getBindPointForKey:")]
		CGPoint Lookin_getBindPointForKey (string key);

		// -(void)lookin_clearBindForKey:(NSString *)key;
		[Export ("lookin_clearBindForKey:")]
		void Lookin_clearBindForKey (string key);
	}

	// @interface Lookin_Coding (NSObject)
	[Category]
	[BaseType (typeof(NSObject))]
	interface NSObject_Lookin_Coding
	{
		// -(id)lookin_encodedObjectWithType:(LookinCodingValueType)type;
		[Export ("lookin_encodedObjectWithType:")]
		NSObject Lookin_encodedObjectWithType (LookinCodingValueType type);

		// -(id)lookin_decodedObjectWithType:(LookinCodingValueType)type;
		[Export ("lookin_decodedObjectWithType:")]
		NSObject Lookin_decodedObjectWithType (LookinCodingValueType type);
	}

	// @interface Lookin (NSString)
	[Category]
	[BaseType (typeof(NSString))]
	interface NSString_Lookin
	{
		// +(NSString *)lookin_stringFromDouble:(double)doubleValue decimal:(NSUInteger)decimal;
		[Static]
		[Export ("lookin_stringFromDouble:decimal:")]
		string Lookin_stringFromDouble (double doubleValue, nuint @decimal);

		// +(NSString *)lookin_stringFromRect:(CGRect)rect;
		[Static]
		[Export ("lookin_stringFromRect:")]
		string Lookin_stringFromRect (CGRect rect);

		// +(NSString *)lookin_stringFromInset:(UIEdgeInsets)insets;
		[Static]
		[Export ("lookin_stringFromInset:")]
		string Lookin_stringFromInset (UIEdgeInsets insets);

		// +(NSString *)lookin_stringFromSize:(CGSize)size;
		[Static]
		[Export ("lookin_stringFromSize:")]
		string Lookin_stringFromSize (CGSize size);

		// +(NSString *)lookin_stringFromPoint:(CGPoint)point;
		[Static]
		[Export ("lookin_stringFromPoint:")]
		string Lookin_stringFromPoint (CGPoint point);

		// +(NSString *)lookin_rgbaStringFromColor:(UIColor *)color;
		[Static]
		[Export ("lookin_rgbaStringFromColor:")]
		string Lookin_rgbaStringFromColor (UIColor color);

		// -(NSString *)lookin_safeInitWithUTF8String:(const char *)string;
		[Export ("lookin_safeInitWithUTF8String:")]
		unsafe string Lookin_safeInitWithUTF8String (sbyte* @string);

		// -(NSString *)lookin_shortClassNameString;
		[Export ("lookin_shortClassNameString")]
		[Verify (MethodToProperty)]
		string Lookin_shortClassNameString { get; }
	}

	// @interface LookinStaticAsyncUpdateTask : NSObject <NSSecureCoding>
	[BaseType (typeof(NSObject))]
	interface LookinStaticAsyncUpdateTask : INSSecureCoding
	{
		// @property (assign, nonatomic) unsigned long oid;
		[Export ("oid")]
		nuint Oid { get; set; }

		// @property (assign, nonatomic) LookinStaticAsyncUpdateTaskType taskType;
		[Export ("taskType", ArgumentSemantic.Assign)]
		LookinStaticAsyncUpdateTaskType TaskType { get; set; }

		// @property (assign, nonatomic) CGSize frameSize;
		[Export ("frameSize", ArgumentSemantic.Assign)]
		CGSize FrameSize { get; set; }
	}

	// @interface LookinStaticAsyncUpdateTasksPackage : NSObject <NSSecureCoding>
	[BaseType (typeof(NSObject))]
	interface LookinStaticAsyncUpdateTasksPackage : INSSecureCoding
	{
		// @property (copy, nonatomic) NSArray<LookinStaticAsyncUpdateTask *> * tasks;
		[Export ("tasks", ArgumentSemantic.Copy)]
		LookinStaticAsyncUpdateTask[] Tasks { get; set; }
	}

	// @interface LookinTwoTuple : NSObject <NSSecureCoding>
	[BaseType (typeof(NSObject))]
	interface LookinTwoTuple : INSSecureCoding
	{
		// @property (nonatomic, strong) NSObject * first;
		[Export ("first", ArgumentSemantic.Strong)]
		NSObject First { get; set; }

		// @property (nonatomic, strong) NSObject * second;
		[Export ("second", ArgumentSemantic.Strong)]
		NSObject Second { get; set; }
	}

	// @interface LookinStringTwoTuple : NSObject <NSSecureCoding, NSCopying>
	[BaseType (typeof(NSObject))]
	interface LookinStringTwoTuple : INSSecureCoding, INSCopying
	{
		// +(instancetype)tupleWithFirst:(NSString *)firstString second:(NSString *)secondString;
		[Static]
		[Export ("tupleWithFirst:second:")]
		LookinStringTwoTuple TupleWithFirst (string firstString, string secondString);

		// @property (copy, nonatomic) NSString * first;
		[Export ("first")]
		string First { get; set; }

		// @property (copy, nonatomic) NSString * second;
		[Export ("second")]
		string Second { get; set; }
	}

	// @interface LookinWeakContainer : NSObject
	[BaseType (typeof(NSObject))]
	interface LookinWeakContainer
	{
		// +(instancetype)containerWithObject:(id)object;
		[Static]
		[Export ("containerWithObject:")]
		LookinWeakContainer ContainerWithObject (NSObject @object);

		// @property (nonatomic, weak) id object;
		[Export ("object", ArgumentSemantic.Weak)]
		NSObject Object { get; set; }
	}

	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const Lookin_PTProtocolErrorDomain;
		[Field ("Lookin_PTProtocolErrorDomain", "__Internal")]
		NSString Lookin_PTProtocolErrorDomain { get; }
	}

	// @interface Lookin_PTProtocol : NSObject
	[BaseType (typeof(NSObject))]
	interface Lookin_PTProtocol
	{
		// @property dispatch_queue_t queue;
		[Export ("queue", ArgumentSemantic.Assign)]
		DispatchQueue Queue { get; set; }

		// +(Lookin_PTProtocol *)sharedProtocolForQueue:(dispatch_queue_t)queue;
		[Static]
		[Export ("sharedProtocolForQueue:")]
		Lookin_PTProtocol SharedProtocolForQueue (DispatchQueue queue);

		// -(id)initWithDispatchQueue:(dispatch_queue_t)queue;
		[Export ("initWithDispatchQueue:")]
		NativeHandle Constructor (DispatchQueue queue);

		// -(uint32_t)newTag;
		[Export ("newTag")]
		[Verify (MethodToProperty)]
		uint NewTag { get; }

		// -(void)sendFrameOfType:(uint32_t)frameType tag:(uint32_t)tag withPayload:(dispatch_data_t)payload overChannel:(dispatch_io_t)channel callback:(void (^)(NSError *))callback;
		[Export ("sendFrameOfType:tag:withPayload:overChannel:callback:")]
		void SendFrameOfType (uint frameType, uint tag, DispatchData payload, OS_dispatch_io channel, Action<NSError> callback);

		// -(void)readFramesOverChannel:(dispatch_io_t)channel onFrame:(void (^)(NSError *, uint32_t, uint32_t, uint32_t, dispatch_block_t))onFrame;
		[Export ("readFramesOverChannel:onFrame:")]
		void ReadFramesOverChannel (OS_dispatch_io channel, Action<NSError, uint, uint, uint, dispatch_block_t> onFrame);

		// -(void)readFrameOverChannel:(dispatch_io_t)channel callback:(void (^)(NSError *, uint32_t, uint32_t, uint32_t))callback;
		[Export ("readFrameOverChannel:callback:")]
		void ReadFrameOverChannel (OS_dispatch_io channel, Action<NSError, uint, uint, uint> callback);

		// -(void)readPayloadOfSize:(size_t)payloadSize overChannel:(dispatch_io_t)channel callback:(void (^)(NSError *, dispatch_data_t, const uint8_t *, size_t))callback;
		[Export ("readPayloadOfSize:overChannel:callback:")]
		unsafe void ReadPayloadOfSize (nuint payloadSize, OS_dispatch_io channel, Action<NSError, DispatchData, byte*, nuint> callback);

		// -(void)readAndDiscardDataOfSize:(size_t)size overChannel:(dispatch_io_t)channel callback:(void (^)(NSError *, BOOL))callback;
		[Export ("readAndDiscardDataOfSize:overChannel:callback:")]
		void ReadAndDiscardDataOfSize (nuint size, OS_dispatch_io channel, Action<NSError, bool> callback);
	}

	// @interface Lookin_PTProtocol (NSData)
	[Category]
	[BaseType (typeof(NSData))]
	interface NSData_Lookin_PTProtocol
	{
		// -(dispatch_data_t)createReferencingDispatchData;
		[Export ("createReferencingDispatchData")]
		[Verify (MethodToProperty)]
		DispatchData CreateReferencingDispatchData { get; }

		// +(NSData *)dataWithContentsOfDispatchData:(dispatch_data_t)data;
		[Static]
		[Export ("dataWithContentsOfDispatchData:")]
		NSData DataWithContentsOfDispatchData (DispatchData data);
	}

	// @interface Lookin_PTProtocol (NSDictionary)
	[Category]
	[BaseType (typeof(NSDictionary))]
	interface NSDictionary_Lookin_PTProtocol
	{
		// -(dispatch_data_t)createReferencingDispatchData;
		[Export ("createReferencingDispatchData")]
		[Verify (MethodToProperty)]
		DispatchData CreateReferencingDispatchData { get; }

		// +(NSDictionary *)dictionaryWithContentsOfDispatchData:(dispatch_data_t)data;
		[Static]
		[Export ("dictionaryWithContentsOfDispatchData:")]
		NSDictionary DictionaryWithContentsOfDispatchData (DispatchData data);
	}

	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const Lookin_PTUSBDeviceDidAttachNotification;
		[Field ("Lookin_PTUSBDeviceDidAttachNotification", "__Internal")]
		NSString Lookin_PTUSBDeviceDidAttachNotification { get; }

		// extern NSString *const Lookin_PTUSBDeviceDidDetachNotification;
		[Field ("Lookin_PTUSBDeviceDidDetachNotification", "__Internal")]
		NSString Lookin_PTUSBDeviceDidDetachNotification { get; }

		// extern NSString *const Lookin_PTUSBHubErrorDomain;
		[Field ("Lookin_PTUSBHubErrorDomain", "__Internal")]
		NSString Lookin_PTUSBHubErrorDomain { get; }
	}

	// @interface Lookin_PTUSBHub : NSObject
	[BaseType (typeof(NSObject))]
	interface Lookin_PTUSBHub
	{
		// +(Lookin_PTUSBHub *)sharedHub;
		[Static]
		[Export ("sharedHub")]
		[Verify (MethodToProperty)]
		Lookin_PTUSBHub SharedHub { get; }

		// -(void)connectToDevice:(NSNumber *)deviceID port:(int)port onStart:(void (^)(NSError *, dispatch_io_t))onStart onEnd:(void (^)(NSError *))onEnd;
		[Export ("connectToDevice:port:onStart:onEnd:")]
		void ConnectToDevice (NSNumber deviceID, int port, Action<NSError, OS_dispatch_io> onStart, Action<NSError> onEnd);

		// -(void)listenOnQueue:(dispatch_queue_t)queue onStart:(void (^)(NSError *))onStart onEnd:(void (^)(NSError *))onEnd;
		[Export ("listenOnQueue:onStart:onEnd:")]
		void ListenOnQueue (DispatchQueue queue, Action<NSError> onStart, Action<NSError> onEnd);
	}

	// @interface Lookin_PTChannel : NSObject
	[BaseType (typeof(NSObject))]
	interface Lookin_PTChannel
	{
		[Wrap ("WeakDelegate")]
		Lookin_PTChannelDelegate Delegate { get; set; }

		// @property (strong) id<Lookin_PTChannelDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Strong)]
		NSObject WeakDelegate { get; set; }

		// @property Lookin_PTProtocol * protocol;
		[Export ("protocol", ArgumentSemantic.Assign)]
		Lookin_PTProtocol Protocol { get; set; }

		// @property (readonly) BOOL isListening;
		[Export ("isListening")]
		bool IsListening { get; }

		// @property (readonly) BOOL isConnected;
		[Export ("isConnected")]
		bool IsConnected { get; }

		// @property (strong) id userInfo;
		[Export ("userInfo", ArgumentSemantic.Strong)]
		NSObject UserInfo { get; set; }

		// +(Lookin_PTChannel *)channelWithDelegate:(id<Lookin_PTChannelDelegate>)delegate;
		[Static]
		[Export ("channelWithDelegate:")]
		Lookin_PTChannel ChannelWithDelegate (Lookin_PTChannelDelegate @delegate);

		// -(id)initWithProtocol:(Lookin_PTProtocol *)protocol;
		[Export ("initWithProtocol:")]
		NativeHandle Constructor (Lookin_PTProtocol protocol);

		// -(id)initWithProtocol:(Lookin_PTProtocol *)protocol delegate:(id<Lookin_PTChannelDelegate>)delegate;
		[Export ("initWithProtocol:delegate:")]
		NativeHandle Constructor (Lookin_PTProtocol protocol, Lookin_PTChannelDelegate @delegate);

		// -(void)connectToPort:(int)port overUSBHub:(Lookin_PTUSBHub *)usbHub deviceID:(NSNumber *)deviceID callback:(void (^)(NSError *))callback;
		[Export ("connectToPort:overUSBHub:deviceID:callback:")]
		void ConnectToPort (int port, Lookin_PTUSBHub usbHub, NSNumber deviceID, Action<NSError> callback);

		// -(void)connectToPort:(in_port_t)port IPv4Address:(in_addr_t)address callback:(void (^)(NSError *, Lookin_PTAddress *))callback;
		[Export ("connectToPort:IPv4Address:callback:")]
		void ConnectToPort (ushort port, uint address, Action<NSError, Lookin_PTAddress> callback);

		// -(void)listenOnPort:(in_port_t)port IPv4Address:(in_addr_t)address callback:(void (^)(NSError *))callback;
		[Export ("listenOnPort:IPv4Address:callback:")]
		void ListenOnPort (ushort port, uint address, Action<NSError> callback);

		// -(void)sendFrameOfType:(uint32_t)frameType tag:(uint32_t)tag withPayload:(dispatch_data_t)payload callback:(void (^)(NSError *))callback;
		[Export ("sendFrameOfType:tag:withPayload:callback:")]
		void SendFrameOfType (uint frameType, uint tag, DispatchData payload, Action<NSError> callback);

		// -(BOOL)startReadingFromConnectedChannel:(dispatch_io_t)channel error:(NSError **)error;
		[Export ("startReadingFromConnectedChannel:error:")]
		bool StartReadingFromConnectedChannel (OS_dispatch_io channel, out NSError error);

		// -(void)close;
		[Export ("close")]
		void Close ();

		// -(void)cancel;
		[Export ("cancel")]
		void Cancel ();
	}

	// @interface Lookin_PTData : NSObject
	[BaseType (typeof(NSObject))]
	interface Lookin_PTData
	{
		// @property (readonly) dispatch_data_t dispatchData;
		[Export ("dispatchData")]
		DispatchData DispatchData { get; }

		// @property (readonly) void * data;
		[Export ("data")]
		unsafe void* Data { get; }

		// @property (readonly) size_t length;
		[Export ("length")]
		nuint Length { get; }
	}

	// @interface Lookin_PTAddress : NSObject
	[BaseType (typeof(NSObject))]
	interface Lookin_PTAddress
	{
		// @property (readonly) NSString * name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly) NSInteger port;
		[Export ("port")]
		nint Port { get; }
	}

	// @protocol Lookin_PTChannelDelegate <NSObject>
	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof(NSObject))]
	interface Lookin_PTChannelDelegate
	{
		// @required -(void)ioFrameChannel:(Lookin_PTChannel *)channel didReceiveFrameOfType:(uint32_t)type tag:(uint32_t)tag payload:(Lookin_PTData *)payload;
		[Abstract]
		[Export ("ioFrameChannel:didReceiveFrameOfType:tag:payload:")]
		void IoFrameChannel (Lookin_PTChannel channel, uint type, uint tag, Lookin_PTData payload);

		// @optional -(BOOL)ioFrameChannel:(Lookin_PTChannel *)channel shouldAcceptFrameOfType:(uint32_t)type tag:(uint32_t)tag payloadSize:(uint32_t)payloadSize;
		[Export ("ioFrameChannel:shouldAcceptFrameOfType:tag:payloadSize:")]
		bool IoFrameChannel (Lookin_PTChannel channel, uint type, uint tag, uint payloadSize);

		// @optional -(void)ioFrameChannel:(Lookin_PTChannel *)channel didEndWithError:(NSError *)error;
		[Export ("ioFrameChannel:didEndWithError:")]
		void IoFrameChannel (Lookin_PTChannel channel, NSError error);

		// @optional -(void)ioFrameChannel:(Lookin_PTChannel *)channel didAcceptConnection:(Lookin_PTChannel *)otherChannel fromAddress:(Lookin_PTAddress *)address;
		[Export ("ioFrameChannel:didAcceptConnection:fromAddress:")]
		void IoFrameChannel (Lookin_PTChannel channel, Lookin_PTChannel otherChannel, Lookin_PTAddress address);
	}

	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern double PeertalkVersionNumber;
		[Field ("PeertalkVersionNumber", "__Internal")]
		double PeertalkVersionNumber { get; }

		// extern const unsigned char[] PeertalkVersionString;
		[Field ("PeertalkVersionString", "__Internal")]
		byte[] PeertalkVersionString { get; }

		// extern double LookinServerVersionNumber;
		[Field ("LookinServerVersionNumber", "__Internal")]
		double LookinServerVersionNumber { get; }

		// extern const unsigned char[] LookinServerVersionString;
		[Field ("LookinServerVersionString", "__Internal")]
		byte[] LookinServerVersionString { get; }
	}
}
