using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using IxMilia.Step;
using IxMilia.Step.Items;

class Program
{
    static void Main(string[] args)
    {
        // Load the STEP file
        StepFile stepFile;
        using (FileStream fs = new FileStream(@"C:\Path\To\File.stp", FileMode.Open))
        {
            stepFile = StepFile.Load(fs);
        }
        Console.WriteLine(stepFile);
        // Analyze the STEP file and build the hierarchical structure
        var hierarchy = new Dictionary<string, object>();
        foreach (StepRepresentationItem item in stepFile.Items)
        {
            // Example: Process StepProduct items
 //           if (item is StepProduct product)
   //         {
                // Add product to hierarchy
       //         hierarchy[product.Name] = new { Quantity = 1, Parts = new List<string>() };
     //       }
            // Add more cases for other item types as needed
        }

        // Serialize the hierarchy to JSON
        string json = JsonSerializer.Serialize(hierarchy, new JsonSerializerOptions { WriteIndented = true });

        // Output the JSON to the console
        Console.WriteLine(json);
    }
}