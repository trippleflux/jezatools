#region

using System;
using System.Data;
using System.Data.SqlClient;
using log4net;

#endregion

namespace Library
{
	public class SQL
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof (SQL));



		public static bool InsertPlayer(ServerData sd)
		{
			SqlCommand command = new SqlCommand("InsertPlayer", sd.Connection);
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Clear();
			command.Parameters.Add("@PlayerId", SqlDbType.Int).Value = sd.PlayerUID;
			command.Parameters.Add("@PlayerName", SqlDbType.VarChar).Value = "jezonsky";
			sd.Connection.Open();
			command.ExecuteNonQuery();
			sd.Connection.Close();
			return true;
		}



		/// <summary>
		/// Insert villages to DB
		/// </summary>
		/// <param name="sd"></param>
		/// <param name="v"></param>
		/// <returns></returns>
		/// 
		public static bool InsertVillages
			(ServerData sd,
			 Village v)
		{
			SqlCommand command = new SqlCommand("InsertVillage", sd.Connection);
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Clear();
			command.Parameters.Add("@VillageId", SqlDbType.Int).Value = v.VillageId;
			command.Parameters.Add("@VillageName", SqlDbType.VarChar).Value = v.VillageName;
			command.Parameters.Add("@PlayerId", SqlDbType.Int).Value = sd.PlayerUID;
			sd.Connection.Open();
			command.ExecuteNonQuery();
			sd.Connection.Close();
			return true;
		}



		public static bool InsertProduction
			(ServerData sd,
			 Village v,
			 int village)
		{
			Production p = sd.ProductionList[village] as Production;
			if (p != null)
			{
				//System.Console.WriteLine(v.ToString());
				//System.Console.WriteLine(p.ToString());
				SqlCommand command = new SqlCommand("InsertProduction", sd.Connection);
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Clear();
				command.Parameters.Add("@VillageId", SqlDbType.Int).Value = v.VillageId;
				command.Parameters.Add("@Warehouse", SqlDbType.Int).Value = p.WarehouseKapacity;
				command.Parameters.Add("@Granary", SqlDbType.Int).Value = p.GranaryKapacity;
				command.Parameters.Add("@Wood", SqlDbType.Int).Value = p.Wood;
				command.Parameters.Add("@Clay", SqlDbType.Int).Value = p.Clay;
				command.Parameters.Add("@Iron", SqlDbType.Int).Value = p.Iron;
				command.Parameters.Add("@Crop", SqlDbType.Int).Value = p.Crop;
				command.Parameters.Add("@WoodPerHour", SqlDbType.Int).Value = p.WoodPerHour;
				command.Parameters.Add("@ClayPerHour", SqlDbType.Int).Value = p.ClayPerHour;
				command.Parameters.Add("@IronPerHour", SqlDbType.Int).Value = p.IronPerHour;
				command.Parameters.Add("@CropPerHour", SqlDbType.Int).Value = p.CropPerHour;
				command.Parameters.Add("@PlayerId", SqlDbType.Int).Value = sd.PlayerUID;
				sd.Connection.Open();
				command.ExecuteNonQuery();
				sd.Connection.Close();
			}
			return true;
		}



// ReSharper disable UnusedMethodReturnValue
		private static bool InsertResourceForVillage
			(ServerData sd,
			 Resource resource)
