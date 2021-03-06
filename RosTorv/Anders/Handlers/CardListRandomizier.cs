﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using RosTorv.Anders.Model;
using RosTorv.Anders.ViewModel;

namespace RosTorv.Anders.Handlers
{
    class CardListRandomizier
    {
        //public static void Shuffle<T>(IList<T> list)
        //{
        //    RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
        //    int n = list.Count;
        //    while (n > 1)
        //    {
        //        byte[] box = new byte[1];
        //        do provider.GetBytes(box);
        //        while (!(box[0] < n * (Byte.MaxValue / n)));
        //        int k = (box[0] % n);
        //        n--;
        //        T value = list[k];
        //        list[k] = list[n];
        //        list[n] = value;
        //    }
        //}

        //TODO: Lav din egen randomizer

        


        public static ObservableCollection<Card> Shuffle (ObservableCollection<Card> collectionOfCard)
        {
            ObservableCollection<Card> ShuffledCollection = new ObservableCollection<Card>();
            List<Card> TempListOfCards = new List<Card>(collectionOfCard);
            Random random = new Random(DateTime.Now.Millisecond);

            //foreach (T VARIABLE in collectionOfCard)
            //{
            //    int randomNumber = random.Next(0, collectionOfCard.Count);
            //    if (ShuffledCollection[randomNumber] == null)
            //    {
            //     ShuffledCollection.Insert(randomNumber, VARIABLE);   
            //    }
            //    else if (randomNumber == collectionOfCard.Count - 1 || ShuffledCollection[randomNumber] != null)
            //    {
            //        randomNumber--;
            //        if (ShuffledCollection[randomNumber] == null)
            //        {
            //            ShuffledCollection.Insert(randomNumber, VARIABLE);
            //        }
            //    }
            //    else if (randomNumber == 0 || ShuffledCollection[randomNumber] != null)
            //    {
            //        randomNumber--;
            //        if (ShuffledCollection[randomNumber] == null)
            //        {
            //            ShuffledCollection.Insert(randomNumber, VARIABLE);
            //        }
            //    }
            //}

            while (TempListOfCards.Count > 0)
            {
                int number = random.Next(TempListOfCards.Count);

                ShuffledCollection.Add(TempListOfCards[number]);
                TempListOfCards.RemoveAt(number);
            }

            return ShuffledCollection;


        }


    }
}
