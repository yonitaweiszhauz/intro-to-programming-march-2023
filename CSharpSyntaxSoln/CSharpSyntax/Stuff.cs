﻿using System.Security.Cryptography.X509Certificates;

namespace CSharpSyntax;

public class Stuff
{
    private int x = 20;
    public void DoIt()
    {
        x -= 1;
    }

    public int GetX()
    {
        return x;
    }

    public void SetX(int newValue)
    {
        x = newValue;
    }
}
public class StuffUtilities{
    public static void DoSomeStuff(Stuff obj)
    {

    }
}
