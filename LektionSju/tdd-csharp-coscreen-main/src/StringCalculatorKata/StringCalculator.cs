using System;
using System.ComponentModel.Design.Serialization;
using System.Linq;

public class StringCalculator
{
    public int Add(string number)
    {
        // kollar om det är en tom sträng
        if (string.IsNullOrEmpty(number))
        {
            return 0;
        }
        //klar rätt första if där uppe


        // Dela upp strängen med kvarvarande nummer
        string[] numbers = { ",","\n","*", "/", ";" };//send it inside the split 
        int sum = 0;
        // Lägg till de återstående numren i summan
        //foreach (var num in numbers)
        //{
        //    //create an if state to see if the string geting a number och if its a letter if its not letter than plus.
        //    //if(!)
        //    sum += int.Parse(num);
        //}
        for (int i = 0; i < numbers.Length;i++) 
        {
            if (numbers[i] == number) 
            {
                string dolites= numbers[i];
            }
            else if (numbers[i] != number) 
            {
                sum += int.Parse(number);
            }
        }
        return sum;
        // det vad han gjorde är :

        var integer= number
            .Split(',')
            .Where(i => !string.IsNullOrWhiteSpace(i))
            .Select(i  => int.Parse(i.Trim()) )
            .ToList();
        return integer.Sum();

    }
    public double Roots(string nums) 
    {
        if (string.IsNullOrEmpty(nums))
        {
            return 0;
        }
        double sum= int.Parse(nums);
       return  Math.Sqrt(sum);

    }
}
