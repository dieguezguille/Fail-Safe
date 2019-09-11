using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace FailSafe
{
	public class TaskRunner
	{
		public static void CloseVsStudio()
		{
			var processes = System.Diagnostics.Process.GetProcesses().Where(p => p.ProcessName.Contains("devenv"));

			foreach (System.Diagnostics.Process process in processes)
			{
				process.Kill();
			}
		}

		public static void DeleteBinAndObj(string path)
		{
			try
			{
				// directories to search
				var bin = Directory.EnumerateFileSystemEntries(path, "bin", SearchOption.AllDirectories);
				var obj = Directory.EnumerateFileSystemEntries(path, "obj", SearchOption.AllDirectories);

				var dirs = bin.Concat(obj);

				if (dirs != null && dirs.Count() > 0)
				{
					Console.WriteLine("Se encontraron los siguientes directorios:");
					Console.WriteLine("");

					foreach (var dir in dirs)
					{
						Console.WriteLine(dir);
					}
				}
				else
				{
					Console.WriteLine("No se encontraron directorios para eliminar. Cierre Visual Studio e intente nuevamente.");
					Console.ReadLine();
					return;
				}

				// delete directories
				Console.WriteLine("");
				Console.WriteLine("Presione ENTER para eliminar o CTRL + C para cancelar.");
				Console.WriteLine("");
				Console.ReadLine();

				Console.WriteLine("Borrando directorios...");
				Console.WriteLine("");

				foreach (var dir in dirs)
				{
					// delete all
					Directory.Delete(dir, true);
				}

				Console.WriteLine("Los directorios se eliminaron exitosamente. Presione ENTER para continuar.");
				Console.ReadLine();
			}
			catch (Exception ex)
			{
				// handle exception
				Console.WriteLine("La operación falló con el siguiente error:");
				Console.WriteLine("");
				Console.WriteLine(ex.Message);
				Console.WriteLine("");
			}
		}

		public static void ReopenVsStudio(int times)
		{
			for (int i = 0; i < times; i++)
			{
				RunVsAsAdmin();
			}
		}

		private static void RunVsAsAdmin()
		{
			Process proc = new Process();
			proc.StartInfo.FileName = "devenv.exe";
			proc.StartInfo.UseShellExecute = true;
			proc.StartInfo.Verb = "runas";
			proc.Start();
		}

		public static void DeleteVsFolder(string path)
		{
			try
			{
				// get .vs folder
				string[] dirs = Directory.GetDirectories(path);
				var vsFolder = dirs
					.Where(dir => dir.Contains("vs"))
					.FirstOrDefault();

				if (vsFolder != null)
				{
					Console.WriteLine("Se encontró la varpeta '.vs' en la siguiente ubicación:");
					Console.WriteLine("");
					Console.WriteLine(vsFolder);
					Console.WriteLine("");
					Console.WriteLine("Presione ENTER para eliminar o CTRL + C para cancelar.");
					Console.ReadLine();

					// delete all
					Directory.Delete(vsFolder, true);

					Console.WriteLine("El directorio se eliminó exitosamente. Presione ENTER para SALIR.");
					Console.ReadLine();

				}
				else
				{
					Console.WriteLine("No se encontró la carpeta '.vs'. Asegúrese de que existe e intente nuevamente.");
					Console.ReadLine();
					return;
				}
			}
			catch (Exception ex)
			{
				// handle exception
				Console.WriteLine("La operación falló con el siguiente error:");
				Console.WriteLine("");
				Console.WriteLine(ex.Message);
				Console.WriteLine("Presione ENTER para SALIR.");
				Console.WriteLine("");
				Console.ReadLine();
			}
		}
		//private static void GetConfigFile(string path)
		//{
		//    // get applicationhost.config file
		//    var file = Directory
		//        .GetFiles(path, "applicationhost.config", SearchOption.AllDirectories)
		//        .FirstOrDefault();

		//    if (file != null && file.Count() > 0)
		//    {
		//        Console.WriteLine("Se encontró el archivo .config en la siguiente ubicación:");
		//        Console.WriteLine("");
		//        Console.WriteLine(file);
		//        Console.WriteLine("");
		//        Console.WriteLine("Presione ENTER para modificar o CTRL + C para cancelar");
		//        Console.ReadLine();
		//        EditConfigFile(file);
		//    }
		//    else
		//    {
		//        Console.WriteLine("No se encontraron archivos para editar. Cierre Visual Studio e intente nuevamente.");
		//        Console.ReadLine();
		//        return;
		//    }
		//}

		//private static void EditConfigFile(string file)
		//{
		//    // get local ip address
		//    var ip = GetLocalIp();

		//    if (ip.Length < 16) //IPv4 received
		//    {
		//        Console.WriteLine("La dirección IP local es:");
		//        Console.WriteLine("");
		//        Console.WriteLine(ip);
		//        Console.WriteLine("");
		//        Console.WriteLine("Presione ENTER para actualizar el archivo .config o CTRL + C para cancelar");
		//        Console.ReadLine();


		//    }
		//    else
		//    {
		//        //handle error
		//        Console.WriteLine("");
		//    }

		//    // edit .config file
		//}

		//private static string GetLocalIp()
		//{
		//    var host = Dns.GetHostEntry(Dns.GetHostName());

		//    foreach (var ip in host.AddressList)
		//    {
		//        if (ip.AddressFamily == AddressFamily.InterNetwork)
		//        {
		//            return ip.ToString();
		//        }
		//    }

		//    return("No se encontró una dirección IPv4. Asegúrese de estar conectado a una red.");
		//}
	}
}
