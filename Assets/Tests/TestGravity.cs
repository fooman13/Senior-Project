using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestGravity
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestGravitySimplePasses()
    {
        // Use the Assert class to test conditions
        // arrange
        int a = 10;
        // act
        int result = a * 3;
        // assert
        Assert.AreEqual(20, result);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TestGravityWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
