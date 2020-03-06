using System;
using System.Reflection;

#if GORILLA
namespace RoboScout
{
	public static class GorillaSdkHelper
	{
		public static readonly Type TabControlType = typeof(UXDivers.Artina.Shared.TabControl);
		public static readonly Type RepeaterControlType = typeof(UXDivers.Artina.Shared.Repeater);
	}
}
#endif