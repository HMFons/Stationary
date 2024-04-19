using System.Xml.Linq;

namespace Stationary;

public static class XElementExtensions
{
    public static XElement StripNamespace(this XElement xElement)
    {
        foreach (var node in xElement.DescendantsAndSelf()) { 
            node.Name = node.Name.LocalName; }
        return xElement;
    }
    public static XElement AssignNamespace(this XElement xElement, XNamespace ns)
    {
        foreach (var node in xElement.DescendantsAndSelf())
        {
            node.Name = ns+ node.Name.LocalName;
        }
        return xElement;
    }
}
