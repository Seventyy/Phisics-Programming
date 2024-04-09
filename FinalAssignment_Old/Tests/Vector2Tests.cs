using System;
using GXPEngine;
using GXPEngine.Core;

[TestClass]
public class Vector2Tests
{
    [TestMethod]
    public void TestLength()
    {
        Vector2 v = new Vector2(3, 4);
        Assert.AreEqual(5, v.Length());
    }
    
}
