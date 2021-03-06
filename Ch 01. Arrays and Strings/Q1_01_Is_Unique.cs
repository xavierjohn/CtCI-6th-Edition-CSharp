﻿using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter01
{
    public class Q1_01_Is_Unique : Question
    {
        public bool IsUniqueChars(string str)
        {
            if (str.Length > 256)
                throw new ArgumentException("String has to be less than 256 characters");

            var checker = 0;
            for (var i = 0; i < str.Length; i++)
            {
                var val = str[i] - 'a';
                if ((checker & (1 << val)) > 0) return false;
                checker |= (1 << val);
            }

            return true;
        }

        public bool IsUniqueChars2(String str)
        {
            var hashset = new HashSet<char>();
            foreach (var c in str)
            {
                if (hashset.Contains(c)) return false;
                hashset.Add(c);
            }
            return true;
        }

        public override void Run()
        {
            foreach (var word in new string[] { "abcde", "hello", "apple", "kite", "padle" })
            {
                Console.WriteLine(word + ": " + IsUniqueChars(word) + " " + IsUniqueChars2(word));
            }
        }
    }
}