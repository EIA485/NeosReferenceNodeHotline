using HarmonyLib;
using NeosModLoader;
using FrooxEngine;
using FrooxEngine.LogiX;

namespace ReferenceNodeHotline
{
	public class ReferenceNodeHotline : NeosMod
	{
		public override string Name => "ReferenceNodeHotline";
		public override string Author => "eia485";
		public override string Version => "1.0.0";
		public override string Link => "https://github.com/EIA485/NeosReferenceNodeHotline/";
		public override void OnEngineInit()
		{
			Harmony harmony = new Harmony("net.eia485.ReferenceNodeHotline");
			harmony.PatchAll();
		}
		[HarmonyPatch(typeof(ReferenceNode<IChangeable>), "Cleanup")]
		class ReferenceNodeHotlinePatch
		{
			static bool Prefix(ReferenceNode<IChangeable> __instance)
			{
				if (__instance.RefTarget.State == ReferenceState.Invalid)
					__instance.Slot.Destroy();
				return false;
			}
		}
	}
}