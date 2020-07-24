using System;
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


    }

}
