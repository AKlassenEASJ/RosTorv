using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments.AppointmentsProvider;
using Windows.UI.Xaml.Controls;

namespace RosTorv.Thomas.Model
{
    public class AI
    {
        public int _case;
        private int FindSmallestNumber(List<int> numbers)
        {
            {
                int smallest = numbers[0];
                for (int index = 1; index < numbers.Count; index++)
                {
                    if (numbers[index] < smallest)
                    {
                        smallest = numbers[index];
                    }
                }
                return smallest;
            }
        }
        public int Case
        { get {return _case; }
            set { _case = value; }
        }

        public int DecideWhatToRoll(int Die1Value, int Die2Value, int Die3Value, int Die4Value, int Die5Value)
        {
            int D1 = Die1Value;
            int D2 = Die2Value;
            int D3 = Die3Value;
            int D4 = Die4Value;
            int D5 = Die5Value;
            Case = 0;
            CheckForPairs(D1,D2,D3,D4,D5);
            CheckForThreeLike(D1, D2, D3, D4, D5);
            CheckForFourLike(D1, D2, D3, D4, D5);
            CheckForYatziOrStraights(D1, D2, D3, D4, D5);
            return Case;
        }

        public void CheckForYatziOrStraights(int Die1Value, int Die2Value, int Die3Value, int Die4Value, int Die5Value)
        {
            int D1 = Die1Value;
            int D2 = Die2Value;
            int D3 = Die3Value;
            int D4 = Die4Value;
            int D5 = Die5Value;

            List<int>OrderNumbers=new List<int>();
            OrderNumbers.Add(D1);
            OrderNumbers.Add(D2);
            OrderNumbers.Add(D3);
            OrderNumbers.Add(D4);
            OrderNumbers.Add(D5);

            int OrderD1 = FindSmallestNumber(OrderNumbers);
            OrderNumbers.Remove(FindSmallestNumber(OrderNumbers));
            int OrderD2 = FindSmallestNumber(OrderNumbers);
            OrderNumbers.Remove(FindSmallestNumber(OrderNumbers));
            int OrderD3 = FindSmallestNumber(OrderNumbers);
            OrderNumbers.Remove(FindSmallestNumber(OrderNumbers));
            int OrderD4 = FindSmallestNumber(OrderNumbers);
            OrderNumbers.Remove(FindSmallestNumber(OrderNumbers));
            int OrderD5 = OrderNumbers[0];

            if (D1 == D2 && D2 == D3 && D3 == D4 && D4 == D5
                || OrderD1 == 1 && OrderD2 == 2 && OrderD3 == 3 && OrderD4 == 4 && OrderD5 == 5
                || OrderD1 == 2 && OrderD2 == 3 && OrderD3 == 4 && OrderD4 == 5 && OrderD5 == 6)
            {
                Case = 26;
            }
        }
        public void CheckForFourLike(int Die1Value, int Die2Value, int Die3Value, int Die4Value, int Die5Value)
        {
            int D1 = Die1Value;
            int D2 = Die2Value;
            int D3 = Die3Value;
            int D4 = Die4Value;
            int D5 = Die5Value;

            if (D1 == D2 && D2 == D3 && D3 == D4)
            {
                Case = 21;
            }
            if (D1 == D3 && D3 == D4 && D4 == D5)
            {
                Case = 22;
            }
            if (D1 == D2 && D2 == D4 && D4 == D5)
            {
                Case = 23;
            }
            if (D1 == D2 && D2 == D3 && D3 == D5)
            {
                Case = 24;
            }
            if (D2 == D3 && D3 == D4 && D4 == D5)
            {
                Case = 25;
            }
        }
        public void CheckForThreeLike(int Die1Value, int Die2Value, int Die3Value, int Die4Value, int Die5Value)
        {
            int D1 = Die1Value;
            int D2 = Die2Value;
            int D3 = Die3Value;
            int D4 = Die4Value;
            int D5 = Die5Value;

            if (D1 == D2 && D2 == D3)
            {
                Case = 11;
            }
            if (D1 == D2 && D2 == D4)
            {
                Case = 12;
            }
            if (D1 == D2 && D2 == D5)
            {
                Case = 13;
            }
            if (D1 == D3 && D3 == D4)
            {
                Case = 14;
            }
            if (D2 == D3 && D3 == D4)
            {
                Case = 15;
            }
            if (D2 == D3 && D3 == D5)
            {
                Case = 16;
            }
            if (D1 == D4 && D4 == D5)
            {
                Case = 17;
            }
            if (D2 == D4 && D4 == D5)
            {
                Case = 18;
            }
            if (D3 == D4 && D4 == D5)
            {
                Case = 19;
            }
            if (D1 == D3 && D3 == D5)
            {
                Case = 20;
            }
        }

       
        public void CheckForPairs(int Die1Value, int Die2Value, int Die3Value, int Die4Value, int Die5Value)
        {
            int D1 = Die1Value;
            int D2 = Die2Value;
            int D3 = Die3Value;
            int D4 = Die4Value;
            int D5 = Die5Value;

            if (D1 == D2)
            {
                Case = 4;
            }
            if (D1 == D3)
            {
                Case = 3;
            }
            if (D1 == D4)
            {
                Case = 2;
            }
            if (D1 == D5)
            {
                Case = 1;
            }
            if (D2 == D3)
            {
                Case = 5;
            }
            if (D2 == D4)
            {
                Case = 6;
            }
            if (D2 == D5)
            {
                Case = 7;
            }
            if (D3 == D4)
            {
                Case = 8;
            }
            if (D3 == D5)
            {
                Case = 9;
            }
            if (D4 == D5)
            {
                Case = 10;
            }
        }
        
    }
}
