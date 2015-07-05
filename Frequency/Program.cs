//Sample code to read in test cases:
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        //args[0] = "Z:\\Programming\\VSWorkSpace\\ConsoleApplication1\\roman_nums.txt";
        using (StreamReader reader = File.OpenText("Z:\\Programming\\VSWorkSpace\\Frequency\\sample.txt"))
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (null == line)
                    continue;
                // do something with line
                FrequencyWithFourier(line);
                //Console.ReadLine();
            }
    }

    public static void FrequencyWithFourier(string line)
    {
        int[] wave = line.Split(' ').Select(h => Int32.Parse(h)).ToArray();
        double ftCos = 0;
        double sumCos;
        double maxSumCos = 0;
        int freq = 0;
        int waveFreq = 0;
        for (int j = 15; j<=200; j++)
        {
            freq = j * 10;
            //Console.WriteLine(freq);
            sumCos = 0;
            for (int i = 0; i < wave.Length; i++)
            {
                ftCos = wave[i] * Math.Cos(2 * Math.PI * (i) / 20000 * freq) / 20000;
                sumCos += ftCos;
            }
            if (Math.Abs(sumCos) > maxSumCos)
            {
                maxSumCos = 0.9*Math.Abs(sumCos);
                waveFreq = freq;
            }
        }
        Console.WriteLine(waveFreq);
        
        
    }



}
