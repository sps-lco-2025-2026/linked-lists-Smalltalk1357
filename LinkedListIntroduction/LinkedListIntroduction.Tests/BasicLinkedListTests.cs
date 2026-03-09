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
        Assert.AreEqual("{5, 8, 7, 9, 6}", ill.ToString());
        
        ill.Insert(1, 0);
        Assert.AreEqual("{1, 5, 8, 7, 9, 6}", ill.ToString());

        ill.Insert(15, -1);
        Assert.AreEqual("{15, 1, 5, 8, 7, 9, 6}", ill.ToString());
    }

    [TestMethod]
    public void TestJoin()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        var ill2 = new IntegerLinkedList(11);
        ill2.Append(13);
        ill2.Append(15);
        ill.Join(ill2);
        Assert.AreEqual("{5, 7, 9, 11, 13, 15}", ill.ToString());
        
        var ill3 = new IntegerLinkedList(1);
        ill3.Append(3);
        var ill4 = new IntegerLinkedList();
        ill3.Join(ill4);
        Assert.AreEqual("{1, 3}", ill3.ToString());
    }
    
    [TestMethod]
    public void TestContains()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        Assert.IsTrue(ill.Contains(7));
        Assert.IsFalse(ill.Contains(10));
    }

    [TestMethod]
    public void TestDuplicates()
    {
        var ill = new IntegerLinkedList(1);
        ill.Append(1);
        ill.Append(2);
        ill.Append(3);
        ill.Append(5);
        ill.Append(5);
        ill.RemoveDuplicates();
        Assert.AreEqual("{1, 2, 3, 5}", ill.ToString());
        
        var ill2 = new IntegerLinkedList(1);
        ill2.Append(1);
        ill2.Append(1);
        ill2.RemoveDuplicates();
        Assert.AreEqual("{1}", ill2.ToString());
    }

    [TestMethod]
    public void TestMeshLists()
    {
        var ill = new IntegerLinkedList(0);
        ill.Append(2);
        var ill2 = new IntegerLinkedList(1);
        ill2.Append(3);
        ill.MeshLists(ill2);
        Assert.AreEqual("{0, 1, 2, 3}", ill.ToString());
        
        var ill3 = new IntegerLinkedList(0);
        ill3.Append(2);
        var ill4 = new IntegerLinkedList(1);
        ill4.Append(3);
        ill4.Append(5);
        var ill5 = new IntegerLinkedList();
        ill3.MeshLists(ill3);
        Assert.AreEqual("{0, 2}", ill3.ToString());
        ill3.MeshLists(ill4);
        Assert.AreEqual("{0, 1, 2, 3, 5}", ill3.ToString());
        ill3.MeshLists(ill5);
        Assert.AreEqual("{0, 1, 2, 3, 5}", ill3.ToString());
    }
    
    [TestMethod]
    public void Reverse()
    {
        var ill = new IntegerLinkedList(0);
        ill.Append(1);
        ill.Append(2);
        ill.Append(3);
        ill.Append(4);
        ill.Append(5);
        var ill2 = ill.Reverse();
        Assert.AreEqual("{5, 4, 3, 2, 1, 0}", ill2.ToString());
        
        var ill3 = new IntegerLinkedList();
        var ill4 = ill3.Reverse();
        Assert.AreEqual("{}", ill4.ToString());
    }

    [TestMethod]
    public void TestSorted()
    {
        var ill = new SortedIntegerLinkedList();
        ill.Append(5);
        ill.Append(1);
        ill.Append(-1);
        ill.Append(100);
        ill.Append(9);
        Assert.AreEqual("{-1, 1, 5, 9, 100}", ill.ToString());
    }
}
