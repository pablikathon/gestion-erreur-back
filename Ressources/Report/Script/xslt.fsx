open System.IO;
open System.Xml.Xsl;

if fsi.CommandLineArgs.Length <> 4
then
    printfn "wrong command, please use :"
    printfn "dotnet fsi xslt.fsx {inputXML} {xslt file} {outputfile}"
else    
    let currentDir = __SOURCE_DIRECTORY__
    let rec findParentDirectoryAndMoveUp directory targetDirectoryName =
        let parentDirectory = Directory.GetParent(directory)
        if parentDirectory = null then
            failwithf "Dossier '%s' non trouvé dans la hiérarchie des dossiers." targetDirectoryName
        elif Path.GetFileName(directory) = targetDirectoryName then
            parentDirectory.FullName
        else
            findParentDirectoryAndMoveUp parentDirectory.FullName targetDirectoryName

    let targetDirectoryName = "Ressources"

    let parentDir = findParentDirectoryAndMoveUp currentDir targetDirectoryName
    printfn $"le dossier de réréfrence est : {parentDir}"
    let inputfile = Path.Combine(parentDir, fsi.CommandLineArgs.[1])
    let transform = Path.Combine(parentDir, fsi.CommandLineArgs.[2])
    let outputfile = Path.Combine(parentDir, fsi.CommandLineArgs.[3])
    printfn $"inputfile : {inputfile} transform {transform},  outputfile {outputfile} "


    if not <| File.Exists(inputfile)
    then  printfn $"File not found: {inputfile}"

    if not <| File.Exists(transform)
    then  printfn $"File not found: {transform}"
    
    let xslTransform = new XslTransform();
    xslTransform.Load(transform);
    xslTransform.Transform(inputfile, outputfile);
    printfn $"Finished, output: {outputfile}"