﻿using System.IO;


class Urho3DAll
{
    static string PATH = @"d:\MyGames\Urho3D\Build\include";

    static void Main()
    {
        PATH = PATH.Replace('\\', '/');
        if (PATH[PATH.Length - 1] != '/')
            PATH += '/';

        StreamWriter result = File.CreateText("Urho3DAll.h");
        result.WriteLine("#pragma once");
        result.WriteLine();
        result.WriteLine("#include <Urho3D/Urho3D.h>");
        result.WriteLine();

        foreach (string path in Directory.EnumerateFiles(PATH, "*.*", SearchOption.AllDirectories))
        {
            string str = path.Replace('\\', '/').Replace(PATH, "");
            if (str.StartsWith("Urho3D/ThirdParty"))
                continue;
            if (str.StartsWith("Urho3D/Graphics/Direct3D"))
                continue;
            if (str.StartsWith("Urho3D/Graphics/OpenGL"))
                continue;
            if (str == "Urho3D/LuaScript/ToluaUtils.h")
                continue;
            if (str == "Urho3D/DebugNew.h")
                continue;
            if (str == "Urho3D/librevision.h")
                continue;
            if (str == "Urho3D/Precompiled.h")
                continue;
            if (str == "Urho3D/Urho3D.h")
                continue;
            str = "#include <" + str + ">";
            result.WriteLine(str);
        }

        result.WriteLine();
        result.WriteLine("#include <Urho3D/DebugNew.h>");
        result.WriteLine();
        result.WriteLine("using namespace Urho3D;");
        result.Close();
    }
}