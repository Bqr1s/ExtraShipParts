using System.Collections.Generic;
using System.Reflection;
using Verse;
using RimWorld;
using RimWorld.Planet;
using HarmonyLib;
using UnityEngine;

namespace ExtraShipParts
{
	[StaticConstructorOnStartup]
	public class Main
	{
		static Main()
		{
			Harmony pat = new Harmony("ExtraShipParts");
			pat.PatchAll();
		}
	}

	// Electric engine (in Tiny submod) has 2 power comps, so need to disable post spawn setup for one of those
	[HarmonyPatch(typeof(CompPowerBattery), "PostExposeData")]
	public static class DoublePowerCompOnElectricEngineFix
	{
		public static bool Prefix(CompPower __instance)
		{
			if (__instance.parent.def.defName == "Ship_Engine_Electric_Tiny")
			{
				return false;
			}
			return true;
		}
	}


}

