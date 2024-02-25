namespace HelloMsa_1
{
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using Skyline.DataMiner.Automation;
	using Skyline.DataMiner.Core.DataMinerSystem.Automation;

	/// <summary>
	/// Represents a DataMiner Automation script.
	/// </summary>
	public class Script
	{
		/// <summary>
		/// The script entry point.
		/// </summary>
		/// <param name="engine">Link with SLAutomation process.</param>
		public void Run(IEngine engine)
		{
			// Get DataMiner System
			var thisDms = engine.GetDms();

			// Get number of interfaces for every switch
			var switches = thisDms.GetElements().Where(e => e.Protocol.Name == "Mellanox Technologies MLNX-OS Manager");
			foreach ( var mellanox in switches)
			{
				var interfaceTable = mellanox.GetTable(1100);
				var keys = interfaceTable.GetPrimaryKeys();
				engine.GenerateInformation($"Switch {mellanox.Name} found with {keys.Count()} interfaces");
			}
		}
	}
}