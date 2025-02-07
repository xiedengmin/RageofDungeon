#region 程序集 GodotSharp, Version=4.4.0.0, Culture=neutral, PublicKeyToken=null
// C:\Users\Administrator\.nuget\packages\godotsharp\4.4.0-beta\lib\net9.0\GodotSharp.dll
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

namespace Godot;

public enum EulerOrder : long
{
    //
    // 摘要:
    //     Specifies that Euler angles should be in XYZ order. When composing, the order
    //     is X, Y, Z. When decomposing, the order is reversed, first Z, then Y, and X last.
    Xyz,
    //
    // 摘要:
    //     Specifies that Euler angles should be in XZY order. When composing, the order
    //     is X, Z, Y. When decomposing, the order is reversed, first Y, then Z, and X last.
    Xzy,
    //
    // 摘要:
    //     Specifies that Euler angles should be in YXZ order. When composing, the order
    //     is Y, X, Z. When decomposing, the order is reversed, first Z, then X, and Y last.
    Yxz,
    //
    // 摘要:
    //     Specifies that Euler angles should be in YZX order. When composing, the order
    //     is Y, Z, X. When decomposing, the order is reversed, first X, then Z, and Y last.
    Yzx,
    //
    // 摘要:
    //     Specifies that Euler angles should be in ZXY order. When composing, the order
    //     is Z, X, Y. When decomposing, the order is reversed, first Y, then X, and Z last.
    Zxy,
    //
    // 摘要:
    //     Specifies that Euler angles should be in ZYX order. When composing, the order
    //     is Z, Y, X. When decomposing, the order is reversed, first X, then Y, and Z last.
    Zyx
}
#if false // 反编译日志
缓存中的 170 项
------------------
解析: "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net9.0\System.Runtime.dll"
------------------
解析: "System.Runtime.Loader, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Runtime.Loader, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net9.0\System.Runtime.Loader.dll"
------------------
解析: "System.Collections.Concurrent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Collections.Concurrent, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net9.0\System.Collections.Concurrent.dll"
------------------
解析: "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Collections, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net9.0\System.Collections.dll"
------------------
解析: "System.Diagnostics.StackTrace, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Diagnostics.StackTrace, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net9.0\System.Diagnostics.StackTrace.dll"
------------------
解析: "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Runtime.InteropServices, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net9.0\System.Runtime.InteropServices.dll"
------------------
解析: "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Threading, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net9.0\System.Threading.dll"
------------------
解析: "System.Diagnostics.TraceSource, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Diagnostics.TraceSource, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net9.0\System.Diagnostics.TraceSource.dll"
------------------
解析: "System.Memory, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
找到单个程序集: "System.Memory, Version=8.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net9.0\System.Memory.dll"
------------------
解析: "System.Linq, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Linq, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net9.0\System.Linq.dll"
------------------
解析: "System.Security.Cryptography, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Security.Cryptography, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net9.0\System.Security.Cryptography.dll"
------------------
解析: "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Text.RegularExpressions, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net9.0\System.Text.RegularExpressions.dll"
------------------
解析: "System.Console, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
找到单个程序集: "System.Console, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net9.0\System.Console.dll"
------------------
解析: "System.Runtime.CompilerServices.Unsafe, Version=8.0.0.0, Culture=neutral, PublicKeyToken=null"
找到单个程序集: "System.Runtime.CompilerServices.Unsafe, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
从以下位置加载: "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.12\ref\net9.0\System.Runtime.CompilerServices.Unsafe.dll"
#endif
