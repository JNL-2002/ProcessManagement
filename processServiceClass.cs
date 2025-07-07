using System;
using System.Diagnostics;

namespace processService
{
	public class processServiceClass
	{
		public string PathValue;
        public processServiceClass(string pathValue)
		{
			this.PathValue = pathValue;
        }

		public void Restart(bool Button)
		{ 
			while (Button)
			{
				Process p = Process.Start(PathValue);
				p.WaitForExit();
				if(p.HasExited)
				{
					continue;
                }
            }
		}

    }
}
