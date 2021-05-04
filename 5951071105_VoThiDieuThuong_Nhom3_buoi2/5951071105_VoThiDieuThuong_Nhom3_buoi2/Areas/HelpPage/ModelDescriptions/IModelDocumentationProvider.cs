using System;
using System.Reflection;

namespace _5951071105_VoThiDieuThuong_Nhom3_buoi2.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}