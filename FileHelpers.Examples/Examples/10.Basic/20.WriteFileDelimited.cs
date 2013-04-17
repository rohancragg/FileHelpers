﻿using System;
using System.Collections;
using System.Collections.Generic;
using FileHelpers;

namespace ExamplesFx
{
    //-> Name:Write Delimited File
    //-> Description:Example of how to write a Delimited File
    //-> AutoRun:true

    public class WriteFile
        : ExampleBase
    {
        public override void Run()
        {
            //-> File:Example.cs
            var engine = new FileHelperEngine<Orders>();
            
            var orders = new List<Orders>();

            orders.Add(new Orders()
                             {
                                 OrderID = 1,
                                 CustomerID = "AIRG", 
                                 Freight = 82.43M, 
                                 OrderDate = new DateTime(2009,05,01)
                             });

            orders.Add(new Orders()
                             {
                                 OrderID = 2, 
                                 CustomerID = "JSYV", 
                                 Freight = 12.22M,
                                 OrderDate = new DateTime(2009,05,02)
                             });

            engine.WriteFile("Output.Txt", orders);

            //-> /File
            Console.WriteLine(engine.WriteString(orders));

        }

        //-> File:RecordClass.cs
        /// <summary>
        /// Layout for a file delimited by |
        /// </summary>
        [DelimitedRecord("|")]
        public class Orders
        {
            public int OrderID;

            public string CustomerID;

            [FieldConverter(ConverterKind.Date, "ddMMyyyy")]
            public DateTime OrderDate;

            public decimal Freight;
        }
        //-> /File

        //-> File: Output.Txt
        //-> /File

        //-> File: example_easy_write.html
        /*<h2>Easy Write Example</h2>
         * <blockquote>
         * <p>To write an output file separated by a |:</p>
         * ${Output.Txt}
         * <p>You use the same Record Mapping Class as you would to read it:</p>
         * ${RecordClass.cs}
         * <p>Finally you must to instantiate a FileHelperEngine and write the file:</p>
         * ${Example.cs}
         * <p>The classes you use could come from anywhere,  Linq to Entities,
         * SQL database reads, or in this case classes created within an application.
        */
        //-> /File
    }
}
