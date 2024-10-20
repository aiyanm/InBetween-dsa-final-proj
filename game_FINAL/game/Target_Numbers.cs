using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    internal class Target_Numbers
    {

        private List<List<int>> listofTargetNums = new List<List<int>>();

        private List<int> listofEasy = new List<int>();
        private List<int> listofMedium = new List<int>();
        private List<int> listofHard = new List<int>();

        public List<List<int>> ListofTargetNums
        {
            get { return listofTargetNums; }
        }

        public Target_Numbers() 
        {
            initializeTargetNums();
        }

        public void initializeTargetNums ()
        {
            initializeEasyShit();
            initializeMediumShit();
            initializeHardShit();

            listofTargetNums.Add(listofEasy);
            listofTargetNums.Add(listofMedium);
            listofTargetNums.Add (listofHard);
        }

        public void initializeEasyShit()
        {
            for(int i = 1; i <= 20; i++)
            {
                listofEasy.Add(i);
            }
        }

        public void initializeMediumShit()
        {
            for (int i = 1; i <= 50; i++)
            {
                listofMedium.Add(i);
            }
        }
        public void initializeHardShit()
        {
            for (int i = 1; i <= 100; i++)
            {
                listofHard.Add(i);
            }
        }



    }
}
