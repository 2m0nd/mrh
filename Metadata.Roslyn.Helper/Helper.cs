using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Metadata.Roslyn.Helper
{
    public class Helper
    {
        public static void AddToMetadataBuildNumber(string metadataSourceCodePath, string buildNumber)
        {
            var content = File.ReadAllText(metadataSourceCodePath);

            SyntaxTree tree = CSharpSyntaxTree.ParseText(content);

            //get root
            var root = tree.GetRoot();

            //get namespace declaration
            var namespaceDeclaration = root.ChildNodes()
                .OfType<NamespaceDeclarationSyntax>().Single();

            //get class declaration
            var classDeclaration = namespaceDeclaration.ChildNodes()
                .OfType<ClassDeclarationSyntax>().ToArray().Single();

            //get property "BuildNumber" declaration
            var propBuildNumberDeclaration = classDeclaration.ChildNodes()
                .OfType<FieldDeclarationSyntax>()
                .Single(p => p.Declaration.Variables.Any(d => d.Identifier.ValueText == "BuildNumber"));


            var propertyInitializeSyntax = propBuildNumberDeclaration.Declaration.Variables.Single();
            var oldToken = propertyInitializeSyntax.Initializer.Value.ChildTokens().Single();
            var newToken = SyntaxFactory.Literal(buildNumber);

            //use root for replace token
            var newtree = root.ReplaceToken(oldToken, newToken).SyntaxTree;
            var result = newtree.ToString();

            if (File.Exists(metadataSourceCodePath))
            {
                File.Delete(metadataSourceCodePath);
            }
            Console.WriteLine(result);
            File.WriteAllText(metadataSourceCodePath, result);
        }
    }
}
