open System.IO;
open System.Xml.Xsl;

if fsi.CommandLineArgs.Length <> 4
then
    printfn "wrong command, please use :"
    printfn "dotnet fsi xslt.fsx {inputXML} {xslt file} {outputfile}"
else    

    let inputfile = Path.Combine(__SOURCE_DIRECTORY__, fsi.CommandLineArgs.[1])
    let transform = Path.Combine(__SOURCE_DIRECTORY__, fsi.CommandLineArgs.[2])
    let outputfile = Path.Combine(__SOURCE_DIRECTORY__, fsi.CommandLineArgs.[3])
    printfn $"inputfile : {inputfile} transform {transform},  outputfile {outputfile} "


    if not <| File.Exists(inputfile)
    then  printfn $"File not found: {inputfile}"

    if not <| File.Exists(transform)
    then  printfn $"File not found: {transform}"

    printfn $"Création de l'objet XslTransform "
    let xslTransform = new XslTransform();
    printfn $"exécution de load "
    xslTransform.Load(transform);
        printfn $"exécution de transfrom "
    xslTransform.Transform(inputfile, outputfile);
    printfn $"Finished, output: {outputfile}"