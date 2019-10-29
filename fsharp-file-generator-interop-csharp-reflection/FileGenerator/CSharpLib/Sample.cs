using System.ComponentModel;

namespace CSharpLib
{
    public enum Sample
    {
        [Description("Foo description")]
        Foo = 1,

        [Description("Bar description")]
        Bar = 2,
        
        [Description("Baz description")]
        Baz = 99
    }
}