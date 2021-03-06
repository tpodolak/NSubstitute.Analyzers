﻿using System.Reflection;
using System.Resources;
using Microsoft.CodeAnalysis;

namespace NSubstitute.Analyzers
{
    public class DiagnosticDescriptors
    {

#if CSHARP
        private const string ResourceBaseName = "NSubstitute.Analyzers.CSharp.Resources";
#elif VISUAL_BASIC
        private const string ResourceBaseName = "NSubstitute.Analyzers.VisualBasic.Resources";
#endif

        public static readonly ResourceManager ResourceManager =
            new ResourceManager(
                ResourceBaseName,
                typeof(DiagnosticDescriptors).GetTypeInfo().Assembly);

        public static DiagnosticDescriptor NonVirtualSetupSpecification { get; } =
            CreateDiagnosticDescriptor(
                name: nameof(NonVirtualSetupSpecification),
                id: DiagnosticIdentifiers.NonVirtualSetupSpecification,
                category: DiagnosticCategories.Usage,
                defaultSeverity: DiagnosticSeverity.Warning,
                isEnabledByDefault: true);

        public static DiagnosticDescriptor UnusedReceived { get; } =
            CreateDiagnosticDescriptor(
                name: nameof(UnusedReceived),
                id: DiagnosticIdentifiers.UnusedReceived,
                category: DiagnosticCategories.Usage,
                defaultSeverity: DiagnosticSeverity.Warning,
                isEnabledByDefault: true);

        private static DiagnosticDescriptor CreateDiagnosticDescriptor(
            string name, string id, string category, DiagnosticSeverity defaultSeverity, bool isEnabledByDefault)
        {
            var title = GetDiagnosticResourceString(name, nameof(DiagnosticDescriptor.Title));
            var messageFormat = GetDiagnosticResourceString(name, nameof(DiagnosticDescriptor.MessageFormat));
            var description = GetDiagnosticResourceString(name, nameof(DiagnosticDescriptor.Description));
            return new DiagnosticDescriptor(id, title, messageFormat, category, defaultSeverity, isEnabledByDefault, description);
        }

        private static LocalizableResourceString GetDiagnosticResourceString(string name, string propertyName)
        {
            return new LocalizableResourceString(name + propertyName, ResourceManager, typeof(DiagnosticDescriptors));
        }
    }
}