// ReSharper restore UnusedMethodReturnValue
		{
			SqlCommand command = new SqlCommand("InsertResources", sd.Connection);
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Clear();
			command.Parameters.Add("@VillageId", SqlDbType.Int).Value = resource.VillageId;
			command.Parameters.Add("@ResourcesFullName", SqlDbType.VarChar).Value = resource.ResourceFullName;
			command.Parameters.Add("@ResourcesId", SqlDbType.Int).Value = resource.ResourceId;
			command.Parameters.Add("@ResourcesName", SqlDbType.VarChar).Value = resource.ResourceName;
			command.Parameters.Add("@ResourcesLevel", SqlDbType.Int).Value = resource.ResourceLevel;
			command.Parameters.Add("@PlayerId", SqlDbType.Int).Value = sd.PlayerUID;
			sd.Connection.Open();
			command.ExecuteNonQuery();
			sd.Connection.Close();
			//System.Console.WriteLine(command.Parameters.);
			return true;
		}



		/// <summary>
		/// Get enabled task list.
		/// </summary>
		/// <param name="sd"><see cref="ServerData"/></param>
		/// <list type="table">
		/// <item><term>Item</term><description>Description</description></item>
		/// <item><term>column[0] (int)</term><description>ID in table TaskList</description></item>
		/// <item><term>column[1] (int)</term><description>ID in table Tasks</description></item>
		/// <item><term>column[2] (int)</term><description>ID in table Villages</description></item>
		/// <item><term>column[3] (string)</term><description>BuildIdName in table BuildIds</description></item>
		/// <item><term>column[4] (int)</term><description>Priority</description></item>
		/// <item><term>column[5] (int)</term><description>Build level</description></item>
		/// <item><term>column[6] (datetime)</term><description>DateTime of next check</description></item>
		/// <item><term>column[7] (int)</term><description><c>1</c> if task is enabled</description></item>
		/// <item><term>column[8] (string)</term><description>VillageName in table Villages</description></item>
		/// <item><term>column[9] (int)</term><description>BuildId in table BuildIds</description></item>
		/// </list>
		/// <returns>Data Table with tasks <see cref="DataTable"/></returns>
		/// 
		public static DataTable GetTaskList(ServerData sd)
		{
			SqlCommand command = new SqlCommand("GetTaskList", sd.Connection);
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Clear();
			command.Parameters.Add("@PlayerId", SqlDbType.Int).Value = sd.PlayerUID;
			command.Parameters.Add("@NextCheck", SqlDbType.DateTime).Value = DateTime.Now;
			SqlDataAdapter da = new SqlDataAdapter(command);
			DataTable dt = new DataTable();
			da.Fill(dt);
			return dt;
		}



		/// <summary>
		/// Get farm list.
		/// </summary>
		/// <param name="sd"><see cref="ServerData"/></param>
		/// <list type="table">
		/// <item><term>Item</term><description>Description</description></item>
		/// <item><term>column[0] (int)</term><description>ID in table FarmList</description></item>
		/// <item><term>column[1] (int)</term><description>VillageId in table Villages</description></item>
		/// <item><term>column[2] (int)</term><description>Coordinates of attack X</description></item>
		/// <item><term>column[3] (int)</term><description>Coordinates of attack Y</description></item>
		/// <item><term>column[4] (int)</term><description>AttackId in table AttackTypes</description></item>
		/// <item><term>column[5] (string)</term><description>trooplist</description></item>
		/// <item><term>column[6] (string)</term><description>TroopName in table TroopTypes</description></item>
		/// <item><term>column[7] (int)</term><description>How many units to check for</description></item>
		/// <item><term>column[8] (string)</term><description>Description</description></item>
		/// </list>
		/// <returns>Data Table with FarmList <see cref="DataTable"/></returns>
		/// 
		public static DataTable GetFarmList(ServerData sd)
		{
			SqlCommand command = new SqlCommand("GetFarmList", sd.Connection);
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Clear();
			command.Parameters.Add("@PlayerId", SqlDbType.Int).Value = sd.PlayerUID;
			SqlDataAdapter da = new SqlDataAdapter(command);
			DataTable dt = new DataTable();
			da.Fill(dt);
			return dt;
		}



		public static bool UpdateNextCheckForTask(ServerData sd, int taskId, DateTime dt)
		{
			SqlCommand command = new SqlCommand("UpdateNextCheckForTask", sd.Connection);
			command.CommandType = CommandType.StoredProcedure;
			command.Parameters.Clear();
			command.Parameters.Add("@TaskId", SqlDbType.Int).Value = taskId;
			command.Parameters.Add("@NextCheck", SqlDbType.DateTime).Value = dt;
			sd.Connection.Open();
			command.ExecuteNonQuery();
			sd.Connection.Close();
			return true;
		}



		public static void InsertResources(ServerData sd)
		{
			for (int i = 0; i < sd.ResourcesList.Count; i++)
			{
				VillageData villageResource = sd.ResourcesList[i] as VillageData;
				if (villageResource != null)
				{
					Resource villResource = villageResource.ResourcesForVillage[0] as Resource;
					if (villResource != null)
					{
						InsertResourceForVillage(sd, villResource);
						Log.DebugFormat("Resources: {0}", villResource.ToString());
					}
				}
			}
		}
	}
}