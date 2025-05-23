namespace Rules.MS_Build.Indent_XML;

public class Reports
{
    [Test]
    public void Faulty_indented()
        => new IndentXml()
        .ForProject("FaultyIndenting.cs")
        .HasIssues(
            Issue.WRN("Proj1700", "The element <PropertyGroup> has not been properly indented" /*...*/).WithSpan(04, 04, 04, 18),
            Issue.WRN("Proj1700", "The element <TargetFramework> has not been properly indented" /*.*/).WithSpan(05, 02, 05, 18),
            Issue.WRN("Proj1700", "The element </PropertyGroup> has not been properly indented" /*..*/).WithSpan(06, 05, 06, 21),
            Issue.WRN("Proj1700", "The element <Compile> has not been properly indented" /*.........*/).WithSpan(09, 04, 09, 43),
            Issue.WRN("Proj1700", "The element <Folder> has not been properly indented" /*..........*/).WithSpan(12, 13, 12, 21));
}

public class Guards
{
    [TestCase("CompliantCSharp.cs")]
    [TestCase("CompliantCSharpPackage.cs")]
    public void Projects_without_issues(string project)
         => new IndentXml()
        .ForProject(project)
        .HasNoIssues();
}
