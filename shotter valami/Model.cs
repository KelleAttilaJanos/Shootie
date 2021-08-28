using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shotter_valami
{
    public class Model
    {
        public List<double[]> mapp = new List<double[]>();
        public List<double[]> maps = new List<double[]>();
        public List<double[]> myballs = new List<double[]>();
        public List<double[]> myballv = new List<double[]>();
        public List<int> lifetime = new List<int>();
        public List<int> lifeh = new List<int> {0,1,2,3,10,11,12,13,20,21,22,23,30,31,32,33};
        public List<double[]> enemiesp = new List<double[]>();
        public List<double[]> enemiesi = new List<double[]>();
        public double[] pp = new double[2] { 0, 0.2 };
        public double[] ip = new double[2] { 0, 0 };
        public double[,] hp = new double[4,4];
        public double wsl = 0;
        public void Generate()
        {
            double[] floorp = new double[] {-1,0.9};
            mapp.Add(floorp);
            double[] wallleftp = new double[] {-1, -1};
            mapp.Add(wallleftp);
            double[] wallreigthp = new double[] { 0.7, -1 };
            mapp.Add(wallreigthp);
            double[] cliffp = new double[] {0.3,0.6 };
            mapp.Add(cliffp);
            double[] floors = new double[] { 3, 1 };
            maps.Add(floors);
            double[] walllefts = new double[] { 1.3, 3 };
            maps.Add(walllefts);
            double[] wallreigths = new double[] { 1.3, 3 };
            maps.Add(wallreigths);
            double[] cliffs = new double[] { 0.4, 0.4 };
            maps.Add(cliffs);
        }
        public Random s = new Random();
        public void GenEnemies()
        {
            double szam1 = s.Next(Convert.ToInt32((mapp[1][0] + maps[1][0] + 0.7)*100), Convert.ToInt32(maps[0][0])*100)/100;
            double szam2 = s.Next(1,90)/100;
            double[] poz = new double[2] {szam1,szam2};
            enemiesp.Add(poz);
            double[] vect = new double[2] { 0, 0 };
            enemiesi.Add(vect);
        }
    }
}
