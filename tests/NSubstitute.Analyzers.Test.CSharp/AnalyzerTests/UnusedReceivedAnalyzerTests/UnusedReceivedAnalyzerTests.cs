﻿using Microsoft.CodeAnalysis.Diagnostics;

namespace NSubstitute.Analyzers.Test.CSharp.AnalyzerTests.UnusedReceivedAnalyzerTests
{
    public abstract class UnusedReceivedAnalyzerTests : UnusedReceivedAnalyzerTestBase
    {
        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer()
        {
            return new UnusedReceivedAnalyzer();
        }
    }
}