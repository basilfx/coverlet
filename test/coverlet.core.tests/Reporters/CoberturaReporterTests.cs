using System;
using System.Collections.Generic;
using Xunit;

namespace Coverlet.Core.Reporters.Tests
{
    public class CoberturaReporterTests
    {
        [Fact]
        public void TestReport()
        {
            CoverageResult result = new CoverageResult();
            result.Identifier = Guid.NewGuid().ToString();
            Lines lines = new Lines();
            lines.Add(1, new HitInfo { Hits = 1 });
            lines.Add(2, new HitInfo { Hits = 0 });
            Branches branches = new Branches();
            branches[(Number: 1, Offset: 23, EndOffset: 24, Path: 0, Ordinal: 1)] = new HitInfo { Hits = 1 };
            branches[(Number: 1, Offset: 23, EndOffset: 27, Path: 0, Ordinal: 2)] = new HitInfo { Hits = 0 };
            Methods methods = new Methods();
            var methodString = "System.Void Coverlet.Core.Reporters.Tests.CoberturaReporterTests::TestReport()";
            methods.Add(methodString, new Method());
            methods[methodString].Lines = lines;
            methods[methodString].Branches = branches;
            Classes classes = new Classes();
            classes.Add("Coverlet.Core.Reporters.Tests.CoberturaReporterTests", methods);
            Documents documents = new Documents();
            documents.Add("doc.cs", classes);
            result.Modules = new Modules();
            result.Modules.Add("module", documents);

            CoberturaReporter reporter = new CoberturaReporter();
            Assert.NotEqual(string.Empty, reporter.Report(result));
        }
    }
}