﻿using System.IO;

namespace FailSafe
{
	public class Program
	{
		public static void Main(string[] args)
		{
			// make sure to locate program in the solution folder
			var path = Directory.GetCurrentDirectory();

			RunTasks(path);
		}

		public static void RunTasks(string path)
		{
			TaskRunner.CloseVsStudio();
			TaskRunner.DeleteBinAndObj(path);
			TaskRunner.DeleteVsFolder(path);
			TaskRunner.ReopenVsStudio(2);
		}
	}
}
