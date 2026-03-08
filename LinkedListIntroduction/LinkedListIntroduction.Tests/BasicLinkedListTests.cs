using LinkedListIntroduction.Lib; 

namespace LinkedListIntroduction.Tests;

[TestClass]
public sealed class BasicLinkedListTests
{

    [TestMethod]
    public void TestEmpty()
    {
        IntegerLinkedList ill = new IntegerLinkedList();
        Assert.AreEqual(0, ill.Count);
    }

    [TestMethod]
    public void TestCount()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        Assert.AreEqual(3, ill.Count);
    }

    [TestMethod]
    public void TestSum()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        Assert.AreEqual(21, ill.Sum);
    }

    [TestMethod]
    public void TestToStringExplicit()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        Assert.AreEqual("{5, 7, 9}", ill.ToString());
    }

    [TestMethod]
    public void TestPrepend()
    {
        var ill = new IntegerLinkedList(5);
        ill.Prepend(7);
        ill.Prepend(9);
        Assert.AreEqual("{9, 7, 5}", ill.ToString());
    }
    
    [TestMethod]
    public void TestRemove()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        ill.Delete(7);
        Assert.AreEqual("{5, 9}", ill.ToString());

        var ill2 = new IntegerLinkedList(5);
        ill2.Append(5);
        bool result = ill2.Delete(5);
        Assert.AreEqual("{5}", ill2.ToString());
        Assert.IsTrue(result);

        // test deletion of non-existent item
        result = ill2.Delete(10);
        Assert.AreEqual("{5}", ill2.ToString());
        Assert.IsFalse(result);

        // test deletion of first item
        ill = new IntegerLinkedList();
        ill.Append(1);
        ill.Append(2);
        ill.Append(3);
        result = ill.Delete(1);
        Assert.AreEqual("{2, 3}", ill.ToString());
        Assert.AreEqual(2, ill.Count);
        Assert.IsTrue(result);

        // test deletion of last item
        ill = new IntegerLinkedList();
        ill.Append(1);
        ill.Append(2);
        ill.Append(3);
        result = ill.Delete(3);
        Assert.AreEqual("{1, 2}", ill.ToString());
        Assert.AreEqual(2, ill.Count);
        Assert.IsTrue(result);
    }
    
    [TestMethod]
    public void TestInsert()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        ill.Insert(8, 1);
        Assert.AreEqual("{5, 8, 7, 9}", ill.ToString());
        
        ill.Insert(6, 10);
        Assert.AreEqual("{5, 8, 7, 9, 10}", ill.ToString());
        
        ill.Insert(1, 0);
        Assert.AreEqual("{0, 5, 8, 7, 9, 10}", ill.ToString());

        ill.Insert(15, -1);
        Assert.AreEqual("{15, 0, 5, 8, 7, 9, 10}", ill.ToString());
    }
}
