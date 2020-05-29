// Creates a Unique Measure with multiples Measures 
// Add a table Metrics with the list of all


var StrMetricas = "DATATABLE (" + '"'  + "Metric"  + '"' + ",STRING,{" ;
var StrFormula = "if(HASONEVALUE(Metrics[Metric]) ,SWITCH(SELECTEDVALUE(Metrics[Metric])" ;


foreach(var m in Selected.Measures) {
    StrFormula = StrFormula + "," + '"'  + m.Name + '"' + ",[" + m.Name +"]" ;
    StrMetricas = StrMetricas + "{" + '"' + m.Name + '"' + "}"; 
    
    if (!Selected.Measures.LastOrDefault().Equals(m))
    {
        StrMetricas = StrMetricas + "," ;
    }
  
 }

//Selected.Table


StrMetricas = StrMetricas + "})";
StrFormula = StrFormula + ", 0),0)";
Selected.Table.AddMeasure("UniqueValue",StrFormula);
Model.AddCalculatedTable("Metrics", @StrMetricas);
   
