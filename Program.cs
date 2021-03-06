﻿using System;
using System.Collections.Generic;
using System.Linq;
using codingchallenge.Models;
using System.Text.RegularExpressions;
using System.Text.Json;




namespace codingchallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Thank you for the chance to apply for this position!!");
            Convertstring("one, two, three, four, five, six", 2);
            convertjson("[{\"employee_Name\": \"Tom\", \"employee_ID\": 885, \"response_Text\":\"Response: 'Employee created successfully.\"}, {\"employee_Name\": \"Frank\", \"employee_ID\": 907, \"response_Text\":\"Response: 'Error, employee already exists.\"}]");
            

        }


        public static string Convertstring(string InputString, int columncount)
        {
           int x = columncount;
           var myarray = InputString.Split(',')
                            .Select(p => Regex.Split(p, "(?<=\\G.{3})"))
                            .ToArray();


            var stringystring = new String[myarray.Length,myarray[0].Length];
            for (int i = 0 ; i != myarray.Length ; i++){
                for (int j = 0 ; j != columncount; j++)
                {
                    stringystring[i,j] = myarray[i][j];
                }
            }

           var results = string.Join(",",
            Enumerable.Range(0, stringystring.GetUpperBound(0) + 1)
            .Select(x => Enumerable.Range(0, stringystring.GetUpperBound(1) + 1)
            .Select(y => stringystring[x, y]))
            .Select(z => "[" + string.Join("", z) + "]"));

            Console.WriteLine(results);
            return results;

            // notes for solutions below:

            //  this solution will only return the original string as a string with each word separated out into individual arrays.
            // "one, two, three, four, five, six"  becomes - "[one], [two], [three], [four], [five], [six] rather than the intended solution. 
            // I was able to use the regular expression as well as the Split and Join functions in order to convert a string to an Array and then to a multidimensional array which was fun, but my experience with this is lacking. 
            // I was unable to convert this to a string with multidimensional arrays that were specified to the column count. 
            // goal was to conver to "[[one, two], [three, four], [five, six]]" 
            // in the event that the column count did not match the number of inputs within the string a new jagged array should be created to account for the unequal input. 

            
        }

        static object convertjson(string jsonstring)
        {
           
            var employees = JsonSerializer.Deserialize<Employee[]>(jsonstring);

            foreach(var person in employees)
            {
                Console.WriteLine("employee name " + person.employee_Name  + " Employee ID " + person.employee_ID +  " Employee Response " + person.response_Text);
            }
            
            
            return employees;
        }

        // notes for Solution below: 
        // this solution utilizes the built in javascript serializer for .Net  
        // the major issue that I ran into with this was formatting the JSON string that is being received in the Method. 
        // I was able to convert the information to a series of employee objects and print that information by looping through it and adding in some string text for clarity. 
        // this solution did call for the information to be returned as an array of objects, however I was only able to parse through the information and produce an object. 


    }

}
