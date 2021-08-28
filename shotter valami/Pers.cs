using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shotter_valami
{
    class Pers
    {
    public void Export(int szam)
        {
            StreamWriter file = new StreamWriter("data.txt");
            file.Write(szam);
            file.Close();
        }
    public int Import()
        {
            if (File.Exists("data.txt") == true)
            {
                StreamReader file = new StreamReader("data.txt");
                int szam = Convert.ToInt32(file.ReadLine());
                file.Close();
                return szam;
            }
            else
            {
                File.Create("data.txt");
                return 0;
            }
        }
    }
}
