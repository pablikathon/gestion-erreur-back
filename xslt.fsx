open System
open System.Xml
open System.Xml.Xsl

try
    let transform = new XslCompiledTransform()
    transform.Load("ic.xslt")
    transform.Transform("inspectcode.xml", "inspectcode.html")
    printfn "Transformation completed successfully."
with
| ex -> printfn "An error occurred: %s" (ex.Message)
