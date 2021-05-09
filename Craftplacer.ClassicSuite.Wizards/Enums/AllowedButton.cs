using System;

namespace Craftplacer.ClassicSuite.Wizards.Enums
{
    [Flags]
    public enum AllowedButton
    {
        None = 0,
        Back,
        Next,
        Cancel,
        NoCancel = Back | Next,
        All = NoCancel | Cancel,
    }
}