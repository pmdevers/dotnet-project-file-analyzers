using DotNetProjectFile.Analyzers.Ini;

namespace Rules.INI.INI_syntax;

public class Reports
{
    [Test]
    public void errors() => new IniSyntaxAnalyzer()
        .ForProject("IniSyntaxErrors.cs")
        .HasIssues(
            Issue.WRN("Proj4001", "] is expected" /*..,,,.*/).WithSpan(02, 10, 03, 00),
            Issue.WRN("Proj4002", "= or : is expected" /*.*/).WithSpan(03, 22, 03, 27),
            Issue.WRN("Proj4002", "Value is missing" /*...*/).WithSpan(04, 16, 04, 17),
            Issue.WRN("Proj4002", "= or : is expected" /*.*/).WithSpan(10, 08, 10, 15),
            Issue.WRN("Proj4001", "] is unexpected" /*......*/).WithSpan(12, 01, 12, 02),
            Issue.WRN("Proj4001", "[ is unexpected" /*....*/).WithSpan(15, 01, 15, 02));
}

public class Guards
{
    [TestCase("CompliantCSharp.cs")]
    [TestCase("CompliantCSharpPackage.cs")]
    public void Projects_without_issues(string project) => new IniSyntaxAnalyzer()
        .ForProject(project)
        .HasNoIssues();
}

