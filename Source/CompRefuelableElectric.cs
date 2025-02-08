using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using UnityEngine;
using Verse;
using RimWorld;

namespace ExtraShipParts
{
	class CompRefuelableElectric : CompRefuelable
	{
		public CompPowerBattery battery;
		public override void PostSpawnSetup(bool respawningAfterLoad)
		{
			battery = parent.GetComp<CompPowerBattery>();
		}
		public override void CompTick()
		{
			base.CompTick();
			if (battery == null)
			{
				return;
			}
			if (Find.TickManager.TicksGame % 30 == 0)
			{
				this.GetType().GetField("fuel", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(this, battery.StoredEnergy);
			}
		}
	}
}