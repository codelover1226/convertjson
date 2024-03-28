using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using System.Text.Json;
using IxMilia.Step;
using IxMilia.Step.Items;
class Program
{
    static void Main(string[] args)
    {
        Program program = new Program();
        // Load the STEP file
        StepFile stepFile;
        using (FileStream fs = new FileStream(@"C:\Users\Administrator\Documents\step files\PH1.011.00124_D (1).step", FileMode.Open))
        {
            stepFile = StepFile.Load(fs);
        }
        Console.WriteLine(stepFile);
        // Analyze the STEP file and build the hierarchical structure
        var hierarchy = new Dictionary<string, object>();

        stepFile = StepFile.Parse(@"ISO-10303-21;
        HEADER;
        ...
        END-ISO-103030-21;");


        foreach (StepRepresentationItem item in stepFile.Items)
        {
            switch (item.ItemType)
            {
                case StepItemType.Line:
                    StepLine line = (StepLine)item;
                    // ...
                    break;
                    // ...
            }
        }

        //foreach (StepRepresentationItem item in stepFile.Items)
        //{
        // Example: Process StepProduct items
        //           if (item is StepProduct product)
        //         {
        // Add product to hierarchy
        //         hierarchy[product.Name] = new { Quantity = 1, Parts = new List<string>() };
        //       }
        // Add more cases for other item types as needed
        //}

        // Serialize the hierarchy to JSON
        string json = JsonSerializer.Serialize(hierarchy, new JsonSerializerOptions { WriteIndented = true });

        // Output the JSON to the console
        Console.WriteLine(json);
    }
}